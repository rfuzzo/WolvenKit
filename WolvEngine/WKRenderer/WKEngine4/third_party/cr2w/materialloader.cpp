#include "materialloader.h"
#include "cr2w.h"

#ifdef USE_GAME_BUNDLES
#include "bundlemanager.h"
#endif

namespace WolvenEngine
{
    bool loadMaterial(const std::string& filename, std::string& diffuseTexture, std::string& normalTexture)
    {
        char lastChar = filename[filename.length() - 1];
        if (lastChar == 'i')
        {
            // w2mi
            WolvenEngine::File fp;
#ifdef USE_GAME_BUNDLES
            if(!WolvenEngine::BundleManager::instance()->open(filename.c_str(), fp))
            {
                return false;
            }
#else
            if (!fp.open(filename.c_str(), "rb"))
                return false;
#endif

            return readW2MI(fp, diffuseTexture, normalTexture);
        }

        return false; // just use a default
    }
}