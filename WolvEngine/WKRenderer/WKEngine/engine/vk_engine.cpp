#define _USE_MATH_DEFINES
#include <cmath>

#include "vk_engine.h"

#include <vk_types.h>
#include <vk_initializers.h>
#include "VulkanTools.h"

#include "VkBootstrap.h"

#include <iostream>
#include <fstream>

#include "vk_textures.h"

#define VMA_IMPLEMENTATION
#include "vk_mem_alloc.h"


constexpr bool bUseValidationLayers = true;

//we want to immediately abort when there is an error. In normal engines this would give an error message to the user, or perform a dump of state.
using namespace std;
#define VK_CHECK(x)                                                 \
	do                                                              \
	{                                                               \
		VkResult err = x;                                           \
		if (err)                                                    \
		{                                                           \
			std::cout <<"Detected Vulkan error: " << err << std::endl; \
			abort();                                                \
		}                                                           \
	} while (0)

namespace WolvenEngine
{
	VulkanEngine::VulkanEngine()
	{
        _camera.type = Camera::CameraType::firstperson;
		_camera.setPosition(glm::vec3(0.0f, -6.0f, -10.f));
        _camera.setRotationSpeed(0.5f);
        _camera.setMovementSpeed(100.0f);
        _camera.setPerspective(60.0f, (float_t)_windowExtent.width / (float_t)_windowExtent.height, 0.001f, 100000.0f);
        settings.overlay = true;

        _world = glm::rotate(glm::mat4(1.0f), (float_t)M_PI_2, glm::vec3(1.0f, 0, 0));
        glm::scale(_world, glm::vec3(1.0f, -1.0f, 1.0f));

		_sceneParameters.ambientColor = glm::vec4(0, 0, 0.1f,1.0f);
		_sceneParameters.sunlightDirection = glm::vec4(0,-1.0f, 0.0f,1.0f);

        loadPathHashes("pathhashes.csv", m_pathHashes);

#ifdef _DEBUG
		settings.validation = true;
		setupConsole("Vulkan validation output");
#else
		settings.validation = false;
#endif
		setupDPIAwareness();
	}

	VulkanEngine::~VulkanEngine()
	{

	}

	void VulkanEngine::setupConsole(std::string title)
	{
        AllocConsole();
        AttachConsole(GetCurrentProcessId());
        FILE* stream;
        freopen_s(&stream, "CONOUT$", "w+", stdout);
        freopen_s(&stream, "CONOUT$", "w+", stderr);
        SetConsoleTitle(TEXT(title.c_str()));
	}

	void VulkanEngine::setupDPIAwareness()
	{
        typedef HRESULT* (__stdcall* SetProcessDpiAwarenessFunc)(PROCESS_DPI_AWARENESS);

        HMODULE shCore = LoadLibraryA("Shcore.dll");
        if (shCore)
        {
            SetProcessDpiAwarenessFunc setProcessDpiAwareness =
                (SetProcessDpiAwarenessFunc)GetProcAddress(shCore, "SetProcessDpiAwareness");

            if (setProcessDpiAwareness != nullptr)
            {
                setProcessDpiAwareness(PROCESS_PER_MONITOR_DPI_AWARE);
            }

            FreeLibrary(shCore);
        }
	}

	void VulkanEngine::init()
	{
		init_vulkan();

		init_swapchain();

		init_default_renderpass();

		init_framebuffers();

		init_commands();

		init_sync_structures();

		init_descriptors();

		init_pipelines();

        if (settings.overlay) {
            UIOverlay._device = _device;
			UIOverlay._memoryProperties = _memoryProperties;
            UIOverlay.shaders = {
                load_shader("../../runtime/uioverlay.vert.spv", VK_SHADER_STAGE_VERTEX_BIT),
				load_shader("../../runtime/uioverlay.frag.spv", VK_SHADER_STAGE_FRAGMENT_BIT),
            };
            //UIOverlay.prepareResources(_graphicsQueue, _frames[0]._commandPool);
			UIOverlay.prepareResources(_graphicsQueue, _uiCommandPool);
            UIOverlay.preparePipeline(_renderPass);
        }

		//everything went fine
		_isInitialized = true;
		prepared = true;
	}

	void VulkanEngine::cleanup()
	{	
		if (_isInitialized) {
		
			//make sure the gpu has stopped doing its things
			vkDeviceWaitIdle(_device);

			_mainDeletionQueue.flush();

            if (settings.overlay) {
                UIOverlay.freeResources();
            }

			vkDestroySurfaceKHR(_instance, _surface, nullptr);

			vkDestroyDevice(_device, nullptr);
#ifdef _DEBUG
			vkb::destroy_debug_utils_messenger(_instance, _debug_messenger);
#endif
			vkDestroyInstance(_instance, nullptr);
		}
	}

	void VulkanEngine::draw()
	{	
		//wait until the gpu has finished rendering the last frame. Timeout of 1 second
		VK_CHECK(vkWaitForFences(_device, 1, &get_current_frame()._renderFence, true, 1000000000));
		VK_CHECK(vkResetFences(_device, 1, &get_current_frame()._renderFence));

		//now that we are sure that the commands finished executing, we can safely reset the command buffer to begin recording again.
		VK_CHECK(vkResetCommandBuffer(get_current_frame()._mainCommandBuffer, 0));

		//request image from the swapchain
		uint32_t swapchainImageIndex;
		VK_CHECK(vkAcquireNextImageKHR(_device, _swapchain, 1000000000, get_current_frame()._presentSemaphore, nullptr, &swapchainImageIndex));

		//naming it cmd for shorter writing
		VkCommandBuffer cmd = get_current_frame()._mainCommandBuffer;

		//begin the command buffer recording. We will use this command buffer exactly once, so we want to let vulkan know that
		VkCommandBufferBeginInfo cmdBeginInfo = vkinit::command_buffer_begin_info(VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT);

		VK_CHECK(vkBeginCommandBuffer(cmd, &cmdBeginInfo));

		VkClearValue clearValue;
		clearValue.color = { { 0.0f, 0.0f, 0.1f, 1.0f } };

		//clear depth at 1
		VkClearValue depthClear;
		depthClear.depthStencil.depth = 1.f;

		//start the main renderpass. 
		//We will use the clear color from above, and the framebuffer of the index the swapchain gave us
		VkRenderPassBeginInfo rpInfo = vkinit::renderpass_begin_info(_renderPass, _windowExtent, _framebuffers[swapchainImageIndex]);

		//connect clear values
		rpInfo.clearValueCount = 2;

		VkClearValue clearValues[] = { clearValue, depthClear };

		rpInfo.pClearValues = &clearValues[0];
	
		vkCmdBeginRenderPass(cmd, &rpInfo, VK_SUBPASS_CONTENTS_INLINE);

		draw_objects(cmd);
		drawUI(cmd);
		//finalize the render pass
		vkCmdEndRenderPass(cmd);
		//finalize the command buffer (we can no longer add commands, but it can now be executed)
		VK_CHECK(vkEndCommandBuffer(cmd));

		//prepare the submission to the queue. 
		//we want to wait on the _presentSemaphore, as that semaphore is signaled when the swapchain is ready
		//we will signal the _renderSemaphore, to signal that rendering has finished

		VkSubmitInfo submit = vkinit::submit_info(&cmd);
		VkPipelineStageFlags waitStage = VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;

		submit.pWaitDstStageMask = &waitStage;

		submit.waitSemaphoreCount = 1;
		submit.pWaitSemaphores = &get_current_frame()._presentSemaphore;

		submit.signalSemaphoreCount = 1;
		submit.pSignalSemaphores = &get_current_frame()._renderSemaphore;

		//submit command buffer to the queue and execute it.
		// _renderFence will now block until the graphic commands finish execution
		VK_CHECK(vkQueueSubmit(_graphicsQueue, 1, &submit, get_current_frame()._renderFence));

		//prepare present
		// this will put the image we just rendered to into the visible window.
		// we want to wait on the _renderSemaphore for that, 
		// as its necessary that drawing commands have finished before the image is displayed to the user
		VkPresentInfoKHR presentInfo = vkinit::present_info();

		presentInfo.pSwapchains = &_swapchain;
		presentInfo.swapchainCount = 1;

		presentInfo.pWaitSemaphores = &get_current_frame()._renderSemaphore;
		presentInfo.waitSemaphoreCount = 1;

		presentInfo.pImageIndices = &swapchainImageIndex;

		VK_CHECK(vkQueuePresentKHR(_graphicsQueue, &presentInfo));

		updateOverlay();

		//increase the number of frames drawn
		_frameNumber++;
	}

	void VulkanEngine::run()
	{
        destWidth = _windowExtent.width;
        destHeight = _windowExtent.height;
        lastTimestamp = std::chrono::high_resolution_clock::now();
        MSG msg;
        bool quitMessageReceived = false;
        while (!quitMessageReceived) {
            while (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE)) {
                TranslateMessage(&msg);
                DispatchMessage(&msg);
                if (msg.message == WM_QUIT) {
                    quitMessageReceived = true;
                    break;
                }
            }
            if (prepared && !IsIconic(_window)) {
                nextFrame();
            }
        }
	}
	void VulkanEngine::processRenderQueue()
	{
		RenderMessage m;
		if (_renderQueue.try_dequeue(m))
		{
			switch (m._type)
			{
#ifdef THREADING_PART2
            case RenderMessage::MessageType::AddMesh:
                render_addMesh(m._meshName, m._material, m._matrix);
                break;
            case RenderMessage::MessageType::AddTerrain:
                render_addTerrain(m._meshName, m._material, m._matrix);
                break;
#else
			case RenderMessage::MessageType::AddMesh:
				addMesh(m._meshPath, m._matrix);
				break;
            case RenderMessage::MessageType::AddTerrain:
                addTerrain(m._meshPath, m._tileRes, m._maxElevation, m._minElevation, m._tileSize, m._matrix, m._index);
                break;
#endif
			default:
				break;
			}
		}
	}

    void VulkanEngine::nextFrame()
    {
		processRenderQueue();

        auto tStart = std::chrono::high_resolution_clock::now();

        draw();
        //updateOverlay();
        
		frameCounter++;
        auto tEnd = std::chrono::high_resolution_clock::now();
        auto tDiff = std::chrono::duration<double, std::milli>(tEnd - tStart).count();
        frameTimer = (float)tDiff / 1000.0f;
        _camera.update(frameTimer);
		_frustum.update(_camera.matrices.viewproj);

        // Convert to clamped timer value
        if (!paused)
        {
            timer += timerSpeed * frameTimer;
            if (timer > 1.0)
            {
                timer -= 1.0f;
            }
        }
        float fpsTimer = (float)(std::chrono::duration<double, std::milli>(tEnd - lastTimestamp).count());
        if (fpsTimer > 1000.0f)
        {
            lastFPS = static_cast<uint32_t>((float)frameCounter * (1000.0f / fpsTimer));
            frameCounter = 0;
            lastTimestamp = tEnd;
        }
    }

#if 1
    void VulkanEngine::updateOverlay()
    {
        if (!settings.overlay)
            return;

        ImGuiIO& io = ImGui::GetIO();

        io.DisplaySize = ImVec2((float)_windowExtent.width, (float)_windowExtent.height);
        io.DeltaTime = frameTimer;

        io.MousePos = ImVec2(mousePos.x, mousePos.y);
        io.MouseDown[0] = mouseButtons.left;
        io.MouseDown[1] = mouseButtons.right;

        ImGui::NewFrame();

        ImGui::PushStyleVar(ImGuiStyleVar_WindowRounding, 0);
        ImGui::SetNextWindowPos(ImVec2(10, 10));
        ImGui::SetNextWindowSize(ImVec2(0, 0), ImGuiSetCond_FirstUseEver);
        ImGui::Begin(title.c_str(), nullptr, ImGuiWindowFlags_AlwaysAutoResize | ImGuiWindowFlags_NoResize | ImGuiWindowFlags_NoMove);
        ImGui::Text("%.2f ms/frame (%.1d fps)", (1000.0f / lastFPS), lastFPS);
        ImGui::End();
        ImGui::PopStyleVar();
        ImGui::Render();

        if (UIOverlay.update() || UIOverlay.updated) {
            UIOverlay.updated = false;
        }
    }

    void VulkanEngine::drawUI(const VkCommandBuffer commandBuffer)
    {
        if (settings.overlay) {
            const VkViewport viewport = vks::initializers::viewport((float)_windowExtent.width, (float)_windowExtent.height, 0.0f, 1.0f);
            const VkRect2D scissor = vks::initializers::rect2D(_windowExtent.width, _windowExtent.height, 0, 0);
            vkCmdSetViewport(commandBuffer, 0, 1, &viewport);
            vkCmdSetScissor(commandBuffer, 0, 1, &scissor);

            UIOverlay.draw(commandBuffer);
        }
    }
#else
	void VulkanEngine::updateOverlay()
	{

	}

    void VulkanEngine::drawUI(const VkCommandBuffer commandBuffer)
    {
        if (settings.overlay) {
            ImGuiIO& io = ImGui::GetIO();

            io.DisplaySize = ImVec2((float)_windowExtent.width, (float)_windowExtent.height);
            io.DeltaTime = frameTimer;

            io.MousePos = ImVec2(mousePos.x, mousePos.y);
            io.MouseDown[0] = mouseButtons.left;
            io.MouseDown[1] = mouseButtons.right;

            ImGui::NewFrame();

            ImGui::PushStyleVar(ImGuiStyleVar_WindowRounding, 0);
            ImGui::SetNextWindowPos(ImVec2(10, 10));
            ImGui::SetNextWindowSize(ImVec2(0, 0), ImGuiSetCond_FirstUseEver);
            ImGui::Begin("Wolven Engine", nullptr, ImGuiWindowFlags_AlwaysAutoResize | ImGuiWindowFlags_NoResize | ImGuiWindowFlags_NoMove);
            //ImGui::TextUnformatted(title.c_str());
            ImGui::Text("%.2f ms/frame (%.1d fps)", (1000.0f / lastFPS), lastFPS);
            ImGui::End();
            ImGui::PopStyleVar();
            ImGui::Render();

			if (UIOverlay.update() || UIOverlay.updated)
			{
				UIOverlay.updated = false;
			}

            const VkViewport viewport = vks::initializers::viewport((float)_windowExtent.width, (float)_windowExtent.height, 0.0f, 1.0f);
            const VkRect2D scissor = vks::initializers::rect2D(_windowExtent.width, _windowExtent.height, 0, 0);
            vkCmdSetViewport(commandBuffer, 0, 1, &viewport);
            vkCmdSetScissor(commandBuffer, 0, 1, &scissor);

            UIOverlay.draw(commandBuffer);
        }
    }
#endif

	FrameData& VulkanEngine::get_current_frame()
	{
		return _frames[_frameNumber % FRAME_OVERLAP];
	}

	FrameData& VulkanEngine::get_last_frame()
	{
		return _frames[(_frameNumber -1) % 2];
	}

    std::string VulkanEngine::getWindowTitle()
    {
        return title;
    }

	void VulkanEngine::init_vulkan()
	{
		vkb::InstanceBuilder builder;

		//make the vulkan instance, with basic debug features
		auto inst_ret = builder.set_app_name(title.c_str())
			.request_validation_layers(settings.validation)
#ifdef _DEBUG
			.use_default_debug_messenger()
#endif
			.require_api_version(1, 1, 0)
			.build();

		vkb::Instance vkb_inst = inst_ret.value();

		//grab the instance 
		_instance = vkb_inst.instance;
#ifdef _DEBUG
		_debug_messenger = vkb_inst.debug_messenger;
#endif

        VkWin32SurfaceCreateInfoKHR surfaceCreateInfo = {};
        surfaceCreateInfo.sType = VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR;
        surfaceCreateInfo.hinstance = _windowInstance;
        surfaceCreateInfo.hwnd = _window;
		
		VkResult err = vkCreateWin32SurfaceKHR(_instance, &surfaceCreateInfo, nullptr, &_surface);

		//use vkbootstrap to select a gpu. 
		//We want a gpu that can write to the SDL surface and supports vulkan 1.2
		vkb::PhysicalDeviceSelector selector{ vkb_inst };
		vkb::PhysicalDevice physicalDevice = selector
			.select_first_device_unconditionally(true)
			.set_surface(_surface)
			.select()
			.value();

		//create the final vulkan device

		vkb::DeviceBuilder deviceBuilder{ physicalDevice };

		vkb::Device vkbDevice = deviceBuilder.build().value();

		// Get the VkDevice handle used in the rest of a vulkan application
		_device = vkbDevice.device;
		_chosenGPU = physicalDevice.physical_device;

		// use vkbootstrap to get a Graphics queue
		_graphicsQueue = vkbDevice.get_queue(vkb::QueueType::graphics).value();

		_graphicsQueueFamily = vkbDevice.get_queue_index(vkb::QueueType::graphics).value();

		//initialize the memory allocator
		VmaAllocatorCreateInfo allocatorInfo = {};
		allocatorInfo.physicalDevice = _chosenGPU;
		allocatorInfo.device = _device;
		allocatorInfo.instance = _instance;
		vmaCreateAllocator(&allocatorInfo, &_allocator);

		_mainDeletionQueue.push_function([&]() {
			vmaDestroyAllocator(_allocator);
		});

		vkGetPhysicalDeviceProperties(_chosenGPU, &_gpuProperties);
		vkGetPhysicalDeviceMemoryProperties(_chosenGPU, &_memoryProperties);
	}

	void VulkanEngine::init_swapchain()
	{
		vkb::SwapchainBuilder swapchainBuilder{ _chosenGPU,_device,_surface };

		vkb::Swapchain vkbSwapchain = swapchainBuilder
			.use_default_format_selection()
			//use vsync present mode
			.set_desired_present_mode(VK_PRESENT_MODE_FIFO_KHR)
			.set_desired_extent(_windowExtent.width, _windowExtent.height)
			.build()
			.value();

		//store swapchain and its related images
		_swapchain = vkbSwapchain.swapchain;
		_swapchainImages = vkbSwapchain.get_images().value();
		_swapchainImageViews = vkbSwapchain.get_image_views().value();

		_swachainImageFormat = vkbSwapchain.image_format;

		_mainDeletionQueue.push_function([=]() {
			vkDestroySwapchainKHR(_device, _swapchain, nullptr);
			});

		setupDepthStencil();
	}

	void VulkanEngine::setupDepthStencil()
	{
        //depth image size will match the window
        VkExtent3D depthImageExtent = {
            _windowExtent.width,
            _windowExtent.height,
            1
        };

		//hardcoding the depth format to 32 bit float
		_depthFormat = VK_FORMAT_D32_SFLOAT;

		//the depth image will be a image with the format we selected and Depth Attachment usage flag
		VkImageCreateInfo dimg_info = vkinit::image_create_info(_depthFormat, VK_IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT, depthImageExtent);

		//for the depth image, we want to allocate it from gpu local memory
		VmaAllocationCreateInfo dimg_allocinfo = {};
		dimg_allocinfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;
		dimg_allocinfo.requiredFlags = VkMemoryPropertyFlags(VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT);

		//allocate and create the image
		vmaCreateImage(_allocator, &dimg_info, &dimg_allocinfo, &_depthImage._image, &_depthImage._allocation, nullptr);

		//build a image-view for the depth image to use for rendering
		VkImageViewCreateInfo dview_info = vkinit::imageview_create_info(_depthFormat, _depthImage._image, VK_IMAGE_ASPECT_DEPTH_BIT);;

		VK_CHECK(vkCreateImageView(_device, &dview_info, nullptr, &_depthImageView));

		//add to deletion queues
		_mainDeletionQueue.push_function([=]() {
			vkDestroyImageView(_device, _depthImageView, nullptr);
			vmaDestroyImage(_allocator, _depthImage._image, _depthImage._allocation);
		});
	}

	void VulkanEngine::init_default_renderpass()
	{
		//we define an attachment description for our main color image
		//the attachment is loaded as "clear" when renderpass start
		//the attachment is stored when renderpass ends
		//the attachment layout starts as "undefined", and transitions to "Present" so its possible to display it
		//we dont care about stencil, and dont use multisampling

		VkAttachmentDescription color_attachment = {};
		color_attachment.format = _swachainImageFormat;
		color_attachment.samples = VK_SAMPLE_COUNT_1_BIT;
		color_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
		color_attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
		color_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
		color_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
		color_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
		color_attachment.finalLayout = VK_IMAGE_LAYOUT_PRESENT_SRC_KHR;

		VkAttachmentReference color_attachment_ref = {};
		color_attachment_ref.attachment = 0;
		color_attachment_ref.layout = VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

		VkAttachmentDescription depth_attachment = {};
		// Depth attachment
		depth_attachment.flags = 0;
		depth_attachment.format = _depthFormat;
		depth_attachment.samples = VK_SAMPLE_COUNT_1_BIT;
		depth_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
		depth_attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
		depth_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
		depth_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
		depth_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
		depth_attachment.finalLayout = VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL;

		VkAttachmentReference depth_attachment_ref = {};
		depth_attachment_ref.attachment = 1;
		depth_attachment_ref.layout = VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL;

		//we are going to create 1 subpass, which is the minimum you can do
		VkSubpassDescription subpass = {};
		subpass.pipelineBindPoint = VK_PIPELINE_BIND_POINT_GRAPHICS;
		subpass.colorAttachmentCount = 1;
		subpass.pColorAttachments = &color_attachment_ref;
		//hook the depth attachment into the subpass
		subpass.pDepthStencilAttachment = &depth_attachment_ref;

		//1 dependency, which is from "outside" into the subpass. And we can read or write color
		VkSubpassDependency dependency = {};
		dependency.srcSubpass = VK_SUBPASS_EXTERNAL;
		dependency.dstSubpass = 0;
		dependency.srcStageMask = VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
		dependency.srcAccessMask = 0;
		dependency.dstStageMask = VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
		dependency.dstAccessMask = VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT;


		//array of 2 attachments, one for the color, and other for depth
		VkAttachmentDescription attachments[2] = { color_attachment,depth_attachment };

		VkRenderPassCreateInfo render_pass_info = {};
		render_pass_info.sType = VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO;
		//2 attachments from said array
		render_pass_info.attachmentCount = 2;
		render_pass_info.pAttachments = &attachments[0];
		render_pass_info.subpassCount = 1;
		render_pass_info.pSubpasses = &subpass;
		render_pass_info.dependencyCount = 1;
		render_pass_info.pDependencies = &dependency;
	
		VK_CHECK(vkCreateRenderPass(_device, &render_pass_info, nullptr, &_renderPass));

		_mainDeletionQueue.push_function([=]() {
			vkDestroyRenderPass(_device, _renderPass, nullptr);
		});
	}

	void VulkanEngine::init_framebuffers()
	{
		//create the framebuffers for the swapchain images. This will connect the render-pass to the images for rendering
		VkFramebufferCreateInfo fb_info = vkinit::framebuffer_create_info(_renderPass, _windowExtent);

		const size_t swapchain_imagecount = _swapchainImages.size();
		_framebuffers = std::vector<VkFramebuffer>(swapchain_imagecount);

		for (size_t i = 0; i < swapchain_imagecount; i++) {

			VkImageView attachments[2];
			attachments[0] = _swapchainImageViews[i];
			attachments[1] = _depthImageView;

			fb_info.pAttachments = attachments;
			fb_info.attachmentCount = 2;
			VK_CHECK(vkCreateFramebuffer(_device, &fb_info, nullptr, &_framebuffers[i]));

			_mainDeletionQueue.push_function([=]() {
				vkDestroyFramebuffer(_device, _framebuffers[i], nullptr);
				vkDestroyImageView(_device, _swapchainImageViews[i], nullptr);
			});
		}
	}

	void VulkanEngine::init_commands()
	{
		//create a command pool for commands submitted to the graphics queue.
		//we also want the pool to allow for resetting of individual command buffers
		VkCommandPoolCreateInfo commandPoolInfo = vkinit::command_pool_create_info(_graphicsQueueFamily, VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT);

	
		for (int i = 0; i < FRAME_OVERLAP; i++) {

	
			VK_CHECK(vkCreateCommandPool(_device, &commandPoolInfo, nullptr, &_frames[i]._commandPool));

			//allocate the default command buffer that we will use for rendering
			VkCommandBufferAllocateInfo cmdAllocInfo = vkinit::command_buffer_allocate_info(_frames[i]._commandPool, 1);

			VK_CHECK(vkAllocateCommandBuffers(_device, &cmdAllocInfo, &_frames[i]._mainCommandBuffer));

			_mainDeletionQueue.push_function([=]() {
				vkDestroyCommandPool(_device, _frames[i]._commandPool, nullptr);
			});
		}

		VkCommandPoolCreateInfo uiCommandPoolInfo = vkinit::command_pool_create_info(_graphicsQueueFamily, VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT);
		VK_CHECK(vkCreateCommandPool(_device, &uiCommandPoolInfo, nullptr, &_uiCommandPool));
        VkCommandBufferAllocateInfo cmdBufAllocateInfo = vks::initializers::commandBufferAllocateInfo(_uiCommandPool, VK_COMMAND_BUFFER_LEVEL_PRIMARY, 1);
        VK_CHECK_RESULT(vkAllocateCommandBuffers(_device, &cmdBufAllocateInfo, &_uiCommandBuffer));

        _mainDeletionQueue.push_function([=]() {
            vkDestroyCommandPool(_device, _uiCommandPool, nullptr);
            });

		VkCommandPoolCreateInfo uploadCommandPoolInfo = vkinit::command_pool_create_info(_graphicsQueueFamily);
		//create pool for upload context
		VK_CHECK(vkCreateCommandPool(_device, &uploadCommandPoolInfo, nullptr, &_uploadContext._commandPool));

		_mainDeletionQueue.push_function([=]() {
			vkDestroyCommandPool(_device, _uploadContext._commandPool, nullptr);
		});
	}

	void VulkanEngine::init_sync_structures()
	{
		//create syncronization structures
		//one fence to control when the gpu has finished rendering the frame,
		//and 2 semaphores to syncronize rendering with swapchain
		//we want the fence to start signalled so we can wait on it on the first frame
		VkFenceCreateInfo fenceCreateInfo = vkinit::fence_create_info(VK_FENCE_CREATE_SIGNALED_BIT);

		VkSemaphoreCreateInfo semaphoreCreateInfo = vkinit::semaphore_create_info();

		for (int i = 0; i < FRAME_OVERLAP; i++) {

			VK_CHECK(vkCreateFence(_device, &fenceCreateInfo, nullptr, &_frames[i]._renderFence));

		//enqueue the destruction of the fence
		_mainDeletionQueue.push_function([=]() {
			vkDestroyFence(_device, _frames[i]._renderFence, nullptr);
			});


		VK_CHECK(vkCreateSemaphore(_device, &semaphoreCreateInfo, nullptr, &_frames[i]._presentSemaphore));
		VK_CHECK(vkCreateSemaphore(_device, &semaphoreCreateInfo, nullptr, &_frames[i]._renderSemaphore));

		//enqueue the destruction of semaphores
		_mainDeletionQueue.push_function([=]() {
			vkDestroySemaphore(_device, _frames[i]._presentSemaphore, nullptr);
			vkDestroySemaphore(_device, _frames[i]._renderSemaphore, nullptr);
			});
		}
	
		VkFenceCreateInfo uploadFenceCreateInfo = vkinit::fence_create_info();

		VK_CHECK(vkCreateFence(_device, &uploadFenceCreateInfo, nullptr, &_uploadContext._uploadFence));
		_mainDeletionQueue.push_function([=]() {
			vkDestroyFence(_device, _uploadContext._uploadFence, nullptr);
		});
	}


	void VulkanEngine::init_pipelines()
	{
#ifdef _DEBUG
        VkShaderModule debugShader;
        if (!load_shader_module("../../runtime/wk_debug.frag.spv", &debugShader))
        {
            std::cout << "Error when building the debug shader" << std::endl;
        }
#endif
        VkShaderModule terrainFragShader;
        if (!load_shader_module("../../runtime/wk_terrain.frag.spv", &terrainFragShader))
        {
            std::cout << "Error when building the terrain frag shader" << std::endl;
        }

        VkShaderModule terrainVertShader;
        if (!load_shader_module("../../runtime/wk_terrain.vert.spv", &terrainVertShader))
        {
            std::cout << "Error when building the terrain vert shader" << std::endl;
        }

		VkShaderModule colorMeshShader;
		if (!load_shader_module("../../runtime/wk_default_lit.frag.spv", &colorMeshShader))
		{
			std::cout << "Error when building the colored mesh shader" << std::endl;
		}

		VkShaderModule texturedMeshShader;
		if (!load_shader_module("../../runtime/wk_textured_lit.frag.spv", &texturedMeshShader))
		{
			std::cout << "Error when building the colored mesh shader" << std::endl;
		}

		VkShaderModule meshVertShader;
		if (!load_shader_module("../../runtime/wk_mesh.vert.spv", &meshVertShader))
		{
			std::cout << "Error when building the mesh vertex shader module" << std::endl;
		}

	
		//build the stage-create-info for both vertex and fragment stages. This lets the pipeline know the shader modules per stage
		PipelineBuilder pipelineBuilder;

		pipelineBuilder._shaderStages.push_back(
			vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_VERTEX_BIT, meshVertShader));

		pipelineBuilder._shaderStages.push_back(
			vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_FRAGMENT_BIT, colorMeshShader));


		//we start from just the default empty pipeline layout info
		VkPipelineLayoutCreateInfo mesh_pipeline_layout_info = vkinit::pipeline_layout_create_info();

		//setup push constants
		VkPushConstantRange push_constant;
		//offset 0
		push_constant.offset = 0;
		//size of a MeshPushConstant struct
		push_constant.size = sizeof(MeshPushConstants);
		//for the vertex shader
		push_constant.stageFlags = VK_SHADER_STAGE_VERTEX_BIT;

		mesh_pipeline_layout_info.pPushConstantRanges = &push_constant;
		mesh_pipeline_layout_info.pushConstantRangeCount = 1;

		VkDescriptorSetLayout setLayouts[] = { _globalSetLayout, _objectSetLayout };

		mesh_pipeline_layout_info.setLayoutCount = 2;
		mesh_pipeline_layout_info.pSetLayouts = setLayouts;

		VkPipelineLayout meshPipeLayout;
		VK_CHECK(vkCreatePipelineLayout(_device, &mesh_pipeline_layout_info, nullptr, &meshPipeLayout));

#ifdef _DEBUG
		VK_CHECK(vkCreatePipelineLayout(_device, &mesh_pipeline_layout_info, nullptr, &_debugPipelineLayout));
#endif

		//we start from  the normal mesh layout
		VkPipelineLayoutCreateInfo textured_pipeline_layout_info = mesh_pipeline_layout_info;
		
		VkDescriptorSetLayout texturedSetLayouts[] = { _globalSetLayout, _objectSetLayout,_singleTextureSetLayout };

		textured_pipeline_layout_info.setLayoutCount = 3;
		textured_pipeline_layout_info.pSetLayouts = texturedSetLayouts;

		VK_CHECK(vkCreatePipelineLayout(_device, &textured_pipeline_layout_info, nullptr, &_texturedPipeLayout));

		//hook the push constants layout
		pipelineBuilder._pipelineLayout = meshPipeLayout;

		//vertex input controls how to read vertices from vertex buffers. We arent using it yet
		pipelineBuilder._vertexInputInfo = vkinit::vertex_input_state_create_info();

		//input assembly is the configuration for drawing triangle lists, strips, or individual points.
		//we are just going to draw triangle list
		pipelineBuilder._inputAssembly = vkinit::input_assembly_create_info(VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST);

		//build viewport and scissor from the swapchain extents
		pipelineBuilder._viewport.x = 0.0f;
		pipelineBuilder._viewport.y = 0.0f;
		pipelineBuilder._viewport.width = (float)_windowExtent.width;
		pipelineBuilder._viewport.height = (float)_windowExtent.height;
		pipelineBuilder._viewport.minDepth = 0.0f;
		pipelineBuilder._viewport.maxDepth = 1.0f;

		pipelineBuilder._scissor.offset = { 0, 0 };
		pipelineBuilder._scissor.extent = _windowExtent;

		//configure the rasterizer to draw filled triangles
		pipelineBuilder._rasterizer = vkinit::rasterization_state_create_info(VK_POLYGON_MODE_FILL);

		//we dont use multisampling, so just run the default one
		pipelineBuilder._multisampling = vkinit::multisampling_state_create_info();

		//a single blend attachment with no blending and writing to RGBA
		pipelineBuilder._colorBlendAttachment = vkinit::color_blend_attachment_state();


		//default depthtesting
		pipelineBuilder._depthStencil = vkinit::depth_stencil_create_info(true, true, VK_COMPARE_OP_LESS_OR_EQUAL);

		//build the mesh pipeline

		VertexInputDescription vertexDescription = Vertex::get_vertex_description();

		//connect the pipeline builder vertex input info to the one we get from Vertex
		pipelineBuilder._vertexInputInfo.pVertexAttributeDescriptions = vertexDescription.attributes.data();
		pipelineBuilder._vertexInputInfo.vertexAttributeDescriptionCount = (uint32_t)vertexDescription.attributes.size();

		pipelineBuilder._vertexInputInfo.pVertexBindingDescriptions = vertexDescription.bindings.data();
		pipelineBuilder._vertexInputInfo.vertexBindingDescriptionCount = (uint32_t)vertexDescription.bindings.size();

		//build the mesh triangle pipeline
		VkPipeline meshPipeline = pipelineBuilder.build_pipeline(_device, _renderPass);

		create_material(meshPipeline, meshPipeLayout, "defaultmesh");

		pipelineBuilder._shaderStages.clear();
		pipelineBuilder._shaderStages.push_back(
			vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_VERTEX_BIT, meshVertShader));

		pipelineBuilder._shaderStages.push_back(
			vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_FRAGMENT_BIT, texturedMeshShader));

		pipelineBuilder._pipelineLayout = _texturedPipeLayout;
		_texPipeline = pipelineBuilder.build_pipeline(_device, _renderPass);
		create_material(_texPipeline, _texturedPipeLayout, "texturedmesh");

		// terrain pipeline
		VkPipelineLayoutCreateInfo terrain_pipeline_layout_info = vkinit::pipeline_layout_create_info();
		terrain_pipeline_layout_info.pPushConstantRanges = &push_constant;
		terrain_pipeline_layout_info.pushConstantRangeCount = 1;
		terrain_pipeline_layout_info.setLayoutCount = 1;
		terrain_pipeline_layout_info.pSetLayouts = &_globalSetLayout;
		
		VK_CHECK(vkCreatePipelineLayout(_device, &terrain_pipeline_layout_info, nullptr, &_terrainPipeLayout));
        pipelineBuilder._pipelineLayout = _terrainPipeLayout;
        pipelineBuilder._shaderStages.clear();
        pipelineBuilder._shaderStages.push_back(
            vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_VERTEX_BIT, terrainVertShader));
        pipelineBuilder._shaderStages.push_back(
            vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_FRAGMENT_BIT, terrainFragShader));
        pipelineBuilder._inputAssembly = vkinit::input_assembly_create_info(VK_PRIMITIVE_TOPOLOGY_TRIANGLE_STRIP);

		_terrainPipeline = pipelineBuilder.build_pipeline(_device, _renderPass);
		create_terrain_material(_terrainPipeline, _terrainPipeLayout, "terrain");

#ifdef _DEBUG
		// build the debug line drawing pipeline
		pipelineBuilder._pipelineLayout = _debugPipelineLayout;
        pipelineBuilder._shaderStages.clear();
        pipelineBuilder._shaderStages.push_back(
            vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_VERTEX_BIT, meshVertShader));
        pipelineBuilder._shaderStages.push_back(
            vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_FRAGMENT_BIT, debugShader));
        pipelineBuilder._inputAssembly = vkinit::input_assembly_create_info(VK_PRIMITIVE_TOPOLOGY_LINE_STRIP);
        pipelineBuilder._rasterizer = vkinit::rasterization_state_create_info(VK_POLYGON_MODE_LINE);

        _debugPipeline = pipelineBuilder.build_pipeline(_device, _renderPass);

		vkDestroyShaderModule(_device, debugShader, nullptr);
#endif

		vkDestroyShaderModule(_device, terrainFragShader, nullptr);
		vkDestroyShaderModule(_device, terrainVertShader, nullptr);
        vkDestroyShaderModule(_device, meshVertShader, nullptr);
        vkDestroyShaderModule(_device, colorMeshShader, nullptr);
        vkDestroyShaderModule(_device, texturedMeshShader, nullptr);

		_mainDeletionQueue.push_function([=]() {
			vkDestroyPipeline(_device, meshPipeline, nullptr);
			vkDestroyPipeline(_device, _texPipeline, nullptr);
            vkDestroyPipeline(_device, _terrainPipeline, nullptr);
#ifdef _DEBUG
			vkDestroyPipeline(_device, _debugPipeline, nullptr);
			vkDestroyPipelineLayout(_device, _debugPipelineLayout, nullptr);
#endif

			vkDestroyPipelineLayout(_device, meshPipeLayout, nullptr);
			vkDestroyPipelineLayout(_device, _texturedPipeLayout, nullptr);
            vkDestroyPipelineLayout(_device, _terrainPipeLayout, nullptr);
            });
	}

	VkPipelineShaderStageCreateInfo VulkanEngine::load_shader(std::string fileName, VkShaderStageFlagBits stage)
	{
        VkPipelineShaderStageCreateInfo shaderStage = {};
        shaderStage.sType = VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO;
        shaderStage.stage = stage;       			
		if (load_shader_module(fileName.c_str(), &shaderStage.module))
		{
			shaderStage.pName = "main";
		}
        assert(shaderStage.module != VK_NULL_HANDLE);
        return shaderStage;
	}

	bool VulkanEngine::load_shader_module(const char* filePath, VkShaderModule* outShaderModule)
	{
		//open the file. With cursor at the end
		std::ifstream file(filePath, std::ios::ate | std::ios::binary);

		if (!file.is_open()) {
			return false;
		}

		//find what the size of the file is by looking up the location of the cursor
		//because the cursor is at the end, it gives the size directly in bytes
		size_t fileSize = (size_t)file.tellg();

		//spirv expects the buffer to be on uint32, so make sure to reserve a int vector big enough for the entire file
		std::vector<uint32_t> buffer(fileSize / sizeof(uint32_t));

		//put file cursor at beginning
		file.seekg(0);

		//load the entire file into the buffer
		file.read((char*)buffer.data(), fileSize);

		//now that the file is loaded into the buffer, we can close it
		file.close();

		//create a new shader module, using the buffer we loaded
		VkShaderModuleCreateInfo createInfo = {};
		createInfo.sType = VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
		createInfo.pNext = nullptr;

		//codeSize has to be in bytes, so multply the ints in the buffer by size of int to know the real size of the buffer
		createInfo.codeSize = buffer.size() * sizeof(uint32_t);
		createInfo.pCode = buffer.data();

		//check that the creation goes well.
		VkShaderModule shaderModule;
		if (vkCreateShaderModule(_device, &createInfo, nullptr, &shaderModule) != VK_SUCCESS) {
			return false;
		}
		*outShaderModule = shaderModule;
		return true;
	}

	VkPipeline PipelineBuilder::build_pipeline(VkDevice device, VkRenderPass pass)
	{
		//make viewport state from our stored viewport and scissor.
			//at the moment we wont support multiple viewports or scissors
		VkPipelineViewportStateCreateInfo viewportState = {};
		viewportState.sType = VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO;
		viewportState.pNext = nullptr;

		viewportState.viewportCount = 1;
		viewportState.pViewports = &_viewport;
		viewportState.scissorCount = 1;
		viewportState.pScissors = &_scissor;

		//setup dummy color blending. We arent using transparent objects yet
		//the blending is just "no blend", but we do write to the color attachment
		VkPipelineColorBlendStateCreateInfo colorBlending = {};
		colorBlending.sType = VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO;
		colorBlending.pNext = nullptr;

		colorBlending.logicOpEnable = VK_FALSE;
		colorBlending.logicOp = VK_LOGIC_OP_COPY;
		colorBlending.attachmentCount = 1;
		colorBlending.pAttachments = &_colorBlendAttachment;

		//build the actual pipeline
		//we now use all of the info structs we have been writing into into this one to create the pipeline
		VkGraphicsPipelineCreateInfo pipelineInfo = {};
		pipelineInfo.sType = VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO;
		pipelineInfo.pNext = nullptr;

		pipelineInfo.stageCount = (uint32_t)_shaderStages.size();
		pipelineInfo.pStages = _shaderStages.data();
		pipelineInfo.pVertexInputState = &_vertexInputInfo;
		pipelineInfo.pInputAssemblyState = &_inputAssembly;
		pipelineInfo.pViewportState = &viewportState;
		pipelineInfo.pRasterizationState = &_rasterizer;
		pipelineInfo.pMultisampleState = &_multisampling;
		pipelineInfo.pColorBlendState = &colorBlending;
		pipelineInfo.pDepthStencilState = &_depthStencil;
		pipelineInfo.layout = _pipelineLayout;
		pipelineInfo.renderPass = pass;
		pipelineInfo.subpass = 0;
		pipelineInfo.basePipelineHandle = VK_NULL_HANDLE;

		//its easy to error out on create graphics pipeline, so we handle it a bit better than the common VK_CHECK case
		VkPipeline newPipeline;
		if (vkCreateGraphicsPipelines(
			device, VK_NULL_HANDLE, 1, &pipelineInfo, nullptr, &newPipeline) != VK_SUCCESS) {
			std::cout << "failed to create pipline\n";
			return VK_NULL_HANDLE; // failed to create graphics pipeline
		}
		else
		{
			return newPipeline;
		}
	}
	
#ifdef THREADING_PART2
    void VulkanEngine::upload_mesh(Mesh* mesh)
    {
        const size_t vertexBufferSize = mesh->_vertices.size() * sizeof(Vertex);
        const size_t indexBufferSize = mesh->_indices.size() * sizeof(uint16_t);

        {
            //allocate vertex buffer
            VkBufferCreateInfo stagingBufferInfo = {};
            stagingBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            stagingBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            stagingBufferInfo.size = vertexBufferSize;
            //this buffer is going to be used as a Vertex Buffer
            stagingBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

            AllocatedBuffer stagingBuffer;

            //let the VMA library know that this data should be writeable by CPU, but also readable by GPU
            VmaAllocationCreateInfo vmaallocInfo = {};
            vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &stagingBufferInfo, &vmaallocInfo,
                &stagingBuffer._buffer,
                &stagingBuffer._allocation,
                nullptr));

            //copy vertex data
            void* data;
            vmaMapMemory(_allocator, stagingBuffer._allocation, &data);

            memcpy(data, mesh->_vertices.data(), mesh->_vertices.size() * sizeof(Vertex));

            vmaUnmapMemory(_allocator, stagingBuffer._allocation);

            //allocate vertex buffer
            VkBufferCreateInfo vertexBufferInfo = {};
            vertexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            vertexBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            vertexBufferInfo.size = vertexBufferSize;
            //this buffer is going to be used as a Vertex Buffer
            vertexBufferInfo.usage = VK_BUFFER_USAGE_VERTEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT;

            //let the VMA library know that this data should be gpu native	
            vmaallocInfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &vertexBufferInfo, &vmaallocInfo,
                &mesh->_vertexBuffer._buffer,
                &mesh->_vertexBuffer._allocation,
                nullptr));
            //add the destruction of triangle mesh buffer to the deletion queue
            _mainDeletionQueue.push_function([=]() {

                vmaDestroyBuffer(_allocator, mesh->_vertexBuffer._buffer, mesh->_vertexBuffer._allocation);
                });

            immediate_submit([=](VkCommandBuffer cmd) {
                VkBufferCopy copy;
                copy.dstOffset = 0;
                copy.srcOffset = 0;
                copy.size = vertexBufferSize;
                vkCmdCopyBuffer(cmd, stagingBuffer._buffer, mesh->_vertexBuffer._buffer, 1, &copy);
                });

            vmaDestroyBuffer(_allocator, stagingBuffer._buffer, stagingBuffer._allocation);
        }

        {
            //allocate index buffer
            VkBufferCreateInfo stagingBufferInfo = {};
            stagingBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            stagingBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            stagingBufferInfo.size = indexBufferSize;
            //this buffer is going to be used as a Index Buffer
            stagingBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

            AllocatedBuffer stagingBuffer;

            //let the VMA library know that this data should be writeable by CPU, but also readable by GPU
            VmaAllocationCreateInfo vmaallocInfo = {};
            vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &stagingBufferInfo, &vmaallocInfo,
                &stagingBuffer._buffer,
                &stagingBuffer._allocation,
                nullptr));

            //copy vertex data
            void* data;
            vmaMapMemory(_allocator, stagingBuffer._allocation, &data);

            memcpy(data, mesh->_indices.data(), mesh->_indices.size() * sizeof(uint16_t));

            vmaUnmapMemory(_allocator, stagingBuffer._allocation);

            //allocate index buffer
            VkBufferCreateInfo indexBufferInfo = {};
            indexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            indexBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            indexBufferInfo.size = indexBufferSize;
            //this buffer is going to be used as a Index Buffer
            indexBufferInfo.usage = VK_BUFFER_USAGE_INDEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT;

            //let the VMA library know that this data should be gpu native	
            vmaallocInfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &indexBufferInfo, &vmaallocInfo,
                &mesh->_indexBuffer._buffer,
                &mesh->_indexBuffer._allocation,
                nullptr));
            //add the destruction of triangle mesh buffer to the deletion queue
            _mainDeletionQueue.push_function([=]() {

                vmaDestroyBuffer(_allocator, mesh->_indexBuffer._buffer, mesh->_indexBuffer._allocation);
                });

            immediate_submit([=](VkCommandBuffer cmd) {
                VkBufferCopy copy;
                copy.dstOffset = 0;
                copy.srcOffset = 0;
                copy.size = indexBufferSize;
                vkCmdCopyBuffer(cmd, stagingBuffer._buffer, mesh->_indexBuffer._buffer, 1, &copy);
                });

            vmaDestroyBuffer(_allocator, stagingBuffer._buffer, stagingBuffer._allocation);
        }
    }

    void VulkanEngine::upload_mesh(TerrainMesh* mesh)
    {
        const size_t vertexBufferSize = mesh->_vertices.size() * sizeof(Vertex);
        const size_t indexBufferSize = mesh->_indices.size() * sizeof(uint32_t);

        {
            //allocate vertex buffer
            VkBufferCreateInfo stagingBufferInfo = {};
            stagingBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            stagingBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            stagingBufferInfo.size = vertexBufferSize;
            //this buffer is going to be used as a Vertex Buffer
            stagingBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

            AllocatedBuffer stagingBuffer;

            //let the VMA library know that this data should be writeable by CPU, but also readable by GPU
            VmaAllocationCreateInfo vmaallocInfo = {};
            vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &stagingBufferInfo, &vmaallocInfo,
                &stagingBuffer._buffer,
                &stagingBuffer._allocation,
                nullptr));

            //copy vertex data
            void* data;
            vmaMapMemory(_allocator, stagingBuffer._allocation, &data);

            memcpy(data, mesh->_vertices.data(), mesh->_vertices.size() * sizeof(Vertex));

            vmaUnmapMemory(_allocator, stagingBuffer._allocation);

            //allocate vertex buffer
            VkBufferCreateInfo vertexBufferInfo = {};
            vertexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            vertexBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            vertexBufferInfo.size = vertexBufferSize;
            //this buffer is going to be used as a Vertex Buffer
            vertexBufferInfo.usage = VK_BUFFER_USAGE_VERTEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT;

            //let the VMA library know that this data should be gpu native	
            vmaallocInfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &vertexBufferInfo, &vmaallocInfo,
                &mesh->_vertexBuffer._buffer,
                &mesh->_vertexBuffer._allocation,
                nullptr));
            //add the destruction of triangle mesh buffer to the deletion queue
            _mainDeletionQueue.push_function([=]() {

                vmaDestroyBuffer(_allocator, mesh->_vertexBuffer._buffer, mesh->_vertexBuffer._allocation);
                });

            immediate_submit([=](VkCommandBuffer cmd) {
                VkBufferCopy copy;
                copy.dstOffset = 0;
                copy.srcOffset = 0;
                copy.size = vertexBufferSize;
                vkCmdCopyBuffer(cmd, stagingBuffer._buffer, mesh->_vertexBuffer._buffer, 1, &copy);
                });

            vmaDestroyBuffer(_allocator, stagingBuffer._buffer, stagingBuffer._allocation);
        }

        {
            //allocate index buffer
            VkBufferCreateInfo stagingBufferInfo = {};
            stagingBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            stagingBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            stagingBufferInfo.size = indexBufferSize;
            //this buffer is going to be used as a Index Buffer
            stagingBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

            AllocatedBuffer stagingBuffer;

            //let the VMA library know that this data should be writeable by CPU, but also readable by GPU
            VmaAllocationCreateInfo vmaallocInfo = {};
            vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &stagingBufferInfo, &vmaallocInfo,
                &stagingBuffer._buffer,
                &stagingBuffer._allocation,
                nullptr));

            //copy vertex data
            void* data;
            vmaMapMemory(_allocator, stagingBuffer._allocation, &data);

            memcpy(data, mesh->_indices.data(), mesh->_indices.size() * sizeof(uint32_t));

            vmaUnmapMemory(_allocator, stagingBuffer._allocation);

            //allocate index buffer
            VkBufferCreateInfo indexBufferInfo = {};
            indexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            indexBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            indexBufferInfo.size = indexBufferSize;
            //this buffer is going to be used as a Index Buffer
            indexBufferInfo.usage = VK_BUFFER_USAGE_INDEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT;

            //let the VMA library know that this data should be gpu native	
            vmaallocInfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &indexBufferInfo, &vmaallocInfo,
                &mesh->_indexBuffer._buffer,
                &mesh->_indexBuffer._allocation,
                nullptr));
            //add the destruction of triangle mesh buffer to the deletion queue
            _mainDeletionQueue.push_function([=]() {

                vmaDestroyBuffer(_allocator, mesh->_indexBuffer._buffer, mesh->_indexBuffer._allocation);
                });

            immediate_submit([=](VkCommandBuffer cmd) {
                VkBufferCopy copy;
                copy.dstOffset = 0;
                copy.srcOffset = 0;
                copy.size = indexBufferSize;
                vkCmdCopyBuffer(cmd, stagingBuffer._buffer, mesh->_indexBuffer._buffer, 1, &copy);
                });

            vmaDestroyBuffer(_allocator, stagingBuffer._buffer, stagingBuffer._allocation);
        }
    }
#else
	void VulkanEngine::upload_mesh(Mesh& mesh)
	{
		const size_t vertexBufferSize = mesh._vertices.size() * sizeof(Vertex);
		const size_t indexBufferSize = mesh._indices.size() * sizeof(uint16_t);

		{
			//allocate vertex buffer
			VkBufferCreateInfo stagingBufferInfo = {};
			stagingBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
			stagingBufferInfo.pNext = nullptr;
			//this is the total size, in bytes, of the buffer we are allocating
			stagingBufferInfo.size = vertexBufferSize;
			//this buffer is going to be used as a Vertex Buffer
			stagingBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

			AllocatedBuffer stagingBuffer;

            //let the VMA library know that this data should be writeable by CPU, but also readable by GPU
            VmaAllocationCreateInfo vmaallocInfo = {};
            vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

			//allocate the buffer
			VK_CHECK(vmaCreateBuffer(_allocator, &stagingBufferInfo, &vmaallocInfo,
				&stagingBuffer._buffer,
				&stagingBuffer._allocation,
				nullptr));

			//copy vertex data
			void* data;
			vmaMapMemory(_allocator, stagingBuffer._allocation, &data);

			memcpy(data, mesh._vertices.data(), mesh._vertices.size() * sizeof(Vertex));

			vmaUnmapMemory(_allocator, stagingBuffer._allocation);

			//allocate vertex buffer
			VkBufferCreateInfo vertexBufferInfo = {};
			vertexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
			vertexBufferInfo.pNext = nullptr;
			//this is the total size, in bytes, of the buffer we are allocating
			vertexBufferInfo.size = vertexBufferSize;
			//this buffer is going to be used as a Vertex Buffer
			vertexBufferInfo.usage = VK_BUFFER_USAGE_VERTEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT;

			//let the VMA library know that this data should be gpu native	
			vmaallocInfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

			//allocate the buffer
			VK_CHECK(vmaCreateBuffer(_allocator, &vertexBufferInfo, &vmaallocInfo,
				&mesh._vertexBuffer._buffer,
				&mesh._vertexBuffer._allocation,
				nullptr));
			//add the destruction of triangle mesh buffer to the deletion queue
			_mainDeletionQueue.push_function([=]() {

				vmaDestroyBuffer(_allocator, mesh._vertexBuffer._buffer, mesh._vertexBuffer._allocation);
				});

			immediate_submit([=](VkCommandBuffer cmd) {
				VkBufferCopy copy;
				copy.dstOffset = 0;
				copy.srcOffset = 0;
				copy.size = vertexBufferSize;
				vkCmdCopyBuffer(cmd, stagingBuffer._buffer, mesh._vertexBuffer._buffer, 1, &copy);
				});

			vmaDestroyBuffer(_allocator, stagingBuffer._buffer, stagingBuffer._allocation);
		}

		{
			//allocate index buffer
			VkBufferCreateInfo stagingBufferInfo = {};
			stagingBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
			stagingBufferInfo.pNext = nullptr;
			//this is the total size, in bytes, of the buffer we are allocating
			stagingBufferInfo.size = indexBufferSize;
			//this buffer is going to be used as a Index Buffer
			stagingBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

			AllocatedBuffer stagingBuffer;

            //let the VMA library know that this data should be writeable by CPU, but also readable by GPU
            VmaAllocationCreateInfo vmaallocInfo = {};
            vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

			//allocate the buffer
			VK_CHECK(vmaCreateBuffer(_allocator, &stagingBufferInfo, &vmaallocInfo,
				&stagingBuffer._buffer,
				&stagingBuffer._allocation,
				nullptr));

			//copy vertex data
			void* data;
			vmaMapMemory(_allocator, stagingBuffer._allocation, &data);

			memcpy(data, mesh._indices.data(), mesh._indices.size() * sizeof(uint16_t));

			vmaUnmapMemory(_allocator, stagingBuffer._allocation);

			//allocate index buffer
			VkBufferCreateInfo indexBufferInfo = {};
			indexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
			indexBufferInfo.pNext = nullptr;
			//this is the total size, in bytes, of the buffer we are allocating
			indexBufferInfo.size = indexBufferSize;
			//this buffer is going to be used as a Index Buffer
			indexBufferInfo.usage = VK_BUFFER_USAGE_INDEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT;

			//let the VMA library know that this data should be gpu native	
			vmaallocInfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

			//allocate the buffer
			VK_CHECK(vmaCreateBuffer(_allocator, &indexBufferInfo, &vmaallocInfo,
				&mesh._indexBuffer._buffer,
				&mesh._indexBuffer._allocation,
				nullptr));
			//add the destruction of triangle mesh buffer to the deletion queue
			_mainDeletionQueue.push_function([=]() {

				vmaDestroyBuffer(_allocator, mesh._indexBuffer._buffer, mesh._indexBuffer._allocation);
				});

			immediate_submit([=](VkCommandBuffer cmd) {
				VkBufferCopy copy;
				copy.dstOffset = 0;
				copy.srcOffset = 0;
				copy.size = indexBufferSize;
				vkCmdCopyBuffer(cmd, stagingBuffer._buffer, mesh._indexBuffer._buffer, 1, &copy);
				});

			vmaDestroyBuffer(_allocator, stagingBuffer._buffer, stagingBuffer._allocation);
		}
	}

    void VulkanEngine::upload_mesh(TerrainMesh& mesh)
    {
        const size_t vertexBufferSize = mesh._vertices.size() * sizeof(Vertex);
        const size_t indexBufferSize = mesh._indices.size() * sizeof(uint32_t);

        {
            //allocate vertex buffer
            VkBufferCreateInfo stagingBufferInfo = {};
            stagingBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            stagingBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            stagingBufferInfo.size = vertexBufferSize;
            //this buffer is going to be used as a Vertex Buffer
            stagingBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

            AllocatedBuffer stagingBuffer;

            //let the VMA library know that this data should be writeable by CPU, but also readable by GPU
            VmaAllocationCreateInfo vmaallocInfo = {};
            vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &stagingBufferInfo, &vmaallocInfo,
                &stagingBuffer._buffer,
                &stagingBuffer._allocation,
                nullptr));

            //copy vertex data
            void* data;
            vmaMapMemory(_allocator, stagingBuffer._allocation, &data);

            memcpy(data, mesh._vertices.data(), mesh._vertices.size() * sizeof(Vertex));

            vmaUnmapMemory(_allocator, stagingBuffer._allocation);

            //allocate vertex buffer
            VkBufferCreateInfo vertexBufferInfo = {};
            vertexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            vertexBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            vertexBufferInfo.size = vertexBufferSize;
            //this buffer is going to be used as a Vertex Buffer
            vertexBufferInfo.usage = VK_BUFFER_USAGE_VERTEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT;

            //let the VMA library know that this data should be gpu native	
            vmaallocInfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &vertexBufferInfo, &vmaallocInfo,
                &mesh._vertexBuffer._buffer,
                &mesh._vertexBuffer._allocation,
                nullptr));
            //add the destruction of triangle mesh buffer to the deletion queue
            _mainDeletionQueue.push_function([=]() {

                vmaDestroyBuffer(_allocator, mesh._vertexBuffer._buffer, mesh._vertexBuffer._allocation);
                });

            immediate_submit([=](VkCommandBuffer cmd) {
                VkBufferCopy copy;
                copy.dstOffset = 0;
                copy.srcOffset = 0;
                copy.size = vertexBufferSize;
                vkCmdCopyBuffer(cmd, stagingBuffer._buffer, mesh._vertexBuffer._buffer, 1, &copy);
                });

            vmaDestroyBuffer(_allocator, stagingBuffer._buffer, stagingBuffer._allocation);
        }

        {
            //allocate index buffer
            VkBufferCreateInfo stagingBufferInfo = {};
            stagingBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            stagingBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            stagingBufferInfo.size = indexBufferSize;
            //this buffer is going to be used as a Index Buffer
            stagingBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

            AllocatedBuffer stagingBuffer;

            //let the VMA library know that this data should be writeable by CPU, but also readable by GPU
            VmaAllocationCreateInfo vmaallocInfo = {};
            vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &stagingBufferInfo, &vmaallocInfo,
                &stagingBuffer._buffer,
                &stagingBuffer._allocation,
                nullptr));

            //copy vertex data
            void* data;
            vmaMapMemory(_allocator, stagingBuffer._allocation, &data);

            memcpy(data, mesh._indices.data(), mesh._indices.size() * sizeof(uint32_t));

            vmaUnmapMemory(_allocator, stagingBuffer._allocation);

            //allocate index buffer
            VkBufferCreateInfo indexBufferInfo = {};
            indexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
            indexBufferInfo.pNext = nullptr;
            //this is the total size, in bytes, of the buffer we are allocating
            indexBufferInfo.size = indexBufferSize;
            //this buffer is going to be used as a Index Buffer
            indexBufferInfo.usage = VK_BUFFER_USAGE_INDEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT;

            //let the VMA library know that this data should be gpu native	
            vmaallocInfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

            //allocate the buffer
            VK_CHECK(vmaCreateBuffer(_allocator, &indexBufferInfo, &vmaallocInfo,
                &mesh._indexBuffer._buffer,
                &mesh._indexBuffer._allocation,
                nullptr));
            //add the destruction of triangle mesh buffer to the deletion queue
            _mainDeletionQueue.push_function([=]() {

                vmaDestroyBuffer(_allocator, mesh._indexBuffer._buffer, mesh._indexBuffer._allocation);
                });

            immediate_submit([=](VkCommandBuffer cmd) {
                VkBufferCopy copy;
                copy.dstOffset = 0;
                copy.srcOffset = 0;
                copy.size = indexBufferSize;
                vkCmdCopyBuffer(cmd, stagingBuffer._buffer, mesh._indexBuffer._buffer, 1, &copy);
                });

            vmaDestroyBuffer(_allocator, stagingBuffer._buffer, stagingBuffer._allocation);
        }
    }
#endif

	/*
	Material* VulkanEngine::create_material(VkPipeline pipeline, VkPipelineLayout layout, const std::string& name)
	{
		Material mat;
		mat.pipeline = pipeline;
		mat.pipelineLayout = layout;
		_materials[name] = mat;
		return &_materials[name];
	}
	*/

    RenderBucket* VulkanEngine::create_material(VkPipeline pipeline, VkPipelineLayout layout, const std::string& name)
    {
        // create a bucket with a material
        RenderBucket rb;
        rb.material.pipeline = pipeline;
        rb.material.pipelineLayout = layout;

		auto result = _renderBuckets.insert(std::pair<std::string, RenderBucket>(name, rb));
		return &(result.first->second);
    }

	TerrainRenderBucket* VulkanEngine::create_terrain_material(VkPipeline pipeline, VkPipelineLayout layout, const std::string& name)
    {
        // create a bucket with a material
        TerrainRenderBucket rb;
        rb.material.pipeline = pipeline;
        rb.material.pipelineLayout = layout;

        auto result = _terrainRenderBuckets.insert(std::pair<std::string, TerrainRenderBucket>(name, rb));
        return &(result.first->second);
    }

	/*
	Material* VulkanEngine::get_material(const std::string& name)
	{
		//search for the object, and return nullpointer if not found
		auto it = _materials.find(name);
		if (it == _materials.end()) {
			return nullptr;
		}
		else {
			return &(*it).second;
		}
	}
	*/

	Mesh* VulkanEngine::get_mesh(const std::string& name)
	{
		auto it = _meshes.find(name);
		if (it == _meshes.end()) {
			return nullptr;
		}
		else {
			return &(*it).second;
		}
	}

	TerrainMesh* VulkanEngine::get_terrainMesh(const std::string& name)
	{
        auto it = _terrainMeshes.find(name);
        if (it == _terrainMeshes.end()) {
            return nullptr;
        }
        else {
            return &(*it).second;
        }
	}

	void VulkanEngine::draw_objects(VkCommandBuffer cmd)
	{
		void* data;
		vmaMapMemory(_allocator, get_current_frame().cameraBuffer._allocation, &data);
		memcpy(data, &_camera.matrices, sizeof(Camera::GPUCameraData));
		vmaUnmapMemory(_allocator, get_current_frame().cameraBuffer._allocation);

		char* sceneData;
		vmaMapMemory(_allocator, _sceneParameterBuffer._allocation , (void**)&sceneData);

		int frameIndex = _frameNumber % FRAME_OVERLAP;

		sceneData += pad_uniform_buffer_size(sizeof(GPUSceneData)) * frameIndex;

		_sceneParameters.sunlightDirection = glm::normalize(_camera.matrices.view[2]);
		memcpy(sceneData, &_sceneParameters, sizeof(GPUSceneData));

		vmaUnmapMemory(_allocator, _sceneParameterBuffer._allocation);

		//void* objectData;
		//vmaMapMemory(_allocator, get_current_frame().objectBuffer._allocation, &objectData);	
		//GPUObjectData* objectSSBO = (GPUObjectData*)objectData;	
		//vmaUnmapMemory(_allocator, get_current_frame().objectBuffer._allocation);

        uint32_t uniform_offset = (uint32_t)pad_uniform_buffer_size(sizeof(GPUSceneData)) * frameIndex;
#if 0
		Mesh* lastMesh = nullptr;
		Material* lastMaterial = nullptr;
	
		for (auto it = _renderables.begin(); it != _renderables.end(); it++)
		{
			// Check visibility against view frustum using a simple sphere check based on the radius of the mesh
			glm::vec4 p = it->transformMatrix * glm::vec4(it->mesh->_center, 1.0f);
			if (!_frustum.checkSphere(p, it->mesh->_radius))
			{
				continue;
			}

			//only bind the pipeline if it doesn't match with the already bound one
			if (it->material != lastMaterial) {

				vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, it->material->pipeline);
				lastMaterial = it->material;

				vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, it->material->pipelineLayout, 0, 1, &get_current_frame().globalDescriptor, 1, &uniform_offset);
		
				//object data descriptor
				vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, it->material->pipelineLayout, 1, 1, &get_current_frame().objectDescriptor, 0, nullptr);

				if (it->material->textureSet != VK_NULL_HANDLE) {
					//texture descriptor
					vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, it->material->pipelineLayout, 2, 1, &it->material->textureSet, 0, nullptr);

				}
			}

			MeshPushConstants constants;
			constants.render_matrix = it->transformMatrix;

			//upload the mesh to the gpu via pushconstants
			vkCmdPushConstants(cmd, it->material->pipelineLayout, VK_SHADER_STAGE_VERTEX_BIT, 0, sizeof(MeshPushConstants), &constants);

			//only bind the mesh if its a different one from last bind
			if (it->mesh != lastMesh) {
				//bind the mesh vertex buffer with offset 0
				VkDeviceSize offset = 0;
				vkCmdBindVertexBuffers(cmd, 0, 1, &it->mesh->_vertexBuffer._buffer, &offset);
				vkCmdBindIndexBuffer(cmd, it->mesh->_indexBuffer._buffer, 0, VK_INDEX_TYPE_UINT16);
				lastMesh = it->mesh;
			}
			//we can now draw			

			// 1 instance (for now!)
			// 0 for the offset into the index buffer
			// 0 for the offset to add to the indices in the buffer
			// 0 for the offset for the instancing
			vkCmdDrawIndexed(cmd, static_cast<uint32_t>(it->mesh->_indices.size()), 1, 0, 0, 0);

#ifdef _DEBUG
			lastMaterial = nullptr; // force refreshing of material
            vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _debugPipeline);

			vkCmdPushConstants(cmd, _debugPipelineLayout, VK_SHADER_STAGE_VERTEX_BIT, 0, sizeof(MeshPushConstants), &constants);

            uint32_t uniform_offset = (uint32_t)pad_uniform_buffer_size(sizeof(GPUSceneData)) * frameIndex;
            vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _debugPipelineLayout, 0, 1, &get_current_frame().globalDescriptor, 1, &uniform_offset);

            //object data descriptor
            vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _debugPipelineLayout, 1, 1, &get_current_frame().objectDescriptor, 0, nullptr);

			vkCmdDraw(cmd, NUM_BOUNDING_BOX_VERTICES, 1, static_cast<uint32_t>(it->mesh->_vertices.size()) - NUM_BOUNDING_BOX_VERTICES, 0);
#endif
		}

        vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _terrainPipeline);
        vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _terrainPipeLayout, 0, 1, &get_current_frame().globalDescriptor, 1, &uniform_offset);
        //vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _terrainPipelineLayout, 2, 1, &_terrainTextureSet, 0, nullptr);

		for (auto it = _terrainRenderables.begin(); it != _terrainRenderables.end(); it++)
		{
			// Check visibility against view frustum using a simple sphere check based on the radius of the mesh
			glm::vec4 p = it->transformMatrix * glm::vec4(it->mesh->_center, 1.0f);
			if (!_frustum.checkSphere(p, it->mesh->_radius))
			{
				continue;
			}

			MeshPushConstants constants;
			constants.render_matrix = it->transformMatrix;

			//upload the mesh to the gpu via pushconstants
			vkCmdPushConstants(cmd, it->material->pipelineLayout, VK_SHADER_STAGE_VERTEX_BIT, 0, sizeof(MeshPushConstants), &constants);

			//bind the mesh vertex buffer with offset 0
			VkDeviceSize offset = 0;
			vkCmdBindVertexBuffers(cmd, 0, 1, &it->mesh->_vertexBuffer._buffer, &offset);
			vkCmdBindIndexBuffer(cmd, it->mesh->_indexBuffer._buffer, 0, VK_INDEX_TYPE_UINT32);

			// 1 instance (for now!)
			// 0 for the offset into the index buffer
			// 0 for the offset to add to the indices in the buffer
			// 0 for the offset for the instancing
			vkCmdDrawIndexed(cmd, static_cast<uint32_t>(it->mesh->_indices.size()), 1, 0, 0, 0);
		}
#else
		for (auto rit = _renderBuckets.begin(); rit != _renderBuckets.end(); rit++)
		{
			// each bucket is a unique material so just set it once for all renderables
            vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, rit->second.material.pipeline);
            vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, rit->second.material.pipelineLayout, 0, 1, &get_current_frame().globalDescriptor, 1, &uniform_offset);
            vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, rit->second.material.pipelineLayout, 1, 1, &get_current_frame().objectDescriptor, 0, nullptr);

            //texture descriptor
            //vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, it->material->pipelineLayout, 2, 1, &it->material->textureSet, 0, nullptr);

			for (auto it = rit->second.renderObjects.begin(); it != rit->second.renderObjects.end(); ++it)
			{
                // Check visibility against view frustum using a simple sphere check based on the radius of the mesh
                glm::vec4 p = it->transformMatrix * glm::vec4(it->mesh->_center, 1.0f);
                if (!_frustum.checkSphere(p, it->mesh->_radius))
                {
                    continue;
                }

                MeshPushConstants constants;
                constants.render_matrix = it->transformMatrix;

                //upload the mesh to the gpu via pushconstants
                vkCmdPushConstants(cmd, rit->second.material.pipelineLayout, VK_SHADER_STAGE_VERTEX_BIT, 0, sizeof(MeshPushConstants), &constants);

                //bind the mesh vertex buffer with offset 0
                VkDeviceSize offset = 0;
                vkCmdBindVertexBuffers(cmd, 0, 1, &it->mesh->_vertexBuffer._buffer, &offset);
                vkCmdBindIndexBuffer(cmd, it->mesh->_indexBuffer._buffer, 0, VK_INDEX_TYPE_UINT16);

				//we can now draw			

                // 1 instance (for now!)
                // 0 for the offset into the index buffer
                // 0 for the offset to add to the indices in the buffer
                // 0 for the offset for the instancing
                vkCmdDrawIndexed(cmd, static_cast<uint32_t>(it->mesh->_indices.size()), 1, 0, 0, 0);
			}

//#ifdef _DEBUG
#if 0
            vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _debugPipeline);
            vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _debugPipelineLayout, 0, 1, &get_current_frame().globalDescriptor, 1, &uniform_offset);
            vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _debugPipelineLayout, 1, 1, &get_current_frame().objectDescriptor, 0, nullptr);

			for (auto it = rit->second.renderObjects.begin(); it != rit->second.renderObjects.end(); ++it)
			{
				// Check visibility against view frustum using a simple sphere check based on the radius of the mesh
				glm::vec4 p = it->transformMatrix * glm::vec4(it->mesh->_center, 1.0f);
				if (!_frustum.checkSphere(p, it->mesh->_radius))
				{
					continue;
				}

                MeshPushConstants constants;
                constants.render_matrix = it->transformMatrix;

                //upload the mesh to the gpu via pushconstants
                vkCmdPushConstants(cmd, _debugPipelineLayout, VK_SHADER_STAGE_VERTEX_BIT, 0, sizeof(MeshPushConstants), &constants);

                //bind the mesh vertex buffer with offset 0
                VkDeviceSize offset = 0;
                vkCmdBindVertexBuffers(cmd, 0, 1, &it->mesh->_vertexBuffer._buffer, &offset);
                vkCmdBindIndexBuffer(cmd, it->mesh->_indexBuffer._buffer, 0, VK_INDEX_TYPE_UINT16);

				vkCmdDraw(cmd, NUM_BOUNDING_BOX_VERTICES, 1, static_cast<uint32_t>(it->mesh->_vertices.size()) - NUM_BOUNDING_BOX_VERTICES, 0);
			}
#endif

		}

		// now terrain
		for (auto rit = _terrainRenderBuckets.begin(); rit != _terrainRenderBuckets.end(); rit++)
		{
			// each bucket is a unique material so just set it once for all renderables
			vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, rit->second.material.pipeline);
			vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, rit->second.material.pipelineLayout, 0, 1, &get_current_frame().globalDescriptor, 1, &uniform_offset);

			for (auto it = rit->second.renderObjects.begin(); it != rit->second.renderObjects.end(); ++it)
			{
				// Check visibility against view frustum using a simple sphere check based on the radius of the mesh
				glm::vec4 p = it->transformMatrix * glm::vec4(it->mesh->_center, 1.0f);
				if (!_frustum.checkSphere(p, it->mesh->_radius))
				{
					continue;
				}

                MeshPushConstants constants;
                constants.render_matrix = it->transformMatrix;

                //upload the mesh to the gpu via pushconstants
                vkCmdPushConstants(cmd, rit->second.material.pipelineLayout, VK_SHADER_STAGE_VERTEX_BIT, 0, sizeof(MeshPushConstants), &constants);

                //bind the mesh vertex buffer with offset 0
                VkDeviceSize offset = 0;
                vkCmdBindVertexBuffers(cmd, 0, 1, &it->mesh->_vertexBuffer._buffer, &offset);
                vkCmdBindIndexBuffer(cmd, it->mesh->_indexBuffer._buffer, 0, VK_INDEX_TYPE_UINT32); // notice 32 bit indices here!

                //we can now draw			

                // 1 instance (for now!)
                // 0 for the offset into the index buffer
                // 0 for the offset to add to the indices in the buffer
                // 0 for the offset for the instancing
                vkCmdDrawIndexed(cmd, static_cast<uint32_t>(it->mesh->_indices.size()), 1, 0, 0, 0);
			}
		}
#endif
    }

	/*
	void VulkanEngine::load_meshes()
	{
		Mesh triMesh{};
		//make the array 3 vertices long
		triMesh._vertices.resize(3);

		//vertex positions
		triMesh._vertices[0].position = { 1.f,1.f, 0.0f };
		triMesh._vertices[1].position = { -1.f,1.f, 0.0f };
		triMesh._vertices[2].position = { 0.f,-1.f, 0.0f };

		//vertex colors, all green
		triMesh._vertices[0].color = { 0.f,1.f, 0.0f }; //pure green
		triMesh._vertices[1].color = { 0.f,1.f, 0.0f }; //pure green
		triMesh._vertices[2].color = { 0.f,1.f, 0.0f }; //pure green
		//we dont care about the vertex normals

		//load the monkey
		Mesh monkeyMesh{};
		monkeyMesh.load_from_obj("../../assets/monkey_smooth.obj");

		Mesh lostEmpire{};
		lostEmpire.load_from_obj("../../assets/lost_empire.obj");

		upload_mesh(triMesh);
		upload_mesh(monkeyMesh);
		upload_mesh(lostEmpire);

		_meshes["monkey"] = monkeyMesh;
		_meshes["triangle"] = triMesh;
		_meshes["empire"] = lostEmpire;
	}


	void VulkanEngine::load_images()
	{
		Texture lostEmpire;

		vkutil::load_image_from_file(*this, "../../assets/lost_empire-RGBA.png", lostEmpire.image);

		VkImageViewCreateInfo imageinfo = vkinit::imageview_create_info(VK_FORMAT_R8G8B8A8_SRGB, lostEmpire.image._image, VK_IMAGE_ASPECT_COLOR_BIT);
		vkCreateImageView(_device, &imageinfo, nullptr, &lostEmpire.imageView);

		_mainDeletionQueue.push_function([=]() {
			vkDestroyImageView(_device, lostEmpire.imageView, nullptr);
		});

		_loadedTextures["empire_diffuse"] = lostEmpire;
	}

	void VulkanEngine::init_scene()
	{
		RenderObject monkey;
		monkey.mesh = get_mesh("monkey");
		monkey.material = get_material("defaultmesh");
		monkey.transformMatrix = glm::mat4{ 1.0f };

		_renderables.push_back(monkey);

		RenderObject map;
		map.mesh = get_mesh("empire");
		map.material = get_material("texturedmesh");
		map.transformMatrix = glm::translate(glm::vec3{ 5,-10,0 }); //glm::mat4{ 1.0f };

		_renderables.push_back(map);

		for (int x = -20; x <= 20; x++) {
			for (int y = -20; y <= 20; y++) {

				RenderObject tri;
				tri.mesh = get_mesh("triangle");
				tri.material = get_material("defaultmesh");
				glm::mat4 translation = glm::translate(glm::mat4{ 1.0 }, glm::vec3(x, 0, y));
				glm::mat4 scale = glm::scale(glm::mat4{ 1.0 }, glm::vec3(0.2, 0.2, 0.2));
				tri.transformMatrix = translation * scale;

				_renderables.push_back(tri);
			}
		}


		Material* texturedMat=	get_material("texturedmesh");

		VkDescriptorSetAllocateInfo allocInfo = {};
		allocInfo.pNext = nullptr;
		allocInfo.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO;
		allocInfo.descriptorPool = _descriptorPool;
		allocInfo.descriptorSetCount = 1;
		allocInfo.pSetLayouts = &_singleTextureSetLayout;

		vkAllocateDescriptorSets(_device, &allocInfo, &texturedMat->textureSet);

		VkSamplerCreateInfo samplerInfo = vkinit::sampler_create_info(VK_FILTER_NEAREST);

		VkSampler blockySampler;
		vkCreateSampler(_device, &samplerInfo, nullptr, &blockySampler);

		_mainDeletionQueue.push_function([=]() {
			vkDestroySampler(_device, blockySampler, nullptr);
		});

		VkDescriptorImageInfo imageBufferInfo;
		imageBufferInfo.sampler = blockySampler;
		imageBufferInfo.imageView = _loadedTextures["empire_diffuse"].imageView;
		imageBufferInfo.imageLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;

		VkWriteDescriptorSet texture1 = vkinit::write_descriptor_image(VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, texturedMat->textureSet, &imageBufferInfo, 0);

		vkUpdateDescriptorSets(_device, 1, &texture1, 0, nullptr);
	}
	*/

	AllocatedBuffer VulkanEngine::create_buffer(size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage)
	{
		//allocate vertex buffer
		VkBufferCreateInfo bufferInfo = {};
		bufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
		bufferInfo.pNext = nullptr;
		bufferInfo.size = allocSize;

		bufferInfo.usage = usage;


		//let the VMA library know that this data should be writeable by CPU, but also readable by GPU
		VmaAllocationCreateInfo vmaallocInfo = {};
		vmaallocInfo.usage = memoryUsage;

		AllocatedBuffer newBuffer;

		//allocate the buffer
		VK_CHECK(vmaCreateBuffer(_allocator, &bufferInfo, &vmaallocInfo,
			&newBuffer._buffer,
			&newBuffer._allocation,
			nullptr));

		return newBuffer;
	}

	size_t VulkanEngine::pad_uniform_buffer_size(size_t originalSize)
	{
		// Calculate required alignment based on minimum device offset alignment
		size_t minUboAlignment = _gpuProperties.limits.minUniformBufferOffsetAlignment;
		size_t alignedSize = originalSize;
		if (minUboAlignment > 0) {
			alignedSize = (alignedSize + minUboAlignment - 1) & ~(minUboAlignment - 1);
		}
		return alignedSize;
	}


	void VulkanEngine::immediate_submit(std::function<void(VkCommandBuffer cmd)>&& function)
	{
		VkCommandBuffer cmd;

		//allocate the default command buffer that we will use for rendering
		VkCommandBufferAllocateInfo cmdAllocInfo = vkinit::command_buffer_allocate_info(_uploadContext._commandPool, 1);

		VK_CHECK(vkAllocateCommandBuffers(_device, &cmdAllocInfo, &cmd));

		//begin the command buffer recording. We will use this command buffer exactly once, so we want to let vulkan know that
		VkCommandBufferBeginInfo cmdBeginInfo = vkinit::command_buffer_begin_info(VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT);

		VK_CHECK(vkBeginCommandBuffer(cmd, &cmdBeginInfo));


		function(cmd);


		VK_CHECK(vkEndCommandBuffer(cmd));

		VkSubmitInfo submit = vkinit::submit_info(&cmd);


		//submit command buffer to the queue and execute it.
		// _renderFence will now block until the graphic commands finish execution
		VK_CHECK(vkQueueSubmit(_graphicsQueue, 1, &submit, _uploadContext._uploadFence));

		vkWaitForFences(_device, 1, &_uploadContext._uploadFence, true, 9999999999);
		vkResetFences(_device, 1, &_uploadContext._uploadFence);

		vkResetCommandPool(_device, _uploadContext._commandPool, 0);
	}

	void VulkanEngine::init_descriptors()
	{

		//create a descriptor pool that will hold 10 uniform buffers
		std::vector<VkDescriptorPoolSize> sizes =
		{
			{ VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, 10 },
			{ VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, 10 },
			{ VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, 10 },
			{ VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, 10 }
		};

		VkDescriptorPoolCreateInfo pool_info = {};
		pool_info.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO;
		pool_info.flags = 0;
		pool_info.maxSets = 10;
		pool_info.poolSizeCount = (uint32_t)sizes.size();
		pool_info.pPoolSizes = sizes.data();
	
		vkCreateDescriptorPool(_device, &pool_info, nullptr, &_descriptorPool);	
	
		VkDescriptorSetLayoutBinding cameraBind = vkinit::descriptorset_layout_binding(VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER,VK_SHADER_STAGE_VERTEX_BIT,0);
		VkDescriptorSetLayoutBinding sceneBind = vkinit::descriptorset_layout_binding(VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, VK_SHADER_STAGE_VERTEX_BIT | VK_SHADER_STAGE_FRAGMENT_BIT, 1);
	
		VkDescriptorSetLayoutBinding bindings[] = { cameraBind,sceneBind };

		VkDescriptorSetLayoutCreateInfo setinfo = {};
		setinfo.bindingCount = 2;
		setinfo.flags = 0;
		setinfo.pNext = nullptr;
		setinfo.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO;
		setinfo.pBindings = bindings;

		vkCreateDescriptorSetLayout(_device, &setinfo, nullptr, &_globalSetLayout);

		VkDescriptorSetLayoutBinding objectBind = vkinit::descriptorset_layout_binding(VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_VERTEX_BIT, 0);

		VkDescriptorSetLayoutCreateInfo set2info = {};
		set2info.bindingCount = 1;
		set2info.flags = 0;
		set2info.pNext = nullptr;
		set2info.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO;
		set2info.pBindings = &objectBind;

		vkCreateDescriptorSetLayout(_device, &set2info, nullptr, &_objectSetLayout);

		VkDescriptorSetLayoutBinding textureBind = vkinit::descriptorset_layout_binding(VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, VK_SHADER_STAGE_FRAGMENT_BIT, 0);

		VkDescriptorSetLayoutCreateInfo set3info = {};
		set3info.bindingCount = 1;
		set3info.flags = 0;
		set3info.pNext = nullptr;
		set3info.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO;
		set3info.pBindings = &textureBind;

		vkCreateDescriptorSetLayout(_device, &set3info, nullptr, &_singleTextureSetLayout);


		const size_t sceneParamBufferSize = FRAME_OVERLAP * pad_uniform_buffer_size(sizeof(GPUSceneData));

		_sceneParameterBuffer = create_buffer(sceneParamBufferSize, VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);
	

		for (int i = 0; i < FRAME_OVERLAP; i++)
		{
			_frames[i].cameraBuffer = create_buffer(sizeof(Camera::GPUCameraData), VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);

			const int MAX_OBJECTS = 1;
			_frames[i].objectBuffer = create_buffer(sizeof(GPUObjectData) * MAX_OBJECTS, VK_BUFFER_USAGE_STORAGE_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);

			VkDescriptorSetAllocateInfo allocInfo = {};
			allocInfo.pNext = nullptr;
			allocInfo.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO;
			allocInfo.descriptorPool = _descriptorPool;
			allocInfo.descriptorSetCount = 1;
			allocInfo.pSetLayouts = &_globalSetLayout;

			vkAllocateDescriptorSets(_device, &allocInfo, &_frames[i].globalDescriptor);

			VkDescriptorSetAllocateInfo objectSetAlloc = {};
			objectSetAlloc.pNext = nullptr;
			objectSetAlloc.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO;
			objectSetAlloc.descriptorPool = _descriptorPool;
			objectSetAlloc.descriptorSetCount = 1;
			objectSetAlloc.pSetLayouts = &_objectSetLayout;

			vkAllocateDescriptorSets(_device, &objectSetAlloc, &_frames[i].objectDescriptor);

			VkDescriptorBufferInfo cameraInfo;
			cameraInfo.buffer = _frames[i].cameraBuffer._buffer;
			cameraInfo.offset = 0;
			cameraInfo.range = sizeof(Camera::GPUCameraData);

			VkDescriptorBufferInfo sceneInfo;
			sceneInfo.buffer = _sceneParameterBuffer._buffer;
			sceneInfo.offset = 0;
			sceneInfo.range = sizeof(GPUSceneData);

			VkDescriptorBufferInfo objectBufferInfo;
			objectBufferInfo.buffer = _frames[i].objectBuffer._buffer;
			objectBufferInfo.offset = 0;
			objectBufferInfo.range = sizeof(GPUObjectData) * MAX_OBJECTS;


			VkWriteDescriptorSet cameraWrite = vkinit::write_descriptor_buffer(VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, _frames[i].globalDescriptor,&cameraInfo,0);
		
			VkWriteDescriptorSet sceneWrite = vkinit::write_descriptor_buffer(VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, _frames[i].globalDescriptor, &sceneInfo, 1);

			VkWriteDescriptorSet objectWrite = vkinit::write_descriptor_buffer(VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, _frames[i].objectDescriptor, &objectBufferInfo, 0);

			VkWriteDescriptorSet setWrites[] = { cameraWrite,sceneWrite,objectWrite };

			vkUpdateDescriptorSets(_device, 3, setWrites, 0, nullptr);
		}


		_mainDeletionQueue.push_function([&]() {

			vmaDestroyBuffer(_allocator, _sceneParameterBuffer._buffer, _sceneParameterBuffer._allocation);

			vkDestroyDescriptorSetLayout(_device, _objectSetLayout, nullptr);
			vkDestroyDescriptorSetLayout(_device, _globalSetLayout, nullptr);
			vkDestroyDescriptorSetLayout(_device, _singleTextureSetLayout, nullptr);

			vkDestroyDescriptorPool(_device, _descriptorPool, nullptr);

			for (int i = 0; i < FRAME_OVERLAP; i++)
			{
				vmaDestroyBuffer(_allocator, _frames[i].cameraBuffer._buffer, _frames[i].cameraBuffer._allocation);

				vmaDestroyBuffer(_allocator, _frames[i].objectBuffer._buffer, _frames[i].objectBuffer._allocation);
			}
		});
	}

	void VulkanEngine::addOrInsert(std::string materialName, RenderObject& ro)
	{
		auto it = _renderBuckets.find(materialName);
		if (it != _renderBuckets.end())
		{
			// add render object to the bucket
			it->second.renderObjects.emplace_back(ro);
		}
		else
		{
            // new bucket!
			RenderBucket* rb = create_material(_texPipeline, _texturedPipeLayout, materialName);
			rb->renderObjects.emplace_back(ro);
        }
	}
}