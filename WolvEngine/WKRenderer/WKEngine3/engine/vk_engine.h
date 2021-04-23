// vulkan_guide.h : Include file for standard system include files,
// or project specific include files.

#pragma once

#ifdef _WIN32
#pragma comment(linker, "/subsystem:windows")
#include <windows.h>
#include <fcntl.h>
#include <io.h>
#include <ShellScalingAPI.h>
#endif

#include "vulkanexamplebase.h"
#include "Vulkancr2wModel.h"

namespace WolvenEngine
{
    class VulkanEngine : public VulkanExampleBase
    {
	private:
#ifdef USE_VMA
        VmaAllocator _allocator; //vma lib allocator
        AllocatedBuffer create_buffer(size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage);
#endif

    public:
        PFN_vkCmdBeginConditionalRenderingEXT vkCmdBeginConditionalRenderingEXT;
        PFN_vkCmdEndConditionalRenderingEXT vkCmdEndConditionalRenderingEXT;
		vkcr2w::Model scene;

		struct {
			glm::mat4 projection;
			glm::mat4 view;
			glm::mat4 model;
		} uboVS;

#ifdef USE_VMA
		AllocatedBuffer uniformBuffer;
		AllocatedBuffer conditionalBuffer;
#else
		vks::Buffer uniformBuffer;
        vks::Buffer conditionalBuffer;
#endif

		std::vector<int32_t> conditionalVisibility;

		VkPipelineLayout pipelineLayout;
		VkPipeline pipeline;
		VkDescriptorSetLayout descriptorSetLayout;
		VkDescriptorSet descriptorSet;

        VkPipeline terrainPipeline;

		VulkanEngine();
		~VulkanEngine();

		void renderNode(vkcr2w::Node* node, VkCommandBuffer commandBuffer);
		void renderNode(vkcr2w::TerrainNode* node, VkCommandBuffer commandBuffer);
		void buildCommandBuffers();
		void setupDescriptorSets();
		void preparePipelines();
		void prepareUniformBuffers();
		void updateUniformBuffers();
		void updateConditionalBuffer();
		void prepareConditionalRendering();
		void loadAssets(const std::string& asset);
		void draw();
		void prepare(const std::string& asset);
		virtual void render();
		virtual void OnUpdateUIOverlay(vks::UIOverlay* overlay);
    };
}
