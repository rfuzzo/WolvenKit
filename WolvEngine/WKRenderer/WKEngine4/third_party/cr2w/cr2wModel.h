#pragma once

#include <stdlib.h>
#include <string>
#include <fstream>
#include <vector>
#include <unordered_map>

#include "cr2w.h"
#include "meshloader.h"
#include "terrainloader.h"
#include "materialloader.h"

#ifdef USE_GAME_BUNDLES
#include "bundle.h"
#endif

namespace WolvenEngine
{
    struct Mesh {
        std::string filename;
        uint64_t hash;
    };

    struct Node {
        std::string label;
        glm::mat4 matrix;
        std::shared_ptr<Mesh> mesh;
        Node(const glm::mat4& m) :matrix(m) {}
        Node(std::string n) :label(n) {}
    };

    struct Tile {
        std::string filename;
        glm::mat4 matrix;
        uint32_t resolution;
    };

    class Model {
    private:
        bool addWorld(const std::string& asset);
        bool addLayer(const std::string& asset);

#ifdef USE_GAME_BUNDLES
        WolvenEngine::Bundle _archive;
#endif
    public:

        std::vector<Node*> nodes;
        std::vector<Tile> terrain;

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

        std::unordered_map<uint64_t, std::shared_ptr<Mesh>> cachedMeshes;

        Model(){};
        ~Model();
        bool loadFromFile(std::string filename);
    };

}