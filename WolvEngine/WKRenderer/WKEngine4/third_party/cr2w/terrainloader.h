#pragma once

#include "vk_mesh.h"
#include <string>

namespace WolvenEngine
{
    bool loadTerrain(const std::string& filename, uint32_t tileRes, float_t highestElevation, float_t lowestElevation, float_t terrainSize, Mesh& mesh);
}