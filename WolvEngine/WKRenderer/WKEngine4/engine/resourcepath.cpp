#include "resourcepath.h"

namespace WolvenEngine
{
    std::stack<std::string> resourcePaths;

    void AddResourcePath(const char* resourcePath)
    {
        if (resourcePath)
        {
            WolvenEngine::resourcePaths.emplace(resourcePath);
        }
    }
}