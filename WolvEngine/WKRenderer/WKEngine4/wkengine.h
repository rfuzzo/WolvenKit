#pragma once

#ifdef WKENGINE_EXPORTS
#include <windows.h>
#define WKENGINE_API extern __declspec(dllexport)
#else
#include <libloaderapi.h>
#include <windef.h>
#define WKENGINE_API extern __declspec(dllimport)
#endif

extern "C"
{
    WKENGINE_API void SetWitcherExePath(const char* exePath);
    WKENGINE_API void AddResourcePath(const char* resourcePath);
    WKENGINE_API bool LoadAsset(const char* assetPath);
    WKENGINE_API bool ImportAsset(const char* assetPath);
    WKENGINE_API void WKRun(HMODULE hInstance, HWND hWnd, unsigned int width, unsigned int height);
}