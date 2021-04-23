#pragma once

#include <string>
#include <unordered_map>

namespace WolvenEngine
{
    typedef std::unordered_map<uint64_t, std::string> HashDictionary;
    extern HashDictionary PathHashes;
    bool LoadPathHashes(const std::string& path);
#ifdef _DEBUG
    void CreateBinFromCSV(const std::string& path);
#endif
}