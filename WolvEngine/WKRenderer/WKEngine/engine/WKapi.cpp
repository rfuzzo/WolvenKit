#include "wkengine.h"
#include "resourcepath.h"
#include "vk_engine.h"
#include <iostream>
#include <thread>

static std::string Asset;

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

WolvenEngine::VulkanEngine* engine = nullptr;
LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
    if (engine != nullptr)
    {
        engine->handleMessages(hWnd, uMsg, wParam, lParam);
    }
    return (DefWindowProc(hWnd, uMsg, wParam, lParam));
}

void renderThread(HMODULE hInstance)
{
    engine = new WolvenEngine::VulkanEngine();
    engine->setupWindow(hInstance, WndProc);
    engine->init();
    engine->load(Asset);
    engine->run();
    engine->cleanup();
    delete(engine);
}

void WKRun(HMODULE hInstance)
{
    std::thread t(renderThread, hInstance);
    t.join();
}
