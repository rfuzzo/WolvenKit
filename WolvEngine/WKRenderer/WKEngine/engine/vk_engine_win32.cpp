#include "vk_engine.h"
#include "keycodes.hpp"

namespace WolvenEngine
{
	HWND VulkanEngine::setupWindow(HINSTANCE hinstance, WNDPROC wndproc)
	{
        _windowInstance = hinstance;

        WNDCLASSEX wndClass;

        wndClass.cbSize = sizeof(WNDCLASSEX);
        wndClass.style = CS_HREDRAW | CS_VREDRAW;
        wndClass.lpfnWndProc = wndproc;
        wndClass.cbClsExtra = 0;
        wndClass.cbWndExtra = 0;
        wndClass.hInstance = hinstance;
        wndClass.hIcon = LoadIcon(NULL, IDI_APPLICATION);
        wndClass.hCursor = LoadCursor(NULL, IDC_ARROW);
        wndClass.hbrBackground = (HBRUSH)GetStockObject(BLACK_BRUSH);
        wndClass.lpszMenuName = NULL;
        wndClass.lpszClassName = name.c_str();
        wndClass.hIconSm = LoadIcon(NULL, IDI_WINLOGO);

        if (!RegisterClassEx(&wndClass))
        {
            std::cout << "Could not register window class!\n";
            fflush(stdout);
            exit(1);
        }

        int screenWidth = GetSystemMetrics(SM_CXSCREEN);
        int screenHeight = GetSystemMetrics(SM_CYSCREEN);

        if (settings.fullscreen)
        {
            if ((_windowExtent.width != (uint32_t)screenWidth) && (_windowExtent.height != (uint32_t)screenHeight))
            {
                DEVMODE dmScreenSettings;
                memset(&dmScreenSettings, 0, sizeof(dmScreenSettings));
                dmScreenSettings.dmSize = sizeof(dmScreenSettings);
                dmScreenSettings.dmPelsWidth = _windowExtent.width;
                dmScreenSettings.dmPelsHeight = _windowExtent.height;
                dmScreenSettings.dmBitsPerPel = 32;
                dmScreenSettings.dmFields = DM_BITSPERPEL | DM_PELSWIDTH | DM_PELSHEIGHT;
                if (ChangeDisplaySettings(&dmScreenSettings, CDS_FULLSCREEN) != DISP_CHANGE_SUCCESSFUL)
                {
                    if (MessageBox(NULL, "Fullscreen Mode not supported!\n Switch to window mode?", "Error", MB_YESNO | MB_ICONEXCLAMATION) == IDYES)
                    {
                        settings.fullscreen = false;
                    }
                    else
                    {
                        return nullptr;
                    }
                }
                screenWidth = _windowExtent.width;
                screenHeight = _windowExtent.height;
            }

        }

        DWORD dwExStyle;
        DWORD dwStyle;

        if (settings.fullscreen)
        {
            dwExStyle = WS_EX_APPWINDOW;
            dwStyle = WS_POPUP | WS_CLIPSIBLINGS | WS_CLIPCHILDREN;
        }
        else
        {
            dwExStyle = WS_EX_APPWINDOW | WS_EX_WINDOWEDGE;
            dwStyle = WS_OVERLAPPEDWINDOW | WS_CLIPSIBLINGS | WS_CLIPCHILDREN;
        }

        RECT windowRect;
        windowRect.left = 0L;
        windowRect.top = 0L;
        windowRect.right = settings.fullscreen ? (long)screenWidth : (long)_windowExtent.width;
        windowRect.bottom = settings.fullscreen ? (long)screenHeight : (long)_windowExtent.height;

        AdjustWindowRectEx(&windowRect, dwStyle, FALSE, dwExStyle);

        std::string windowTitle = getWindowTitle();
        _window = CreateWindowEx(0,
            name.c_str(),
            windowTitle.c_str(),
            dwStyle | WS_CLIPSIBLINGS | WS_CLIPCHILDREN,
            0,
            0,
            windowRect.right - windowRect.left,
            windowRect.bottom - windowRect.top,
            NULL,
            NULL,
            hinstance,
            NULL);

        if (!settings.fullscreen)
        {
            // Center on screen
            uint32_t x = (GetSystemMetrics(SM_CXSCREEN) - windowRect.right) / 2;
            uint32_t y = (GetSystemMetrics(SM_CYSCREEN) - windowRect.bottom) / 2;
            SetWindowPos(_window, 0, x, y, 0, 0, SWP_NOZORDER | SWP_NOSIZE);
        }

        if (!_window)
        {
            printf("Could not create window!\n");
            fflush(stdout);
            return nullptr;
        }

        ShowWindow(_window, SW_SHOW);
        SetForegroundWindow(_window);
        SetFocus(_window);

        return _window;
	}

	void VulkanEngine::handleMessages(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
	{
        switch (uMsg)
        {
        case WM_CLOSE:
            prepared = false;
            DestroyWindow(hWnd);
            PostQuitMessage(0);
            break;
        case WM_PAINT:
            ValidateRect(_window, NULL);
            break;
        case WM_KEYDOWN:
            switch (wParam)
            {
            case KEY_P:
                paused = !paused;
                break;
            case KEY_F1:
                if (settings.overlay) {
                    UIOverlay.visible = !UIOverlay.visible;
                }
                break;
            case KEY_ESCAPE:
                PostQuitMessage(0);
                break;
            }

            if (_camera.type == Camera::firstperson)
            {
                switch (wParam)
                {
                case KEY_W:
                    _camera.keys.up = true;
                    break;
                case KEY_S:
                    _camera.keys.down = true;
                    break;
                case KEY_A:
                    _camera.keys.left = true;
                    break;
                case KEY_D:
                    _camera.keys.right = true;
                    break;
                }
            }

            //keyPressed((uint32_t)wParam);
            break;
        case WM_KEYUP:
            if (_camera.type == Camera::firstperson)
            {
                switch (wParam)
                {
                case KEY_W:
                    _camera.keys.up = false;
                    break;
                case KEY_S:
                    _camera.keys.down = false;
                    break;
                case KEY_A:
                    _camera.keys.left = false;
                    break;
                case KEY_D:
                    _camera.keys.right = false;
                    break;
                }
            }
            break;
        case WM_LBUTTONDOWN:
            mousePos = glm::vec2((float)LOWORD(lParam), (float)HIWORD(lParam));
            mouseButtons.left = true;
            break;
        case WM_RBUTTONDOWN:
            mousePos = glm::vec2((float)LOWORD(lParam), (float)HIWORD(lParam));
            mouseButtons.right = true;
            break;
        case WM_MBUTTONDOWN:
            mousePos = glm::vec2((float)LOWORD(lParam), (float)HIWORD(lParam));
            mouseButtons.middle = true;
            break;
        case WM_LBUTTONUP:
            mouseButtons.left = false;
            break;
        case WM_RBUTTONUP:
            mouseButtons.right = false;
            break;
        case WM_MBUTTONUP:
            mouseButtons.middle = false;
            break;
        case WM_MOUSEWHEEL:
        {
            short wheelDelta = GET_WHEEL_DELTA_WPARAM(wParam);
            _camera.translate(glm::vec3(0.0f, 0.0f, (float)wheelDelta * 0.005f));
            break;
        }
        case WM_MOUSEMOVE:
        {
            handleMouseMove(LOWORD(lParam), HIWORD(lParam));
            break;
        }
        case WM_SIZE:
            if ((prepared) && (wParam != SIZE_MINIMIZED))
            {
                if ((resizing) || ((wParam == SIZE_MAXIMIZED) || (wParam == SIZE_RESTORED)))
                {
                    destWidth = LOWORD(lParam);
                    destHeight = HIWORD(lParam);
                    windowResize();
                }
            }
            break;
        case WM_GETMINMAXINFO:
        {
            LPMINMAXINFO minMaxInfo = (LPMINMAXINFO)lParam;
            minMaxInfo->ptMinTrackSize.x = 64;
            minMaxInfo->ptMinTrackSize.y = 64;
            break;
        }
        case WM_ENTERSIZEMOVE:
            resizing = true;
            break;
        case WM_EXITSIZEMOVE:
            resizing = false;
            break;
        }
	}

    void VulkanEngine::windowResize()
    {
		/*
        if (!prepared)
        {
            return;
        }
        prepared = false;
        resized = true;

        // Ensure all operations on the device have been finished before destroying resources
        vkDeviceWaitIdle(_device);

        // Recreate swap chain
        _windowExtent.width = destWidth;
		_windowExtent.height = destHeight;
        setupSwapChain();

        // Recreate the frame buffers
        vkDestroyImageView(_device, _depthImageView, nullptr);
		vmaDestroyImage(_allocator, _depthImage._image, _depthImage._allocation);
        
		setupDepthStencil();

        for (uint32_t i = 0; i < _framebuffers.size(); i++) {
            vkDestroyFramebuffer(_device, _framebuffers[i], nullptr);
        }
		init_framebuffers();

        if ((_windowExtent.width > 0.0f) && (_windowExtent.height > 0.0f)) {
            if (settings.overlay) {
                UIOverlay.resize(_windowExtent.width, _windowExtent.height);
            }
        }

        // Command buffers need to be recreated as they may store
        // references to the recreated frame buffer
        for (int i = 0; i < FRAME_OVERLAP; i++) {
			vkDestroyCommandPool(_device, _frames[i]._commandPool, nullptr);
        }

        createCommandBuffers();
        buildCommandBuffers();

        vkDeviceWaitIdle(_device);

        if ((_windowExtent.width > 0.0f) && (_windowExtent.height > 0.0f)) {
            camera.updateAspectRatio((float)_windowExtent.width / (float)_windowExtent.height);
        }

        prepared = true;
		*/

		prepared = true;
    }

    void VulkanEngine::handleMouseMove(int32_t x, int32_t y)
    {
        int32_t dx = (int32_t)mousePos.x - x;
        int32_t dy = (int32_t)mousePos.y - y;

        bool handled = false;

        if (settings.overlay) {
            ImGuiIO& io = ImGui::GetIO();
            handled = io.WantCaptureMouse;
        }

        if (handled) {
            mousePos = glm::vec2((float)x, (float)y);
            return;
        }

        if (mouseButtons.left) {
            _camera.rotate(glm::vec3(dy * _camera._rotationSpeed, -dx * _camera._rotationSpeed, 0.0f));
        }
        if (mouseButtons.right) {
            _camera.translate(glm::vec3(-0.0f, 0.0f, dy * .005f));
        }
        if (mouseButtons.middle) {
            _camera.translate(glm::vec3(-dx * 0.01f, -dy * 0.01f, 0.0f));
        }
        mousePos = glm::vec2((float)x, (float)y);
    }
}