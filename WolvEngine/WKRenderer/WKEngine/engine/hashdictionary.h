#pragma once
#pragma once

#include <string>
#include <unordered_map>

namespace WolvenEngine
{
    typedef std::unordered_map<uint64_t, std::string> HashDictionary;

    bool loadPathHashes(const std::string& path, HashDictionary& dictionary);
}