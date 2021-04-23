#include "bundlemanager.h"
#include "bundledictionary.h"

namespace WolvenEngine
{
    BundleManager* BundleManager::s_instance = nullptr;

    BundleManager* BundleManager::instance()
    {
        if (!s_instance)
            s_instance = new BundleManager();

        return s_instance;
    }

    BundleManager::BundleManager()
    {

    }

    BundleManager::~BundleManager()
    {
        if (s_instance)
            delete s_instance;
    }

    bool BundleManager::open(const char* filename, File& fp)
    {
        WolvenEngine::BundleEntry entry;
        if (!WolvenEngine::GetFileInfo(filename, entry))
        {
            return false;
        }

        Bundle* archive = nullptr;

        const auto& it = _bundles.find(entry.index);
        if (it != _bundles.end())
        {
            archive = &(it->second);
        }
        else
        {
            // add it!
            Bundle a;

            std::pair<std::unordered_map<uint16_t, Bundle>::iterator, bool> p = _bundles.insert(std::pair<uint16_t, Bundle>(entry.index, a));
            archive = &(p.first->second);

            std::string bundlePath = WolvenEngine::GetBundlePath(entry.index);
            if (!archive->open(bundlePath.c_str()))
                return false;
        }

        return archive->load(entry.offset, entry.compressedSize, entry.uncompressedSize, entry.compression, fp);
    }
}