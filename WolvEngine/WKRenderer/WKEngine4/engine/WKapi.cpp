#include "wkengine.h"
#include "resourcepath.h"
#include "cr2w/bundledictionary.h"
#include "vk_engine.h"
#include <iostream>
#include <thread>

static std::string Asset;

void SetWitcherExePath(const char* exePath)
{
#ifdef _DEBUG
    std::cout << "Witcher 3 exe located at: " << exePath << "\n";
#endif
    WolvenEngine::SetWitcherExePath(exePath);
}

void AddResourcePath(const char* resourcePath)
{
#ifdef _DEBUG
    std::cout << "adding " << resourcePath << " to search path\n";
#endif
    WolvenEngine::AddResourcePath(resourcePath);
}

bool LoadAsset(const char* asset)
{
    if (asset && strlen(asset) > 0)
    {
#ifdef _DEBUG
        std::cout << "loading " << asset << "\n";
#endif
        Asset = asset;
        return true;
    }

    return false;
}

bool ImportAsset(const char* asset)
{
    if (asset && strlen(asset) > 0)
    {
#ifdef _DEBUG
        std::cout << "importing " << asset << "\n";
#endif
        Asset = asset;
        return true;
    }

    return false;
}

VulkanEngine* engine = nullptr;
void renderThread(HMODULE hInstance, HWND hWnd, uint32_t width, uint32_t height)
{
    engine = new VulkanEngine();
    engine->init(hInstance, hWnd, width, height, Asset);
    engine->run();
    delete(engine);
}

void WKRun(HMODULE hInstance, HWND hWnd, uint32_t width, uint32_t height)
{
    std::thread t(renderThread, hInstance, hWnd, width, height);
    t.join();
}