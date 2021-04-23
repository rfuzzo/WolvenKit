#pragma once

#ifdef WKENGINE_EXPORTS
#include <windows.h>
#define WKENGINE_API extern __declspec(dllexport)
#else
#include <libloaderapi.h>
#define WKENGINE_API extern __declspec(dllimport)
#endif

WKENGINE_API void AddResourcePath(const char* resourcePath);
WKENGINE_API bool LoadAsset(const char* assetPath);
WKENGINE_API void WKRun(HMODULE hInstance);
