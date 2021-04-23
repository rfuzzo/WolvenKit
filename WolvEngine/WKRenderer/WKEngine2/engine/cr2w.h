#pragma once

#include <string>
#include <vector>
#include "file.h"

namespace WolvenEngine
{
    struct ContentInfo
    {
        uint32_t type;
        uint32_t address;
        uint32_t end;
    };

    bool readCR2W(File& fp, std::vector<std::string>& labels, std::vector<std::string>& fileNames, std::vector<ContentInfo>& contents);
    bool readCR2W(File& fp, std::vector<std::string>& labels, std::vector<std::string>& fileNames, std::vector<std::string>& tileNames, std::vector<ContentInfo>& contents);
    bool readWTER(File& fp, uint32_t lod, uint32_t& tileLOD, uint32_t& tileResolution);

    struct Variable
    {
        uint16_t name;
        uint16_t type;
        uint32_t end;
    };

    bool readVariable(File& fp, Variable& var);
    template <class T>
    T readVariable(File& fp);

    int32_t readVLQInt32(File& fp);
}
