#define _USE_MATH_DEFINES
#include <cmath>

#include "vk_engine.h"
#include <stdint.h>
#include <iostream>
#include "cr2w.h"
#include "resourcepath.h"

// byte-align structures
#if defined(_MSC_VER) || defined(__BORLANDC__) || defined (__BCPLUSPLUS__)
#	pragma warning(disable: 4103)
#	pragma pack( push, packing )
#	pragma pack( 1 )
#	define PACK_STRUCT
#endif

//#define _DUMPOBJ
//#define SIMPLIFY

#ifdef SIMPLIFY
#include "simplify.h"
#endif

namespace WolvenEngine
{
#ifdef _DUMPOBJ
    void DumpOBJ(std::string filename, const std::vector<Vertex>& vertices, const std::vector<uint32_t>& indices, const glm::mat4& transformToWorld)
    {
        FILE* fp = nullptr;
        fopen_s(&fp, filename.c_str(), "wt");
        if (fp == nullptr)
            return;

        fprintf(fp, "# %d vertices, %d indices\n", (uint32_t)vertices.size(), (uint32_t)indices.size());

        for (size_t i = 0; i < vertices.size(); ++i)
        {
            glm::vec4 v = transformToWorld * glm::vec4(vertices[i].position, 1.0f);

            fprintf(fp, "v %g %g %g\n", v.x, v.y, v.z);
            //fprintf(fp, "vt %g %g\n", vertices[i].uv.x, vertices[i].uv.y);
            //fprintf(fp, "vn %g %g %g\n", vertices[i].normal.x, vertices[i].normal.y, vertices[i].normal.z);
        }

        for (size_t i = 0; i < indices.size();)
        {
            uint32_t v0 = indices[i++] + 1;
            uint32_t v1 = indices[i++] + 1;
            uint32_t v2 = indices[i++] + 1;
            //fprintf(fp, "f %d/%d/%d %d/%d/%d %d/%d/%d\n", v0, v0, v0, v1, v1, v1, v2, v2, v2);
            fprintf(fp, "f %d %d %d\n", v0, v1, v2);
        }

        fclose(fp);
    }

    void DumpOBJ(std::string filename, const std::vector<Vertex>& vertices, const std::vector<uint16_t>& indices, const glm::mat4& transformToWorld)
    {
        FILE* fp = nullptr;
        fopen_s(&fp, filename.c_str(), "wt");
        if (fp == nullptr)
            return;

        fprintf(fp, "# %d vertices, %d indices\n", (uint32_t)vertices.size(), (uint32_t)indices.size());

        for (size_t i = 0; i < vertices.size(); ++i)
        {
            glm::vec4 v = transformToWorld * glm::vec4(vertices[i].position, 1.0f);

            fprintf(fp, "v %g %g %g\n", v.x, v.y, v.z);
            //fprintf(fp, "vt %g %g\n", vertices[i].uv.x, vertices[i].uv.y);
            //fprintf(fp, "vn %g %g %g\n", vertices[i].normal.x, vertices[i].normal.y, vertices[i].normal.z);
        }

        for (size_t i = 0; i < indices.size();)
        {
            uint16_t v0 = indices[i++] + 1;
            uint16_t v1 = indices[i++] + 1;
            uint16_t v2 = indices[i++] + 1;
            //fprintf(fp, "f %d/%d/%d %d/%d/%d %d/%d/%d\n", v0, v0, v0, v1, v1, v1, v2, v2, v2);
            fprintf(fp, "f %d %d %d\n", v0, v1, v2);
        }

        fclose(fp);
    }
#endif

    inline float_t lerp(float_t a, float_t b, float_t t)
    {
        return a + t * (b - a);
    }

    void VulkanEngine::addTerrain(std::string filename, uint32_t tileRes, float_t highestElevation, float_t lowestElevation, float_t terrainSize, const glm::mat4& matrix, uint32_t meshIndex)
    {
        FILE* fp = nullptr;
        fopen_s(&fp, filename.c_str(), "rb");
        if(fp == nullptr)
            return;

        uint32_t nVertices = tileRes * tileRes;

        uint16_t* values = (uint16_t*)malloc(nVertices * sizeof(uint16_t));
        fread(values, nVertices * sizeof(uint16_t), 1, fp);
        fclose(fp);

        uint32_t nIndices = (tileRes - 1) * (tileRes * 2) + (tileRes - 2) * 2;

        TerrainMesh mesh;
        mesh._indices.resize(nIndices);
        mesh._vertices.resize(nVertices);

        std::string meshName = "tile" + std::to_string(meshIndex);

        float_t currY = 0.0f;
        float_t stepSize = terrainSize / tileRes;

        float_t r = 0;
        float_t g = 0;
        float_t b = 0;

        float_t minZ = 1.0E9f;
        float_t maxZ = -1.0E9f;

        float_t heightScale = highestElevation - lowestElevation;

        const uint16_t* val = values;
        uint32_t index = 0;

        for (uint32_t y = 0; y < tileRes; ++y)
        {
            float_t currX = 0.0f;

            for (uint32_t x = 0; x < tileRes; ++x, ++index)
            {
                float_t hN = (float_t)(*val++ / 65535.0f);
                float_t h = hN * heightScale + lowestElevation;

#if 0
                if (h < 0.0f)
                {
                    r = 0;
                    g = 0;
                    b = 0.6f;
                }
                else
                {
                    float_t hscaled = h / highestElevation * 2.0f - 1e-05f; // hscaled should range in [0,2)
                    uint32_t hi = uint32_t(hscaled); // hi should range in [0,1]
                    float_t hfrac = hscaled - float_t(hi); // hfrac should range in [0,1]
                    if (hi == 0)
                    {
                        r = lerp(0.1f, 0.4f, hfrac);
                        g = lerp(0.3f, 0.8f, hfrac);
                        b = lerp(0.1f, 0.4f, hfrac);
                    }
                    else
                    {
                        r = lerp(0.4f, 1.0f, hfrac);
                        g = lerp(0.8f, 1.0f, hfrac);
                        b = lerp(0.4f, 1.0f, hfrac);
                    }
                }
#else
                float_t hscaled = h / highestElevation * 2.0f - 1e-05f; // hscaled should range in [0,2)
                uint32_t hi = uint32_t(hscaled); // hi should range in [0,1]
                float_t hfrac = hscaled - float_t(hi); // hfrac should range in [0,1]
#endif
                Vertex& v = mesh._vertices[index];
                //v.color = glm::vec3(r, g, b);
                v.color = glm::vec3(hfrac, hi, 0);
                v.position.x = currX;
                v.position.y = currY;
                v.position.z = h;

                if (h < minZ)
                    minZ = h;
                else if (h > maxZ)
                    maxZ = h;

                currX += stepSize;
            }

            currY += stepSize;
        }

        // create faces
        index = 0;
        uint32_t row0Index = 0;
        uint32_t row1Index = tileRes;


        for (uint32_t z = 0; z < tileRes - 2; ++z)
        {
            // do two rows at a time to make a triangle strip
            for (uint32_t x = 0; x < tileRes; ++x)
            {
                mesh._indices[index++] = row0Index++;
                mesh._indices[index++] = row1Index++;
            }

            // add degenerate triangle to get to next row
            //TODO: consider a termination value 0xFFFF to indicate end of a row
            mesh._indices[index++] = row1Index - 1;
            mesh._indices[index++] = row0Index;
        }

        // do two rows at a time to make a triangle strip
        for (uint32_t x = 0; x < tileRes; ++x)
        {
            mesh._indices[index++] = row0Index++;
            mesh._indices[index++] = row1Index++;
        }

        for (uint32_t y = 1; y < tileRes - 1; ++y)
        {
            index = y * tileRes + 1;

            for (uint32_t x = 1; x < tileRes - 1; ++x, ++index)
            {
                const Vertex& vback = mesh._vertices[index - tileRes];
                const Vertex& vforward = mesh._vertices[index + tileRes];
                const Vertex& vleft = mesh._vertices[index - 1];
                const Vertex& vright = mesh._vertices[index + 1];

                float_t nX = vleft.position.x - vright.position.x;
                float_t nY = vback.position.y - vforward.position.y;
                float_t nZ = 100.0f;

                Vertex& vertex = mesh._vertices[index];
                vertex.normal = glm::normalize(glm::vec3(nX, nY, nZ));
            }
        }

        free(values);
        // mesh bounds
        mesh._min = glm::vec3(0.0f, 0.0f, minZ);
        mesh._max = glm::vec3(terrainSize, terrainSize, maxZ);
        mesh._center = (mesh._min + mesh._max) / 2.0f;
        mesh._radius = glm::distance(mesh._min, mesh._max) / 2.0f;

#ifdef THREADING_PART2
        //upload_mesh(mesh);
        _terrainMeshes.insert(std::pair<std::string, TerrainMesh>(meshName, mesh));

        glm::mat4 localToWorld = _world * matrix;
        _renderQueue.enqueue(RenderMessage(RenderMessage::MessageType::AddTerrain, meshName, "terrain", localToWorld));
#else
        upload_mesh(mesh);
        _terrainMeshes.insert(std::pair<std::string, TerrainMesh>(meshName, mesh));

        glm::mat4 localToWorld = _world * matrix;

        TerrainRenderObject ro;
        ro.mesh = get_terrainMesh(meshName);
        ro.transformMatrix = localToWorld;
        _terrainRenderBuckets["terrain"].renderObjects.emplace_back(ro);

        glm::vec3 p = mesh._center - mesh._radius * glm::vec3(4.0f, 0, 0);
        p = localToWorld * glm::vec4(p, 1.0f);
        glm::vec3 c = localToWorld * glm::vec4(mesh._center, 1.0f);
        _camera.lookAt(p, c);
#endif
    }

    union Float
    {
        unsigned __int32 u32;
        float_t f32;
        struct // single precision floating point (binary32) format IEEE 754-2008
        {
            unsigned __int32 frac : 23;
            unsigned __int32 exp : 8;
            unsigned __int32 sign : 1;
        };
    };

    union Half
    {
        unsigned short u16;
        struct // half (binary16) format IEEE 754-2008
        {
            unsigned short frac : 10;
            unsigned short exp : 5;
            unsigned short sign : 1;
        };
        Float toFloat()
        {
            Float f;
            f.sign = sign;
            switch (exp)
            {
            case 0: // subnormal : (-1)^sign * 2^-14 * 0.frac
                if (frac) // subnormals but non-zeros -> normals in float32
                {
                    f.exp = -15 + 127;
                    unsigned __int32 _frac(frac);
                    while (!(_frac & 0x200)) { _frac <<= 1; f.exp--; }
                    f.frac = (_frac & 0x1FF) << 14;
                }
                else { f.frac = 0; f.exp = 0; } // ± 0 -> ± 0
                break;
            case 31: // infinity or NaNs : frac ? NaN : (-1)^sign * infinity
                f.exp = 255;
                f.frac = frac ? 0x200000 : 0; // signaling Nan or zero
                break;
            default: // normal : (-1)^sign * 2^(exp-15) * 1.frac
                f.exp = exp - 15 + 127;
                f.frac = ((unsigned __int32)frac) << 13;
            }
            return f;
        }
    };

    inline float_t halfToFloat(unsigned short val)
    {
        Half h;
        h.u16 = val;

        return h.toFloat().f32;
    }

    struct SMeshInfos
    {
        SMeshInfos() : numVertices(0), numIndices(0), numBonesPerVertex(4), firstVertex(0), firstIndex(0), vertexType(0), materialID(0) {}

        uint32_t numVertices;
        uint32_t numIndices;
        uint32_t numBonesPerVertex;
        uint32_t firstVertex;
        uint32_t firstIndex;
        uint32_t vertexType;
        uint32_t materialID;
        //glm::vec3 minBounds = glm::vec3(0.0f);
        //glm::vec3 maxBounds = glm::vec3(0.0f);
    };

    // Informations about the .buffer file
    struct SVertexBufferInfos
    {
        SVertexBufferInfos() : verticesCoordsOffset(0), uvOffset(0), normalsOffset(0), indicesOffset(0), nbVertices(0), nbIndices(0), lod(1) {}

        uint32_t verticesCoordsOffset;
        uint32_t uvOffset;
        uint32_t normalsOffset;
        uint32_t indicesOffset;
        uint32_t nbIndices;
        uint16_t nbVertices;
        uint8_t lod;
        uint8_t unused = 0;
    };

    struct SBufferInfos
    {
        SBufferInfos() : vertexBufferOffset(0), vertexBufferSize(0), indexBufferOffset(0), indexBufferSize(0),
            quantizationScale(glm::vec3(1, 1, 1)), quantizationOffset(glm::vec3(0, 0, 0)) {}

        uint32_t vertexBufferOffset;
        uint32_t vertexBufferSize;
        uint32_t indexBufferOffset;
        uint32_t indexBufferSize;

        glm::vec3 quantizationScale;
        glm::vec3 quantizationOffset;

        std::vector<SVertexBufferInfos> verticesBuffer;
    };

    bool loadGeometry(std::string filename, Mesh& mesh, const SBufferInfos& bufferInfo, const std::vector<SMeshInfos>& meshInfos)
    {
        std::string bufferFileName = filename + ".1.buffer";
        WolvenEngine::File fp;
        if (!fp.open(bufferFileName.c_str(), "rb"))
            return false;

        uint16_t totalVerts = 0;
        uint16_t totalIndices = 0;

        Mesh temp;

        for (auto it = meshInfos.begin(); it != meshInfos.end(); it++)
        {
            const SMeshInfos& mi = *it;

            SVertexBufferInfos vBufferInf;
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

            for (uint32_t j = 0; j < mi.numVertices; ++j)
            {
                uint16_t x = fp.read<uint16_t>();
                uint16_t y = fp.read<uint16_t>();
                uint16_t z = fp.read<uint16_t>();

                fp.seek(sizeof(uint16_t), SEEK_CUR); // skip w

                if (mi.vertexType == 1)
                {
                    // skip weighting for now
                    fp.seek(mi.numBonesPerVertex * 2, SEEK_CUR);
                }
                Vertex v;
                v.position.x = x / 65535.0f;
                v.position.y = y / 65535.0f;
                v.position.z = z / 65535.0f;

                v.position *= bufferInfo.quantizationScale;
                v.position += bufferInfo.quantizationOffset;

                temp._vertices.emplace_back(v);
            }

            fp.seek(vBufferInf.uvOffset + firstVertexOffset * 4, SEEK_SET);

            for (uint32_t j = 0; j < mi.numVertices; ++j)
            {
                uint16_t u = fp.read<uint16_t>();
                uint16_t v = fp.read<uint16_t>();

                Vertex& vert = temp._vertices[j + totalVerts];

                vert.uv.x = halfToFloat(u);
                vert.uv.y = halfToFloat(v);
            }

            // there is a lot of unknown data after the uvs and before the indices so just ignore it all...

            fp.seek(bufferInfo.indexBufferOffset + vBufferInf.indicesOffset + firstIndexOffset * 2, SEEK_SET);

            for (uint32_t j = 0; j < mi.numIndices; j += 3)
            {
                uint16_t index0, index1, index2;
                uint16_t index;

                //TODO: this is how it was done in Irrlicht but maybe we can leave the data as is and just change the normal when calculated?
                // change the winding to invert the normal when calculated
                index = fp.read<uint16_t>(); index0 = totalVerts + index;
                index = fp.read<uint16_t>(); index1 = totalVerts + index;
                index = fp.read<uint16_t>(); index2 = totalVerts + index;

                temp._indices.emplace_back(index0);
                temp._indices.emplace_back(index1);
                temp._indices.emplace_back(index2);

                const glm::vec3& v0 = temp._vertices[index0].position;
                const glm::vec3& v1 = temp._vertices[index1].position;
                const glm::vec3& v2 = temp._vertices[index2].position;

                // get the normal for the plane
                glm::vec3 d1 = v0 - v1;
                glm::vec3 d2 = v2 - v0;
                glm::vec3 normal = glm::cross(d2, d1);
                if (normal.x != 0 && normal.y != 0 && normal.z != 0)
                    normal = glm::normalize(normal);
                else
                    normal = glm::vec3(0.0f, 0.0f, 1.0f);

                temp._vertices[index0].normal = normal;
                temp._vertices[index1].normal = normal;
                temp._vertices[index2].normal = normal;

#if 0
                // get the tangent
                const glm::vec2& t0 = mesh._vertices[index0].uv;
                const glm::vec2& t1 = mesh._vertices[index1].uv;
                const glm::vec2& t2 = mesh._vertices[index2].uv;

                float_t dy1 = t0.y - t1.y;
                float_t dy2 = t2.y - t0.y;
                glm::vec3 tangent = d1 * dy2 - d2 * dy1;
                tangent = glm::normalize(tangent);

                float_t dx1 = t0.x - t1.x;
                float_t dx2 = t2.x - t0.x;
                glm::vec3 binormal = d1 * dx2 - d2 * dx1;
                binormal = glm::normalize(binormal);

                glm::vec3 txb = glm::cross(tangent, binormal);
                glm::vec4 T = glm::make_vec4(tangent);
                T.w = glm::dot(txb, normal) < 0.0f ? -1.0f : 1.0f;

                mesh._vertices[index0].tangent = T;
                mesh._vertices[index1].tangent = T;
                mesh._vertices[index2].tangent = T;
#endif
            }

            totalVerts += mi.numVertices;
            totalIndices += mi.numIndices;
        }

        if (temp._vertices.size() > 0)
        {
            temp._min = mesh._min;
            temp._max = mesh._max;
            temp._center = (temp._min + temp._max) / 2.0f;
            temp._radius = glm::distance(temp._min, temp._max) / 2.0f;

#ifdef SIMPLIFY
#ifdef _DEBUG
            std::cout << "before mesh: " << temp._vertices.size() << " vertices " << temp._indices.size() << " indices" << std::endl;
#endif
            if (temp._vertices.size() > 100)
            {
#ifdef _DEBUG
                size_t pos = filename.rfind('\\');
                if (pos == std::string::npos)
                    pos = filename.rfind('/');
                std::string meshName = filename.substr(pos + 1);

                std::string inname = meshName + "_src.obj";
                write_obj(inname, temp);

#endif
                Simplify::simplify_mesh(temp, mesh);
                if (mesh._vertices.size() > temp._vertices.size())
                {
#ifdef _DEBUG
                    std::cout << "------ ALERT: " << meshName << " increased in size!" << std::endl;
                    std::string outname = meshName + "_bad.obj";
                    write_obj(outname, mesh);
#endif
                    mesh._center = temp._center;
                    mesh._max = temp._max;
                    mesh._min = temp._min;
                    mesh._vertices = temp._vertices;
                    mesh._indices = temp._indices;
                }
#ifdef _DEBUG
                else
                {
                    std::string outname = meshName + "_simplified.obj";
                    write_obj(outname, mesh);
                }
#endif
            }
            else
            {
                // small enough to leave alone
                mesh._center = temp._center;
                mesh._max = temp._max;
                mesh._min = temp._min;
                mesh._vertices = temp._vertices;
                mesh._indices = temp._indices;
            }
#ifdef _DEBUG
            std::cout << "after mesh: " << mesh._vertices.size() << " vertices" << mesh._indices.size() << " indices" << std::endl;
#endif
#else
            mesh = temp;
#endif

//#ifdef _DEBUG
#if 0
            // bounding box vertices
            // v0 = min x, min y, min z
            // v1 = min x, min y, max z
            // v2 = min x, max y, max z
            // v3 = min x, max y, min z
            // v4 = max x, min y, min z
            // v5 = max x, min y, max z
            // v6 = max x, max y, max z
            // v7 = max x, max y, min z
            Vertex v0;
            v0.position.x = mesh._min.x;
            v0.position.y = mesh._min.y;
            v0.position.z = mesh._min.z;

            Vertex v1;
            v1.position.x = mesh._min.x;
            v1.position.y = mesh._max.y;
            v1.position.z = mesh._min.z;

            Vertex v2;
            v2.position.x = mesh._max.x;
            v2.position.y = mesh._max.y;
            v2.position.z = mesh._min.z;

            Vertex v3;
            v3.position.x = mesh._max.x;
            v3.position.y = mesh._max.y;
            v3.position.z = mesh._max.z;

            Vertex v4;
            v4.position.x = mesh._max.x;
            v4.position.y = mesh._min.y;
            v4.position.z = mesh._max.z;

            Vertex v5;
            v5.position.x = mesh._min.x;
            v5.position.y = mesh._min.y;
            v5.position.z = mesh._max.z;

            Vertex v6 = v0;

            Vertex v7;
            v7.position.x = mesh._max.x;
            v7.position.y = mesh._min.y;
            v7.position.z = mesh._min.z;

            Vertex v8 = v2;

            Vertex v9;
            v9.position.x = mesh._min.x;
            v9.position.y = mesh._max.y;
            v9.position.z = mesh._max.z;

            Vertex v10 = v5;
            Vertex v11 = v4;

            Vertex v12 = v7;
            Vertex v13 = v2;
            Vertex v14 = v1;
            Vertex v15 = v9;
            Vertex v16 = v3;

            mesh._vertices.emplace_back(v0);
            mesh._vertices.emplace_back(v1);
            mesh._vertices.emplace_back(v2);
            mesh._vertices.emplace_back(v3);
            mesh._vertices.emplace_back(v4);
            mesh._vertices.emplace_back(v5);
            mesh._vertices.emplace_back(v6);
            mesh._vertices.emplace_back(v7);
            mesh._vertices.emplace_back(v8);
            mesh._vertices.emplace_back(v9);
            mesh._vertices.emplace_back(v10);
            mesh._vertices.emplace_back(v11);
            mesh._vertices.emplace_back(v12);
            mesh._vertices.emplace_back(v13);
            mesh._vertices.emplace_back(v14);
            mesh._vertices.emplace_back(v15);
            mesh._vertices.emplace_back(v16);
#endif
            return true;
        }

        return false;
    }

    void VulkanEngine::addMesh(std::string filename, const glm::mat4& matrix)
    {
        WolvenEngine::File fp;
        if (!fp.open(filename.c_str(), "rb"))
            return;

        std::vector<std::string> labels;
        std::vector<std::string> fileNames;
        std::vector<ContentInfo> contents;

        SBufferInfos bufferInfo;
        std::vector<SMeshInfos> meshes;

        Mesh mesh;

        if (readCR2W(fp, labels, fileNames, contents))
        {
            for (size_t i = 0; i < contents.size(); ++i)
            {
                ContentInfo& ci = contents[i];

                if (labels[ci.type] == "CMesh")
                {
                    fp.seek(ci.address + 1, SEEK_SET);

                    Variable var;
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
#ifdef _DEBUG
                                    std::cout << "reading material: " << matName.c_str() << "\n";
#endif

                                    char lastChar = matName[matName.length() - 1];
                                    switch (lastChar)
                                    {
                                    case 'i':
                                    {
                                        // w2mi
                                        std::string depot = WolvenEngine::resourcePaths.top();
                                        std::string w2miFileName = depot + fileNames[fileId];
                                        //readW2miFile(w2miFileName, material);
                                    }
                                    break;
                                    case 'g':
                                        // w2mg
                                        break;
                                    case 'm':
                                        // xbm
                                        break;
                                    default:
                                        break;
                                    }

                                    //m_materials.emplace_back(material);

                                }
                            }
                        }
                        else if (labels[var.name] == "chunks")
                        {
                            // read smesh chunk packed property
                            uint32_t nbChunks = fp.read<uint32_t>();

                            SMeshInfos smeshInfo;

                            for (uint32_t j = 0; j < nbChunks; ++j)
                            {
                                fp.seek(1, SEEK_CUR);

                                Variable chunkVar;
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
                                meshes.emplace_back(smeshInfo);
                            }
                        }
                        else if (labels[var.name] == "cookedData")
                        {
                            // read information about the buffer containing the geometry data
                            fp.seek(1, SEEK_CUR);

                            Variable chunkVar;
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
                                        SVertexBufferInfos info;

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

                                mesh._min.x = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                mesh._min.y = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                mesh._min.z = fp.read<float_t>();
                                fp.seek(14, SEEK_CUR); // skip w and then a blank name field
                            }

                            // max bounds
                            {
                                fp.seek(17, SEEK_CUR);

                                mesh._max.x = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                mesh._max.y = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                mesh._max.z = fp.read<float_t>();
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
                        Variable matVar;
                        bool rc = readVariable(fp, matVar);

                        if (labels[matVar.name] == "baseMaterial")
                        {
                            uint32_t fileId = fp.read<uint32_t>();
                            fileId = 0xFFFFFFFF - fileId;

                            // read the material
                            assert(fileId < fileNames.size());
                            std::string matName = fileNames[fileId];
#ifdef _DEBUG
                            std::cout << "reading material: " << matName.c_str() << "\n";
#endif
                            char lastChar = matName[matName.length() - 1];
                            switch (lastChar)
                            {
                            case 'i':
                            {
                                // w2mi
                                std::string depot = WolvenEngine::resourcePaths.top();
                                std::string w2miFileName = depot + fileNames[fileId];
                                //readW2miFile(w2miFileName, material);
                            }
                            break;
                            case 'g':
                                // w2mg
                                break;
                            case 'm':
                                // xbm
                                break;
                            default:
                                break;
                            }

                            //m_materials.emplace_back(material);

                            fp.seek(matVar.end, SEEK_SET);
                        }
                        else if (labels[matVar.name] == "enableMask")
                        {
                            fp.seek(matVar.end, SEEK_SET);
                        }
                        else
                        {
                            //vkw2::Material material(m_device);

                            uint32_t nbProperties = fp.read<uint32_t>();

                            if (nbProperties > 0)
                            {
                                for (uint32_t j = 0; j < nbProperties; ++j)
                                {
                                    long back = fp.tell();
                                    uint32_t propSize = fp.read<uint32_t>();

                                    uint16_t propId = fp.read<uint16_t>();
                                    uint16_t propTypeId = fp.read<uint16_t>();

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
                                            // load the file!
                                            std::string depot = WolvenEngine::resourcePaths.top();
                                            std::string imgFileName = depot + fileNames[texId];

                                            size_t pos = imgFileName.rfind('\\');
                                            std::string texName = imgFileName.substr(pos + 1);

                                            //TODO
                                            /*
                                            size_t texIndex = 0;
                                            TextureDictionary::const_iterator ti = m_textureCache.find(texName);
                                            if (ti == m_textureCache.end())
                                            {
                                                vkw2::Texture* texture = new vkw2::Texture();
                                                texture->loadFromXBM(imgFileName, m_device, transferQueue);
                                                m_textureCache.insert(std::pair<std::string, vkw2::Texture*>(texName, texture));

                                                if (textureLayer == 0)
                                                    material.baseColorTexture = texture;
                                                else
                                                    material.normalTexture = texture;
                                            }
                                            else
                                            {
                                                if (textureLayer == 0)
                                                    material.baseColorTexture = ti->second;
                                                else
                                                    material.normalTexture = ti->second;
                                            }
                                            */
                                        }
                                    }

                                    fp.seek(back + propSize, SEEK_SET);
                                }
                            }
                            //m_materials.emplace_back(material);
                        }
                    }
                }
                else if (labels[ci.type] == "CMaterialGraph")
                {
                    // can't read this so just default to something
                    //vkw2::Material material(m_device);
                    //m_materials.emplace_back(material);
                }
            }
        }

        // can read mesh buffer file now
        size_t pos = filename.rfind('\\');
        if (pos == std::string::npos)
            pos = filename.rfind('/');
        std::string meshName = filename.substr(pos + 1);

#ifdef THREADING_PART2
        if (loadGeometry(filename, mesh, bufferInfo, meshes))
        {
            //upload_mesh(mesh);

            _meshes.insert(std::pair<std::string, Mesh>(meshName, mesh));

            glm::mat4 localToWorld = _world * matrix;
            std::string materialName = "defaultmesh";

            _renderQueue.enqueue(RenderMessage(RenderMessage::MessageType::AddMesh, meshName, materialName, localToWorld));
        }
#else
        if (loadGeometry(filename, mesh, bufferInfo, meshes))
        {
            upload_mesh(mesh);

            _meshes.insert(std::pair<std::string, Mesh>(meshName, mesh));

            glm::mat4 localToWorld = _world * matrix;
            std::string materialName = "defaultmesh";

            RenderObject ro;
            ro.mesh = get_mesh(meshName);
            ro.transformMatrix = localToWorld;

            addOrInsert(materialName, ro);
            
            glm::vec3 p = mesh._center - mesh._radius * glm::vec3(4.0f, 0, 0);
            p = _world * glm::vec4(p,1.0f);
            glm::vec3 c = _world * glm::vec4(mesh._center,1.0f);
            _camera.lookAt(p,c);
        }
#endif
    }

#ifdef THREADING_PART2
    void VulkanEngine::render_addMesh(std::string meshName, std::string materialName, const glm::mat4& matrix)
    {
        RenderObject ro;
        ro.mesh = get_mesh(meshName);
        ro.transformMatrix = matrix;

        upload_mesh(ro.mesh);

        addOrInsert(materialName, ro);

        glm::vec3 p = ro.mesh->_center - ro.mesh->_radius * glm::vec3(4.0f, 0, 0);
        p = _world * glm::vec4(p, 1.0f);
        glm::vec3 c = _world * glm::vec4(ro.mesh->_center, 1.0f);
        _camera.lookAt(p, c);
    }

    void VulkanEngine::render_addTerrain(std::string meshName, std::string materialName, const glm::mat4& matrix)
    {
        TerrainRenderObject ro;
        ro.mesh = get_terrainMesh(meshName);
        ro.transformMatrix = matrix;

        upload_mesh(ro.mesh);

        _terrainRenderBuckets[materialName].renderObjects.emplace_back(ro);

        glm::vec3 p = ro.mesh->_center - ro.mesh->_radius * glm::vec3(4.0f, 0, 0);
        p = matrix * glm::vec4(p, 1.0f);
        glm::vec3 c = matrix * glm::vec4(ro.mesh->_center, 1.0f);
        _camera.lookAt(p, c);
    }
#endif

    bool hasEnding(std::string const& fullString, std::string const& ending)
    {
        if (fullString.length() >= ending.length()) {
            return (0 == fullString.compare(fullString.length() - ending.length(), ending.length(), ending));
        }
        else {
            return false;
        }
    }

    void VulkanEngine::addLayer(std::string filename)
    {
        enum class BlockObjectType
        {
            Invalid = 1,
            Mesh = 2,
            Collision = 3,
            Decal = 4,
            Dimmer = 5,
            PointLight = 6,
            SpotLight = 7,
            RigidBody = 8,
            Cloth = 9,
            Destruction = 10,
            Particles = 11
        };

        constexpr float_t RadiansToFloat = (float_t)(180 / M_PI);

        WolvenEngine::File fp;
        if (!fp.open(filename.c_str(), "rb"))
            return;

        std::cout << "adding layer = " << filename << std::endl;

        std::string depot = WolvenEngine::resourcePaths.top();

        std::vector<std::string> labels;
        std::vector<std::string> fileNames;
        std::vector<WolvenEngine::ContentInfo> contents;

        if (readCR2W(fp, labels, fileNames, contents))
        {
            for (size_t i = 0; i < contents.size(); ++i)
            {
                WolvenEngine::ContentInfo& ci = contents[i];

                if (labels[ci.type] == "CSectorData")
                {
                    int32_t objectCount = 0;
                    std::vector<uint64_t> hashes;
                    struct Object {
                        uint8_t type;
                        uint64_t offset;
                    };
                    std::vector<Object> objects;

                    fp.seek(ci.address, SEEK_SET); // skip all the RED variables

                    // read 5 variables
                    // Unknown uint64_t
                    fp.seek(sizeof(uint64_t), SEEK_CUR);

                    // Resources CBufferVLQInt32
                    {
                        int32_t elementCount = WolvenEngine::readVLQInt32(fp); //22?
                        for (int32_t j = 0; j < elementCount; ++j)
                        {
                            fp.seek(24, SEEK_CUR);

                            uint64_t hash = fp.read<uint64_t>();

                            hashes.emplace_back(hash);
                        }
                    }
                    // Objects CBufferVLQInt32
                    {
                        objectCount = WolvenEngine::readVLQInt32(fp);
                        for (int32_t j = 0; j < objectCount; ++j)
                        {
                            // read 7 properties
                            Object obj;

                            // type uint8_t
                            obj.type = fp.read<uint8_t>();

                            fp.seek(3, SEEK_CUR);

                            // offset uint64_t
                            obj.offset = fp.read<uint64_t>();
                            objects.emplace_back(obj);

                            fp.seek(sizeof(float_t) * 3, SEEK_CUR);
                        }
                    }

                    // blocksize CVLQInt32 - ignored

                    // BlockData CCompressedBuffer - ignored


                    int32_t blockSize = WolvenEngine::readVLQInt32(fp);

                    for (int32_t j = 0; j < objectCount; ++j)
                    {
                        // read blockdata

                        // rotationMatrix CMatrix3x3
                        const float_t* vals = fp.read<const float_t>(9);
                        glm::mat4 rotation(
                            vals[0], vals[1], vals[2], 0.0f,
                            vals[3], vals[4], vals[5], 0.0f,
                            vals[6], vals[7], vals[8], 0.0f,
                               0.0f,    0.0f,    0.0f, 1.0f);

                        // position SVector3D
                        vals = fp.read<const float_t>(3);
                        glm::vec3 translation(vals[0], vals[1], vals[2]);

                        fp.seek(8, SEEK_CUR);

                        BlockObjectType btype = BlockObjectType(objects[j].type);

                        switch (btype)
                        {
                        case BlockObjectType::Invalid:
                        {
                            // packedObject
                            fp.seek(8, SEEK_CUR);
                        }
                        break;

                        case BlockObjectType::Mesh:
                        {
                            // packedObject
                            uint16_t meshIndex = fp.read<uint16_t>();
                            fp.seek(18, SEEK_CUR);

                            auto it = m_pathHashes.find(hashes[meshIndex]);
                            if (it != m_pathHashes.end())
                            {
                                std::string meshPath = depot + it->second;
                                glm::mat4 matrix = glm::translate(glm::mat4(1.0f), translation) * rotation;

                                // get the model
#ifdef THREADING_PART2
                                addMesh(meshPath, matrix);
#else
                                _renderQueue.enqueue(RenderMessage(RenderMessage::MessageType::AddMesh, meshPath, matrix));
#endif // THREADING_PART2
                            }
                        }
                        break;

                        case BlockObjectType::Collision:
                        {
                            fp.seek(20, SEEK_CUR);
                        }
                        break;

                        case BlockObjectType::Decal:
                        {
                            fp.seek(12, SEEK_CUR);
                        }
                        break;

                        case BlockObjectType::Dimmer:
                        {
                            fp.seek(52, SEEK_CUR);
                        }
                        break;

                        case BlockObjectType::PointLight:
                        {
                            fp.seek(80, SEEK_CUR);
                        }
                        break;

                        case BlockObjectType::SpotLight:
                        {
                            fp.seek(40, SEEK_CUR);
                        }
                        break;

                        case BlockObjectType::RigidBody:
                        {
                            fp.seek(20, SEEK_CUR); // verify
                        }
                        break;

                        case BlockObjectType::Cloth:
                        {
                            fp.seek(20, SEEK_CUR); // verify
                        }
                        break;

                        case BlockObjectType::Destruction:
                        {
                            fp.seek(12, SEEK_CUR);
                        }
                        break;

                        case BlockObjectType::Particles:
                        {
                            fp.seek(20, SEEK_CUR); // verify
                        }
                        break;

                        default:
                            break;
                        }
                    }
                }
            }
        }
    }

    void VulkanEngine::addWorld(std::string filename)
    {
        WolvenEngine::File fp;
        if (!fp.open(filename.c_str(), "rb"))
            return;

        std::vector<std::string> labels;
        std::vector<std::string> fileNames;
        std::vector<std::string> tileNames;
        std::vector<WolvenEngine::ContentInfo> contents;

        struct TerrainTileInfo
        {
            uint32_t clipSize;
            uint32_t clipmapSize;
            uint32_t tileRes;
            float_t terrainSize;
            glm::vec3 terrainCorner;
            uint32_t numTilesPerEdge;
            float_t lowestElevation;
            float_t highestElevation;
        };
        TerrainTileInfo terrainInfo;
        bool hasTerrain = false;

        std::string depot = WolvenEngine::resourcePaths.top();

        if (readCR2W(fp, labels, fileNames, tileNames, contents))
        {
            for (size_t i = 0; i < contents.size(); ++i)
            {
                WolvenEngine::ContentInfo& ci = contents[i];

                if (labels[ci.type] == "CLayerInfo")
                {
                    fp.seek(ci.address + 1, SEEK_SET);

                    WolvenEngine::Variable var;
                    while (readVariable(fp, var))
                    {
                        if (labels[var.name] == "depotFilePath")
                        {
                            uint8_t b = fp.read<uint8_t>();
                            if (b != 0x80 && b != 0x0)
                            {
                                bool nxt = (b & (1 << 6)) != 0;
                                bool widechar = (b & (1 << 7)) == 0;
                                uint32_t len = b & ((1 << 6) - 1); // null terminated?
                                if (nxt)
                                {
                                    b = fp.read<uint8_t>();
                                    len += 64 * b;
                                }

                                char* depotFilePath = nullptr;
                                if (!widechar)
                                {
                                    // read string
                                    depotFilePath = fp.read<char>(len);
                                    depotFilePath[len] = '\0';
                                }

                                std::string layerFileName = depot;
                                layerFileName += depotFilePath;
                                addLayer(layerFileName);
                            }
                        }

                        fp.seek(var.end, SEEK_SET);
                    }
                }
                else if (labels[ci.type] == "CClipMap")
                {
                    hasTerrain = true;
                    // terrain
                    fp.seek(ci.address + 1, SEEK_SET);

                    WolvenEngine::Variable var;
                    while (readVariable(fp, var))
                    {
                        if (labels[var.name] == "clipSize")
                        {
                            terrainInfo.clipSize = fp.read<uint32_t>();
                        }
                        else if (labels[var.name] == "clipmapSize")
                        {
                            terrainInfo.clipmapSize = fp.read<uint32_t>();
                        }
                        else if (labels[var.name] == "tileRes")
                        {
                            terrainInfo.tileRes = fp.read<uint32_t>();
                        }
                        else if (labels[var.name] == "terrainSize")
                        {
                            terrainInfo.terrainSize = fp.read<float_t>();
                        }
                        else if (labels[var.name] == "terrainCorner")
                        {
                            fp.seek(9, SEEK_CUR);
                            terrainInfo.terrainCorner.x = fp.read<float_t>();
                            fp.seek(8, SEEK_CUR);
                            terrainInfo.terrainCorner.y = fp.read<float_t>();
                            fp.seek(8, SEEK_CUR);
                            terrainInfo.terrainCorner.z = fp.read<float_t>();
                            fp.seek(14, SEEK_CUR); // skip w and then a null name
                        }
                        else if (labels[var.name] == "numTilesPerEdge")
                        {
                            terrainInfo.numTilesPerEdge = fp.read<uint32_t>();
                        }
                        else if (labels[var.name] == "lowestElevation")
                        {
                            terrainInfo.lowestElevation = fp.read<float_t>();
                        }
                        else if (labels[var.name] == "highestElevation")
                        {
                            terrainInfo.highestElevation = fp.read<float_t>();
                        }

                        // numClipmapStackLevels UInt32
                        // tileRes Uint32
                        // colormapStartingMip Int32
                        // material
                        // textureParams 31 elements
                        // minWaterHeight array: 2,0,Float
                        // cookedMipStackHeight DataBuffer
                        // cookedMipStackControl DataBuffer
                        // cookedMipStackColor DataBuffer
                        // cookedData ptr:CClipMapCookedData

                        fp.seek(var.end, SEEK_SET);
                    }
                }
                //else if (labels[ci.type] == "CMaterialInstance")
                //{

                //}
            }

            if (hasTerrain)
            {
                // finish loading the terrain
                float_t terrainSize = terrainInfo.terrainSize / terrainInfo.numTilesPerEdge;

                glm::vec3 dy = glm::vec3(0.0f, terrainSize, 0.0f);
                glm::vec3 dx = glm::vec3(terrainSize, 0.0f, 0.0f);

                uint32_t index = 0;
                glm::vec3 nextColumn = terrainInfo.terrainCorner;

                for (uint32_t y = 0; y < terrainInfo.numTilesPerEdge; ++y)
                {
                    glm::vec3 nextPt = nextColumn;

                    for (uint32_t x = 0; x < terrainInfo.numTilesPerEdge; ++x, ++index)
                    {
                        // read the .wter file to get the LOD we need
                        std::string wterFileName = depot + tileNames[index];
                        uint32_t tileLOD = 0, tileRes = 0;

                        {
                            WolvenEngine::File fpw;
                            if (fpw.open(wterFileName.c_str(), "rb"))
                            {
                                readWTER(fpw, 1, tileLOD, tileRes);
                            }
                        }

                        std::string tileFileName = wterFileName + ".";
                        tileFileName += std::to_string(tileLOD);
                        tileFileName += ".buffer";

                        glm::mat4 matrix = glm::translate(glm::mat4(1.0f), nextPt);
#ifdef THREADING_PART2
                        addTerrain(tileFileName, tileRes, terrainInfo.highestElevation, terrainInfo.lowestElevation, terrainSize, matrix, index);
#else
                        _renderQueue.enqueue(RenderMessage(RenderMessage::MessageType::AddTerrain, tileFileName, tileRes, terrainInfo.highestElevation, terrainInfo.lowestElevation, terrainSize, matrix, index));
#endif

                        nextPt += dx;
                    }

                    nextColumn += dy;
                }
            }
        }
    }

    void VulkanEngine::load(std::string asset)
    {
        if (hasEnding(asset, "w2w"))
        {
            std::thread (&WolvenEngine::VulkanEngine::addWorld, this, asset).detach();
        }
        else if (hasEnding(asset, "w2l"))
        {
            std::thread (&WolvenEngine::VulkanEngine::addLayer, this, asset).detach();
        }
        else if (hasEnding(asset, "w2mesh"))
        {
            //_camera.type = Camera::CameraType::lookat; // good for model
            addMesh(asset, glm::mat4(1.0f));
        }
        //else if (hasEnding(asset, "obj"))
        //{
        //    Mesh mesh;
        //    mesh.load_from_obj(asset.c_str());

        //    upload_mesh(mesh);

        //    _meshes["monkey"] = mesh;

        //    RenderObject ro;
        //    ro.mesh = get_mesh("monkey");
        //    ro.material = get_material("defaultmesh");
        //    ro.transformMatrix = glm::mat4(1.0f);
        //    _renderables.push_back(ro);

        //    //camera.type = Camera::CameraType::lookat; // good for model
        //    //camera.setPosition(glm::vec3(0.0f, 0.0f, 4.0f));
        //}
    }
}