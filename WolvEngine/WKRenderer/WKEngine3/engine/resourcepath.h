#pragma once

#include <stack>
#include <string>

namespace WolvenEngine
{
    extern std::stack<std::string> resourcePaths;
    void AddResourcePath(const char* resourcePath);
}
