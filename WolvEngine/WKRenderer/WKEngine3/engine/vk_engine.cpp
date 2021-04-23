#define _USE_MATH_DEFINES
#include <cmath>

#include "vk_engine.h"
#define VMA_IMPLEMENTATION
#include "vk_mem_alloc.h"
#include "vk_mem_utils.h"

namespace WolvenEngine
{
#ifdef _DEBUG
    VulkanEngine::VulkanEngine() : VulkanExampleBase(true)
#else
	VulkanEngine::VulkanEngine() : VulkanExampleBase()
#endif
	{
		title = "Wolven Engine";
		settings.overlay = true;
        camera.type = Camera::CameraType::firstperson;
        camera.setPosition(glm::vec3(0.0f, -6.0f, -10.f));
        camera.setRotationSpeed(0.5f);
        camera.setMovementSpeed(20.0f);
        camera.setPerspective(60.0f, (float_t)width / (float_t)height, 0.001f, 100000.0f);

        vkcr2w::world = glm::rotate(glm::mat4(1.0f), -(float_t)M_PI_2, glm::vec3(1.0f, 0, 0));
        //vkcr2w::world = glm::mat4(1.0f);
        //glm::scale(vkcr2w::world, glm::vec3(1.0f, -1.0f, 1.0f));


		/*
			[POI] Enable extension required for conditional rendering
		*/
		enabledDeviceExtensions.push_back(VK_EXT_CONDITIONAL_RENDERING_EXTENSION_NAME);

        loadPathHashes("pathhashes.csv", PathHashes);
	}

	VulkanEngine::~VulkanEngine()
    {
        vkDestroyPipeline(device, pipeline, nullptr);
        vkDestroyPipeline(device, terrainPipeline, nullptr);
        vkDestroyPipelineLayout(device, pipelineLayout, nullptr);
        vkDestroyDescriptorSetLayout(device, descriptorSetLayout, nullptr);
#ifdef USE_VMA
        scene.cleanUp();

        vmaDestroyBuffer(_allocator, uniformBuffer._buffer, uniformBuffer._allocation);
        vmaDestroyBuffer(_allocator, conditionalBuffer._buffer, conditionalBuffer._allocation);
        vmaDestroyAllocator(_allocator);
#else
        uniformBuffer.destroy();
        conditionalBuffer.destroy();
#endif
    }

    AllocatedBuffer VulkanEngine::create_buffer(size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage)
    {
        return WolvenEngine::create_buffer(_allocator, allocSize, usage, memoryUsage);
    }

    void VulkanEngine::renderNode(vkcr2w::Node* node, VkCommandBuffer commandBuffer) {
        if (node->mesh) {
            for (vkcr2w::Primitive* primitive : node->mesh->primitives) {
                const std::vector<VkDescriptorSet> descriptorsets = {
                    descriptorSet,
#ifdef USE_VMA
                    node->descriptorSet
#else
                    node->uniformBuffer.descriptorSet
#endif
                };
                vkCmdBindDescriptorSets(commandBuffer, VK_PIPELINE_BIND_POINT_GRAPHICS, pipelineLayout, 0, static_cast<uint32_t>(descriptorsets.size()), descriptorsets.data(), 0, NULL);

                /*
                    [POI] Setup the conditional rendering
                */
                VkConditionalRenderingBeginInfoEXT conditionalRenderingBeginInfo{};
                conditionalRenderingBeginInfo.sType = VK_STRUCTURE_TYPE_CONDITIONAL_RENDERING_BEGIN_INFO_EXT;
#ifdef USE_VMA
                conditionalRenderingBeginInfo.buffer = conditionalBuffer._buffer;
#else
                conditionalRenderingBeginInfo.buffer = conditionalBuffer.buffer;
#endif
                conditionalRenderingBeginInfo.offset = sizeof(int32_t) * node->index;

                /*
                    [POI] Begin conditionally rendered section

                    If the value from the conditional rendering buffer at the given offset is != 0, the draw commands will be executed
                */
                vkCmdBeginConditionalRenderingEXT(commandBuffer, &conditionalRenderingBeginInfo);

                vkCmdDrawIndexed(commandBuffer, primitive->indexCount, 1, primitive->firstIndex, primitive->firstVertex, 0);

                vkCmdEndConditionalRenderingEXT(commandBuffer);
            }

        };
    }

    void VulkanEngine::renderNode(vkcr2w::TerrainNode* node, VkCommandBuffer commandBuffer) {
        if (node->mesh) {
            const VkDeviceSize offsets[1] = { 0 };
#ifdef USE_VMA
            vkCmdBindVertexBuffers(commandBuffer, 0, 1, &node->vertices._buffer, offsets);
            vkCmdBindIndexBuffer(commandBuffer, node->indices._buffer, 0, VK_INDEX_TYPE_UINT32);
#else
            vkCmdBindVertexBuffers(commandBuffer, 0, 1, &scene.terrainVertices.buffer, offsets);
            vkCmdBindIndexBuffer(commandBuffer, scene.terrainIndices.buffer, 0, VK_INDEX_TYPE_UINT32);
#endif

            for (vkcr2w::Primitive* primitive : node->mesh->primitives) {
                const std::vector<VkDescriptorSet> descriptorsets = {
                    descriptorSet,
#ifdef USE_VMA
                    node->descriptorSet
#else
                    node->uniformBuffer.descriptorSet
#endif
                };
                vkCmdBindDescriptorSets(commandBuffer, VK_PIPELINE_BIND_POINT_GRAPHICS, pipelineLayout, 0, static_cast<uint32_t>(descriptorsets.size()), descriptorsets.data(), 0, NULL);

                /*
                    [POI] Setup the conditional rendering
                */
                VkConditionalRenderingBeginInfoEXT conditionalRenderingBeginInfo{};
                conditionalRenderingBeginInfo.sType = VK_STRUCTURE_TYPE_CONDITIONAL_RENDERING_BEGIN_INFO_EXT;
#ifdef USE_VMA
                conditionalRenderingBeginInfo.buffer = conditionalBuffer._buffer;
#else
                conditionalRenderingBeginInfo.buffer = conditionalBuffer.buffer;
#endif
                conditionalRenderingBeginInfo.offset = sizeof(int32_t) * node->index;

                /*
                    [POI] Begin conditionally rendered section

                    If the value from the conditional rendering buffer at the given offset is != 0, the draw commands will be executed
                */
                vkCmdBeginConditionalRenderingEXT(commandBuffer, &conditionalRenderingBeginInfo);

                vkCmdDrawIndexed(commandBuffer, primitive->indexCount, 1, primitive->firstIndex, primitive->firstVertex, 0);

                vkCmdEndConditionalRenderingEXT(commandBuffer);
            }

        };
    }

    void VulkanEngine::buildCommandBuffers()
    {
        VkCommandBufferBeginInfo cmdBufInfo = vks::initializers::commandBufferBeginInfo();

        VkClearValue clearValues[2];
        clearValues[0].color = { { 0.0f, 0.0f, 0.4f, 1.0f } };
        clearValues[1].depthStencil = { 1.0f, 0 };

        VkRenderPassBeginInfo renderPassBeginInfo = vks::initializers::renderPassBeginInfo();
        renderPassBeginInfo.renderPass = renderPass;
        renderPassBeginInfo.renderArea.offset.x = 0;
        renderPassBeginInfo.renderArea.offset.y = 0;
        renderPassBeginInfo.renderArea.extent.width = width;
        renderPassBeginInfo.renderArea.extent.height = height;
        renderPassBeginInfo.clearValueCount = 2;
        renderPassBeginInfo.pClearValues = clearValues;

        for (int32_t i = 0; i < drawCmdBuffers.size(); ++i) {
            renderPassBeginInfo.framebuffer = frameBuffers[i];

            VK_CHECK_RESULT(vkBeginCommandBuffer(drawCmdBuffers[i], &cmdBufInfo));

            vkCmdBeginRenderPass(drawCmdBuffers[i], &renderPassBeginInfo, VK_SUBPASS_CONTENTS_INLINE);

            VkViewport viewport = vks::initializers::viewport((float)width, (float)height, 0.0f, 1.0f);
            vkCmdSetViewport(drawCmdBuffers[i], 0, 1, &viewport);
            VkRect2D scissor = vks::initializers::rect2D(width, height, 0, 0);
            vkCmdSetScissor(drawCmdBuffers[i], 0, 1, &scissor);

            vkCmdBindDescriptorSets(drawCmdBuffers[i], VK_PIPELINE_BIND_POINT_GRAPHICS, pipelineLayout, 0, 1, &descriptorSet, 0, NULL);

            vkCmdBindPipeline(drawCmdBuffers[i], VK_PIPELINE_BIND_POINT_GRAPHICS, pipeline);

            const VkDeviceSize offsets[1] = { 0 };
#ifdef USE_VMA
            vkCmdBindVertexBuffers(drawCmdBuffers[i], 0, 1, &scene.vertices._buffer, offsets);
            vkCmdBindIndexBuffer(drawCmdBuffers[i], scene.indices._buffer, 0, VK_INDEX_TYPE_UINT16);
#else
            vkCmdBindVertexBuffers(drawCmdBuffers[i], 0, 1, &scene.vertices.buffer, offsets);
            vkCmdBindIndexBuffer(drawCmdBuffers[i], scene.indices.buffer, 0, VK_INDEX_TYPE_UINT16);
#endif
            for (auto node : scene.nodes) {
                renderNode(node, drawCmdBuffers[i]);
            }

            if (scene._hasTerrain)
            {
                vkCmdBindPipeline(drawCmdBuffers[i], VK_PIPELINE_BIND_POINT_GRAPHICS, terrainPipeline);
                for (auto node : scene.terrainNodes) {
                    renderNode(node, drawCmdBuffers[i]);
                }
            }

            drawUI(drawCmdBuffers[i]);

            vkCmdEndRenderPass(drawCmdBuffers[i]);

            VK_CHECK_RESULT(vkEndCommandBuffer(drawCmdBuffers[i]));
        }
    }

    void VulkanEngine::setupDescriptorSets()
    {
        std::vector<VkDescriptorPoolSize> poolSizes = {
            vks::initializers::descriptorPoolSize(VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, 1),
        };
        VkDescriptorPoolCreateInfo descriptorPoolCI = vks::initializers::descriptorPoolCreateInfo((uint32_t)poolSizes.size(), poolSizes.data(), 1);
        VK_CHECK_RESULT(vkCreateDescriptorPool(device, &descriptorPoolCI, nullptr, &descriptorPool));

        std::vector<VkDescriptorSetLayoutBinding> setLayoutBindings = {
            vks::initializers::descriptorSetLayoutBinding(VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, VK_SHADER_STAGE_VERTEX_BIT, 0),
        };
        VkDescriptorSetLayoutCreateInfo descriptorLayoutCI{};
        descriptorLayoutCI.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO;
        descriptorLayoutCI.bindingCount = static_cast<uint32_t>(setLayoutBindings.size());
        descriptorLayoutCI.pBindings = setLayoutBindings.data();
        VK_CHECK_RESULT(vkCreateDescriptorSetLayout(device, &descriptorLayoutCI, nullptr, &descriptorSetLayout));

        std::array<VkDescriptorSetLayout, 2> setLayouts = {
            descriptorSetLayout, vkcr2w::descriptorSetLayoutUbo
        };
        VkPipelineLayoutCreateInfo pipelineLayoutCI = vks::initializers::pipelineLayoutCreateInfo(setLayouts.data(), 2);
        VK_CHECK_RESULT(vkCreatePipelineLayout(device, &pipelineLayoutCI, nullptr, &pipelineLayout));

        VkDescriptorSetAllocateInfo descriptorSetAllocateInfo = vks::initializers::descriptorSetAllocateInfo(descriptorPool, &descriptorSetLayout, 1);
        VK_CHECK_RESULT(vkAllocateDescriptorSets(device, &descriptorSetAllocateInfo, &descriptorSet));
#ifdef USE_VMA
        VkDescriptorBufferInfo uniformBufferInfo;
        uniformBufferInfo.buffer = uniformBuffer._buffer;
        uniformBufferInfo.offset = 0;
        uniformBufferInfo.range = sizeof(uboVS);
        std::vector<VkWriteDescriptorSet> writeDescriptorSets = {
            vks::initializers::writeDescriptorSet(descriptorSet, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, 0, &uniformBufferInfo)
        };
#else
        std::vector<VkWriteDescriptorSet> writeDescriptorSets = {
            vks::initializers::writeDescriptorSet(descriptorSet, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, 0, &uniformBuffer.descriptor)
        };
#endif
        vkUpdateDescriptorSets(device, (uint32_t)writeDescriptorSets.size(), writeDescriptorSets.data(), 0, NULL);
    }

    void VulkanEngine::preparePipelines()
    {
        const std::vector<VkDynamicState> dynamicStateEnables = { VK_DYNAMIC_STATE_VIEWPORT, VK_DYNAMIC_STATE_SCISSOR };

        VkPipelineInputAssemblyStateCreateInfo inputAssemblyStateCI = vks::initializers::pipelineInputAssemblyStateCreateInfo(VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST, 0, VK_FALSE);
        VkPipelineRasterizationStateCreateInfo rasterizationStateCI = vks::initializers::pipelineRasterizationStateCreateInfo(VK_POLYGON_MODE_FILL, VK_CULL_MODE_NONE, /*VK_CULL_MODE_BACK_BIT,*/ VK_FRONT_FACE_COUNTER_CLOCKWISE, 0);
        VkPipelineColorBlendAttachmentState blendAttachmentState = vks::initializers::pipelineColorBlendAttachmentState(0xf, VK_FALSE);
        VkPipelineColorBlendStateCreateInfo colorBlendStateCI = vks::initializers::pipelineColorBlendStateCreateInfo(1, &blendAttachmentState);
        VkPipelineDepthStencilStateCreateInfo depthStencilStateCI = vks::initializers::pipelineDepthStencilStateCreateInfo(VK_TRUE, VK_TRUE, VK_COMPARE_OP_LESS_OR_EQUAL);
        VkPipelineViewportStateCreateInfo viewportStateCI = vks::initializers::pipelineViewportStateCreateInfo(1, 1, 0);
        VkPipelineMultisampleStateCreateInfo multisampleStateCI = vks::initializers::pipelineMultisampleStateCreateInfo(VK_SAMPLE_COUNT_1_BIT, 0);
        VkPipelineDynamicStateCreateInfo dynamicStateCI = vks::initializers::pipelineDynamicStateCreateInfo(dynamicStateEnables.data(), static_cast<uint32_t>(dynamicStateEnables.size()), 0);

        VkGraphicsPipelineCreateInfo pipelineCI = vks::initializers::pipelineCreateInfo(pipelineLayout, renderPass, 0);
        pipelineCI.pInputAssemblyState = &inputAssemblyStateCI;
        pipelineCI.pRasterizationState = &rasterizationStateCI;
        pipelineCI.pColorBlendState = &colorBlendStateCI;
        pipelineCI.pMultisampleState = &multisampleStateCI;
        pipelineCI.pViewportState = &viewportStateCI;
        pipelineCI.pDepthStencilState = &depthStencilStateCI;
        pipelineCI.pDynamicState = &dynamicStateCI;
        pipelineCI.pVertexInputState = vkcr2w::Vertex::getPipelineVertexInputState({ vkcr2w::VertexComponent::Position, vkcr2w::VertexComponent::Normal, vkcr2w::VertexComponent::UV });

        const std::array<VkPipelineShaderStageCreateInfo, 2> shaderStages = {
            loadShader("model.vert.spv", VK_SHADER_STAGE_VERTEX_BIT),
            loadShader("model.frag.spv", VK_SHADER_STAGE_FRAGMENT_BIT)
        };

        pipelineCI.stageCount = static_cast<uint32_t>(shaderStages.size());
        pipelineCI.pStages = shaderStages.data();

        VK_CHECK_RESULT(vkCreateGraphicsPipelines(device, pipelineCache, 1, &pipelineCI, nullptr, &pipeline));

        // terrain pipeline
        inputAssemblyStateCI = vks::initializers::pipelineInputAssemblyStateCreateInfo(VK_PRIMITIVE_TOPOLOGY_TRIANGLE_STRIP, 0, VK_FALSE);
        //rasterizationStateCI = vks::initializers::pipelineRasterizationStateCreateInfo(VK_POLYGON_MODE_FILL, VK_CULL_MODE_NONE, VK_FRONT_FACE_COUNTER_CLOCKWISE, 0);
        rasterizationStateCI = vks::initializers::pipelineRasterizationStateCreateInfo(VK_POLYGON_MODE_FILL, VK_CULL_MODE_BACK_BIT, VK_FRONT_FACE_COUNTER_CLOCKWISE, 0);

        VkGraphicsPipelineCreateInfo terrainPipelineCI = vks::initializers::pipelineCreateInfo(pipelineLayout, renderPass, 0);
        terrainPipelineCI.pInputAssemblyState = &inputAssemblyStateCI;
        terrainPipelineCI.pRasterizationState = &rasterizationStateCI;
        terrainPipelineCI.pColorBlendState = &colorBlendStateCI;
        terrainPipelineCI.pMultisampleState = &multisampleStateCI;
        terrainPipelineCI.pViewportState = &viewportStateCI;
        terrainPipelineCI.pDepthStencilState = &depthStencilStateCI;
        terrainPipelineCI.pDynamicState = &dynamicStateCI;
        terrainPipelineCI.pVertexInputState = vkcr2w::Vertex::getPipelineVertexInputState({ vkcr2w::VertexComponent::Position, vkcr2w::VertexComponent::Normal, vkcr2w::VertexComponent::UV, vkcr2w::VertexComponent::Color});

        const std::array<VkPipelineShaderStageCreateInfo, 2> terrainShaderStages = {
            loadShader("wk_terrain.vert.spv", VK_SHADER_STAGE_VERTEX_BIT),
            loadShader("wk_terrain.frag.spv", VK_SHADER_STAGE_FRAGMENT_BIT)
        };

        terrainPipelineCI.stageCount = static_cast<uint32_t>(terrainShaderStages.size());
        terrainPipelineCI.pStages = terrainShaderStages.data();

        VK_CHECK_RESULT(vkCreateGraphicsPipelines(device, pipelineCache, 1, &terrainPipelineCI, nullptr, &terrainPipeline));
    }

    void VulkanEngine::prepareUniformBuffers()
    {
#ifdef USE_VMA
        uniformBuffer = create_buffer(sizeof(uboVS), VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);
#else
        VK_CHECK_RESULT(vulkanDevice->createBuffer(
            VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT,
            VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT,
            &uniformBuffer,
            sizeof(uboVS)));
        VK_CHECK_RESULT(uniformBuffer.map());
#endif
        updateUniformBuffers();
    }

    void VulkanEngine::updateUniformBuffers()
    {
        uboVS.projection = camera.matrices.perspective;
        uboVS.view = camera.matrices.view;
        uboVS.model = glm::mat4(1.0f);
#ifdef USE_VMA
        char* data;
        vmaMapMemory(_allocator, uniformBuffer._allocation, (void**)&data);
        memcpy(data, &uboVS, sizeof(uboVS));
        vmaUnmapMemory(_allocator, uniformBuffer._allocation);
#else
        memcpy(uniformBuffer.mapped, &uboVS, sizeof(uboVS));
#endif
    }

    void VulkanEngine::updateConditionalBuffer()
    {
#ifdef USE_VMA
        char* data;
        vmaMapMemory(_allocator, conditionalBuffer._allocation, (void**)&data);
        memcpy(data, conditionalVisibility.data(), sizeof(int32_t) * conditionalVisibility.size());
        vmaUnmapMemory(_allocator, conditionalBuffer._allocation);
#else
        memcpy(conditionalBuffer.mapped, conditionalVisibility.data(), sizeof(int32_t) * conditionalVisibility.size());
#endif
    }

    void VulkanEngine::prepareConditionalRendering()
    {
        /*
            The conditional rendering functions are part of an extension so they have to be loaded manually
        */
        vkCmdBeginConditionalRenderingEXT = (PFN_vkCmdBeginConditionalRenderingEXT)vkGetDeviceProcAddr(device, "vkCmdBeginConditionalRenderingEXT");
        if (!vkCmdBeginConditionalRenderingEXT) {
            vks::tools::exitFatal("Could not get a valid function pointer for vkCmdBeginConditionalRenderingEXT", -1);
        }

        vkCmdEndConditionalRenderingEXT = (PFN_vkCmdEndConditionalRenderingEXT)vkGetDeviceProcAddr(device, "vkCmdEndConditionalRenderingEXT");
        if (!vkCmdEndConditionalRenderingEXT) {
            vks::tools::exitFatal("Could not get a valid function pointer for vkCmdEndConditionalRenderingEXT", -1);
        }

        /*
            Create the buffer that contains the conditional rendering information

            A single conditional value is 32 bits and if it's zero the rendering commands are discarded
            This sample renders multiple rows of objects conditionally, so we setup a buffer with one value per row
        */
        conditionalVisibility.resize(scene.linearNodes.size());
#ifdef USE_VMA
        conditionalBuffer = create_buffer(sizeof(int32_t) * conditionalVisibility.size(), VK_BUFFER_USAGE_CONDITIONAL_RENDERING_BIT_EXT, VMA_MEMORY_USAGE_CPU_TO_GPU);
#else
        VK_CHECK_RESULT(vulkanDevice->createBuffer(
            VK_BUFFER_USAGE_CONDITIONAL_RENDERING_BIT_EXT,
            VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT,
            &conditionalBuffer,
            sizeof(int32_t) * conditionalVisibility.size(),
            conditionalVisibility.data()));
        VK_CHECK_RESULT(conditionalBuffer.map());
#endif

        // By default, all parts of the glTF are visible
        for (auto i = 0; i < conditionalVisibility.size(); i++) {
            conditionalVisibility[i] = 1;
        }

        /*
            Copy visibility data
        */
        updateConditionalBuffer();
    }

    void VulkanEngine::draw()
    {
        VulkanExampleBase::prepareFrame();
        submitInfo.commandBufferCount = 1;
        submitInfo.pCommandBuffers = &drawCmdBuffers[currentBuffer];
        VK_CHECK_RESULT(vkQueueSubmit(queue, 1, &submitInfo, VK_NULL_HANDLE));
        VulkanExampleBase::submitFrame();
    }

    void VulkanEngine::loadAssets(const std::string& asset)
    {
        scene.camera = &camera;
        scene.loadFromFile(asset, vulkanDevice, queue);
    }

    void VulkanEngine::prepare(const std::string& asset)
    {
        VulkanExampleBase::prepare();
#ifdef USE_VMA
        //initialize the memory allocator
        VmaAllocatorCreateInfo allocatorInfo = {};
        allocatorInfo.physicalDevice = physicalDevice;
        allocatorInfo.device = device;
        allocatorInfo.instance = instance;
        vmaCreateAllocator(&allocatorInfo, &_allocator);
        scene.setAllocator(_allocator);
#endif
        loadAssets(asset);
        prepareConditionalRendering();
        prepareUniformBuffers();
        setupDescriptorSets();
        preparePipelines();
        buildCommandBuffers();
        prepared = true;
    }

    void VulkanEngine::render()
    {
        if (!prepared)
            return;
        draw();
        if (camera.updated) {
            updateUniformBuffers();
        }
    }

    void VulkanEngine::OnUpdateUIOverlay(vks::UIOverlay* overlay)
    {
        if (overlay->header("Visibility")) {

            if (overlay->button("All")) {
                for (auto i = 0; i < conditionalVisibility.size(); i++) {
                    conditionalVisibility[i] = 1;
                }
                updateConditionalBuffer();
            }
            ImGui::SameLine();
            if (overlay->button("None")) {
                for (auto i = 0; i < conditionalVisibility.size(); i++) {
                    conditionalVisibility[i] = 0;
                }
                updateConditionalBuffer();
            }
            ImGui::NewLine();

            ImGui::BeginChild("InnerRegion", ImVec2(200.0f, 400.0f), false);
            for (auto node : scene.linearNodes) {
                // Add visibility toggle checkboxes for all model nodes with a mesh
                //if (node->mesh) 
                {
                    if (overlay->checkBox(("[" + std::to_string(node.index) + "] " + node.name).c_str(), &conditionalVisibility[node.index])) {
                        updateConditionalBuffer();
                    }
                }
            }
            ImGui::EndChild();

        }
    }

}