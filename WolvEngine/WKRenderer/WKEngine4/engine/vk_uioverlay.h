/*
* UI overlay class using ImGui
*
* Copyright (C) 2017 by Sascha Willems - www.saschawillems.de
*
* This code is licensed under the MIT license (MIT) (http://opensource.org/licenses/MIT)
*/

#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <assert.h>
#include <vector>
#include <sstream>
#include <iomanip>
#include "VulkanBuffer.h"
#include <glm/glm.hpp>

#include "imgui/imgui.h"

namespace WolvenEngine
{
	class UIOverlay 
	{
	public:
		VkDevice _device;
		VkQueue _queue;
		VkPhysicalDeviceMemoryProperties _memProperties;
		VkSampleCountFlagBits _rasterizationSamples = VK_SAMPLE_COUNT_1_BIT;
		uint32_t _subpass = 0;

        vks::Buffer _vertexBuffer;
		vks::Buffer _indexBuffer;

		int32_t _vertexCount = 0;
		int32_t _indexCount = 0;

		std::vector<VkPipelineShaderStageCreateInfo> _shaders;

		VkCommandPool _commandPool = VK_NULL_HANDLE;
		VkDescriptorPool _descriptorPool;
		VkDescriptorSetLayout _descriptorSetLayout;
		VkDescriptorSet _descriptorSet;
		VkPipelineLayout _pipelineLayout;
		VkPipeline _pipeline;
		VkPipelineCache _pipelineCache;

		VkDeviceMemory _fontMemory = VK_NULL_HANDLE;
		VkImage _fontImage = VK_NULL_HANDLE;
		VkImageView _fontView = VK_NULL_HANDLE;
		VkSampler _sampler;

		struct PushConstBlock {
			glm::vec2 scale;
			glm::vec2 translate;
		} _pushConstBlock;

		bool _visible = true;
		bool _updated = false;
		float _scale = 1.0f;

		UIOverlay();
		~UIOverlay();

		void preparePipeline(const VkRenderPass renderPass);
		void prepareResources(uint32_t graphicsQueueFamily);

		bool update();
		void draw(const VkCommandBuffer commandBuffer);
		void draw(const VkCommandBuffer commandBuffer, const VkRenderPass renderPass);
		void resize(uint32_t width, uint32_t height);

		void freeResources();

		bool header(const char* caption);
		bool checkBox(int index, const char* caption, ImGuiTreeNodeFlags flags, bool* checked, bool* selected);
		bool checkBox(const char* caption, int32_t* value);
		bool inputFloat(const char* caption, float* value, float step, uint32_t precision);
		bool sliderFloat(const char* caption, float* value, float min, float max);
		bool sliderInt(const char* caption, int32_t* value, int32_t min, int32_t max);
		bool comboBox(const char* caption, int32_t* itemindex, std::vector<std::string> items);
		bool button(const char* caption);
		void text(const char* formatstr, ...);

	private:
		std::vector<VkShaderModule> _shaderModules;

		VkPipelineShaderStageCreateInfo loadShader(std::string fileName, VkShaderStageFlagBits stage);
		VkResult createBuffer(VkBufferUsageFlags usageFlags, VkMemoryPropertyFlags memoryPropertyFlags, vks::Buffer* buffer, VkDeviceSize size, void* data = nullptr);
		VkCommandBuffer createCommandBuffer(VkCommandBufferLevel level, bool begin = false);

		VkCommandPool createCommandPool(uint32_t queueFamilyIndex, VkCommandPoolCreateFlags createFlags = VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT);
		uint32_t getMemoryType(VkMemoryPropertyFlags properties, uint32_t type_bits);
	};
}