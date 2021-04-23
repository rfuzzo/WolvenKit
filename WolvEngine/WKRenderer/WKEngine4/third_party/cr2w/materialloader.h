#pragma once

#include <string>

namespace WolvenEngine
{
    bool loadMaterial(const std::string& filename, std::string& diffuseTexture, std::string& normalTexture);

    enum class ImageFormat
    {
        Unknown,
        BC3,
        BC5
    };

}