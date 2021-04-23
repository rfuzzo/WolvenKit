#pragma once

#include <stdint.h>
#include <string>
#include "file.h"

namespace WolvenEngine
{
    class Bundle
    {
    public:
        Bundle();
        ~Bundle();

        bool open(const char* filename);
        bool load(uint32_t offset, uint32_t compressedSize, uint32_t uncompressedSize, uint16_t compression, File& fp);
    private:
        File _fp;
        std::string _filename;
    };
}