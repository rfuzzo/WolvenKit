#include "meshloader.h"
#include "resourcepath.h"
#include "file.h"
#include "cr2w.h"

#ifdef USE_GAME_BUNDLES
#include "bundlemanager.h"
#endif

#ifdef _DEBUG
#include <iostream>
#endif

namespace WolvenEngine
{
    bool loadGeometry(std::string filename, const WolvenEngine::SBufferInfos& bufferInfo, const std::vector<WolvenEngine::SMeshInfos>& meshInfos, std::vector<Material>& allMaterials, std::vector<Mesh>& meshes, std::vector<Material>& materials)
    {
        size_t pos = filename.rfind('\\');
        if (pos == std::string::npos)
            pos = filename.rfind('/');
        std::string meshName = filename.substr(pos + 1);

        std::string bufferFileName = filename + ".1.buffer";
        WolvenEngine::File fp;

#ifdef USE_GAME_BUNDLES
        if (!WolvenEngine::BundleManager::instance()->open(bufferFileName.c_str(), fp))
        {
            return false;
        }
#else
        if (!fp.open(bufferFileName.c_str(), "rb"))
            return false;
#endif

        for (auto it = meshInfos.begin(); it != meshInfos.end(); it++)
        {
            const WolvenEngine::SMeshInfos& mi = *it;

            WolvenEngine::SVertexBufferInfos vBufferInf;
            uint32_t nbVertices = 0;
            uint32_t firstVertexOffset = 0;
            uint32_t nbIndices = 0;
            uint32_t firstIndexOffset = 0;

            for (size_t i = 0; i < bufferInfo.verticesBuffer.size(); ++i)
            {
                nbVertices += bufferInfo.verticesBuffer[i].nbVertices;
                if (nbVertices > mi.firstVertex)
                {
                    vBufferInf = bufferInfo.verticesBuffer[i];
                    // the index of the first vertex in the buffer
                    firstVertexOffset = mi.firstVertex - (nbVertices - vBufferInf.nbVertices);
                    break;
                }
            }

            for (size_t i = 0; i < bufferInfo.verticesBuffer.size(); ++i)
            {
                nbIndices += bufferInfo.verticesBuffer[i].nbIndices;
                if (nbIndices > mi.firstIndex)
                {
                    vBufferInf = bufferInfo.verticesBuffer[i];
                    firstIndexOffset = mi.firstIndex - (nbIndices - vBufferInf.nbIndices);
                    break;
                }
            }

            if (vBufferInf.lod != 1)
                continue;

            uint32_t vertexSize = 8;
            if (mi.vertexType == 1)
                vertexSize += mi.numBonesPerVertex * 2;

            fp.seek(vBufferInf.verticesCoordsOffset + firstVertexOffset * vertexSize, SEEK_SET);
            Mesh mesh;
            mesh._vertices.resize(mi.numVertices);
            mesh._indices.resize(mi.numIndices);

            for (uint32_t j = 0; j < mi.numVertices; ++j)
            {
                Vertex& vert = mesh._vertices[j];

                uint16_t x = fp.read<uint16_t>();
                uint16_t y = fp.read<uint16_t>();
                uint16_t z = fp.read<uint16_t>();

                fp.seek(sizeof(uint16_t), SEEK_CUR); // skip w

                if (mi.vertexType == 1)
                {
                    // skip weighting for now
                    fp.seek(mi.numBonesPerVertex * 2, SEEK_CUR);
                }
                vert.position.x = x / 65535.0f;
                vert.position.y = y / 65535.0f;
                vert.position.z = z / 65535.0f;

                vert.position *= bufferInfo.quantizationScale;
                vert.position += bufferInfo.quantizationOffset;
            }

            fp.seek(vBufferInf.uvOffset + firstVertexOffset * 4, SEEK_SET);

            for (uint32_t j = 0; j < mi.numVertices; ++j)
            {
                Vertex& vert = mesh._vertices[j];

                uint16_t u = fp.read<uint16_t>();
                uint16_t v = fp.read<uint16_t>();

                vert.uv.x = WolvenEngine::halfToFloat(u);
                vert.uv.y = WolvenEngine::halfToFloat(v);
            }

            // there is a lot of unknown data after the uvs and before the indices so just ignore it all...

            fp.seek(bufferInfo.indexBufferOffset + vBufferInf.indicesOffset + firstIndexOffset * 2, SEEK_SET);

            for (uint32_t j = 0; j < mi.numIndices; j += 3)
            {
                uint16_t index0, index1, index2;

                index0 = fp.read<uint16_t>();
                index1 = fp.read<uint16_t>();
                index2 = fp.read<uint16_t>();

                mesh._indices[j] = index0;
                mesh._indices[j+1] = index1;
                mesh._indices[j+2] = index2;

                const glm::vec3 v0 = mesh._vertices[index0].position;
                const glm::vec3 v1 = mesh._vertices[index1].position;
                const glm::vec3 v2 = mesh._vertices[index2].position;

                // get the normal for the plane
                glm::vec3 d1 = v0 - v1;
                glm::vec3 d2 = v2 - v0;
                glm::vec3 normal = glm::cross(d2, d1);
                if (normal.x != 0 && normal.y != 0 && normal.z != 0)
                    normal = glm::normalize(normal);
                else
                    normal = glm::vec3(0.0f, 0.0f, 1.0f);

                mesh._vertices[index0].pack_normal_fast(normal);
                mesh._vertices[index1].oct_normal = mesh._vertices[index0].oct_normal;
                mesh._vertices[index2].oct_normal = mesh._vertices[index0].oct_normal;
            }

            assert(mi.materialID < (uint32_t)allMaterials.size());

            materials.push_back(allMaterials[mi.materialID]);
            meshes.emplace_back(mesh);
        }

        return true;
    }

    bool loadMesh(const std::string& filename, std::vector<Mesh>& meshes, std::vector<Material>& materials)
    {
        WolvenEngine::File fp;
#ifdef USE_GAME_BUNDLES
        if (!WolvenEngine::BundleManager::instance()->open(filename.c_str(), fp))
        {
            return false;
        }
#else
        if (!fp.open(filename.c_str(), "rb"))
            return false;

        std::string depot = WolvenEngine::resourcePaths.top();
#endif

        size_t pos = filename.rfind('\\');
        if (pos == std::string::npos)
            pos = filename.rfind('/');
        std::string meshName = filename.substr(pos + 1);

        std::vector<std::string> labels;
        std::vector<std::string> fileNames;
        std::vector<WolvenEngine::ContentInfo> contents;

        WolvenEngine::SBufferInfos bufferInfo;
        std::vector<WolvenEngine::SMeshInfos> miMeshes;
        std::vector<Material> allMaterials;
        glm::vec3 minBounds, maxBounds;

        if (readCR2W(fp, labels, fileNames, contents))
        {
            for (size_t i = 0; i < contents.size(); ++i)
            {
                WolvenEngine::ContentInfo& ci = contents[i];

                if (labels[ci.type] == "CMesh")
                {
                    fp.seek(ci.address + 1, SEEK_SET);

                    WolvenEngine::Variable var;
                    while (readVariable(fp, var))
                    {
                        if (labels[var.name] == "materials")
                        {
                            uint32_t nbChunks = fp.read<uint32_t>();

                            for (uint32_t j = 0; j < nbChunks; ++j)
                            {
                                uint32_t fileId = fp.read<uint32_t>();
                                fileId = 0xFFFFFFFF - fileId;

                                // read the material
                                if (fileId < fileNames.size())
                                {
                                    std::string matName = fileNames[fileId];

                                    if (!matName.ends_with("w2mg"))
                                    {
                                        Material m;
#ifdef USE_GAME_BUNDLES
                                        m.name = matName;
#else
                                        m.name = depot + matName;
#endif
                                        allMaterials.emplace_back(m);
                                    }
                                    else
                                    {
                                        Material m;
                                        m.name = "default";
                                        allMaterials.emplace_back(m);
                                    }
                                }
                            }
                        }
                        else if (labels[var.name] == "chunks")
                        {
                            // read smesh chunk packed property
                            uint32_t nbChunks = fp.read<uint32_t>();

                            WolvenEngine::SMeshInfos smeshInfo;

                            for (uint32_t j = 0; j < nbChunks; ++j)
                            {
                                fp.seek(1, SEEK_CUR);

                                WolvenEngine::Variable chunkVar;
                                while (readVariable(fp, chunkVar))
                                {
                                    if (labels[chunkVar.name] == "numVertices")
                                    {
                                        smeshInfo.numVertices = fp.read<uint32_t>();
                                    }
                                    else if (labels[chunkVar.name] == "numIndices")
                                    {
                                        smeshInfo.numIndices = fp.read<uint32_t>();
                                    }
                                    else if (labels[chunkVar.name] == "materialID")
                                    {
                                        smeshInfo.materialID = fp.read<uint32_t>();
                                    }
                                    else if (labels[chunkVar.name] == "firstVertex")
                                    {
                                        smeshInfo.firstVertex = fp.read<uint32_t>();
                                    }
                                    else if (labels[chunkVar.name] == "firstIndex")
                                    {
                                        smeshInfo.firstIndex = fp.read<uint32_t>();
                                    }
                                    else if (labels[chunkVar.name] == "vertexType")
                                    {
                                        uint16_t enumStringId = fp.read<uint16_t>();

                                        if (labels[enumStringId] == "MVT_SkinnedMesh")
                                        {
                                            smeshInfo.vertexType = 1;
                                        }
                                    }

                                    fp.seek(chunkVar.end, SEEK_SET);
                                }

                                // mesh is done
                                miMeshes.emplace_back(smeshInfo);
                            }
                        }
                        else if (labels[var.name] == "cookedData")
                        {
                            // read information about the buffer containing the geometry data
                            fp.seek(1, SEEK_CUR);

                            WolvenEngine::Variable chunkVar;
                            while (readVariable(fp, chunkVar))
                            {
                                if (labels[chunkVar.name] == "indexBufferSize")
                                {
                                    bufferInfo.indexBufferSize = fp.read<uint32_t>();
                                }
                                else if (labels[chunkVar.name] == "indexBufferOffset")
                                {
                                    bufferInfo.indexBufferOffset = fp.read<uint32_t>();
                                }
                                else if (labels[chunkVar.name] == "vertexBufferSize")
                                {
                                    bufferInfo.vertexBufferSize = fp.read<uint32_t>();
                                }
                                else if (labels[chunkVar.name] == "quantizationScale")
                                {
                                    fp.seek(9, SEEK_CUR);
                                    bufferInfo.quantizationScale.x = fp.read<float_t>();
                                    fp.seek(8, SEEK_CUR);
                                    bufferInfo.quantizationScale.y = fp.read<float_t>();
                                    fp.seek(8, SEEK_CUR);
                                    bufferInfo.quantizationScale.z = fp.read<float_t>();
                                }
                                else if (labels[chunkVar.name] == "quantizationOffset")
                                {
                                    fp.seek(9, SEEK_CUR);
                                    bufferInfo.quantizationOffset.x = fp.read<float_t>();
                                    fp.seek(8, SEEK_CUR);
                                    bufferInfo.quantizationOffset.y = fp.read<float_t>();
                                    fp.seek(8, SEEK_CUR);
                                    bufferInfo.quantizationOffset.z = fp.read<float_t>();
                                }
                                else if (labels[chunkVar.name] == "renderChunks")
                                {
                                    fp.seek(sizeof(int32_t), SEEK_CUR);

                                    uint8_t nBuffers = fp.read<uint8_t>();

                                    for (uint8_t ib = 0; ib < nBuffers; ++ib)
                                    {
                                        WolvenEngine::SVertexBufferInfos info;

                                        fp.seek(1, SEEK_CUR);

                                        info.verticesCoordsOffset = fp.read<uint32_t>();
                                        info.uvOffset = fp.read<uint32_t>();
                                        info.normalsOffset = fp.read<uint32_t>();

                                        fp.seek(9, SEEK_CUR);
                                        info.indicesOffset = fp.read<uint32_t>();
                                        fp.seek(1, SEEK_CUR); // 0x1D

                                        info.nbVertices = fp.read<uint16_t>();
                                        info.nbIndices = fp.read<uint32_t>();
                                        fp.seek(3, SEEK_CUR);
                                        info.lod = fp.read<uint8_t>();

                                        bufferInfo.verticesBuffer.emplace_back(info);
                                    }
                                }

                                fp.seek(chunkVar.end, SEEK_SET);
                            }
                        }
                        else if (labels[var.name] == "boundingBox")
                        {
                            // min bounds
                            {
                                fp.seek(18, SEEK_CUR);

                                minBounds.x = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                minBounds.y = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                minBounds.z = fp.read<float_t>();
                                fp.seek(14, SEEK_CUR); // skip w and then a blank name field
                            }

                            // max bounds
                            {
                                fp.seek(17, SEEK_CUR);

                                maxBounds.x = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                maxBounds.y = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                maxBounds.z = fp.read<float_t>();
                                fp.seek(16, SEEK_CUR); // skip w and then a blank name field
                            }
                        }

                        fp.seek(var.end, SEEK_SET);
                    }
                }
                else if (labels[ci.type] == "CMaterialInstance")
                {
                    fp.seek(ci.address + 1, SEEK_SET);

                    while (fp.tell() < (long)ci.end)
                    {
                        WolvenEngine::Variable matVar;
                        readVariable(fp, matVar);

                        if (labels[matVar.name] == "baseMaterial")
                        {
                            uint32_t fileId = fp.read<uint32_t>();
                            fileId = 0xFFFFFFFF - fileId;

                            // read the material
                            assert(fileId < fileNames.size());
                            std::string matName = fileNames[fileId];

                            if (!matName.ends_with("w2mg"))
                            {
                                Material m;
#ifdef USE_GAME_BUNDLES
                                m.name = matName;
#else
                                m.name = depot + matName;
#endif
                                allMaterials.emplace_back(m);
                            }
                            else
                            {
                                Material m;
                                m.name = "default";
                                allMaterials.emplace_back(m);
                            }

                            fp.seek(matVar.end, SEEK_SET);
                        }
                        else if (labels[matVar.name] == "enableMask")
                        {
                            fp.seek(matVar.end, SEEK_SET);
                        }
                        else
                        {
                            uint32_t nbProperties = fp.read<uint32_t>();

                            if (nbProperties > 0)
                            {
                                Material m;
                                m.name = meshName;

                                for (uint32_t j = 0; j < nbProperties; ++j)
                                {
                                    long back = fp.tell();
                                    uint32_t propSize = fp.read<uint32_t>();

                                    uint16_t propId = fp.read<uint16_t>();
                                    //uint16_t propTypeId = fp.read<uint16_t>();
                                    fp.seek(sizeof(uint16_t), SEEK_CUR);

                                    if (propId >= labels.size())
                                        break;

                                    // texture type
                                    int32_t textureLayer = -1;
                                    if (labels[propId] == "Diffuse")
                                        textureLayer = 0;
                                    else if (labels[propId] == "Normal")
                                        textureLayer = 1;

                                    if (textureLayer != -1)
                                    {
                                        uint8_t texId = fp.read<uint8_t>();
                                        texId = 255 - texId;

                                        if ((size_t)texId < fileNames.size())
                                        {
                                            if (textureLayer == 0)
                                                m.diffuseTexture = fileNames[texId];
                                            else
                                                m.normalTexture = fileNames[texId];
                                        }
                                    }

                                    fp.seek(back + propSize, SEEK_SET);
                                }

                                if (!m.diffuseTexture.empty())
                                {
                                    allMaterials.emplace_back(m);
                                }
                                else
                                {
                                    m.name = "default";
                                    allMaterials.emplace_back(m);
                                }
                            }
                            
                        }
                    }
                }
                else if (labels[ci.type] == "CMaterialGraph")
                {
                    // can't read this so just default to something
                    Material m;
                    m.name = "default";
                    allMaterials.emplace_back(m);
                }
            }
        }

        if (allMaterials.size() == 0)
        {
            Material m;
            m.name = "default";
            allMaterials.emplace_back(m);
        }

        // can read mesh buffer file now
        if (loadGeometry(filename, bufferInfo, miMeshes, allMaterials, meshes, materials))
        {            
            RenderBounds rb;
            rb.extents = (maxBounds - maxBounds) / 2.0f;
            rb.origin = minBounds + rb.extents;
            rb.radius = glm::distance(minBounds, maxBounds) / 2.0f;
            rb.valid = true;

            for (auto& m : meshes)
            {
                m.bounds = rb;
            }

            return true;
        }

        return false;
    }
}