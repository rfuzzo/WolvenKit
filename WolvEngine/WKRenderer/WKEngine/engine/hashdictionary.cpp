#include "hashdictionary.h"
#include <iostream>

namespace WolvenEngine
{
    bool loadPathHashes(const std::string& path, HashDictionary& dictionary)
    {
        FILE* fp = nullptr;
        fopen_s(&fp, path.c_str(), "rt");
        if (fp != nullptr)
        {
            char path[256];
            uint64_t hash;

            // skip first line
            fgets(path, 255, fp);

            while (!feof(fp))
            {
                fgets(path, 255, fp);
                char* p = strchr(path, ',');
                if (p != nullptr)
                {
                    *p = '\0';
                    p++;
                    sscanf_s(p, "%llu", &hash);
                    dictionary.insert(std::pair<uint64_t, std::string>(hash, path));
                }
            }
            fclose(fp);
            return true;
        }

        return false;
    }
}