#include "hashdictionary.h"
#include "file.h"
#ifdef _DEBUG
#include <iostream>
#include <filesystem>
#endif

namespace WolvenEngine
{
    HashDictionary PathHashes;

#ifdef _DEBUG
    void CreateBinFromCSV(const std::string& path)
    {
        struct elem
        {
            uint64_t hash;
            std::string path;
        };
        std::vector<elem> elements;

        FILE* fp = nullptr;
        fopen_s(&fp, path.c_str(), "rt");
        if (fp != nullptr)
        {
            char line[256];
            uint64_t hash;

            // skip first line
            fgets(line, 255, fp);

            while (!feof(fp))
            {
                fgets(line, 255, fp);
                char* p = strchr(line, ',');
                if (p != nullptr)
                {
                    *p = '\0';
                    p++;
                    sscanf_s(p, "%llu", &hash);

                    size_t len = strlen(line);

                    // if this is a type we want, add it
                    if ((strcmp(line + len - 6, "w2mesh") == 0) ||
                        (strcmp(line + len - 3, "w2l") == 0) ||
                        (strcmp(line + len - 3, "w2w") == 0) ||
                        (strcmp(line + len - 3, "xbm") == 0) ||
                        (strcmp(line + len - 6, "buffer") == 0) ||
                        (strcmp(line + len - 4, "w2mi") == 0) ||
                        (strcmp(line + len - 5, "w2ter") == 0))
                    {
                        PathHashes.insert(std::pair<uint64_t, std::string>(hash, line));

                        elem e;
                        e.hash = hash;
                        e.path = line;
                        elements.emplace_back(e);
                    }
                }
            }
            fclose(fp);

            // now save the binary file
            std::string outputPath = path;
            outputPath.replace(outputPath.rfind("csv"), 3, "bin");

            if (std::filesystem::exists(outputPath))
            {
                std::filesystem::remove(outputPath);
            }

            fopen_s(&fp, outputPath.c_str(), "wb");
            uint32_t nElements = (uint32_t)elements.size();
            fwrite(&nElements, sizeof(uint32_t), 1, fp);

            uint8_t zero = 0;

            for (auto& it : elements)
            {
                fwrite(&(it.hash), sizeof(uint64_t), 1, fp);
                size_t sz = it.path.length();
                fwrite(it.path.c_str(), sz, 1, fp);
                fwrite(&zero, sizeof(uint8_t), 1, fp);
            }
            fclose(fp);
        }
    }
#endif

    bool LoadPathHashes(const std::string& filename)
    {
        WolvenEngine::File fp;
        if (!fp.open(filename.c_str(), "rb"))
            return false;

        uint32_t nElements = fp.read<uint32_t>();

        for (uint32_t i = 0; i < nElements; ++i)
        {
            uint64_t hash = fp.read<uint64_t>();
            std::string path = fp.getBuffer<const char*>();
            long sz = (long)path.length() + 1; // plus the null terminator that was added

            PathHashes.insert(std::pair<uint64_t, std::string>(hash, path));
            fp.seek(sz, SEEK_CUR);
        }
       
        return true;
    }
}