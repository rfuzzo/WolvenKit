#pragma once

#include "vk_mesh.h"
#include <string>

namespace WolvenEngine
{
    struct Material
    {
        std::string name;
        std::string diffuseTexture;
        std::string normalTexture;
    };

    bool loadMesh(const std::string& filename, std::vector<Mesh>& meshes, std::vector<Material>& materials);
}