#include "bundledictionary.h"
#include "file.h"
#include <iostream>
#include <filesystem>

namespace WolvenEngine
{
    typedef std::unordered_map<std::string, std::string> LookupDictionary;

    constexpr uint32_t HASH_SIZE = 16;
    BundleDictionary RawPathHashes;
    LookupDictionary Lookup;
    std::vector<std::string> BundleNames;
    std::string Witcher3ExePath;

    void SetWitcherExePath(const char* exePath)
    {
        Witcher3ExePath = exePath;
    }

#ifdef _DEBUG
    bool LoadBundle(const char* bundleName, uint16_t index)
    {
        // read bundle header
        WolvenEngine::File fp;
        if (!fp.open(bundleName, "rb"))
            return false;

        const char* pIdString = fp.read<char>(8); // POTATO70
        if (strncmp(pIdString, "POTATO70", 8) != 0)
            return false;

        uint32_t bundlesize = fp.read<uint32_t>();
        fp.seek(sizeof(uint32_t), SEEK_CUR);
        uint32_t dataoffset = fp.read<uint32_t>();

        fp.seek(32, SEEK_SET);

        dataoffset += 32;

        while (fp.tell() < (long)dataoffset)
        {            
            const char* strname = fp.read<char>(256);
            size_t len = strlen(strname);

            char* pHash = fp.read<char>(16);

            BundleEntry bundle;
            fp.seek(sizeof(uint32_t), SEEK_CUR); // Empty
            bundle.uncompressedSize = fp.read<uint32_t>();
            bundle.compressedSize = fp.read<uint32_t>();
            bundle.offset = fp.read<uint32_t>();

#ifdef _DEBUG
            uint32_t date = fp.read<uint32_t>(); // Date
            uint32_t time = fp.read<uint32_t>(); // Time
            fp.seek(16, SEEK_CUR); // Zero
            uint32_t crc = fp.read<uint32_t>(); // CRC
#else
            fp.seek(28, SEEK_CUR); // Date
#endif
            uint32_t compression = fp.read<uint32_t>();
            bundle.compression = (uint16_t)compression;
            bundle.index = index;

            // only want .w2mesh, .w2l, .w2w, .xbm, .1.buffer, .wter, .w2mi files
            if ((strcmp(strname + len - 6, "w2mesh") == 0) ||
                (strcmp(strname + len - 3, "w2l") == 0) ||
                (strcmp(strname + len - 3, "w2w") == 0) ||
                (strcmp(strname + len - 3, "xbm") == 0) ||
                (strcmp(strname + len - 6, "buffer") == 0) ||
                (strcmp(strname + len - 4, "w2mi") == 0) ||
                (strcmp(strname + len - 5, "w2ter") == 0))
            {
                std::string hash;
                hash.assign(pHash, 16);

                const auto it = RawPathHashes.find(hash);
                if (it == RawPathHashes.end())
                {
                    RawPathHashes.insert(std::pair<std::string, BundleEntry>(hash, bundle));
#ifdef _DEBUG
                    std::cout << "Added " << strname << " from index " << index << std::endl;
#endif
                }
#ifdef _DEBUG
                else
                {
                    std::cout << "Ignored " << strname << " from index " << index << " as it already existed" << std::endl;
                }
#endif

                const auto itl = Lookup.find(strname);
                if (itl == Lookup.end())
                {
                    Lookup.insert(std::pair<std::string, std::string>(strname, hash));
                }
#ifdef _DEBUG
                else
                {
                    std::cout << "Ignored " << strname << " for lookup as it already existed" << std::endl;
                }
#endif
            }
        }

        return true;
    }

    bool OverrideBundle(const char* bundleName, uint32_t index)
    {
        // read bundle header
        WolvenEngine::File fp;
        if (!fp.open(bundleName, "rb"))
            return false;

        const char* pIdString = fp.read<char>(8); // POTATO70
        if (strncmp(pIdString, "POTATO70", 8) != 0)
            return false;

        uint32_t bundlesize = fp.read<uint32_t>();
        fp.seek(sizeof(uint32_t), SEEK_CUR);
        uint32_t dataoffset = fp.read<uint32_t>();

        fp.seek(32, SEEK_SET);

        dataoffset += 32;

        while (fp.tell() < (long)dataoffset)
        {
            const char* strname = fp.read<char>(256);
            size_t len = strlen(strname);

            char* pHash = fp.read<char>(16);

            BundleEntry bundle;
            fp.seek(sizeof(uint32_t), SEEK_CUR); // Empty
            bundle.uncompressedSize = fp.read<uint32_t>();
            bundle.compressedSize = fp.read<uint32_t>();
            bundle.offset = fp.read<uint32_t>();

#ifdef _DEBUG
            uint32_t date = fp.read<uint32_t>(); // Date
            uint32_t time = fp.read<uint32_t>(); // Time
            fp.seek(16, SEEK_CUR); // Zero
            uint32_t crc = fp.read<uint32_t>(); // CRC
#else
            fp.seek(28, SEEK_CUR); // Date
#endif
            uint32_t compression = fp.read<uint32_t>();
            bundle.compression = (uint16_t)compression;

            // only want .w2mesh, .w2l, .w2w, .xbm, .1.buffer, .wter, .w2mi files
            if ((strcmp(strname + len - 6, "w2mesh") == 0) ||
                (strcmp(strname + len - 3, "w2l") == 0) ||
                (strcmp(strname + len - 3, "w2w") == 0) ||
                (strcmp(strname + len - 3, "xbm") == 0) ||
                (strcmp(strname + len - 6, "buffer") == 0) ||
                (strcmp(strname + len - 4, "w2mi") == 0) ||
                (strcmp(strname + len - 5, "w2ter") == 0))
            {
                const auto itl = Lookup.find(strname);
                if (itl != Lookup.end())
                {
                    const auto it = RawPathHashes.find(itl->second);
                    if (it != RawPathHashes.end())
                    {
                        it->second.compressedSize = bundle.compressedSize;
                        it->second.compression = bundle.compression;
                        it->second.index = index;
                        it->second.offset = bundle.offset;
                        it->second.uncompressedSize = bundle.uncompressedSize;

#ifdef _DEBUG
                        std::cout << "Patching " << strname << std::endl;
#endif
                    }
                }
            }
        }

        return true;
    }

    bool CreateTableOfContentsFromBundles()
    {
        if (!std::filesystem::exists(Witcher3ExePath))
            return false;

        if (std::filesystem::exists("rawpathhashes.bin"))
        {
            std::filesystem::remove("rawpathhashes.bin");
        }

        std::filesystem::path exePath = Witcher3ExePath;
        exePath = exePath.parent_path().parent_path();
        std::filesystem::path dlc = exePath;
        dlc.append("DLC");
        std::filesystem::path content = exePath;
        content.append("content");

        std::vector<std::string> bundleNames;

        // get all content directories

        // dlc takes next priority
        for (const auto& entry : std::filesystem::directory_iterator(dlc))
        {
            if (entry.is_directory())
            {
                // now get the bundle files in here!
                // want the content/bundles directory
                std::filesystem::path bundleDir = entry.path();
                bundleDir.append("content").append("bundles");

                for (const auto& bundleEntry : std::filesystem::directory_iterator(bundleDir))
                {
                    if (bundleEntry.path().extension() == ".bundle")
                    {
                        uint32_t index = (uint32_t)bundleNames.size();

                        std::filesystem::path rpath = std::filesystem::proximate(bundleEntry, exePath);
                        bundleNames.push_back(rpath.string());

#ifdef _DEBUG
                        std::cout << rpath.string() << " added at index " << index << std::endl;
#endif

                        // got a bundle to load!
                        LoadBundle(bundleEntry.path().string().c_str(), index);
                    }
                }
            }
        }

        // then the regular content directories
        for (const auto& entry : std::filesystem::directory_iterator(content))
        {
            if (entry.is_directory())
            {
                // is this a content or patch directory?
                if (entry.path().filename().string().find("content") != std::string::npos)                    
                {
                    std::filesystem::path bundleDir = entry.path();
                    bundleDir.append("bundles");

                    if (!std::filesystem::exists(bundleDir))
                        continue;

                    // now get the bundle files in here!
                    for (const auto& bundleEntry : std::filesystem::directory_iterator(bundleDir))
                    {
                        if ((bundleEntry.path().string().ends_with("blob.bundle")) ||
                            (bundleEntry.path().string().ends_with("buffers.bundle")) ||
                            (bundleEntry.path().string().ends_with("buffers0.bundle")) ||
                            (bundleEntry.path().string().ends_with("buffers1.bundle")) ||
                            (bundleEntry.path().string().ends_with("startup.bundle")) ||
                            (bundleEntry.path().string().ends_with("runtime.bundle")) ||
                            (bundleEntry.path().string().ends_with("patch.bundle")))
                        {                            
                            uint32_t index = (uint32_t)bundleNames.size();

                            std::filesystem::path rpath = std::filesystem::proximate(bundleEntry, exePath);
                            bundleNames.push_back(rpath.string());
#ifdef _DEBUG
                            std::cout << rpath.string() << " added at index " << index << std::endl;
#endif

                            // got a bundle to load!
                            LoadBundle(bundleEntry.path().string().c_str(), index);
                        }
                    }
                }
            }
        }

        // patches take first priority
        for (const auto& entry : std::filesystem::directory_iterator(content))
        {
            if (entry.is_directory())
            {
                // is this a patch directory?
                if (entry.path().filename().string().find("patch") != std::string::npos)
                {
                    std::filesystem::path bundleDir = entry.path();
                    bundleDir.append("bundles");

                    if (!std::filesystem::exists(bundleDir))
                        continue;

                    // now get the bundle files in here!
                    for (const auto& bundleEntry : std::filesystem::directory_iterator(bundleDir))
                    {
                        if ((bundleEntry.path().string().ends_with("blob.bundle")) ||
                            (bundleEntry.path().string().ends_with("buffers.bundle")) ||
                            (bundleEntry.path().string().ends_with("buffers0.bundle")) ||
                            (bundleEntry.path().string().ends_with("buffers1.bundle")) ||
                            (bundleEntry.path().string().ends_with("startup.bundle")) ||
                            (bundleEntry.path().string().ends_with("runtime.bundle")) ||
                            (bundleEntry.path().string().ends_with("patch.bundle")))
                        {
                            uint32_t index = (uint32_t)bundleNames.size();

                            std::filesystem::path rpath = std::filesystem::proximate(bundleEntry, exePath);
                            bundleNames.push_back(rpath.string());
#ifdef _DEBUG
                            std::cout << rpath.string() << " added at index " << index << std::endl;
#endif

                            // got a bundle to load!
                            OverrideBundle(bundleEntry.path().string().c_str(), index);
                        }
                    }
                }
            }
        }

        // dump
        FILE* fp = nullptr;
        fopen_s(&fp, "rawpathhashes.bin", "wb");
        if (fp != nullptr)
        {
            uint32_t nLookupEntries = (uint32_t)Lookup.size();
            fwrite(&nLookupEntries, sizeof(uint32_t), 1, fp);

            const uint8_t zero = 0;

            for (auto& it : Lookup)
            {
                size_t sz = it.first.length();
                fwrite(it.first.c_str(), sz, 1, fp);
                fwrite(&zero, sizeof(uint8_t), 1, fp);
                fwrite(it.second.c_str(), HASH_SIZE, 1, fp);
            }

            uint32_t nBundleFolders = (uint32_t)bundleNames.size();
            fwrite(&nBundleFolders, sizeof(uint32_t), 1, fp);

            for (auto& it : bundleNames)
            {
                size_t sz = it.length();
                fwrite(it.c_str(), sz, 1, fp);
                fwrite(&zero, sizeof(uint8_t), 1, fp);
            }

            uint32_t nElements = (uint32_t)RawPathHashes.size();
            fwrite(&nElements, sizeof(uint32_t), 1, fp);

            for (auto& it : RawPathHashes)
            {
                fwrite(it.first.c_str(), HASH_SIZE, 1, fp);
                fwrite(&(it.second.offset), sizeof(uint32_t), 1, fp);
                fwrite(&(it.second.uncompressedSize), sizeof(uint32_t), 1, fp);
                fwrite(&(it.second.compressedSize), sizeof(uint32_t), 1, fp);
                fwrite(&(it.second.index), sizeof(uint16_t), 1, fp);
                fwrite(&(it.second.compression), sizeof(uint16_t), 1, fp);
            }
            fclose(fp);
        }
        return true;
    }
#endif

    bool GetFileInfo(const std::string& filename, BundleEntry& bundle)
    {
        std::string fname = filename;
        std::replace(fname.begin(), fname.end(), '/', '\\');

        auto fit = Lookup.find(fname);
        if (fit != Lookup.end())
        {
            auto it = RawPathHashes.find(fit->second);
            if (it != RawPathHashes.end())
            {
                bundle = it->second;
                return true;
            }
        }
        return false;
    }

    std::string GetBundlePath(uint32_t index)
    {
        std::string path;

        if (index < (uint32_t)BundleNames.size())
        {
            std::filesystem::path exePath = Witcher3ExePath;
            exePath = exePath.parent_path().parent_path();

            exePath.append(BundleNames[index]);
            path = exePath.string();
        }

        return path;
    }

    bool LoadRawPathHashes(const std::string& filename)
    {
        WolvenEngine::File fp;
        if (!fp.open(filename.c_str(), "rb"))
            return false;

        BundleNames.clear();
        Lookup.clear();
        RawPathHashes.clear();

        uint32_t nLookupEntries = fp.read<uint32_t>();

        for (uint32_t i = 0; i < nLookupEntries; ++i)
        {
            std::string path = fp.getBuffer<const char*>();
            long sz = (long)path.length() + 1; // plus the null terminator that was added
            fp.seek(sz, SEEK_CUR);

            char* p = fp.read<char>(HASH_SIZE);
            std::string hash;
            hash.assign(p, HASH_SIZE);

            Lookup.insert(std::pair<std::string, std::string>(path, hash));
        }

        uint32_t nBundleNames = fp.read<uint32_t>();

        for (uint32_t i = 0; i < nBundleNames; ++i)
        {
            std::string path = fp.getBuffer<const char*>();
            long sz = (long)path.length() + 1; // plus the null terminator that was added

            BundleNames.push_back(path);
            fp.seek(sz, SEEK_CUR);
        }

        uint32_t nElements = fp.read<uint32_t>();

        for (uint32_t i = 0; i < nElements; ++i)
        {
            char* p = fp.read<char>(HASH_SIZE);
            std::string hash;
            hash.assign(p, HASH_SIZE);

            BundleEntry bundle;
            bundle.offset = fp.read<uint32_t>();
            bundle.uncompressedSize = fp.read<uint32_t>();
            bundle.compressedSize = fp.read<uint32_t>();
            bundle.index = fp.read<uint16_t>();
            bundle.compression = fp.read<uint16_t>();

            RawPathHashes.insert(std::pair<std::string, BundleEntry>(hash, bundle));
        }

        return true;
    }
}