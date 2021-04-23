#pragma once

#include <stdlib.h>
#include <string>
#include <fstream>
#include <vector>
#include <unordered_map>
#include <glm/glm.hpp>
#include "vk_mesh.h"

#include "fbxsdk.h"

namespace FBX
{
    struct Node {
        glm::mat4 matrix;
        std::shared_ptr<Mesh> mesh;
        std::string diffuseTexture;
        std::string normalTexture;

        Node(const glm::mat4& m) :matrix(m) {}
    };

    class Model {
    private:
        std::unordered_map<std::string, std::shared_ptr<Mesh>> cachedMeshes;

        std::shared_ptr<Mesh> processMesh(FbxMesh* pMesh);
        void processNode(FbxNode* pNode);

    public:
        std::vector<Node*> nodes;

        Model(){};
        ~Model();
        bool loadFromFile(std::string filename);
    };

}