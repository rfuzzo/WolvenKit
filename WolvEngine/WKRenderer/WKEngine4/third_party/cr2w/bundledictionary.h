#pragma once

#include <string>
#include <unordered_map>

namespace WolvenEngine
{
    struct BundleEntry 
    {
        uint32_t offset;
        uint32_t uncompressedSize;
        uint32_t compressedSize;
        uint16_t index;
        uint16_t compression;
    };

    void SetWitcherExePath(const char* exePath);

    typedef std::unordered_map<std::string, BundleEntry> BundleDictionary;
    extern BundleDictionary RawPathHashes;
    bool LoadRawPathHashes(const std::string& path);
    bool GetFileInfo(const std::string& filename, BundleEntry& bundle);
    std::string GetBundlePath(uint32_t index);
#ifdef _DEBUG
    bool CreateTableOfContentsFromBundles();
#endif
}