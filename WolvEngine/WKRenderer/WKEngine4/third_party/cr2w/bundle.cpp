#include "bundle.h"
#include <stdio.h>
#include <assert.h>

namespace WolvenEngine
{
    Bundle::Bundle()
    {

    }

    Bundle::~Bundle()
    {

    }

    bool Bundle::open(const char* filename)
    {
        if (_fp.size() == 0)
        {
            _filename = filename;
            return _fp.open(filename, "rb");
        }

        if (_filename == filename)
            return true;
        
        return false;
    }

    bool Bundle::load(uint32_t offset, uint32_t compressedSize, uint32_t uncompressedSize, uint16_t compression, File& fp)
    {
        _fp.seek(offset, SEEK_SET);
        uint8_t* data = _fp.getBuffer<uint8_t*>();

        File::Compression compressionType = File::Compression::NONE;
        switch (compression)
        {
        case 1:
            compressionType = File::Compression::ZLIB;
            break;
        case 2:
            assert(false);
            break;
        case 3:
            compressionType = File::Compression::DOBOZ;
            break;
        case 4:
        case 5:
            compressionType = File::Compression::LZ4;
            break;
        default:
            break;
        }

        return fp.open(data, compressedSize, uncompressedSize, compressionType);
    }
}