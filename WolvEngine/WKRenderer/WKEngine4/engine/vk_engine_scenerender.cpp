#include "vk_engine.h"

#include <vk_types.h>
#include <vk_initializers.h>
#include <vk_descriptors.h>

#include "vk_textures.h"
#include "vk_shaders.h"

#ifdef USE_PROFILER
#include "vk_profiler.h"
#endif

glm::vec4 normalizePlane(glm::vec4 p)
{
	return p / glm::length(glm::vec3(p));
}

void VulkanEngine::execute_compute_cull(VkCommandBuffer cmd, RenderScene::MeshPass& pass,CullParams& params )
{
    if (pass.batches.size() == 0) return;
    VkDescriptorBufferInfo objectBufferInfo = _renderScene.objectDataBuffer.get_info();

    VkDescriptorBufferInfo instanceInfo = pass.passObjectsBuffer.get_info();
    VkDescriptorBufferInfo finalInfo = pass.compactedInstanceBuffer.get_info();
    VkDescriptorBufferInfo indirectInfo = pass.drawIndirectBuffer.get_info();

    VkDescriptorImageInfo depthPyramid;
    depthPyramid.sampler = _depthSampler;
    depthPyramid.imageView = _depthPyramid._defaultView;
    depthPyramid.imageLayout = VK_IMAGE_LAYOUT_GENERAL;

#ifdef USE_MULTITHREADING
    VkDescriptorBufferInfo dynamicInfo = _dynamicData.source.get_info();
    dynamicInfo.range = sizeof(GPUCameraData);

    VkDescriptorSet COMPObjectDataSet;
    vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, _dynamicDescriptorAllocator)
        .bind_buffer(0, &objectBufferInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
        .bind_buffer(1, &indirectInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
        .bind_buffer(2, &instanceInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
        .bind_buffer(3, &finalInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
        .bind_image(4, &depthPyramid, VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, VK_SHADER_STAGE_COMPUTE_BIT)
        .bind_buffer(5, &dynamicInfo, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
        .build(COMPObjectDataSet);
#else
	VkDescriptorBufferInfo dynamicInfo = get_current_frame().dynamicData.source.get_info();
	dynamicInfo.range = sizeof(GPUCameraData);

	VkDescriptorSet COMPObjectDataSet;
	vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, get_current_frame().dynamicDescriptorAllocator)
		.bind_buffer(0, &objectBufferInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
		.bind_buffer(1, &indirectInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
		.bind_buffer(2, &instanceInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
		.bind_buffer(3, &finalInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
		.bind_image(4, &depthPyramid, VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, VK_SHADER_STAGE_COMPUTE_BIT)
		.bind_buffer(5, &dynamicInfo, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
		.build(COMPObjectDataSet);
#endif

	glm::mat4 projection = params.projmat;
	glm::mat4 projectionT = transpose(projection);

	glm::vec4 frustumX = normalizePlane(projectionT[3] + projectionT[0]); // x + w < 0
	glm::vec4 frustumY = normalizePlane(projectionT[3] + projectionT[1]); // y + w < 0

	DrawCullData cullData = {};
	cullData.P00 = projection[0][0];
	cullData.P11 = projection[1][1];
	cullData.znear = 0.001f;
	cullData.zfar = params.drawDist;
	cullData.frustum[0] = frustumX.x;
	cullData.frustum[1] = frustumX.z;
	cullData.frustum[2] = frustumY.y;
	cullData.frustum[3] = frustumY.z;
	cullData.drawCount = static_cast<uint32_t>(pass.flat_batches.size());
	cullData.cullingEnabled = params.frustrumCull;
	cullData.lodEnabled = false;
	cullData.occlusionEnabled = params.occlusionCull;
	cullData.lodBase = 10.f;
	cullData.lodStep = 1.5f;
	cullData.pyramidWidth = static_cast<float>(depthPyramidWidth);
	cullData.pyramidHeight = static_cast<float>(depthPyramidHeight);
	cullData.viewMat = params.viewmat;//get_view_matrix();

	if (params.drawDist > 10000)
	{
		cullData.distanceCheck = false; 
	}
	else
	{
		cullData.distanceCheck = true;
	}

	vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_COMPUTE, _cullPipeline);

	vkCmdPushConstants(cmd, _cullLayout, VK_SHADER_STAGE_COMPUTE_BIT, 0, sizeof(DrawCullData), &cullData);

	vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_COMPUTE, _cullLayout, 0, 1, &COMPObjectDataSet, 0, nullptr);
	
	vkCmdDispatch(cmd, static_cast<uint32_t>((pass.flat_batches.size() / 256)+1), 1, 1);


	//barrier the 2 buffers we just wrote for culling, the indirect draw one, and the instances one, so that they can be read well when rendering the pass
	{
		VkBufferMemoryBarrier barrier = vkinit::buffer_barrier(pass.compactedInstanceBuffer._buffer, _graphicsQueueFamily);
		barrier.srcAccessMask = VK_ACCESS_SHADER_WRITE_BIT;
		barrier.dstAccessMask = VK_ACCESS_INDIRECT_COMMAND_READ_BIT;

		VkBufferMemoryBarrier barrier2 = vkinit::buffer_barrier(pass.drawIndirectBuffer._buffer, _graphicsQueueFamily);	
		barrier2.srcAccessMask = VK_ACCESS_SHADER_WRITE_BIT;
		barrier2.dstAccessMask = VK_ACCESS_INDIRECT_COMMAND_READ_BIT;

		VkBufferMemoryBarrier barriers[] = { barrier,barrier2 };

		postCullBarriers.push_back(barrier);
		postCullBarriers.push_back(barrier2);
		
	}
}
#include <future>
void VulkanEngine::ready_mesh_draw(VkCommandBuffer cmd)
{
	//upload object data to gpu
	
	if (_renderScene.dirtyObjects.size() > 0)
	{
		size_t copySize = _renderScene.renderables.size() * sizeof(GPUObjectData);
		if (_renderScene.objectDataBuffer._size < copySize)
		{
			reallocate_buffer(_renderScene.objectDataBuffer, copySize, VK_BUFFER_USAGE_TRANSFER_DST_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);
		}

		//if 80% of the objects are dirty, then just reupload the whole thing
		if (_renderScene.dirtyObjects.size() >= _renderScene.renderables.size() * 0.8)
		{
			AllocatedBuffer<GPUObjectData> newBuffer = create_buffer<GPUObjectData>(copySize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);

			GPUObjectData* objectSSBO = map_buffer(newBuffer);
			_renderScene.fill_objectData(objectSSBO);
			unmap_buffer(newBuffer);

#ifdef USE_MULTITHREADING
            _frameDeletionQueue.push_function([=]() {
                vmaDestroyBuffer(_allocator, newBuffer._buffer, newBuffer._allocation);
                });
#else
			get_current_frame()._frameDeletionQueue.push_function([=]() {

				vmaDestroyBuffer(_allocator, newBuffer._buffer, newBuffer._allocation);
				});
#endif
		
			//copy from the uploaded cpu side instance buffer to the gpu one
			VkBufferCopy indirectCopy;
			indirectCopy.dstOffset = 0;
			indirectCopy.size = _renderScene.renderables.size() * sizeof(GPUObjectData);
			indirectCopy.srcOffset = 0;
			vkCmdCopyBuffer(cmd, newBuffer._buffer, _renderScene.objectDataBuffer._buffer, 1, &indirectCopy);
		}
		else {
			//update only the changed elements

			std::vector<VkBufferCopy> copies;
			copies.reserve(_renderScene.dirtyObjects.size());

			uint64_t buffersize = sizeof(GPUObjectData) * _renderScene.dirtyObjects.size();
			uint64_t intsize = sizeof(uint32_t);
			uint64_t wordsize = sizeof(GPUObjectData) / sizeof(uint32_t);
			uint64_t uploadSize = _renderScene.dirtyObjects.size() * wordsize * intsize;
			AllocatedBuffer<GPUObjectData> newBuffer = create_buffer<GPUObjectData>(buffersize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);
			AllocatedBuffer<uint32_t> targetBuffer = create_buffer<uint32_t>(uploadSize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);

#ifdef USE_MULTITHREADING
            _frameDeletionQueue.push_function([=]() {
                vmaDestroyBuffer(_allocator, newBuffer._buffer, newBuffer._allocation);
                vmaDestroyBuffer(_allocator, targetBuffer._buffer, targetBuffer._allocation);
                });
#else
			get_current_frame()._frameDeletionQueue.push_function([=]() {

				vmaDestroyBuffer(_allocator, newBuffer._buffer, newBuffer._allocation);
				vmaDestroyBuffer(_allocator, targetBuffer._buffer, targetBuffer._allocation);
				});
#endif
			uint32_t* targetData = map_buffer(targetBuffer);
			GPUObjectData* objectSSBO = map_buffer(newBuffer);
			uint32_t launchcount = static_cast<uint32_t>(_renderScene.dirtyObjects.size() * wordsize);
			{
				//ZoneScopedNC("Write dirty objects", tracy::Color::Red);
				uint32_t sidx = 0;
				for (int i = 0; i < _renderScene.dirtyObjects.size(); i++)
				{
					_renderScene.write_object(objectSSBO + i, _renderScene.dirtyObjects[i]);


					uint32_t dstOffset = static_cast<uint32_t>(wordsize * _renderScene.dirtyObjects[i].handle);

					for (int b = 0; b < wordsize; b++ )
					{
						uint32_t tidx = dstOffset + b;
						targetData[sidx] = tidx;
						sidx++;
					}
				}
				launchcount = sidx;
			}
			unmap_buffer(newBuffer);
			unmap_buffer(targetBuffer); 
			
			VkDescriptorBufferInfo indexData = targetBuffer.get_info();

			VkDescriptorBufferInfo sourceData = newBuffer.get_info(); 

			VkDescriptorBufferInfo targetInfo = _renderScene.objectDataBuffer.get_info();

			VkDescriptorSet COMPObjectDataSet;
#ifdef USE_MULTITHREADING
            vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, _dynamicDescriptorAllocator)
                .bind_buffer(0, &indexData, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
                .bind_buffer(1, &sourceData, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
                .build(COMPObjectDataSet);
#else
			vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, get_current_frame().dynamicDescriptorAllocator)
				.bind_buffer(0, &indexData, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
				.bind_buffer(1, &sourceData, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_COMPUTE_BIT)
				.build(COMPObjectDataSet);
#endif
			vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_COMPUTE, _sparseUploadPipeline);

			
			vkCmdPushConstants(cmd, _sparseUploadLayout, VK_SHADER_STAGE_COMPUTE_BIT, 0, sizeof(uint32_t), &launchcount);

			vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_COMPUTE, _sparseUploadLayout, 0, 1, &COMPObjectDataSet, 0, nullptr);

			vkCmdDispatch(cmd, ((launchcount) / 256) + 1, 1, 1);
		}

		VkBufferMemoryBarrier barrier = vkinit::buffer_barrier(_renderScene.objectDataBuffer._buffer, _graphicsQueueFamily);
		barrier.dstAccessMask = VK_ACCESS_SHADER_WRITE_BIT | VK_ACCESS_SHADER_READ_BIT;
		barrier.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
			
		uploadBarriers.push_back(barrier);
		_renderScene.clear_dirty_objects();
	}

	{
		auto& pass = _renderScene._forwardPass;

		//reallocate the gpu side buffers if needed

		if (pass.batches.size() && pass.drawIndirectBuffer._size < pass.batches.size() * sizeof(GPUIndirectObject))
		{
			reallocate_buffer(pass.drawIndirectBuffer, pass.batches.size() * sizeof(GPUIndirectObject), VK_BUFFER_USAGE_TRANSFER_DST_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT | VK_BUFFER_USAGE_INDIRECT_BUFFER_BIT, VMA_MEMORY_USAGE_GPU_ONLY);
		}

		if (pass.flat_batches.size() && pass.compactedInstanceBuffer._size < pass.flat_batches.size() * sizeof(uint32_t))
		{
			reallocate_buffer(pass.compactedInstanceBuffer, pass.flat_batches.size() * sizeof(uint32_t), VK_BUFFER_USAGE_TRANSFER_DST_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT, VMA_MEMORY_USAGE_GPU_ONLY);
		}

		if (pass.flat_batches.size() && pass.passObjectsBuffer._size < pass.flat_batches.size() * sizeof(GPUInstance))
		{
			reallocate_buffer(pass.passObjectsBuffer, pass.flat_batches.size() * sizeof(GPUInstance), VK_BUFFER_USAGE_TRANSFER_DST_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT, VMA_MEMORY_USAGE_GPU_ONLY);
		}
	}

	std::vector<std::future<void>> async_calls;
	async_calls.reserve(9);

	std::vector<AllocatedBufferUntyped> unmaps;
	
	{
		RenderScene::MeshPass& pass = _renderScene._forwardPass;
		RenderScene::MeshPass* ppass = &_renderScene._forwardPass;

		RenderScene* pScene = &_renderScene;
		//if the pass has changed the batches, need to reupload them
		if (pass.needsIndirectRefresh && pass.batches.size() > 0)
		{
			AllocatedBuffer<GPUIndirectObject> newBuffer = create_buffer<GPUIndirectObject>(sizeof(GPUIndirectObject) * pass.batches.size(), VK_BUFFER_USAGE_TRANSFER_SRC_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT | VK_BUFFER_USAGE_INDIRECT_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);
			GPUIndirectObject* indirect = map_buffer(newBuffer);			

			async_calls.push_back(std::async(std::launch::async, [=] { 
								
				pScene->fill_indirectArray(indirect, *ppass);
				
			}));
			
			unmaps.push_back(newBuffer);

			if (pass.clearIndirectBuffer._buffer != VK_NULL_HANDLE)
			{
				AllocatedBufferUntyped deletionBuffer = pass.clearIndirectBuffer;
				//add buffer to deletion queue of this frame
#ifdef USE_MULTITHREADING
                _frameDeletionQueue.push_function([=]() {
                    vmaDestroyBuffer(_allocator, deletionBuffer._buffer, deletionBuffer._allocation);
                    });
#else
				get_current_frame()._frameDeletionQueue.push_function([=]() {

					vmaDestroyBuffer(_allocator, deletionBuffer._buffer, deletionBuffer._allocation);
				});
#endif
			}

			pass.clearIndirectBuffer = newBuffer;
			pass.needsIndirectRefresh = false;
		}

		if (pass.needsInstanceRefresh && pass.flat_batches.size() >0)
		{
			AllocatedBuffer<GPUInstance> newBuffer = create_buffer<GPUInstance>(sizeof(GPUInstance) * pass.flat_batches.size(), VK_BUFFER_USAGE_TRANSFER_SRC_BIT | VK_BUFFER_USAGE_STORAGE_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);

			GPUInstance* instanceData = map_buffer(newBuffer);
			async_calls.push_back(std::async(std::launch::async, [=] {
				pScene->fill_instancesArray(instanceData, *ppass);
			}));
			unmaps.push_back(newBuffer);

#ifdef USE_MULTITHREADING
            _frameDeletionQueue.push_function([=]() {
                vmaDestroyBuffer(_allocator, newBuffer._buffer, newBuffer._allocation);
                });
#else
			get_current_frame()._frameDeletionQueue.push_function([=]() {

				vmaDestroyBuffer(_allocator, newBuffer._buffer, newBuffer._allocation);
				});
#endif		
			//copy from the uploaded cpu side instance buffer to the gpu one
			VkBufferCopy indirectCopy;
			indirectCopy.dstOffset = 0;
			indirectCopy.size = pass.flat_batches.size() * sizeof(GPUInstance);
			indirectCopy.srcOffset = 0;
			vkCmdCopyBuffer(cmd, newBuffer._buffer, pass.passObjectsBuffer._buffer, 1, &indirectCopy);

			VkBufferMemoryBarrier barrier = vkinit::buffer_barrier(pass.passObjectsBuffer._buffer, _graphicsQueueFamily);
			barrier.dstAccessMask = VK_ACCESS_SHADER_WRITE_BIT | VK_ACCESS_SHADER_READ_BIT;
			barrier.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;

			uploadBarriers.push_back(barrier);

			pass.needsInstanceRefresh = false;
		}
	}

	for (auto& s : async_calls)
	{
		s.get();
	}
	for (auto b : unmaps)
	{
		unmap_buffer(b);
	}

	vkCmdPipelineBarrier(cmd, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_PIPELINE_STAGE_COMPUTE_SHADER_BIT, 0, 0, nullptr, static_cast<uint32_t>(uploadBarriers.size()), uploadBarriers.data(), 0, nullptr);//1, &readBarrier);
	uploadBarriers.clear();
}

void VulkanEngine::draw_objects_forward(VkCommandBuffer cmd, RenderScene::MeshPass& pass)
{
	//make a model view matrix for rendering the object
	//camera view

	_sceneParameters.sunlightShadowMatrix =_mainLight.get_projection() * _mainLight.get_view();
	_sceneParameters.ambientColor = glm::vec4{ 0.5 };
	_sceneParameters.sunlightColor = glm::vec4{ 1.f };
	_sceneParameters.sunlightDirection = glm::vec4(_mainLight.lightDirection * 1.f,1.f);

	_sceneParameters.sunlightColor.w = 0;

    VkDescriptorBufferInfo objectBufferInfo = _renderScene.objectDataBuffer.get_info();
    VkDescriptorBufferInfo instanceInfo = pass.compactedInstanceBuffer.get_info();

	//push data to dynmem
#ifdef USE_MULTITHREADING
    uint32_t scene_data_offset = _dynamicData.push(_sceneParameters);
    uint32_t camera_data_offset = _dynamicData.push(_camera.matrices);

    VkDescriptorBufferInfo sceneInfo = _dynamicData.source.get_info();
    sceneInfo.range = sizeof(GPUSceneData);

    VkDescriptorBufferInfo camInfo = _dynamicData.source.get_info();
    camInfo.range = sizeof(GPUCameraData);

    VkDescriptorSet GlobalSet;
    vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, _dynamicDescriptorAllocator)
        .bind_buffer(0, &camInfo, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, VK_SHADER_STAGE_VERTEX_BIT)
        .bind_buffer(1, &sceneInfo, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, VK_SHADER_STAGE_VERTEX_BIT | VK_SHADER_STAGE_FRAGMENT_BIT)
        .build(GlobalSet);

    VkDescriptorSet ObjectDataSet;
    vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, _dynamicDescriptorAllocator)
        .bind_buffer(0, &objectBufferInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_VERTEX_BIT)
        .bind_buffer(1, &instanceInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_VERTEX_BIT)
        .build(ObjectDataSet);
#else
	uint32_t scene_data_offset = get_current_frame().dynamicData.push(_sceneParameters);
	uint32_t camera_data_offset = get_current_frame().dynamicData.push(_camera.matrices);

	VkDescriptorBufferInfo sceneInfo = get_current_frame().dynamicData.source.get_info();
	sceneInfo.range = sizeof(GPUSceneData);

	VkDescriptorBufferInfo camInfo = get_current_frame().dynamicData.source.get_info();
	camInfo.range = sizeof(GPUCameraData);


	VkDescriptorSet GlobalSet;
	vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, get_current_frame().dynamicDescriptorAllocator)
		.bind_buffer(0, &camInfo, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, VK_SHADER_STAGE_VERTEX_BIT)
		.bind_buffer(1, &sceneInfo, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, VK_SHADER_STAGE_VERTEX_BIT| VK_SHADER_STAGE_FRAGMENT_BIT)
		.build(GlobalSet);

	VkDescriptorSet ObjectDataSet;
	vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, get_current_frame().dynamicDescriptorAllocator)
		.bind_buffer(0, &objectBufferInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_VERTEX_BIT)
		.bind_buffer(1, &instanceInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_VERTEX_BIT)
		.build(ObjectDataSet);
#endif
    vkCmdSetDepthBias(cmd, 0, 0, 0);

	std::vector<uint32_t> dynamic_offsets;
	dynamic_offsets.push_back(camera_data_offset);
	dynamic_offsets.push_back(scene_data_offset);
	execute_draw_commands(cmd, pass, ObjectDataSet, dynamic_offsets, GlobalSet);
}

void VulkanEngine::execute_draw_commands(VkCommandBuffer cmd, RenderScene::MeshPass& pass, VkDescriptorSet ObjectDataSet, std::vector<uint32_t> dynamic_offsets, VkDescriptorSet GlobalSet)
{
	if(pass.batches.size() > 0)
	{
		Mesh* lastMesh = nullptr;
		VkPipeline lastPipeline{ VK_NULL_HANDLE };
		VkDescriptorSet lastMaterialSet{ VK_NULL_HANDLE };

		VkDeviceSize offset = 0;
		vkCmdBindVertexBuffers(cmd, 0, 1, &_renderScene.mergedVertexBuffer._buffer, &offset);

		vkCmdBindIndexBuffer(cmd, _renderScene.mergedIndexBuffer._buffer, 0, VK_INDEX_TYPE_UINT32);

		for (int i = 0; i < pass.multibatches.size(); i++)
		{
			auto& multibatch = pass.multibatches[i];
			auto& instanceDraw = pass.batches[multibatch.first];

			VkPipeline newPipeline = instanceDraw.material.shaderPass->pipeline;
			VkPipelineLayout newLayout = instanceDraw.material.shaderPass->layout;
			VkDescriptorSet newMaterialSet = instanceDraw.material.materialSet;

			Mesh* drawMesh = _renderScene.get_mesh(instanceDraw.meshID)->original;

			if (newPipeline != lastPipeline)
			{
				lastPipeline = newPipeline;
				vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, newPipeline);
				vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, newLayout, 1, 1, &ObjectDataSet, 0, nullptr);

				//update dynamic binds
				vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, newLayout, 0, 1, &GlobalSet, (uint32_t)dynamic_offsets.size(), dynamic_offsets.data());
			}
			if (newMaterialSet && newMaterialSet != lastMaterialSet)
			{
				lastMaterialSet = newMaterialSet;
				vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, newLayout, 2, 1, &newMaterialSet, 0, nullptr);
			}

			bool merged = _renderScene.get_mesh(instanceDraw.meshID)->isMerged;
			if (merged)
			{
				if (lastMesh != nullptr)
				{
					vkCmdBindVertexBuffers(cmd, 0, 1, &_renderScene.mergedVertexBuffer._buffer, &offset);
					vkCmdBindIndexBuffer(cmd, _renderScene.mergedIndexBuffer._buffer, 0, VK_INDEX_TYPE_UINT32);
					lastMesh = nullptr;
				}
			}
			else if (lastMesh != drawMesh) {

				//bind the mesh vertex buffer with offset 0
				vkCmdBindVertexBuffers(cmd, 0, 1, &drawMesh->_vertexBuffer._buffer, &offset);

				if (drawMesh->_indexBuffer._buffer != VK_NULL_HANDLE) {
					vkCmdBindIndexBuffer(cmd, drawMesh->_indexBuffer._buffer, 0, VK_INDEX_TYPE_UINT32);
				}
				lastMesh = drawMesh;
			}

			bool bHasIndices = drawMesh->_indices.size() > 0;
			if (!bHasIndices) {
				vkCmdDraw(cmd, static_cast<uint32_t>(drawMesh->_vertices.size()), instanceDraw.count, 0, instanceDraw.first);
			}
			else {
				vkCmdDrawIndexedIndirect(cmd, pass.drawIndirectBuffer._buffer, multibatch.first * sizeof(GPUIndirectObject), multibatch.count, sizeof(GPUIndirectObject));
			}
		}
	}
}

#ifdef OPT1
void VulkanEngine::prep_draw_objects(RenderScene::MeshPass& pass)
{
    _sceneParameters.sunlightShadowMatrix = _mainLight.get_projection() * _mainLight.get_view();
    _sceneParameters.ambientColor = glm::vec4{ 0.5 };
    _sceneParameters.sunlightColor = glm::vec4{ 1.f };
    _sceneParameters.sunlightDirection = glm::vec4(_mainLight.lightDirection * 1.f, 1.f);
    _sceneParameters.sunlightColor.w = 0;

    VkDescriptorBufferInfo objectBufferInfo = _renderScene.objectDataBuffer.get_info();
    VkDescriptorBufferInfo instanceInfo = pass.compactedInstanceBuffer.get_info();

    //push data to dynmem
    _scene_data_offset = _dynamicData.push(_sceneParameters);
    _camera_data_offset = _dynamicData.push(_camera.matrices);

    VkDescriptorBufferInfo sceneInfo = _dynamicData.source.get_info();
    sceneInfo.range = sizeof(GPUSceneData);

    VkDescriptorBufferInfo camInfo = _dynamicData.source.get_info();
    camInfo.range = sizeof(GPUCameraData);

    vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, _dynamicDescriptorAllocator)
        .bind_buffer(0, &camInfo, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, VK_SHADER_STAGE_VERTEX_BIT)
        .bind_buffer(1, &sceneInfo, VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC, VK_SHADER_STAGE_VERTEX_BIT | VK_SHADER_STAGE_FRAGMENT_BIT)
        .build(_GlobalSet);

    vkutil::DescriptorBuilder::begin(_descriptorLayoutCache, _dynamicDescriptorAllocator)
        .bind_buffer(0, &objectBufferInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_VERTEX_BIT)
        .bind_buffer(1, &instanceInfo, VK_DESCRIPTOR_TYPE_STORAGE_BUFFER, VK_SHADER_STAGE_VERTEX_BIT)
        .build(_ObjectDataSet);
}

void VulkanEngine::draw_objects_forward(VkCommandBuffer cmd, RenderScene::MeshPass& pass, uint32_t start, uint32_t end)
{
    //make a model view matrix for rendering the object
    //camera view

	vkCmdSetDepthBias(cmd, 0, 0, 0);

    std::vector<uint32_t> dynamic_offsets;
    dynamic_offsets.push_back(_camera_data_offset);
    dynamic_offsets.push_back(_scene_data_offset);
    execute_draw_commands(cmd, pass, start, end, _ObjectDataSet, dynamic_offsets, _GlobalSet);
}

void VulkanEngine::execute_draw_commands(VkCommandBuffer cmd, RenderScene::MeshPass& pass, uint32_t start, uint32_t end, VkDescriptorSet ObjectDataSet, std::vector<uint32_t> dynamic_offsets, VkDescriptorSet GlobalSet)
{
    if (pass.batches.size() > 0)
    {
        Mesh* lastMesh = nullptr;
        VkPipeline lastPipeline{ VK_NULL_HANDLE };
        VkDescriptorSet lastMaterialSet{ VK_NULL_HANDLE };

        VkDeviceSize offset = 0;
        vkCmdBindVertexBuffers(cmd, 0, 1, &_renderScene.mergedVertexBuffer._buffer, &offset);

        vkCmdBindIndexBuffer(cmd, _renderScene.mergedIndexBuffer._buffer, 0, VK_INDEX_TYPE_UINT32);

        for (uint32_t i = start; i < end; i++)
        {
            auto& multibatch = pass.multibatches[i];
            auto& instanceDraw = pass.batches[multibatch.first];

            VkPipeline newPipeline = instanceDraw.material.shaderPass->pipeline;
            VkPipelineLayout newLayout = instanceDraw.material.shaderPass->layout;
            VkDescriptorSet newMaterialSet = instanceDraw.material.materialSet;

            Mesh* drawMesh = _renderScene.get_mesh(instanceDraw.meshID)->original;

            if (newPipeline != lastPipeline)
            {
                lastPipeline = newPipeline;
                vkCmdBindPipeline(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, newPipeline);
                vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, newLayout, 1, 1, &ObjectDataSet, 0, nullptr);

                //update dynamic binds
                vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, newLayout, 0, 1, &GlobalSet, (uint32_t)dynamic_offsets.size(), dynamic_offsets.data());
            }
            if (newMaterialSet && newMaterialSet != lastMaterialSet)
            {
                lastMaterialSet = newMaterialSet;
                vkCmdBindDescriptorSets(cmd, VK_PIPELINE_BIND_POINT_GRAPHICS, newLayout, 2, 1, &newMaterialSet, 0, nullptr);
            }

            bool merged = _renderScene.get_mesh(instanceDraw.meshID)->isMerged;
            if (merged)
            {
                if (lastMesh != nullptr)
                {
                    vkCmdBindVertexBuffers(cmd, 0, 1, &_renderScene.mergedVertexBuffer._buffer, &offset);
                    vkCmdBindIndexBuffer(cmd, _renderScene.mergedIndexBuffer._buffer, 0, VK_INDEX_TYPE_UINT32);
                    lastMesh = nullptr;
                }
            }
            else if (lastMesh != drawMesh) {

                //bind the mesh vertex buffer with offset 0
                vkCmdBindVertexBuffers(cmd, 0, 1, &drawMesh->_vertexBuffer._buffer, &offset);

                if (drawMesh->_indexBuffer._buffer != VK_NULL_HANDLE) {
                    vkCmdBindIndexBuffer(cmd, drawMesh->_indexBuffer._buffer, 0, VK_INDEX_TYPE_UINT32);
                }
                lastMesh = drawMesh;
            }

            bool bHasIndices = drawMesh->_indices.size() > 0;
            if (!bHasIndices) {
                vkCmdDraw(cmd, static_cast<uint32_t>(drawMesh->_vertices.size()), instanceDraw.count, 0, instanceDraw.first);
            }
            else {
                vkCmdDrawIndexedIndirect(cmd, pass.drawIndirectBuffer._buffer, multibatch.first * sizeof(GPUIndirectObject), multibatch.count, sizeof(GPUIndirectObject));
            }
        }
    }
}
#endif
