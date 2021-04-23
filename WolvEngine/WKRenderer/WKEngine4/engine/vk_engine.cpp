#define _USE_MATH_DEFINES
#include <cmath>

#include "vk_engine.h"

#include <vk_types.h>
#include <vk_initializers.h>
#include <vk_descriptors.h>

#include "VulkanInitializers.hpp"

#include <iostream>
#include <fstream>
#include <chrono>
#include <sstream>
#include "vk_textures.h"
#include "vk_shaders.h"

#define VMA_IMPLEMENTATION
#include "vma/vk_mem_alloc.h"

#include "imgui/imgui.h"
#include "imgui/imgui_impl_vulkan.h"

#include "cr2w/hashdictionary.h"
#include "cr2w/bundledictionary.h"
#include "cr2w/bundlemanager.h"
#include "cr2w/cr2wModel.h"
#include "fbx/fbxModel.h"
#include "resourcepath.h"

#include "fmt/core.h"
#include "fmt/os.h"
#include "fmt/color.h"

#ifdef USE_LOG
#include "logger.h"
#else
#define LOG_FATAL(message,...)
#define LOG_ERROR(message,...)
#define LOG_INFO(message,...)
#define LOG_WARNING(message,...)
#define LOG_SUCCESS(message,...)
#endif

#include <filesystem>
namespace fs = std::filesystem;

//#define DUMPOBJ
#ifdef DUMPOBJ
void DumpOBJ(std::string filename, MeshObject& mo)
{
    FILE* fp = nullptr;
    fopen_s(&fp, filename.c_str(), "wt");
    if (fp == nullptr)
        return;

    fprintf(fp, "# %d vertices, %d indices\n", (uint32_t)mo.mesh->_vertices.size(), (uint32_t)mo.mesh->_indices.size());

    for (size_t i = 0; i < mo.mesh->_vertices.size(); ++i)
    {
        glm::vec4 v = mo.transformMatrix * glm::vec4(mo.mesh->_vertices[i].position, 1.0f);

        fprintf(fp, "v %g %g %g\n", v.x, v.y, v.z);
        //fprintf(fp, "vt %g %g\n", vertices[i].uv.x, vertices[i].uv.y);
        //fprintf(fp, "vn %g %g %g\n", vertices[i].normal.x, vertices[i].normal.y, vertices[i].normal.z);
    }

    for (size_t i = 0; i < mo.mesh->_indices.size();)
    {
        uint16_t v0 = mo.mesh->_indices[i++] + 1;
        uint16_t v1 = mo.mesh->_indices[i++] + 1;
        uint16_t v2 = mo.mesh->_indices[i++] + 1;
        //fprintf(fp, "f %d/%d/%d %d/%d/%d %d/%d/%d\n", v0, v0, v0, v1, v1, v1, v2, v2, v2);
        fprintf(fp, "f %d %d %d\n", v0, v1, v2);
    }

    fclose(fp);
}
#endif

#ifdef _DEBUG
constexpr bool bUseValidationLayers = true;
#else
constexpr bool bUseValidationLayers = false;
#endif

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


#ifdef USE_MULTISAMPLING
uint32_t getMemoryType(VkPhysicalDeviceMemoryProperties memoryProperties, uint32_t typeBits, VkMemoryPropertyFlags properties, VkBool32& found)
{
	found = false;
    for (uint32_t i = 0; i < memoryProperties.memoryTypeCount; i++)
    {
        if ((typeBits & 1) == 1)
        {
            if ((memoryProperties.memoryTypes[i].propertyFlags & properties) == properties)
            {
				found = true;
                return i;
            }
        }
        typeBits >>= 1;
    }

	return 0;
}
#endif

void VulkanEngine::init(HINSTANCE hInstance, HWND hWnd, uint32_t width, uint32_t height, const std::string& asset)
{
    _windowExtent.width = width;
    _windowExtent.height = height;

    setupWindow(hInstance, hWnd);

    //LogHandler::Get().set_time();

    LOG_INFO("Engine Init");

    init_vulkan();

#ifdef USE_MULTITHREADING
#ifdef OPT1
    _numThreads = std::thread::hardware_concurrency();
    //_numThreads = 4;
    //_numThreads = 2;
#else
    _numThreads = 1;
#endif
    _threadPool.setThreadCount(_numThreads);
#endif

    _shaderCache.init(_device);
    _renderScene.init();

    init_swapchain();

    init_forward_renderpass();
#ifndef USE_MULTITHREADING
    init_copy_renderpass();
#endif
#ifdef USE_PICKING
    init_pick_renderpass();
#endif

    init_framebuffers();

    init_commands();

    init_sync_structures();

    init_descriptors();

    init_pipelines();
    init_imgui();

    LOG_INFO("Engine Initialized, starting Load: {}", asset.c_str());

    load_images();
    init_scene(asset);

    _renderScene.build_batches();
    _renderScene.merge_meshes(this);
    //everything went fine
    _isInitialized = true;

    constexpr float RADIANS_TO_DEGREES = (float)(180.0 / M_PI);

    _camera = {};
    //_camera.type = Camera::lookat;
    _camera.type = Camera::firstperson;
    _camera.flipY = true;
    _camera.setPerspective(70.0f, (float)_windowExtent.width / (float)_windowExtent.height, 50000.0f, 0.1f);
    _camera.setPosition(glm::vec3(0.f, 1000.f, 5.f));
    _camera.setRotationSpeed(0.5f);
    _camera.setMovementSpeed(20.0f);

    _mainLight.lightPosition = { 0,0,0 };
    _mainLight.lightDirection = glm::vec3(0.3, -1, 0.3);
    _mainLight.shadowExtent = { 100 ,100 ,100 };

    _clearValue.color = { { 0.6f, 1.0f, 1.0f, 1.0f } };
    _depthClear.depthStencil.depth = 0.f;
}

void VulkanEngine::cleanup()
{
	if (_isInitialized) {

		//make sure the gpu has stopped doing its things
#ifdef USE_MULTITHREADING
		vkWaitForFences(_device, 1, &_renderFence, true, 1000000000);
#else
		for (auto& frame : _frames)
		{
			vkWaitForFences(_device, 1, &frame._renderFence, true, 1000000000);
		}
#endif
        _mainDeletionQueue.flush();

		vkDestroyCommandPool(_device, _primaryCommandPool, nullptr);
		vkDestroyCommandPool(_device, _threadCommandPool, nullptr);
		vkDestroyCommandPool(_device, _uploadContext._commandPool, nullptr);
		vkDestroyCommandPool(_device, _guiCommandPool, nullptr);

		for (size_t i = 0; i < _framebuffers.size(); i++)
		{
			vkDestroyFramebuffer(_device, _framebuffers[i], nullptr);
		}

		_shaderCache.clear();
		_materialSystem->cleanup();
		delete _materialSystem;

		for (auto& m : _meshes)
		{
			vmaDestroyBuffer(_allocator, m._vertexBuffer._buffer, m._vertexBuffer._allocation);
			vmaDestroyBuffer(_allocator, m._indexBuffer._buffer, m._indexBuffer._allocation);
		}

#ifdef USE_MULTISAMPLING
        vkDestroyImage(_device, _multisampleImage.image, nullptr);
        vkDestroyImageView(_device, _multisampleImage.view, nullptr);
        vkFreeMemory(_device, _multisampleImage.memory, nullptr);
#endif
        vkDestroySampler(_device, _depthSampler, nullptr);
        vkDestroyImageView(_device, _depthPyramid._defaultView, nullptr);
        vmaDestroyImage(_allocator, _depthPyramid._image, _depthPyramid._allocation);
        vkDestroyImageView(_device, _depthImage._defaultView, nullptr);
        vmaDestroyImage(_allocator, _depthImage._image, _depthImage._allocation);

#ifdef USE_MULTITHREADING
		_dynamicDescriptorAllocator->cleanup();
#else
		for (auto& frame : _frames)
		{
			frame.dynamicDescriptorAllocator->cleanup();
		}
#endif

		_descriptorAllocator->cleanup();
		_descriptorLayoutCache->cleanup();

		_gui.freeResources();

        //for (auto& im : _swapchainImages)
        //{
        //    vkDestroyImage(_device, im, nullptr);
        //}
        //for (auto& im : _swapchainImageViews)
        //{
        //    vkDestroyImageView(_device, im, nullptr);
        //}

        vkDestroySwapchainKHR(_device, _swapchain, nullptr);
        vkDestroySurfaceKHR(_instance, _surface, nullptr);

		vkDestroyDevice(_device, nullptr);

		vkb::destroy_instance(vkb_inst);
	}
}

#ifdef USE_MULTITHREADING
void VulkanEngine::updateCommandBuffers(VkFramebuffer frameBuffer)
{
    std::vector<VkCommandBuffer> commandBuffers;

    //begin the command buffer recording. We will use this command buffer exactly once, so we want to let vulkan know that
    VkCommandBufferBeginInfo cmdBeginInfo = vkinit::command_buffer_begin_info();
    // primary buffer
    VK_CHECK(vkBeginCommandBuffer(_primaryCommandBuffer, &cmdBeginInfo));

    {
        postCullBarriers.clear();
        cullReadyBarriers.clear();

        ready_mesh_draw(_primaryCommandBuffer);
        ready_cull_data(_renderScene._forwardPass, _primaryCommandBuffer);
        vkCmdPipelineBarrier(_primaryCommandBuffer, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_PIPELINE_STAGE_COMPUTE_SHADER_BIT, 0, 0, nullptr, (uint32_t)cullReadyBarriers.size(), cullReadyBarriers.data(), 0, nullptr);


        {
            CullParams forwardCull;
            forwardCull.projmat = _camera.matrices.perspective;
            forwardCull.viewmat = _camera.matrices.view;
            forwardCull.frustrumCull = true;
            forwardCull.occlusionCull = false;
            forwardCull.drawDist = 500000;

            execute_compute_cull(_primaryCommandBuffer, _renderScene._forwardPass, forwardCull);
        }

        vkCmdPipelineBarrier(_primaryCommandBuffer, VK_PIPELINE_STAGE_COMPUTE_SHADER_BIT, VK_PIPELINE_STAGE_DRAW_INDIRECT_BIT, 0, 0, nullptr, (uint32_t)postCullBarriers.size(), postCullBarriers.data(), 0, nullptr);

#ifdef USE_MULTISAMPLING
		VkClearValue clearValues[] = { _clearValue, _clearValue, _depthClear };
#else
		VkClearValue clearValues[] = { _clearValue, _depthClear };
#endif

        //start the main renderpass. 
        //We will use the clear color from above, Fand the framebuffer of the index the swapchain gave us
        VkRenderPassBeginInfo rpInfo = vkinit::renderpass_begin_info(_renderPass, _windowExtent, frameBuffer);

        //connect clear values        
#ifdef USE_MULTISAMPLING
		rpInfo.clearValueCount = 3;
#else
        rpInfo.clearValueCount = 2;
#endif
        rpInfo.pClearValues = &clearValues[0];

        vkCmdBeginRenderPass(_primaryCommandBuffer, &rpInfo, VK_SUBPASS_CONTENTS_SECONDARY_COMMAND_BUFFERS);

        // Inheritance info for the secondary command buffers
        VkCommandBufferInheritanceInfo inheritanceInfo = vks::initializers::commandBufferInheritanceInfo();
        inheritanceInfo.renderPass = _renderPass;
        // Secondary command buffer also use the currently active framebuffer
        inheritanceInfo.framebuffer = frameBuffer;

        update_secondaryBuffers(inheritanceInfo);

#ifdef OPT1
		prep_draw_objects(_renderScene._forwardPass);

		uint32_t start = 0;
		uint32_t nBatchSize = (uint32_t)_renderScene._forwardPass.multibatches.size() / _numThreads;
		uint32_t nLastBatchSize = nBatchSize + (uint32_t)_renderScene._forwardPass.multibatches.size() - (nBatchSize * _numThreads);

        for (uint32_t t = 0; t < _numThreads - 1; ++t)
        {
            _threadPool.threads[t]->addJob([=] { threadRenderCode(t, start, start + nBatchSize, inheritanceInfo); });
			start += nBatchSize;
        }
		uint32_t lastThreadIndex = _numThreads - 1;
		_threadPool.threads[lastThreadIndex]->addJob([=] { threadRenderCode(lastThreadIndex, start, start + nLastBatchSize, inheritanceInfo); });
#else
		_threadPool.threads[0]->addJob([=] { threadRenderCode(0, 0, 0, inheritanceInfo); });
#endif

		_threadPool.wait();

#ifdef OPT1
		for (uint32_t t = 0; t < _numThreads; ++t)
		{
			commandBuffers.push_back(_threadData[t].commandBuffer);
		}
#else
		commandBuffers.push_back(_threadCommandBuffer);
#endif
		commandBuffers.push_back(_guiCommandBuffer);

        vkCmdExecuteCommands(_primaryCommandBuffer, (uint32_t)commandBuffers.size(), commandBuffers.data());

        //finalize the render pass
        vkCmdEndRenderPass(_primaryCommandBuffer);
    }

    //finalize the command buffer (we can no longer add commands, but it can now be executed)
    VK_CHECK(vkEndCommandBuffer(_primaryCommandBuffer));

}

void VulkanEngine::draw()
{
    VkResult fenceRes;
    do { fenceRes = vkWaitForFences(_device, 1, &_renderFence, VK_TRUE, 100000000); } while (fenceRes == VK_TIMEOUT);
    VK_CHECK(fenceRes);
    vkResetFences(_device, 1, &_renderFence);
	_dynamicData.reset();

	_renderScene.build_batches();

    _frameDeletionQueue.flush();
    _dynamicDescriptorAllocator->reset_pools();

    VK_CHECK(vkResetCommandBuffer(_primaryCommandBuffer, 0));
    
    uint32_t swapchainImageIndex;
    {
        //request image from the swapchain
        VK_CHECK(vkAcquireNextImageKHR(_device, _swapchain, 0, _presentSemaphore, nullptr, &swapchainImageIndex));
    }

    updateCommandBuffers(_framebuffers[swapchainImageIndex]);

	//TODO assign once ====================
    VkSubmitInfo submit = vkinit::submit_info(&_primaryCommandBuffer);
	
	submit.pWaitDstStageMask = &_waitStage;

    submit.waitSemaphoreCount = 1;
    submit.pWaitSemaphores = &_presentSemaphore;

    submit.signalSemaphoreCount = 1;
    submit.pSignalSemaphores = &_renderSemaphore;
	//======================================

    //submit command buffer to the queue and execute it.
    // _renderFence will now block until the graphic commands finish execution
    VK_CHECK(vkQueueSubmit(_graphicsQueue, 1, &submit, _renderFence));

    VkPresentInfoKHR presentInfo = vkinit::present_info();

    presentInfo.pSwapchains = &_swapchain;
    presentInfo.swapchainCount = 1;

    presentInfo.pWaitSemaphores = &_renderSemaphore;
    presentInfo.waitSemaphoreCount = 1;

    presentInfo.pImageIndices = &swapchainImageIndex;

    VK_CHECK(vkQueuePresentKHR(_graphicsQueue, &presentInfo));
}
#else
void VulkanEngine::draw()
{	
    VkClearValue clearValues[] = { _clearValue, _depthClear };

	{
		//wait until the gpu has finished rendering the last frame. Timeout of 1 second
		VK_CHECK(vkWaitForFences(_device, 1, &get_current_frame()._renderFence, true, 1000000000));
		VK_CHECK(vkResetFences(_device, 1, &get_current_frame()._renderFence));

		get_current_frame().dynamicData.reset();

		_renderScene.build_batches();
	}

	get_current_frame()._frameDeletionQueue.flush();
	get_current_frame().dynamicDescriptorAllocator->reset_pools();

	//now that we are sure that the commands finished executing, we can safely reset the command buffer to begin recording again.
	VK_CHECK(vkResetCommandBuffer(get_current_frame()._mainCommandBuffer, 0));
	////VK_CHECK(vkResetCommandBuffer(_primaryCommandBuffer, 0));
	uint32_t swapchainImageIndex;
	{
		//request image from the swapchain
		VK_CHECK(vkAcquireNextImageKHR(_device, _swapchain, 0, get_current_frame()._presentSemaphore, nullptr, &swapchainImageIndex));

	}

	std::vector<VkCommandBuffer> commandBuffers;

	//naming it cmd for shorter writing
	VkCommandBuffer cmd = get_current_frame()._mainCommandBuffer;

	//begin the command buffer recording. We will use this command buffer exactly once, so we want to let vulkan know that
	VkCommandBufferBeginInfo cmdBeginInfo = vkinit::command_buffer_begin_info(VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT);
	// primary buffer
	VK_CHECK(vkBeginCommandBuffer(cmd, &cmdBeginInfo));

	{
		postCullBarriers.clear();
		cullReadyBarriers.clear();

		{
			ready_mesh_draw(cmd);
			ready_cull_data(_renderScene._forwardPass, cmd);
			vkCmdPipelineBarrier(cmd, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_PIPELINE_STAGE_COMPUTE_SHADER_BIT, 0, 0, nullptr, (uint32_t)cullReadyBarriers.size(), cullReadyBarriers.data(), 0, nullptr);
		}


		{
			CullParams forwardCull;
			forwardCull.projmat = _camera.matrices.perspective;
			forwardCull.viewmat = _camera.matrices.view;
			forwardCull.frustrumCull = true;
			forwardCull.occlusionCull = false;
			forwardCull.drawDist = 500000;

			execute_compute_cull(cmd, _renderScene._forwardPass, forwardCull);
		}

		vkCmdPipelineBarrier(cmd, VK_PIPELINE_STAGE_COMPUTE_SHADER_BIT, VK_PIPELINE_STAGE_DRAW_INDIRECT_BIT, 0, 0, nullptr, (uint32_t)postCullBarriers.size(), postCullBarriers.data(), 0, nullptr);

        //start the main renderpass. 
        //We will use the clear color from above, and the framebuffer of the index the swapchain gave us
        VkRenderPassBeginInfo rpInfo = vkinit::renderpass_begin_info(_renderPass, _windowExtent, _forwardFramebuffer/*_framebuffers[swapchainImageIndex]*/);

        //connect clear values        
		rpInfo.clearValueCount = 2;
        rpInfo.pClearValues = &clearValues[0];

        vkCmdBeginRenderPass(cmd, &rpInfo, VK_SUBPASS_CONTENTS_INLINE);

		forward_pass(cmd);

        //finalize the render pass
		vkCmdEndRenderPass(cmd);

		copy_render_to_swapchain(swapchainImageIndex, cmd);
	}

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
	{
		//submit command buffer to the queue and execute it.
		// _renderFence will now block until the graphic commands finish execution
		VK_CHECK(vkQueueSubmit(_graphicsQueue, 1, &submit, get_current_frame()._renderFence));

	}
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

	//increase the number of frames drawn
	_frameNumber++;
}
#endif

void VulkanEngine::forward_pass(VkCommandBuffer cmd)
{
	VkViewport viewport;
	viewport.x = 0.0f;
	viewport.y = 0.0f;
	viewport.width = (float)_windowExtent.width;
	viewport.height = (float)_windowExtent.height;
	viewport.minDepth = 0.0f;
	viewport.maxDepth = 1.0f;

	VkRect2D scissor;
	scissor.offset = { 0, 0 };
	scissor.extent = _windowExtent;

	vkCmdSetViewport(cmd, 0, 1, &viewport);
	vkCmdSetScissor(cmd, 0, 1, &scissor);
	vkCmdSetDepthBias(cmd, 0, 0, 0);

	draw_objects_forward(cmd, _renderScene._forwardPass);
}

#ifdef OPT1
void VulkanEngine::forward_pass(VkCommandBuffer cmd, uint32_t start, uint32_t count)
{
    VkViewport viewport;
    viewport.x = 0.0f;
    viewport.y = 0.0f;
    viewport.width = (float)_windowExtent.width;
    viewport.height = (float)_windowExtent.height;
    viewport.minDepth = 0.0f;
    viewport.maxDepth = 1.0f;

    VkRect2D scissor;
    scissor.offset = { 0, 0 };
    scissor.extent = _windowExtent;

    vkCmdSetViewport(cmd, 0, 1, &viewport);
    vkCmdSetScissor(cmd, 0, 1, &scissor);
    vkCmdSetDepthBias(cmd, 0, 0, 0);

    draw_objects_forward(cmd, _renderScene._forwardPass, start, count);
}
#endif

#ifndef USE_MULTITHREADING
void VulkanEngine::copy_render_to_swapchain(uint32_t swapchainImageIndex, VkCommandBuffer cmd)
{
	//start the main renderpass. 
	//We will use the clear color from above, and the framebuffer of the index the swapchain gave us
	VkRenderPassBeginInfo copyRP = vkinit::renderpass_begin_info(_copyPass, _windowExtent, _framebuffers[swapchainImageIndex]);


	vkCmdBeginRenderPass(cmd, &copyRP, VK_SUBPASS_CONTENTS_INLINE);

	VkViewport viewport;
	viewport.x = 0.0f;
	viewport.y = 0.0f;
	viewport.width = (float)_windowExtent.width;
	viewport.height = (float)_windowExtent.height;
	viewport.minDepth = 0.0f;
	viewport.maxDepth = 1.0f;

	VkRect2D scissor;
	scissor.offset = { 0, 0 };
	scissor.extent = _windowExtent;

	vkCmdSetViewport(cmd, 0, 1, &viewport);
	vkCmdSetScissor(cmd, 0, 1, &scissor);

	vkCmdSetDepthBias(cmd, 0, 0, 0);

	vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _blitPipeline);

	VkDescriptorImageInfo sourceImage;
	sourceImage.sampler = _smoothSampler;

	sourceImage.imageView = _rawRenderImage._defaultView;
	sourceImage.imageLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;

	VkDescriptorSet blitSet;
	vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, get_current_frame().dynamicDescriptorAllocator)
		.bind_image(0, &sourceImage, VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, VK_SHADER_STAGE_FRAGMENT_BIT)
		.build(blitSet);

	vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, _blitLayout, 0, 1, &blitSet, 0, nullptr);

	vkCmdDraw(cmd, 3, 1, 0, 0);

	vkCmdEndRenderPass(cmd);
}
#endif

void VulkanEngine::run()
{
	MSG msg;
    bool quitMessageReceived = false;
    while (!quitMessageReceived)
	{
        while (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
            TranslateMessage(&msg);
            DispatchMessage(&msg);
            if (msg.message == WM_QUIT)
			{
                quitMessageReceived = true;
                break;
            }
        }

		if (_isInitialized && !IsIconic(_window) && !quitMessageReceived)
		{			
			auto tStart = std::chrono::high_resolution_clock::now();

			draw();

			auto tEnd = std::chrono::high_resolution_clock::now();
			auto tDiff = std::chrono::duration<double, std::milli>(tEnd - tStart).count();
			_frameTimer = (float)tDiff / 1000.0f;
			_camera.update(_frameTimer);

			_mainLight.lightPosition = _camera.getPosition();

            ++_frameCounter;

			float fpsTimer = (float)(std::chrono::duration<double, std::milli>(tEnd - _lastTimestamp).count());
			if (fpsTimer > 1000.0f)
			{
				_lastFPS = static_cast<uint32_t>((float)_frameCounter * (1000.0f / fpsTimer));
                _frameCounter = 0;
                _lastTimestamp = tEnd;
			}

			update_overlay();
		}
    }
}

#ifndef USE_MULTITHREADING
FrameData& VulkanEngine::get_current_frame()
{
	return _frames[_frameNumber % FRAME_OVERLAP];
}

FrameData& VulkanEngine::get_last_frame()
{
	return _frames[(_frameNumber - 1) % 2];
}
#endif

void VulkanEngine::init_vulkan()
{
	
	vkb::InstanceBuilder builder;
	//make the vulkan instance, with basic debug features
	auto inst_ret = builder.set_app_name(_title.c_str())
		.request_validation_layers(bUseValidationLayers)
#ifdef _DEBUG
		.use_default_debug_messenger()
#endif
		.build();


	LOG_SUCCESS("Vulkan Instance initialized");

	vkb_inst = inst_ret.value();

	//grab the instance 
	_instance = vkb_inst.instance;

    VkWin32SurfaceCreateInfoKHR surfaceCreateInfo = {};
    surfaceCreateInfo.sType = VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR;
    surfaceCreateInfo.hinstance = _windowInstance;
    surfaceCreateInfo.hwnd = _window;

    vkCreateWin32SurfaceKHR(_instance, &surfaceCreateInfo, nullptr, &_surface);

	//use vkbootstrap to select a gpu. 
	vkb::PhysicalDeviceSelector selector{ vkb_inst };
	VkPhysicalDeviceFeatures feats{};

	//feats.pipelineStatisticsQuery = true;
	feats.multiDrawIndirect = true;
	feats.drawIndirectFirstInstance = true;
	feats.samplerAnisotropy = true;
#ifdef USE_MULTISAMPLING
	feats.sampleRateShading = true;
#endif
	selector.set_required_features(feats);

	vkb::PhysicalDevice physicalDevice = selector
		.set_minimum_version(1, 1)
		.set_surface(_surface)
		.add_required_extension(VK_EXT_SAMPLER_FILTER_MINMAX_EXTENSION_NAME)		
		.select()
		.value();

	LOG_SUCCESS("GPU found");

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
	
	vkGetPhysicalDeviceProperties(_chosenGPU, &_gpuProperties);
	vkGetPhysicalDeviceMemoryProperties(_chosenGPU, &_memProperties);

#ifdef USE_MULTISAMPLING
    VkSampleCountFlags counts = _gpuProperties.limits.framebufferColorSampleCounts & _gpuProperties.limits.framebufferDepthSampleCounts;
    if (counts & VK_SAMPLE_COUNT_64_BIT) { _msaaSamples = VK_SAMPLE_COUNT_64_BIT; }
    else if (counts & VK_SAMPLE_COUNT_32_BIT) { _msaaSamples = VK_SAMPLE_COUNT_32_BIT; }
	else if (counts & VK_SAMPLE_COUNT_16_BIT) { _msaaSamples = VK_SAMPLE_COUNT_16_BIT; }
	else if (counts & VK_SAMPLE_COUNT_8_BIT) { _msaaSamples = VK_SAMPLE_COUNT_8_BIT; }
	else if (counts & VK_SAMPLE_COUNT_4_BIT) { _msaaSamples = VK_SAMPLE_COUNT_4_BIT; }
	else if (counts & VK_SAMPLE_COUNT_2_BIT) { _msaaSamples = VK_SAMPLE_COUNT_2_BIT; }
#endif

	LOG_INFO("The gpu has a minimum buffer alignment of {}", _gpuProperties.limits.minUniformBufferOffsetAlignment);
}

uint32_t previousPow2(uint32_t v)
{
	uint32_t r = 1;

	while (r * 2 < v)
		r *= 2;

	return r;
}

uint32_t getImageMipLevels(uint32_t width, uint32_t height)
{
	uint32_t result = 1;

	while (width > 1 || height > 1)
	{
		result++;
		width /= 2;
		height /= 2;
	}

	return result;
}

void VulkanEngine::init_swapchain()
{
	if (_swapchain != VK_NULL_HANDLE)
	{
#ifdef USE_MULTISAMPLING
        vkDestroyImage(_device, _multisampleImage.image, nullptr);
        vkDestroyImageView(_device, _multisampleImage.view, nullptr);
        vkFreeMemory(_device, _multisampleImage.memory, nullptr);
#endif
        vkDestroySampler(_device, _depthSampler, nullptr);
        vkDestroyImageView(_device, _depthPyramid._defaultView, nullptr);
        vmaDestroyImage(_allocator, _depthPyramid._image, _depthPyramid._allocation);
        vkDestroyImageView(_device, _depthImage._defaultView, nullptr);
        vmaDestroyImage(_allocator, _depthImage._image, _depthImage._allocation);

		vkDestroySwapchainKHR(_device, _swapchain, nullptr);
	}

	vkb::SwapchainBuilder swapchainBuilder{ _chosenGPU,_device,_surface };

	vkb::Swapchain vkbSwapchain = swapchainBuilder
		.use_default_format_selection()
		//use vsync present mode
		.set_desired_present_mode(VK_PRESENT_MODE_MAILBOX_KHR)
		.set_desired_extent(_windowExtent.width, _windowExtent.height)		
		.build()
		.value();

	//store swapchain and its related images
	_swapchain = vkbSwapchain.swapchain;
	_swapchainImages = vkbSwapchain.get_images().value();
	_swapchainImageViews = vkbSwapchain.get_image_views().value();
	_swachainImageFormat = vkbSwapchain.image_format;

#ifndef USE_MULTITHREADING
	//render image
	{
		VkExtent3D renderImageExtent = {
			_windowExtent.width,
			_windowExtent.height,
			1
		};
		_renderFormat = VK_FORMAT_R32G32B32A32_SFLOAT;
		VkImageCreateInfo ri_info = vkinit::image_create_info(_renderFormat, VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT | VK_IMAGE_USAGE_TRANSFER_SRC_BIT| VK_IMAGE_USAGE_SAMPLED_BIT, renderImageExtent);
		ri_info.samples = _msaaSamples;

		//for the image, we want to allocate it from gpu local memory
		VmaAllocationCreateInfo dimg_allocinfo = {};
		dimg_allocinfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;
		dimg_allocinfo.requiredFlags = VkMemoryPropertyFlags(VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT);

		//allocate and create the image
		vmaCreateImage(_allocator, &ri_info, &dimg_allocinfo, &_rawRenderImage._image, &_rawRenderImage._allocation, nullptr);

		//build a image-view for the depth image to use for rendering
		VkImageViewCreateInfo dview_info = vkinit::imageview_create_info(_renderFormat, _rawRenderImage._image, VK_IMAGE_ASPECT_COLOR_BIT);

		VK_CHECK(vkCreateImageView(_device, &dview_info, nullptr, &_rawRenderImage._defaultView));

        //add to deletion queues
        _mainDeletionQueue.push_function([=]() {
            vkDestroyImageView(_device, _rawRenderImage._defaultView, nullptr);
            vmaDestroyImage(_allocator, _rawRenderImage._image, _rawRenderImage._allocation);
            });
	}
#endif

#ifdef USE_MULTISAMPLING
    // Color target
    VkImageCreateInfo info = vks::initializers::imageCreateInfo();
    info.imageType = VK_IMAGE_TYPE_2D;
    info.format = _swachainImageFormat;
    info.extent.width = _windowExtent.width;
    info.extent.height = _windowExtent.height;
    info.extent.depth = 1;
    info.mipLevels = 1;
    info.arrayLayers = 1;
    info.sharingMode = VK_SHARING_MODE_EXCLUSIVE;
    info.tiling = VK_IMAGE_TILING_OPTIMAL;
    info.samples = _msaaSamples;
    // Image will only be used as a transient target
    info.usage = VK_IMAGE_USAGE_TRANSIENT_ATTACHMENT_BIT | VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT;
    info.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;

    VK_CHECK(vkCreateImage(_device, &info, nullptr, &_multisampleImage.image));

    VkMemoryRequirements memReqs;
    vkGetImageMemoryRequirements(_device, _multisampleImage.image, &memReqs);
    VkMemoryAllocateInfo memAlloc = vks::initializers::memoryAllocateInfo();
    memAlloc.allocationSize = memReqs.size;
    // We prefer a lazily allocated memory type
    // This means that the memory gets allocated when the implementation sees fit, e.g. when first using the images
    VkBool32 lazyMemTypePresent;
    memAlloc.memoryTypeIndex = getMemoryType(_memProperties, memReqs.memoryTypeBits, VK_MEMORY_PROPERTY_LAZILY_ALLOCATED_BIT, lazyMemTypePresent);
    if (!lazyMemTypePresent)
    {
        // If this is not available, fall back to device local memory
        memAlloc.memoryTypeIndex = getMemoryType(_memProperties, memReqs.memoryTypeBits, VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT, lazyMemTypePresent);
    }
    VK_CHECK(vkAllocateMemory(_device, &memAlloc, nullptr, &_multisampleImage.memory));
    vkBindImageMemory(_device, _multisampleImage.image, _multisampleImage.memory, 0);

    // Create image view for the MSAA target
    VkImageViewCreateInfo viewInfo = vks::initializers::imageViewCreateInfo();
    viewInfo.image = _multisampleImage.image;
    viewInfo.viewType = VK_IMAGE_VIEW_TYPE_2D;
    viewInfo.format = _swachainImageFormat;
    viewInfo.components.r = VK_COMPONENT_SWIZZLE_R;
    viewInfo.components.g = VK_COMPONENT_SWIZZLE_G;
    viewInfo.components.b = VK_COMPONENT_SWIZZLE_B;
    viewInfo.components.a = VK_COMPONENT_SWIZZLE_A;
    viewInfo.subresourceRange.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
    viewInfo.subresourceRange.levelCount = 1;
    viewInfo.subresourceRange.layerCount = 1;

    VK_CHECK(vkCreateImageView(_device, &viewInfo, nullptr, &_multisampleImage.view));

#endif

	//depth image size will match the window
	VkExtent3D depthImageExtent = {
		_windowExtent.width,
		_windowExtent.height,
		1
	};

	//hardcoding the depth format to 32 bit float
	_depthFormat = VK_FORMAT_D32_SFLOAT;

	//for the depth image, we want to allocate it from gpu local memory
	VmaAllocationCreateInfo dimg_allocinfo = {};
	dimg_allocinfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;
	dimg_allocinfo.requiredFlags = VkMemoryPropertyFlags(VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT);

	// depth image ------ 
	{
		//the depth image will be a image with the format we selected and Depth Attachment usage flag
		VkImageCreateInfo dimg_info = vkinit::image_create_info(_depthFormat, VK_IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT | VK_IMAGE_USAGE_SAMPLED_BIT, depthImageExtent);
		dimg_info.samples = _msaaSamples;

		//allocate and create the image
		vmaCreateImage(_allocator, &dimg_info, &dimg_allocinfo, &_depthImage._image, &_depthImage._allocation, nullptr);

		//build a image-view for the depth image to use for rendering
		VkImageViewCreateInfo dview_info = vkinit::imageview_create_info(_depthFormat, _depthImage._image, VK_IMAGE_ASPECT_DEPTH_BIT);

		VK_CHECK(vkCreateImageView(_device, &dview_info, nullptr, &_depthImage._defaultView));
	}
#ifdef USE_PICKING
    //pick image
    {
        VkExtent3D pickExtent = {
            _windowExtent.width,
            _windowExtent.height,
            1
        };
        
		VkImageCreateInfo pickimg_info = vkinit::image_create_info(VK_FORMAT_R8G8B8A8_UNORM, VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT | VK_IMAGE_USAGE_TRANSFER_SRC_BIT | VK_IMAGE_USAGE_SAMPLED_BIT, pickExtent);

        //allocate and create the image
        vmaCreateImage(_allocator, &pickimg_info, &dimg_allocinfo, &_pickImage._image, &_pickImage._allocation, nullptr);

        //build a image-view for th
        VkImageViewCreateInfo pview_info = vkinit::imageview_create_info(VK_FORMAT_R8G8B8A8_UNORM, _pickImage._image, VK_IMAGE_ASPECT_COLOR_BIT);

        VK_CHECK(vkCreateImageView(_device, &pview_info, nullptr, &_pickImage._defaultView));

        _mainDeletionQueue.push_function([=]() {
            vkDestroyImageView(_device, _pickImage._defaultView, nullptr);
            vmaDestroyImage(_allocator, _pickImage._image, _pickImage._allocation);
            });
    }
#endif

	// Note: previousPow2 makes sure all reductions are at most by 2x2 which makes sure they are conservative
	depthPyramidWidth = previousPow2(_windowExtent.width);
	depthPyramidHeight = previousPow2(_windowExtent.height);
	depthPyramidLevels = getImageMipLevels(depthPyramidWidth, depthPyramidHeight);

	VkExtent3D pyramidExtent = {
		static_cast<uint32_t>(depthPyramidWidth),
		static_cast<uint32_t>(depthPyramidHeight),
		1
	};

	//TODO: investigate this a bit more to see if this validation error can be fully resolved
	//the depth image will be a image with the format we selected and Depth Attachment usage flag
	VkImageCreateInfo pyramidInfo = vkinit::image_create_info(VK_FORMAT_R32_SFLOAT, VK_IMAGE_USAGE_SAMPLED_BIT | VK_IMAGE_USAGE_STORAGE_BIT | VK_IMAGE_USAGE_TRANSFER_SRC_BIT, pyramidExtent);
	pyramidInfo.mipLevels = depthPyramidLevels;
	pyramidInfo.initialLayout = VK_IMAGE_LAYOUT_GENERAL; // VkImageCreateInfo-initialLayout-00993 must be VK_IMAGE_LAYOUT_UNDEFINED or VK_IMAGE_LAYOUT_PREINITIALIZED
	//pyramidInfo.initialLayout = VK_IMAGE_LAYOUT_PREINITIALIZED; // CoreValidation-DrawState-InvalidLayout must be VK_IMAGE_LAYOUT_GENERAL
	//pyramidInfo.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED; // CoreValidation-DrawState-InvalidImageLayout expects VK_IMAGE_LAYOUT_GENERAL instead is VK_IMAGE_LAYOUT_UNDEFINED

	//allocate and create the image
	vmaCreateImage(_allocator, &pyramidInfo, &dimg_allocinfo, &_depthPyramid._image, &_depthPyramid._allocation, nullptr);

	//build a image-view for the depth image to use for rendering
	VkImageViewCreateInfo priview_info = vkinit::imageview_create_info(VK_FORMAT_R32_SFLOAT, _depthPyramid._image, VK_IMAGE_ASPECT_COLOR_BIT);
	priview_info.subresourceRange.levelCount = depthPyramidLevels;

	VK_CHECK(vkCreateImageView(_device, &priview_info, nullptr, &_depthPyramid._defaultView));

	//for (int32_t i = 0; i < depthPyramidLevels; ++i)
	//{
	//	VkImageViewCreateInfo level_info = vkinit::imageview_create_info(VK_FORMAT_R32_SFLOAT, _depthPyramid._image, VK_IMAGE_ASPECT_COLOR_BIT);
	//	level_info.subresourceRange.levelCount = 1;
	//	level_info.subresourceRange.baseMipLevel = i;

	//	VkImageView pyramid;
	//	vkCreateImageView(_device, &level_info, nullptr, &pyramid);

	//	depthPyramidMips[i] = pyramid;
	//	assert(depthPyramidMips[i]);
	//}

	VkSamplerCreateInfo createInfo = {};

	auto reductionMode = VK_SAMPLER_REDUCTION_MODE_MIN;

	createInfo.sType = VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO;
	createInfo.magFilter = VK_FILTER_LINEAR;
	createInfo.minFilter = VK_FILTER_LINEAR;
	createInfo.mipmapMode = VK_SAMPLER_MIPMAP_MODE_NEAREST;
	createInfo.addressModeU = VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_EDGE;
	createInfo.addressModeV = VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_EDGE;
	createInfo.addressModeW = VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_EDGE;
	createInfo.minLod = 0;
	createInfo.maxLod = 16.f;

	VkSamplerReductionModeCreateInfoEXT createInfoReduction = { VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO_EXT };

	if (reductionMode != VK_SAMPLER_REDUCTION_MODE_WEIGHTED_AVERAGE_EXT)
	{
		createInfoReduction.reductionMode = reductionMode;

		createInfo.pNext = &createInfoReduction;
	}
	
	VK_CHECK(vkCreateSampler(_device, &createInfo, 0, &_depthSampler));

#ifndef USE_MULTITHREADING
	VkSamplerCreateInfo samplerInfo = vkinit::sampler_create_info(VK_FILTER_LINEAR);
	samplerInfo.mipmapMode = VK_SAMPLER_MIPMAP_MODE_LINEAR;
	
	vkCreateSampler(_device, &samplerInfo, nullptr, &_smoothSampler);
#endif
}

void VulkanEngine::init_forward_renderpass()
{
	//we define an attachment description for our main color image
	//the attachment is loaded as "clear" when renderpass start
	//the attachment is stored when renderpass ends
	//the attachment layout starts as "undefined", and transitions to "Present" so its possible to display it
	//we dont care about stencil, and dont use multisampling

    VkAttachmentDescription color_attachment = {};
#ifdef USE_MULTITHREADING
    color_attachment.format = _swachainImageFormat;
    color_attachment.samples = _msaaSamples;
    color_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
    color_attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
    color_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
    color_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
    color_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;

#ifdef USE_MULTISAMPLING
	color_attachment.finalLayout = VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

    VkAttachmentDescription resolve_attachment = {};
    // This is the frame buffer attachment to where the multisampled image
    // will be resolved to and which will be presented to the swapchain
    resolve_attachment.format = _swachainImageFormat;
    resolve_attachment.samples = VK_SAMPLE_COUNT_1_BIT;
    resolve_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
    resolve_attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
    resolve_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
    resolve_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
    resolve_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
    resolve_attachment.finalLayout = VK_IMAGE_LAYOUT_PRESENT_SRC_KHR;

    // Resolve attachment reference
    VkAttachmentReference resolve_attachment_ref = {};
    resolve_attachment_ref.attachment = 1;
    resolve_attachment_ref.layout = VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;
#else
    color_attachment.finalLayout = VK_IMAGE_LAYOUT_PRESENT_SRC_KHR;
#endif
#else
	color_attachment.format = _renderFormat;
	color_attachment.samples = VK_SAMPLE_COUNT_1_BIT;
	color_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
	color_attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
	color_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
	color_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
	color_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
	color_attachment.finalLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;
#endif

	VkAttachmentReference color_attachment_ref = {};
	color_attachment_ref.attachment = 0;
	color_attachment_ref.layout = VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

	VkAttachmentDescription depth_attachment = {};
	// Depth attachment
	depth_attachment.flags = 0;
	depth_attachment.format = _depthFormat;
	depth_attachment.samples = _msaaSamples;
	depth_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
	depth_attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
	depth_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
	depth_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
	depth_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
	depth_attachment.finalLayout = VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL;

	VkAttachmentReference depth_attachment_ref = {};
#ifdef USE_MULTITHREADING

#ifdef USE_MULTISAMPLING
	depth_attachment_ref.attachment = 2;
#else
	depth_attachment_ref.attachment = 1;
#endif
	
#else
	depth_attachment_ref.attachment = 1;
#endif
	depth_attachment_ref.layout = VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL;

	//we are going to create 1 subpass, which is the minimum you can do
	VkSubpassDescription subpass = {};
	subpass.pipelineBindPoint = VK_PIPELINE_BIND_POINT_GRAPHICS;
	subpass.colorAttachmentCount = 1;
	subpass.pColorAttachments = &color_attachment_ref;
	//hook the depth attachment into the subpass
	subpass.pDepthStencilAttachment = &depth_attachment_ref;

#ifdef USE_MULTITHREADING
#ifdef USE_MULTISAMPLING
	subpass.pResolveAttachments = &resolve_attachment_ref;
#endif

    // Subpass dependencies for layout transitions
    std::array<VkSubpassDependency, 2> dependencies;

    dependencies[0].srcSubpass = VK_SUBPASS_EXTERNAL;
    dependencies[0].dstSubpass = 0;
    dependencies[0].srcStageMask = VK_PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT;
    dependencies[0].dstStageMask = VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
    dependencies[0].srcAccessMask = VK_ACCESS_MEMORY_READ_BIT;
    dependencies[0].dstAccessMask = VK_ACCESS_COLOR_ATTACHMENT_READ_BIT | VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT;
    dependencies[0].dependencyFlags = VK_DEPENDENCY_BY_REGION_BIT;

    dependencies[1].srcSubpass = 0;
    dependencies[1].dstSubpass = VK_SUBPASS_EXTERNAL;
    dependencies[1].srcStageMask = VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
    dependencies[1].dstStageMask = VK_PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT;
    dependencies[1].srcAccessMask = VK_ACCESS_COLOR_ATTACHMENT_READ_BIT | VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT;
    dependencies[1].dstAccessMask = VK_ACCESS_MEMORY_READ_BIT;
    dependencies[1].dependencyFlags = VK_DEPENDENCY_BY_REGION_BIT;
#else
	//1 dependency, which is from "outside" into the subpass. And we can read or write color
	//VkSubpassDependency dependency = {};
	//dependency.srcSubpass = VK_SUBPASS_EXTERNAL;
	//dependency.dstSubpass = 0;
	//dependency.srcStageMask = VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
	//dependency.srcAccessMask = 0;
	//dependency.dstStageMask = VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
	//dependency.dstAccessMask = VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT;
#endif

#ifdef USE_MULTITHREADING
#ifdef USE_MULTISAMPLING
	VkAttachmentDescription attachments[3] = { color_attachment,resolve_attachment,depth_attachment };
#else
	VkAttachmentDescription attachments[2] = { color_attachment,depth_attachment };
#endif
#else
    //array of 2 attachments, one for the color, and other for depth
    VkAttachmentDescription attachments[2] = { color_attachment,depth_attachment };
#endif

	VkRenderPassCreateInfo render_pass_info = {};
	render_pass_info.sType = VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO;
#ifdef USE_MULTITHREADING
#ifdef USE_MULTISAMPLING
	render_pass_info.attachmentCount = 3;
#else
	render_pass_info.attachmentCount = 2;
#endif
#else
	render_pass_info.attachmentCount = 2;
#endif
	render_pass_info.pAttachments = &attachments[0];
	render_pass_info.subpassCount = 1;
	render_pass_info.pSubpasses = &subpass;
#ifdef USE_MULTITHREADING
	render_pass_info.dependencyCount = static_cast<uint32_t>(dependencies.size());
	render_pass_info.pDependencies = dependencies.data();
#endif

	VK_CHECK(vkCreateRenderPass(_device, &render_pass_info, nullptr, &_renderPass));

	_mainDeletionQueue.push_function([=]() {
		vkDestroyRenderPass(_device, _renderPass, nullptr);
		});
}

#ifndef USE_MULTITHREADING
void VulkanEngine::init_copy_renderpass()
{
	//we define an attachment description for our main color image
//the attachment is loaded as "clear" when renderpass start
//the attachment is stored when renderpass ends
//the attachment layout starts as "undefined", and transitions to "Present" so its possible to display it
//we dont care about stencil, and dont use multisampling

	VkAttachmentDescription color_attachment = {};
	color_attachment.format = _swachainImageFormat;
	color_attachment.samples = VK_SAMPLE_COUNT_1_BIT;
	color_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
	color_attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
	color_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
	color_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
	color_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
	color_attachment.finalLayout = VK_IMAGE_LAYOUT_PRESENT_SRC_KHR;

	VkAttachmentReference color_attachment_ref = {};
	color_attachment_ref.attachment = 0;
	color_attachment_ref.layout = VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

	//we are going to create 1 subpass, which is the minimum you can do
	VkSubpassDescription subpass = {};
	subpass.pipelineBindPoint = VK_PIPELINE_BIND_POINT_GRAPHICS;
	subpass.colorAttachmentCount = 1;
	subpass.pColorAttachments = &color_attachment_ref;	

	VkRenderPassCreateInfo render_pass_info = {};
	render_pass_info.sType = VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO;
	//2 attachments from said array
	render_pass_info.attachmentCount = 1;
	render_pass_info.pAttachments = &color_attachment;
	render_pass_info.subpassCount = 1;
	render_pass_info.pSubpasses = &subpass;

	VK_CHECK(vkCreateRenderPass(_device, &render_pass_info, nullptr, &_copyPass));

	_mainDeletionQueue.push_function([=]() {
		vkDestroyRenderPass(_device, _copyPass, nullptr);
		});
}
#endif

#ifdef USE_PICKING
void VulkanEngine::init_pick_renderpass()
{
    VkAttachmentDescription color_attachment = {};
	color_attachment.format = VK_FORMAT_R8G8B8A8_UNORM;
    color_attachment.samples = VK_SAMPLE_COUNT_1_BIT;
    color_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
    color_attachment.storeOp = VK_ATTACHMENT_STORE_OP_STORE;
    color_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
    color_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
    color_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
    color_attachment.finalLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;

    VkAttachmentReference color_attachment_ref = {};
    color_attachment_ref.attachment = 0;
    color_attachment_ref.layout = VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

    VkAttachmentDescription depth_attachment = {};
    // Depth attachment
    depth_attachment.flags = 0;
    depth_attachment.format = _depthFormat;
    depth_attachment.samples = VK_SAMPLE_COUNT_1_BIT;
    depth_attachment.loadOp = VK_ATTACHMENT_LOAD_OP_CLEAR;
    depth_attachment.storeOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
    depth_attachment.stencilLoadOp = VK_ATTACHMENT_LOAD_OP_DONT_CARE;
    depth_attachment.stencilStoreOp = VK_ATTACHMENT_STORE_OP_DONT_CARE;
    depth_attachment.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
    depth_attachment.finalLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;

    VkAttachmentReference depth_attachment_ref = {};
    depth_attachment_ref.attachment = 0;
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

	VkAttachmentDescription attachments[2] = { color_attachment,depth_attachment };
    VkRenderPassCreateInfo render_pass_info = {};
    render_pass_info.sType = VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO;
    //2 attachments from said array
    render_pass_info.attachmentCount = 2;
    render_pass_info.pAttachments = &attachments[0];
    render_pass_info.subpassCount = 1;
    render_pass_info.pSubpasses = &subpass;

    VK_CHECK(vkCreateRenderPass(_device, &render_pass_info, nullptr, &_pickPass));

    _mainDeletionQueue.push_function([=]() {
        vkDestroyRenderPass(_device, _pickPass, nullptr);
        });
}
#endif

void VulkanEngine::init_framebuffers()
{
	const uint32_t swapchain_imagecount = static_cast<uint32_t>(_swapchainImages.size());
	_framebuffers.resize(swapchain_imagecount);

	//create the framebuffers for the swapchain images. This will connect the render-pass to the images for rendering
	VkFramebufferCreateInfo fwd_info = vkinit::framebuffer_create_info(_renderPass, _windowExtent);
#ifdef USE_MULTITHREADING
#ifdef USE_MULTISAMPLING
	VkImageView attachments[3];
	attachments[0] = _multisampleImage.view;
    attachments[2] = _depthImage._defaultView;
    fwd_info.pAttachments = attachments;
    fwd_info.attachmentCount = 3;
#else
    VkImageView attachments[2];
    attachments[1] = _depthImage._defaultView;
    fwd_info.pAttachments = attachments;
    fwd_info.attachmentCount = 2;
#endif
#else
    VkImageView attachments[2];
	attachments[0] = _rawRenderImage._defaultView;
	attachments[1] = _depthImage._defaultView;
	fwd_info.pAttachments = attachments;
	fwd_info.attachmentCount = 2;
	VK_CHECK(vkCreateFramebuffer(_device, &fwd_info, nullptr, &_forwardFramebuffer));
#endif

	for (uint32_t i = 0; i < swapchain_imagecount; i++)
	{
#ifdef USE_MULTITHREADING
#ifdef USE_MULTISAMPLING
		attachments[1] = _swapchainImageViews[i];
#else
		attachments[0] = _swapchainImageViews[i];
#endif
		VK_CHECK(vkCreateFramebuffer(_device, &fwd_info, nullptr, &_framebuffers[i]));
#else
		//create the framebuffers for the swapchain images. This will connect the render-pass to the images for rendering
		VkFramebufferCreateInfo fb_info = vkinit::framebuffer_create_info(_copyPass, _windowExtent);
		fb_info.pAttachments = &_swapchainImageViews[i];
		fb_info.attachmentCount = 1;
		VK_CHECK(vkCreateFramebuffer(_device, &fb_info, nullptr, &_framebuffers[i]));

		_mainDeletionQueue.push_function([=]() {
			vkDestroyImageView(_device, _swapchainImageViews[i], nullptr);
			});
#endif
	}

#ifdef USE_PICKING
    //create the framebuffer for pick pass
    VkFramebufferCreateInfo pick_info = vkinit::framebuffer_create_info(_pickPass, _windowExtent);
    VkImageView attachments[2];
    attachments[0] = _pickImage._defaultView;
    attachments[1] = _depthImage._defaultView;

	pick_info.pAttachments = attachments;
	pick_info.attachmentCount = 2;
    VK_CHECK(vkCreateFramebuffer(_device, &pick_info, nullptr, &_pickFramebuffer));
#endif
}

void VulkanEngine::init_commands()
{
	//create a command pool for commands submitted to the graphics queue.
	//we also want the pool to allow for resetting of individual command buffers
    VkCommandPoolCreateInfo commandPoolInfo = vkinit::command_pool_create_info(_graphicsQueueFamily, VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT);

#ifdef USE_MULTITHREADING
	VK_CHECK(vkCreateCommandPool(_device, &commandPoolInfo, nullptr, &_primaryCommandPool));
	VkCommandBufferAllocateInfo primaryCmdAllocInfo = vkinit::command_buffer_allocate_info(_primaryCommandPool, 1);	
	VK_CHECK(vkAllocateCommandBuffers(_device, &primaryCmdAllocInfo, &_primaryCommandBuffer));

#ifdef OPT1
	_threadData.resize(_numThreads);
    for (uint32_t i = 0; i < _numThreads; ++i)
    {
        ThreadData* thread = &_threadData[i];

        VkCommandPoolCreateInfo cmdPoolInfo = vks::initializers::commandPoolCreateInfo();
        cmdPoolInfo.queueFamilyIndex = _graphicsQueueFamily;
        cmdPoolInfo.flags = VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT;
        VK_CHECK(vkCreateCommandPool(_device, &cmdPoolInfo, nullptr, &thread->commandPool));

        _mainDeletionQueue.push_function([=]() {
            vkDestroyCommandPool(_device, thread->commandPool, nullptr);
            });

        VkCommandBufferAllocateInfo threadCmdBufAllocateInfo = vks::initializers::commandBufferAllocateInfo(thread->commandPool, VK_COMMAND_BUFFER_LEVEL_SECONDARY, 1);
        VK_CHECK(vkAllocateCommandBuffers(_device, &threadCmdBufAllocateInfo, &thread->commandBuffer));
    }
#else
    VkCommandPoolCreateInfo cmdPoolInfo = vks::initializers::commandPoolCreateInfo();
    cmdPoolInfo.queueFamilyIndex = _graphicsQueueFamily;
    cmdPoolInfo.flags = VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT;
    VK_CHECK(vkCreateCommandPool(_device, &cmdPoolInfo, nullptr, &_threadCommandPool));

	VkCommandBufferAllocateInfo threadCmdBufAllocateInfo = vks::initializers::commandBufferAllocateInfo(_threadCommandPool, VK_COMMAND_BUFFER_LEVEL_SECONDARY, 1);
    VK_CHECK(vkAllocateCommandBuffers(_device, &threadCmdBufAllocateInfo, &_threadCommandBuffer));
#endif
#else
	for (int i = 0; i < FRAME_OVERLAP; i++) {

		VK_CHECK(vkCreateCommandPool(_device, &commandPoolInfo, nullptr, &_frames[i]._commandPool));

		//allocate the default command buffer that we will use for rendering
		VkCommandBufferAllocateInfo cmdAllocInfo = vkinit::command_buffer_allocate_info(_frames[i]._commandPool, 1);
		//VkCommandBufferAllocateInfo cmdAllocInfo = vks::initializers::commandBufferAllocateInfo(_frames[i]._commandPool, VK_COMMAND_BUFFER_LEVEL_SECONDARY, 1);

		VK_CHECK(vkAllocateCommandBuffers(_device, &cmdAllocInfo, &_frames[i]._mainCommandBuffer));

		_mainDeletionQueue.push_function([=]() {
			vkDestroyCommandPool(_device, _frames[i]._commandPool, nullptr);
		});		
	}
#endif

	VkCommandPoolCreateInfo uploadCommandPoolInfo = vkinit::command_pool_create_info(_graphicsQueueFamily);
	//create pool for upload context
	VK_CHECK(vkCreateCommandPool(_device, &uploadCommandPoolInfo, nullptr, &_uploadContext._commandPool));

    VkCommandPoolCreateInfo guiCommandPoolInfo = vkinit::command_pool_create_info(_graphicsQueueFamily, VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT);
    //create pool for upload context
    VK_CHECK(vkCreateCommandPool(_device, &guiCommandPoolInfo, nullptr, &_guiCommandPool));
    VkCommandBufferAllocateInfo cmdBufAllocateInfo = vks::initializers::commandBufferAllocateInfo(_guiCommandPool, VK_COMMAND_BUFFER_LEVEL_SECONDARY, 1);
    VK_CHECK(vkAllocateCommandBuffers(_device, &cmdBufAllocateInfo, &_guiCommandBuffer));
}

void VulkanEngine::init_sync_structures()
{
	//create syncronization structures
	//one fence to control when the gpu has finished rendering the frame,
	//and 2 semaphores to syncronize rendering with swapchain
	//we want the fence to start signalled so we can wait on it on the first frame
	VkFenceCreateInfo fenceCreateInfo = vkinit::fence_create_info(VK_FENCE_CREATE_SIGNALED_BIT);

	VkSemaphoreCreateInfo semaphoreCreateInfo = vkinit::semaphore_create_info();

#ifdef USE_MULTITHREADING
	VK_CHECK(vkCreateFence(_device, &fenceCreateInfo, nullptr, &_renderFence));
    //enqueue the destruction of the fence
    _mainDeletionQueue.push_function([=]() {
        vkDestroyFence(_device, _renderFence, nullptr);
        });

    VK_CHECK(vkCreateSemaphore(_device, &semaphoreCreateInfo, nullptr, &_presentSemaphore));
    VK_CHECK(vkCreateSemaphore(_device, &semaphoreCreateInfo, nullptr, &_renderSemaphore));

    //enqueue the destruction of semaphores
    _mainDeletionQueue.push_function([=]() {
        vkDestroySemaphore(_device, _presentSemaphore, nullptr);
        vkDestroySemaphore(_device, _renderSemaphore, nullptr);
        });
#else
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
#endif

	VkFenceCreateInfo uploadFenceCreateInfo = vkinit::fence_create_info();

	VK_CHECK(vkCreateFence(_device, &uploadFenceCreateInfo, nullptr, &_uploadContext._uploadFence));
	_mainDeletionQueue.push_function([=]() {
		vkDestroyFence(_device, _uploadContext._uploadFence, nullptr);
		});
}


void VulkanEngine::init_pipelines()
{	
	_materialSystem = new vkutil::MaterialSystem();
	_materialSystem->init(this);
		
#ifndef USE_MULTITHREADING
	//fullscreen triangle pipeline for blits
	ShaderEffect* blitEffect = new ShaderEffect();
	blitEffect->add_stage(_shaderCache.get_shader(shader_path("fullscreen.vert.spv")), VK_SHADER_STAGE_VERTEX_BIT);
	blitEffect->add_stage(_shaderCache.get_shader(shader_path("blit.frag.spv")), VK_SHADER_STAGE_FRAGMENT_BIT);
	blitEffect->reflect_layout(_device, nullptr, 0);


	PipelineBuilder pipelineBuilder;

	//input assembly is the configuration for drawing triangle lists, strips, or individual points.
	//we are just going to draw triangle list
	pipelineBuilder._inputAssembly = vkinit::input_assembly_create_info(VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST);

	//configure the rasterizer to draw filled triangles
	pipelineBuilder._rasterizer = vkinit::rasterization_state_create_info(VK_POLYGON_MODE_FILL);
	pipelineBuilder._rasterizer.cullMode = VK_CULL_MODE_NONE;
	//we dont use multisampling, so just run the default one
	pipelineBuilder._multisampling = vkinit::multisampling_state_create_info();

	//a single blend attachment with no blending and writing to RGBA
	pipelineBuilder._colorBlendAttachment = vkinit::color_blend_attachment_state();


	//default depthtesting
	pipelineBuilder._depthStencil = vkinit::depth_stencil_create_info(true, true, VK_COMPARE_OP_GREATER_OR_EQUAL);

	//build blit pipeline
	pipelineBuilder.setShaders(blitEffect);

	//blit pipeline uses hardcoded triangle so no need for vertex input
	pipelineBuilder.clear_vertex_input();

	pipelineBuilder._depthStencil = vkinit::depth_stencil_create_info(false, false, VK_COMPARE_OP_ALWAYS);

	_blitPipeline = pipelineBuilder.build_pipeline(_device, _copyPass);
	_blitLayout = blitEffect->builtLayout;
	
	_mainDeletionQueue.push_function([=]() {
		vkDestroyPipeline(_device, _blitPipeline, nullptr);
	});
#endif

	//load the compute shaders
	load_compute_shader(shader_path("indirect_cull.comp.spv").c_str(), _cullPipeline, _cullLayout);
	load_compute_shader(shader_path("sparse_upload.comp.spv").c_str(), _sparseUploadPipeline, _sparseUploadLayout);

#ifdef USE_PICKING
	// picking
	{
		ShaderEffect* pickEffect = new ShaderEffect();
		pickEffect->add_stage(_shaderCache.get_shader(shader_path("pick.vert.spv")), VK_SHADER_STAGE_VERTEX_BIT);
		pickEffect->add_stage(_shaderCache.get_shader(shader_path("pick.frag.spv")), VK_SHADER_STAGE_FRAGMENT_BIT);
		pickEffect->reflect_layout(_device, nullptr, 0);

        //build pick pipeline
        pipelineBuilder.setShaders(pickEffect);

		pipelineBuilder.vertexDescription = Vertex::get_vertex_description();

        pipelineBuilder._depthStencil = vkinit::depth_stencil_create_info(false, false, VK_COMPARE_OP_ALWAYS);

        _pickPipeline = pipelineBuilder.build_pipeline(_device, _pickPass);
        _pickLayout = pickEffect->builtLayout;

        _mainDeletionQueue.push_function([=]() {
            vkDestroyPipeline(_device, _pickPipeline, nullptr);
            });
	}
#endif
}

bool VulkanEngine::load_compute_shader(const char* shaderPath, VkPipeline& pipeline, VkPipelineLayout& layout)
{
	ShaderModule computeModule;
	if (!vkutil::load_shader_module(_device, shaderPath, &computeModule))

	{
		std::cout << "Error when building compute shader shader module" << std::endl;
		return false;
	}

	ShaderEffect* computeEffect = new ShaderEffect();;
	computeEffect->add_stage(&computeModule, VK_SHADER_STAGE_COMPUTE_BIT);

	computeEffect->reflect_layout(_device, nullptr, 0);

	ComputePipelineBuilder computeBuilder;
	computeBuilder._pipelineLayout = computeEffect->builtLayout;
	computeBuilder._shaderStage = vkinit::pipeline_shader_stage_create_info(VK_SHADER_STAGE_COMPUTE_BIT, computeModule.module);

	layout = computeEffect->builtLayout;
	pipeline = computeBuilder.build_pipeline(_device);

	vkDestroyShaderModule(_device, computeModule.module, nullptr);

	_mainDeletionQueue.push_function([=]() {
		vkDestroyPipeline(_device, pipeline, nullptr);

		vkDestroyPipelineLayout(_device, layout, nullptr);
	});

	return true;
}

void VulkanEngine::load_images()
{
	//TODO: have a default texture
	load_direct_image_to_cache("default", "white.xbm");
}


bool VulkanEngine::load_image_to_cache(const char* name, const char* path)
{
	if (_loadedTextures.find(name) != _loadedTextures.end()) return true;

    Texture newtex;

	bool result = vkutil::load_image_from_file(*this, path, newtex.image);

	if (!result)
	{
		LOG_ERROR("Error When texture {} at path {}", name, path);
		return false;
	}
	else {
		LOG_SUCCESS("Loaded texture {} at path {}", name, path);
	}
	newtex.imageView = newtex.image._defaultView;

	_loadedTextures[name] = newtex;
	return true;
}

bool VulkanEngine::load_direct_image_to_cache(const char* name, const char* path)
{
    if (_loadedTextures.find(name) != _loadedTextures.end()) return true;

    Texture newtex;

    bool result = vkutil::load_direct_image_from_file(*this, path, newtex.image);

    if (!result)
    {
        LOG_ERROR("Error When texture {} at path {}", name, path);
        return false;
    }
    else {
        LOG_SUCCESS("Loaded texture {} at path {}", name, path);
    }
    newtex.imageView = newtex.image._defaultView;

    _loadedTextures[name] = newtex;
    return true;
}

void VulkanEngine::upload_mesh(Mesh& mesh)
{
	const size_t vertex_buffer_size = mesh._vertices.size() * sizeof(Vertex);
	const size_t index_buffer_size = mesh._indices.size() * sizeof(uint32_t);
	const size_t bufferSize = vertex_buffer_size + index_buffer_size;
	//allocate vertex buffer
	VkBufferCreateInfo vertexBufferInfo = {};
	vertexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
	vertexBufferInfo.pNext = nullptr;
	//this is the total size, in bytes, of the buffer we are allocating
	vertexBufferInfo.size = vertex_buffer_size;
	//this buffer is going to be used as a Vertex Buffer
	vertexBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

	//allocate vertex buffer
	VkBufferCreateInfo indexBufferInfo = {};
	indexBufferInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
	indexBufferInfo.pNext = nullptr;
	//this is the total size, in bytes, of the buffer we are allocating
	indexBufferInfo.size = index_buffer_size;
	//this buffer is going to be used as a Vertex Buffer
	indexBufferInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;

	//let the VMA library know that this data should be writeable by CPU, but also readable by GPU
	VmaAllocationCreateInfo vmaallocInfo = {};
	vmaallocInfo.usage = VMA_MEMORY_USAGE_CPU_ONLY;

	//allocate the buffer
	VK_CHECK(vmaCreateBuffer(_allocator, &vertexBufferInfo, &vmaallocInfo,
		&mesh._vertexBuffer._buffer,
		&mesh._vertexBuffer._allocation,
		nullptr));
	//copy vertex data
	char* data;
	vmaMapMemory(_allocator, mesh._vertexBuffer._allocation, (void**)&data);

	memcpy(data, mesh._vertices.data(), vertex_buffer_size);

	vmaUnmapMemory(_allocator, mesh._vertexBuffer._allocation);

	if (index_buffer_size != 0)
	{
		//allocate the buffer
		VK_CHECK(vmaCreateBuffer(_allocator, &indexBufferInfo, &vmaallocInfo,
			&mesh._indexBuffer._buffer,
			&mesh._indexBuffer._allocation,
			nullptr));
		vmaMapMemory(_allocator, mesh._indexBuffer._allocation, (void**)&data);

		memcpy(data, mesh._indices.data(), index_buffer_size);

		vmaUnmapMemory(_allocator, mesh._indexBuffer._allocation);
	}
}

void VulkanEngine::ready_cull_data(RenderScene::MeshPass& pass, VkCommandBuffer cmd)
{
	if (pass.batches.size())
	{
		//copy from the cleared indirect buffer into the one we will use on rendering. This one happens every frame
		VkBufferCopy indirectCopy;
		indirectCopy.dstOffset = 0;
		indirectCopy.size = pass.batches.size() * sizeof(GPUIndirectObject);
		indirectCopy.srcOffset = 0;
		vkCmdCopyBuffer(cmd, pass.clearIndirectBuffer._buffer, pass.drawIndirectBuffer._buffer, 1, &indirectCopy);

		{
			VkBufferMemoryBarrier barrier = vkinit::buffer_barrier(pass.drawIndirectBuffer._buffer, _graphicsQueueFamily);
			barrier.dstAccessMask = VK_ACCESS_SHADER_WRITE_BIT | VK_ACCESS_SHADER_READ_BIT;
			barrier.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;

			cullReadyBarriers.push_back(barrier);
		}
	}
}

AllocatedBufferUntyped VulkanEngine::create_generic_buffer(size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage, VkMemoryPropertyFlags required_flags)
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
	vmaallocInfo.requiredFlags = required_flags;
	AllocatedBufferUntyped newBuffer;

	//allocate the buffer
	VK_CHECK(vmaCreateBuffer(_allocator, &bufferInfo, &vmaallocInfo,
		&newBuffer._buffer,
		&newBuffer._allocation,
		nullptr));
	newBuffer._size = allocSize;
	return newBuffer;
}

void VulkanEngine::reallocate_buffer(AllocatedBufferUntyped& buffer, size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage, VkMemoryPropertyFlags required_flags /*= 0*/)
{
	AllocatedBufferUntyped newBuffer = create_generic_buffer(allocSize, usage, memoryUsage, required_flags);

#ifdef USE_MULTITHREADING
    _frameDeletionQueue.push_function([=]() {
        vmaDestroyBuffer(_allocator, buffer._buffer, buffer._allocation);
        });
#else
	get_current_frame()._frameDeletionQueue.push_function([=]() {

		vmaDestroyBuffer(_allocator, buffer._buffer, buffer._allocation);
	});
#endif
	buffer = newBuffer;
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


std::string VulkanEngine::asset_path(std::string_view path)
{
	return "./" + std::string(path);
}

std::string VulkanEngine::shader_path(std::string_view path)
{
	return "./" + std::string(path);
}

void VulkanEngine::setRootNode(std::string label)
{
	_rootNode.label = label;
}

VulkanEngine::GUINode* VulkanEngine::addParentNode(VulkanEngine::GUINode* parent, std::string label)
{
	GUINode newParent;
	newParent.label = label;

	parent->children.emplace_back(newParent);
	return &(parent->children.back());
}

void VulkanEngine::addChildNode(VulkanEngine::GUINode* parent, std::string label, Handle<RenderObject> handle)
{
    GUINode node;
	node.label = label;
	node.handle = handle;

    parent->children.emplace_back(node);
}

void VulkanEngine::init_scene(const std::string& asset)
{
	VkSamplerCreateInfo samplerInfo = vkinit::sampler_create_info(VK_FILTER_LINEAR);

	samplerInfo.mipmapMode = VK_SAMPLER_MIPMAP_MODE_LINEAR;
	//info.anisotropyEnable = true;
	samplerInfo.mipLodBias = 2;
	samplerInfo.maxLod = 30.f;
	samplerInfo.minLod = 3;
	VkSampler smoothSampler;

	vkCreateSampler(_device, &samplerInfo, nullptr, &smoothSampler);

	{
		vkutil::MaterialData texturedInfo;
		texturedInfo.baseTemplate = "texturedPBR_opaque";
		texturedInfo.parameters = nullptr;

		vkutil::SampledTexture whiteTex;
		whiteTex.sampler = smoothSampler;
		whiteTex.view = _loadedTextures["default"].imageView;

		texturedInfo.textures.push_back(whiteTex);

		_materialSystem->build_material("textured", texturedInfo);
	}
	{
		vkutil::MaterialData matinfo;
		matinfo.baseTemplate = "texturedPBR_opaque";
		matinfo.parameters = nullptr;

		vkutil::SampledTexture whiteTex;
		whiteTex.sampler = smoothSampler;
		whiteTex.view = _loadedTextures["default"].imageView;

		matinfo.textures.push_back(whiteTex);

		_materialSystem->build_material("default", matinfo);

	}
	{
		vkutil::MaterialData matinfo;
		matinfo.baseTemplate = "terrain";
		matinfo.parameters = nullptr;

		vkutil::SampledTexture whiteTex;
		whiteTex.sampler = smoothSampler;
		whiteTex.view = _loadedTextures["default"].imageView;
		matinfo.textures.push_back(whiteTex);

		_materialSystem->build_material("terrain", matinfo);

	}

	_mainDeletionQueue.push_function([=]() {
		vkDestroySampler(_device, smoothSampler, nullptr);
	});

	if (!asset.ends_with("fbx"))
    {
		setRootNode(asset);
		GUINode* parent = &_rootNode;

#ifdef _DEBUG
		//WolvenEngine::CreateBinFromCSV("pathhashes.csv");
		//WolvenEngine::CreateTableOfContentsFromBundles();
#endif

		WolvenEngine::LoadPathHashes("pathhashes.bin");
#ifdef USE_GAME_BUNDLES
		WolvenEngine::LoadRawPathHashes("rawpathhashes.bin");
#else

		std::string depot = WolvenEngine::resourcePaths.top();
#endif
		glm::mat4 mWorldMatrix = glm::rotate(glm::mat4(1.0f), -(float_t)M_PI_2, glm::vec3(1.0f, 0, 0));
		glm::mat4 scale = glm::scale(glm::mat4{ 1.0 }, glm::vec3(-1.0, 1.0, 1.0));
		mWorldMatrix = mWorldMatrix * scale;

		WolvenEngine::Model model;
		if (model.loadFromFile(asset))
		{
			// load the geometry for the meshes
			std::unordered_map<uint64_t, std::vector<MeshObject>> cachedMeshes;
#if 1
			for (auto& node : model.nodes)
			{
				if (node->mesh == nullptr)
				{
					// parent node!
					parent = addParentNode(&_rootNode, node->label);
					continue;
				}

				auto mit = cachedMeshes.find(node->mesh->hash);
				glm::mat4 transformMatrix = mWorldMatrix * node->matrix;
				if (mit != cachedMeshes.end())
				{
#ifdef DUMPOBJ
					int ci = 0;
#endif
					for (MeshObject& pmo : mit->second)
					{
						MeshObject mo;
						mo.mesh = pmo.mesh;
						mo.transformMatrix = transformMatrix;
						mo.material = pmo.material;
						mo.customSortKey = 0;
						mo.bDrawForwardPass = true;
						mo.bounds = mo.mesh->bounds;

						refresh_renderbounds(&mo);
						Handle<RenderObject> handle = _renderScene.register_object(&mo);

						addChildNode(parent, node->mesh->filename, handle);

#ifdef DUMPOBJ
						{
							size_t pos = node->mesh->filename.rfind('\\');
							if (pos == std::string::npos)
								pos = node->mesh->filename.rfind('/');
							std::string meshName = node->mesh->filename.substr(pos + 1);

							std::string objName = meshName + std::to_string(ci);
							objName += "_cached.obj";

							DumpOBJ(objName, mo);

							++ci;
						}
#endif

					}
				}
				else
				{
					std::vector<MeshObject> parts;
					std::vector<Mesh> meshes;
					std::vector<WolvenEngine::Material> materials;

					WolvenEngine::loadMesh(node->mesh->filename, meshes, materials);
					for (uint32_t i = 0; i < (uint32_t)meshes.size(); ++i)
					{
						Mesh& mesh = meshes[i];
						WolvenEngine::Material& mat = materials[i];

						vkutil::Material* objectMaterial = _materialSystem->get_material(mat.name);
						if (!objectMaterial)
						{
							std::string diffuseTex, normalTex;
							bool gotTextureNames = false;
							if (!mat.diffuseTexture.empty())
							{
								diffuseTex = mat.diffuseTexture;
								gotTextureNames = true;
							}
							else
							{
								gotTextureNames = WolvenEngine::loadMaterial(mat.name, diffuseTex, normalTex);
							}

							if (gotTextureNames)
							{
#ifdef USE_GAME_BUNDLES
								std::string diffuseTexPath = diffuseTex;
#else
								std::string diffuseTexPath = depot + diffuseTex;
#endif

								if (!load_image_to_cache(diffuseTex.c_str(), diffuseTexPath.c_str()))
								{
									diffuseTex = "default";
								}

								{
									vkutil::SampledTexture tex;
									tex.view = _loadedTextures[diffuseTex].imageView;
									tex.sampler = smoothSampler;

									vkutil::MaterialData info;
									info.parameters = nullptr;
									info.baseTemplate = "texturedPBR_opaque";
									info.textures.push_back(tex);

									objectMaterial = _materialSystem->build_material(mat.name, info);
									if (!objectMaterial)
									{
										LOG_ERROR("Error When building material {}", mat.name);
									}
								}

							}
							else
							{
								//LOG_ERROR("Error When loading material at path {}", v.material_path);
								objectMaterial = _materialSystem->get_material("default");
							}
						}

						upload_mesh(mesh);
						_meshes.emplace_back(mesh);

						MeshObject mo;
						mo.mesh = &_meshes.back();
						mo.transformMatrix = transformMatrix;
						mo.material = objectMaterial;
						mo.customSortKey = 0;
						mo.bDrawForwardPass = true;
						mo.bounds = mo.mesh->bounds;

						refresh_renderbounds(&mo);
						Handle<RenderObject> handle = _renderScene.register_object(&mo);

						addChildNode(parent, node->mesh->filename, handle);
#ifdef DUMPOBJ
						{
							size_t pos = node->mesh->filename.rfind('\\');
							if (pos == std::string::npos)
								pos = node->mesh->filename.rfind('/');
							std::string meshName = node->mesh->filename.substr(pos + 1);

							std::string objName = meshName + std::to_string(i);
							objName += ".obj";

							DumpOBJ(objName, mo);
						}
#endif
						parts.push_back(mo);
					}

					cachedMeshes.insert(std::pair <uint64_t, std::vector<MeshObject>>(node->mesh->hash, parts));
				}
			}
#endif
#if 1
			vkutil::Material* objectMaterial = _materialSystem->get_material("terrain");

			float_t terrainSize = model.terrainInfo.terrainSize / model.terrainInfo.numTilesPerEdge;

			// load terrain
			for (auto& tile : model.terrain)
			{
				Mesh mesh;
				if (WolvenEngine::loadTerrain(tile.filename, tile.resolution, model.terrainInfo.highestElevation, model.terrainInfo.lowestElevation, terrainSize, mesh))
				{
					upload_mesh(mesh);
					_meshes.emplace_back(mesh);

					MeshObject mo;
					mo.mesh = &_meshes.back();
					mo.transformMatrix = mWorldMatrix * tile.matrix;
					mo.material = objectMaterial;
					mo.customSortKey = 0;
					mo.bDrawForwardPass = true;
					mo.bounds = mo.mesh->bounds;

					refresh_renderbounds(&mo);
					_renderScene.register_object(&mo);
				}
			}
#endif

			_camera.setMovementSpeed(1000.0f);
		}

		// release all temporary memory
		WolvenEngine::BundleManager::instance()->clear();
		return;
	}

	// else import!
	importModel(asset);
}

void VulkanEngine::focusCamera()
{
	if (_selectedItem)
	{
		RenderObject* ro = _renderScene.get_object(_selectedItem->handle);
		_selectedOrigin = ro->bounds.origin;

		glm::mat4 scale = glm::scale(glm::mat4{ 1.0 }, glm::vec3(-1.0, 1.0, -1.0));
		_selectedOrigin = glm::vec4(_selectedOrigin,1.0f) * scale;

		glm::vec3 dir = glm::vec3(1.0f, 0.0f, 0.0f);
		glm::vec3 eye = _selectedOrigin - ro->bounds.radius * dir;
		_camera.focus(eye, _selectedOrigin);
	}
}

bool VulkanEngine::importModel(const std::string& asset)
{
    glm::mat4 mWorldMatrix = glm::rotate(glm::mat4(1.0f), -(float_t)M_PI_2, glm::vec3(1.0f, 0, 0));

    FBX::Model model;
	if (model.loadFromFile(asset))
	{
        VkSamplerCreateInfo samplerInfo = vkinit::sampler_create_info(VK_FILTER_NEAREST);

        VkSampler blockySampler;
        vkCreateSampler(_device, &samplerInfo, nullptr, &blockySampler);

        samplerInfo = vkinit::sampler_create_info(VK_FILTER_LINEAR);

        samplerInfo.mipmapMode = VK_SAMPLER_MIPMAP_MODE_LINEAR;
        //info.anisotropyEnable = true;
        samplerInfo.mipLodBias = 2;
        samplerInfo.maxLod = 30.f;
        samplerInfo.minLod = 3;
        VkSampler smoothSampler;

        vkCreateSampler(_device, &samplerInfo, nullptr, &smoothSampler);

		std::filesystem::path assetPath = asset;
		assetPath = assetPath.parent_path();

		for (auto& node : model.nodes)
		{
			glm::mat4 transformMatrix = mWorldMatrix * node->matrix;

			upload_mesh(*(node->mesh));
			_meshes.emplace_back(*(node->mesh));

			vkutil::Material* objectMaterial = _materialSystem->get_material("default");
			if (!node->diffuseTexture.empty())
			{
				std::string texPath = assetPath.append(node->diffuseTexture).string();
				Texture newtex;
				if (vkutil::load_imported_image(*this, texPath.c_str(), newtex.image))
				{
					newtex.imageView = newtex.image._defaultView;
					_loadedTextures[node->diffuseTexture] = newtex;

                    vkutil::SampledTexture tex;
                    tex.view = _loadedTextures[node->diffuseTexture].imageView;
                    tex.sampler = smoothSampler;

                    vkutil::MaterialData info;
                    info.parameters = nullptr;
                    info.baseTemplate = "texturedPBR_opaque";
                    info.textures.push_back(tex);

                    objectMaterial = _materialSystem->build_material(node->diffuseTexture, info);
				}
			}

			MeshObject mo;
			mo.mesh = &_meshes.back();
			mo.transformMatrix = transformMatrix;
			mo.material = objectMaterial;
			mo.customSortKey = 0;
			mo.bDrawForwardPass = true;
			mo.bounds = mo.mesh->bounds;

			refresh_renderbounds(&mo);
			_renderScene.register_object(&mo);
		}

		return true;
	}

	return false;
}

void VulkanEngine::refresh_renderbounds(MeshObject* object)
{
    //dont try to update invalid bounds
    if (!object->mesh->bounds.valid) return;

    RenderBounds originalBounds = object->mesh->bounds;

    //convert bounds to 8 vertices, and transform those
    std::array<glm::vec3, 8> boundsVerts;

    for (int i = 0; i < 8; i++) {
        boundsVerts[i] = originalBounds.origin;
    }

    boundsVerts[0] += originalBounds.extents * glm::vec3(1, 1, 1);
    boundsVerts[1] += originalBounds.extents * glm::vec3(1, 1, -1);
    boundsVerts[2] += originalBounds.extents * glm::vec3(1, -1, 1);
    boundsVerts[3] += originalBounds.extents * glm::vec3(1, -1, -1);
    boundsVerts[4] += originalBounds.extents * glm::vec3(-1, 1, 1);
    boundsVerts[5] += originalBounds.extents * glm::vec3(-1, 1, -1);
    boundsVerts[6] += originalBounds.extents * glm::vec3(-1, -1, 1);
    boundsVerts[7] += originalBounds.extents * glm::vec3(-1, -1, -1);

    //recalc max/min
    glm::vec3 min{ std::numeric_limits<float>().max() };
    glm::vec3 max{ -std::numeric_limits<float>().max() };

    glm::mat4 m = object->transformMatrix;

    //transform every vertex, accumulating max/min
    for (int i = 0; i < 8; i++) {
        boundsVerts[i] = m * glm::vec4(boundsVerts[i], 1.f);

        min = glm::min(boundsVerts[i], min);
        max = glm::max(boundsVerts[i], max);
    }

    glm::vec3 extents = (max - min) / 2.f;
    glm::vec3 origin = min + extents;

    float max_scale = 0;
    max_scale = std::max(glm::length(glm::vec3(m[0][0], m[0][1], m[0][2])), max_scale);
    max_scale = std::max(glm::length(glm::vec3(m[1][0], m[1][1], m[1][2])), max_scale);
    max_scale = std::max(glm::length(glm::vec3(m[2][0], m[2][1], m[2][2])), max_scale);

    float radius = max_scale * originalBounds.radius;


    object->bounds.extents = extents;
    object->bounds.origin = origin;
    object->bounds.radius = radius;
    object->bounds.valid = true;
}

void VulkanEngine::unmap_buffer(AllocatedBufferUntyped& buffer)
{
	vmaUnmapMemory(_allocator, buffer._allocation);
}

void VulkanEngine::init_descriptors()
{
	_descriptorAllocator = new vkutil::DescriptorAllocator{};
	_descriptorAllocator->init(_device);

	_descriptorLayoutCache = new vkutil::DescriptorLayoutCache{};
	_descriptorLayoutCache->init(_device);

#ifdef USE_MULTITHREADING
	const size_t sceneParamBufferSize = pad_uniform_buffer_size(sizeof(GPUSceneData));
    _dynamicDescriptorAllocator = new vkutil::DescriptorAllocator{};
    _dynamicDescriptorAllocator->init(_device);

    //1 megabyte of dynamic data buffer
    auto dynamicDataBuffer = create_generic_buffer(1000000, VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_ONLY);
    _dynamicData.init(_allocator, dynamicDataBuffer, (uint32_t)_gpuProperties.limits.minUniformBufferOffsetAlignment);
#else
	const size_t sceneParamBufferSize = FRAME_OVERLAP * pad_uniform_buffer_size(sizeof(GPUSceneData));

	for (int i = 0; i < FRAME_OVERLAP; i++)
	{
		_frames[i].dynamicDescriptorAllocator = new vkutil::DescriptorAllocator{};
		_frames[i].dynamicDescriptorAllocator->init(_device);

		//1 megabyte of dynamic data buffer
		auto dynamicDataBuffer = create_generic_buffer(1000000, VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_ONLY);
		_frames[i].dynamicData.init(_allocator, dynamicDataBuffer, (uint32_t)_gpuProperties.limits.minUniformBufferOffsetAlignment); 
	}
#endif
}

void VulkanEngine::init_imgui()
{
	_gui._device = _device;
	_gui._queue = _graphicsQueue;
	_gui._memProperties = _memProperties;
#ifdef USE_MULTISAMPLING
	_gui._rasterizationSamples = _msaaSamples;
#endif
	_gui.prepareResources(_graphicsQueueFamily);
	_gui.preparePipeline(_renderPass);
}

#ifdef USE_MULTITHREADING
void VulkanEngine::threadRenderCode(uint32_t threadIndex, uint32_t start, uint32_t end, VkCommandBufferInheritanceInfo inheritanceInfo)
{
    VkCommandBufferBeginInfo commandBufferBeginInfo = vks::initializers::commandBufferBeginInfo();
    commandBufferBeginInfo.flags = VK_COMMAND_BUFFER_USAGE_RENDER_PASS_CONTINUE_BIT;
    commandBufferBeginInfo.pInheritanceInfo = &inheritanceInfo;

#ifdef OPT1
	ThreadData* thread = &_threadData[threadIndex];
    VK_CHECK(vkBeginCommandBuffer(thread->commandBuffer, &commandBufferBeginInfo));
    forward_pass(thread->commandBuffer, start, end);
    VK_CHECK(vkEndCommandBuffer(thread->commandBuffer));
#else
    VK_CHECK(vkBeginCommandBuffer(_threadCommandBuffer, &commandBufferBeginInfo));
    forward_pass(_threadCommandBuffer);
    VK_CHECK(vkEndCommandBuffer(_threadCommandBuffer));
#endif

}
#endif

void VulkanEngine::update_secondaryBuffers(VkCommandBufferInheritanceInfo inheritanceInfo)
{
	_gui.update();

    VkCommandBufferBeginInfo commandBufferBeginInfo = vks::initializers::commandBufferBeginInfo();
    commandBufferBeginInfo.flags = VK_COMMAND_BUFFER_USAGE_RENDER_PASS_CONTINUE_BIT;
    commandBufferBeginInfo.pInheritanceInfo = &inheritanceInfo;

    VK_CHECK(vkBeginCommandBuffer(_guiCommandBuffer, &commandBufferBeginInfo));

    VkViewport viewport;
    viewport.x = 0.0f;
    viewport.y = 0.0f;
    viewport.width = (float)_windowExtent.width;
    viewport.height = (float)_windowExtent.height;
    viewport.minDepth = 0.0f;
    viewport.maxDepth = 1.0f;

    VkRect2D scissor;
    scissor.offset = { 0, 0 };
    scissor.extent = _windowExtent;

    vkCmdSetViewport(_guiCommandBuffer, 0, 1, &viewport);
    vkCmdSetScissor(_guiCommandBuffer, 0, 1, &scissor);

    _gui.draw(_guiCommandBuffer);

    VK_CHECK(vkEndCommandBuffer(_guiCommandBuffer));
}

void VulkanEngine::update_overlay()
{
    ImGuiIO& io = ImGui::GetIO();

    io.DisplaySize = ImVec2((float)_windowExtent.width, (float)_windowExtent.height);
    io.DeltaTime = _frameTimer;

    io.MousePos = ImVec2(mousePos.x, mousePos.y);
    io.MouseDown[0] = mouseButtons.left;
    io.MouseDown[1] = mouseButtons.right;

    ImGui::NewFrame();

    ImGui::PushStyleVar(ImGuiStyleVar_WindowRounding, 0);
    ImGui::SetNextWindowSize(ImVec2(0, 0), ImGuiCond_FirstUseEver);
    ImGui::Begin("Wolven Engine", nullptr, ImGuiWindowFlags_AlwaysAutoResize | ImGuiWindowFlags_NoResize);
    ImGui::Text("%.2f ms/frame (%.1d fps)", (1000.0f / _lastFPS), _lastFPS);
	if (_selectedItem != nullptr)
	{
        ImGui::Text("center: %.2f, %.2f, %.2f", _selectedOrigin.x, _selectedOrigin.y, _selectedOrigin.z);
	}
    ImGui::PushItemWidth(110.0f * _gui._scale);
	if (_gui.header("Visibility"))
	{
        ImGui::BeginChild("InnerRegion", ImVec2(300.0f, 400.0f), false, ImGuiWindowFlags_HorizontalScrollbar);
		ImGui::SetNextWindowContentSize(ImVec2(800.0f, 0.0f));
		
        constexpr ImGuiTreeNodeFlags parent_node_flags = ImGuiTreeNodeFlags_OpenOnArrow | ImGuiTreeNodeFlags_OpenOnDoubleClick;
		constexpr ImGuiTreeNodeFlags child_node_flags = ImGuiTreeNodeFlags_Leaf | ImGuiTreeNodeFlags_NoTreePushOnOpen;

		int32_t treeNodeId = 0;
		// is the root node open?
		bool node_open = ImGui::TreeNodeEx((void*)(intptr_t)treeNodeId++, parent_node_flags, _rootNode.label.c_str());
		if (ImGui::IsItemClicked())
		{
			_rootNode.selected = !_rootNode.selected;
		}
        if (node_open)
        {
			// draw the children
			for(auto & n : _rootNode.children)
			{
				if (!n.children.empty())
				{
					// is the parent node open?
					node_open = ImGui::TreeNodeEx((void*)(intptr_t)treeNodeId++, parent_node_flags, n.label.c_str());
					if (ImGui::IsItemClicked())
					{
						n.selected = !n.selected;
					}
					if (node_open)
					{
						for (auto& ni : n.children)
						{
							RenderObject* ro = _renderScene.get_object(ni.handle);
							bool visible = ro->visible;
                            _gui.checkBox(treeNodeId++, ni.label.c_str(), child_node_flags, &ro->visible, &ni.selected);
							if (visible != ro->visible)
							{
								_renderScene.update_object(ni.handle);
							}
                            if (ni.selected)
                            {
                                if (_selectedItem && (_selectedItem != &ni))
                                {
                                    _selectedItem->selected = false;
                                    _selectedItem = &ni;
                                    focusCamera();
                                }
                                else if (_selectedItem == nullptr)
                                {
                                    _selectedItem = &ni;
                                    focusCamera();
                                }
                            }
                            else if (_selectedItem == &ni)
                            {
                                _selectedItem = nullptr;
                            }
						}
						ImGui::TreePop();
					}
				}
				else
				{
					RenderObject* ro = _renderScene.get_object(n.handle);
					_gui.checkBox(treeNodeId++, n.label.c_str(), child_node_flags, &ro->visible, &n.selected);
					if (n.selected)
					{
						if (_selectedItem && (_selectedItem != &n))
						{
							_selectedItem->selected = false;
                            _selectedItem = &n;
                            focusCamera();
						}
						else if (_selectedItem == nullptr)
						{
							_selectedItem = &n;
							focusCamera();
						}
					}
					else if(_selectedItem == &n)
					{
						_selectedItem = nullptr;
					}
				}
			}            
            ImGui::TreePop();
        }
        ImGui::EndChild();
	}
    ImGui::PopItemWidth();
    ImGui::End();
    ImGui::PopStyleVar();
    ImGui::Render();

    //if (_gui.update() || _gui._updated) {
	//	_gui.draw(_guiCommandBuffer);
	//	_gui._updated = false;
    //}
}

#if 0
void VulkanEngine::update_overlay(VkCommandBuffer cmd)
{
    ImGuiIO& io = ImGui::GetIO();

    io.DisplaySize = ImVec2((float)_windowExtent.width, (float)_windowExtent.height);
    io.DeltaTime = _frameTimer;

    io.MousePos = ImVec2(mousePos.x, mousePos.y);
    io.MouseDown[0] = mouseButtons.left;
    io.MouseDown[1] = mouseButtons.right;

    ImGui::NewFrame();

    ImGui::PushStyleVar(ImGuiStyleVar_WindowRounding, 0);
    ImGui::SetNextWindowPos(ImVec2(10, 10));
    ImGui::SetNextWindowSize(ImVec2(0, 0), ImGuiCond_FirstUseEver);
    ImGui::Begin("Wolven Engine", nullptr, ImGuiWindowFlags_AlwaysAutoResize | ImGuiWindowFlags_NoResize | ImGuiWindowFlags_NoMove);
    ImGui::Text("%.2f ms/frame (%.1d fps)", (1000.0f / _lastFPS), _lastFPS);
    ImGui::PushItemWidth(110.0f * _gui._scale);
    if (_gui.header("Visibility"))
    {
        //OnUpdateUIOverlay(&UIOverlay);
    }
    ImGui::PopItemWidth();
    ImGui::End();
    ImGui::PopStyleVar();
    ImGui::Render();

    if (_gui.update() || _gui._updated) {

        //_gui.draw(cmd);
        _gui._updated = false;
    }
}
#endif

glm::mat4 DirectionalLight::get_projection()
{
	glm::mat4 projection = glm::orthoLH_ZO(-shadowExtent.x, shadowExtent.x, -shadowExtent.y, shadowExtent.y, -shadowExtent.z, shadowExtent.z);
	return projection;
}

glm::mat4 DirectionalLight::get_view()
{
	glm::vec3 camPos = lightPosition;

	glm::vec3 camFwd = lightDirection;

	glm::mat4 view = glm::lookAt(camPos, camPos + camFwd, glm::vec3(1.0f, 0.0f, 0.0f));
	return view;
}
