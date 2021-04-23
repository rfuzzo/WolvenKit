#define _USE_MATH_DEFINES
#include <cmath>

#include "cr2wModel.h"
#include "resourcepath.h"
#include "hashdictionary.h"

#ifdef USE_GAME_BUNDLES
#include "bundlemanager.h"
#endif

#ifdef _DEBUG
#include <iostream>
#endif

namespace WolvenEngine
{
    Model::~Model()
    {
        for (auto it = nodes.begin(); it != nodes.end(); ++it)
        {
            delete *it;
        }
    }

    bool Model::addLayer(const std::string& filename)
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

        bool addedParentNode = false;

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

#ifdef _DEBUG
        std::cout << "adding layer = " << filename << std::endl;
#endif

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
                            0.0f, 0.0f, 0.0f, 1.0f);

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

                            glm::mat4 matrix = glm::translate(glm::mat4(1.0f), translation) * rotation;

                            auto mit = cachedMeshes.find(hashes[meshIndex]);
                            if (mit != cachedMeshes.end())
                            {
                                if (!addedParentNode)
                                {
                                    Node* newParentNode = new Node(filename);
                                    nodes.push_back(newParentNode);
                                    addedParentNode = true;
                                }

                                // already have a mesh!
                                Node* newNode = new Node(matrix);
                                newNode->mesh = mit->second;
                                nodes.push_back(newNode);
                            }
                            else
                            {
                                auto it = PathHashes.find(hashes[meshIndex]);
                                if (it != PathHashes.end())
                                {
#ifdef USE_GAME_BUNDLES
                                    std::string meshPath = it->second;
#else
                                    std::string depot = WolvenEngine::resourcePaths.top();
                                    std::string meshPath = depot + it->second;
#endif

                                    if (!addedParentNode)
                                    {
                                        Node* newParentNode = new Node(filename);
                                        nodes.push_back(newParentNode);
                                        addedParentNode = true;
                                    }

                                    Node* newNode = new Node(matrix);
                                    newNode->mesh = std::make_shared<Mesh>();
                                    newNode->mesh->filename = meshPath;
                                    newNode->mesh->hash = hashes[meshIndex];
                                    nodes.push_back(newNode);

                                    cachedMeshes.insert(std::pair<uint64_t, std::shared_ptr<Mesh>>(hashes[meshIndex], newNode->mesh));
                                }
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

        return true;
    }

    bool Model::addWorld(const std::string& filename)
    {
        std::vector<std::string> labels;
        std::vector<std::string> fileNames;
        std::vector<std::string> tileNames;
        std::vector<WolvenEngine::ContentInfo> contents;

        bool hasTerrain = false;
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

#ifdef USE_GAME_BUNDLES
                                std::string layerFileName = depotFilePath;
#else
                                std::string layerFileName = depot;
                                layerFileName += depotFilePath;
#endif
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
                        uint32_t tileLOD = 0, tileRes = 0;
                        std::string wterFileName;
                        {
                            WolvenEngine::File fpw;
#ifdef USE_GAME_BUNDLES
                            wterFileName = tileNames[index];
                            if (WolvenEngine::BundleManager::instance()->open(wterFileName.c_str(), fpw))

#else
                            wterFileName = depot + tileNames[index];
                            if (fpw.open(wterFileName.c_str(), "rb"))
#endif
                            {
                                readWTER(fpw, 1, tileLOD, tileRes);
                            }
                        }

                        std::string tileFileName = wterFileName + ".";
                        tileFileName += std::to_string(tileLOD);
                        tileFileName += ".buffer";

                        glm::mat4 matrix = glm::translate(glm::mat4(1.0f), nextPt);
                        Tile t;
                        t.filename = tileFileName;
                        t.resolution = tileRes;
                        t.matrix = matrix;
                        terrain.emplace_back(t);

                        nextPt += dx;
                    }

                    nextColumn += dy;
                }
            }
        }

        return true;
    }

    bool Model::loadFromFile(std::string asset)
    {
        bool rc = false;

        if (asset.ends_with("w2w"))
        {
            rc = addWorld(asset);
        }
        else if (asset.ends_with("w2l"))
        {
            rc = addLayer(asset);
        }
        else if (asset.ends_with("w2mesh"))
        {
            glm::mat4 matrix = glm::mat4(1.0f);

            Node* newNode = new Node(matrix);
            newNode->mesh = std::make_shared<Mesh>();
            newNode->mesh->filename = asset;
            newNode->mesh->hash = 0;
            nodes.push_back(newNode);

            rc = true;
        }

        return rc;
    }

}