#define _USE_MATH_DEFINES
#include <cmath>

#include "Vulkancr2wModel.h"
#include "resourcepath.h"

#ifdef USE_VMA
#include "vk_mem_utils.h"
#endif

//#define DUMPOBJ
#ifdef DUMPOBJ
void DumpOBJ(std::string filename, const std::vector<vkcr2w::Vertex>& vertices, const std::vector<uint16_t>& indices, const glm::mat4& transformToWorld)
{
    FILE* fp = nullptr;
    fopen_s(&fp, filename.c_str(), "wt");
    if (fp == nullptr)
        return;

    fprintf(fp, "# %d vertices, %d indices\n", (uint32_t)vertices.size(), (uint32_t)indices.size());

    for (size_t i = 0; i < vertices.size(); ++i)
    {
        glm::vec4 v = transformToWorld * glm::vec4(vertices[i].pos, 1.0f);

        fprintf(fp, "v %g %g %g\n", v.x, v.y, v.z);
        //fprintf(fp, "vt %g %g\n", vertices[i].uv.x, vertices[i].uv.y);
        //fprintf(fp, "vn %g %g %g\n", vertices[i].normal.x, vertices[i].normal.y, vertices[i].normal.z);
    }

    for (size_t i = 0; i < indices.size();)
    {
        uint16_t v0 = indices[i++] + 1;
        uint16_t v1 = indices[i++] + 1;
        uint16_t v2 = indices[i++] + 1;
        //fprintf(fp, "f %d/%d/%d %d/%d/%d %d/%d/%d\n", v0, v0, v0, v1, v1, v1, v2, v2, v2);
        fprintf(fp, "f %d %d %d\n", v0, v1, v2);
    }

    fclose(fp);
}
#endif

WolvenEngine::HashDictionary PathHashes;

#ifdef USE_VMA
VmaAllocator vkcr2w::allocator;
#endif

VkDescriptorSetLayout vkcr2w::descriptorSetLayoutImage = VK_NULL_HANDLE;
VkDescriptorSetLayout vkcr2w::descriptorSetLayoutUbo = VK_NULL_HANDLE;
VkMemoryPropertyFlags vkcr2w::memoryPropertyFlags = 0;
uint32_t vkcr2w::descriptorBindingFlags = vkcr2w::DescriptorBindingFlags::ImageBaseColor;
glm::mat4 vkcr2w::world;

void vkcr2w::Texture::updateDescriptor()
{
	descriptor.sampler = sampler;
	descriptor.imageView = view;
	descriptor.imageLayout = imageLayout;
}

void vkcr2w::Texture::destroy()
{
	vkDestroyImageView(device->logicalDevice, view, nullptr);
	vkDestroyImage(device->logicalDevice, image, nullptr);
	vkFreeMemory(device->logicalDevice, deviceMemory, nullptr);
	vkDestroySampler(device->logicalDevice, sampler, nullptr);
}

void vkcr2w::Texture::fromXBMImage(const uint8_t* image, std::string path, vks::VulkanDevice* device, VkQueue copyQueue)
{
	this->device = device;
/*
	VkFormat format;

		unsigned char* buffer = nullptr;
		VkDeviceSize bufferSize = 0;
		bool deleteBuffer = false;
		if (gltfimage.component == 3) {
			// Most devices don't support RGB only on Vulkan so convert if necessary
			// TODO: Check actual format support and transform only if required
			bufferSize = gltfimage.width * gltfimage.height * 4;
			buffer = new unsigned char[bufferSize];
			unsigned char* rgba = buffer;
			unsigned char* rgb = &gltfimage.image[0];
			for (size_t i = 0; i < gltfimage.width * gltfimage.height; ++i) {
				for (int32_t j = 0; j < 3; ++j) {
					rgba[j] = rgb[j];
				}
				rgba += 4;
				rgb += 3;
			}
			deleteBuffer = true;
		}
		else {
			buffer = &gltfimage.image[0];
			bufferSize = gltfimage.image.size();
		}

		format = VK_FORMAT_R8G8B8A8_UNORM;

		VkFormatProperties formatProperties;

		width = gltfimage.width;
		height = gltfimage.height;
		mipLevels = static_cast<uint32_t>(floor(log2(std::max(width, height))) + 1.0);

		vkGetPhysicalDeviceFormatProperties(device->physicalDevice, format, &formatProperties);
		assert(formatProperties.optimalTilingFeatures & VK_FORMAT_FEATURE_BLIT_SRC_BIT);
		assert(formatProperties.optimalTilingFeatures & VK_FORMAT_FEATURE_BLIT_DST_BIT);

		VkMemoryAllocateInfo memAllocInfo{};
		memAllocInfo.sType = VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO;
		VkMemoryRequirements memReqs{};

		VkBuffer stagingBuffer;
		VkDeviceMemory stagingMemory;

		VkBufferCreateInfo bufferCreateInfo{};
		bufferCreateInfo.sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO;
		bufferCreateInfo.size = bufferSize;
		bufferCreateInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;
		bufferCreateInfo.sharingMode = VK_SHARING_MODE_EXCLUSIVE;
		VK_CHECK_RESULT(vkCreateBuffer(device->logicalDevice, &bufferCreateInfo, nullptr, &stagingBuffer));
		vkGetBufferMemoryRequirements(device->logicalDevice, stagingBuffer, &memReqs);
		memAllocInfo.allocationSize = memReqs.size;
		memAllocInfo.memoryTypeIndex = device->getMemoryType(memReqs.memoryTypeBits, VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT);
		VK_CHECK_RESULT(vkAllocateMemory(device->logicalDevice, &memAllocInfo, nullptr, &stagingMemory));
		VK_CHECK_RESULT(vkBindBufferMemory(device->logicalDevice, stagingBuffer, stagingMemory, 0));

		uint8_t* data;
		VK_CHECK_RESULT(vkMapMemory(device->logicalDevice, stagingMemory, 0, memReqs.size, 0, (void**)&data));
		memcpy(data, buffer, bufferSize);
		vkUnmapMemory(device->logicalDevice, stagingMemory);

		VkImageCreateInfo imageCreateInfo{};
		imageCreateInfo.sType = VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO;
		imageCreateInfo.imageType = VK_IMAGE_TYPE_2D;
		imageCreateInfo.format = format;
		imageCreateInfo.mipLevels = mipLevels;
		imageCreateInfo.arrayLayers = 1;
		imageCreateInfo.samples = VK_SAMPLE_COUNT_1_BIT;
		imageCreateInfo.tiling = VK_IMAGE_TILING_OPTIMAL;
		imageCreateInfo.usage = VK_IMAGE_USAGE_SAMPLED_BIT;
		imageCreateInfo.sharingMode = VK_SHARING_MODE_EXCLUSIVE;
		imageCreateInfo.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
		imageCreateInfo.extent = { width, height, 1 };
		imageCreateInfo.usage = VK_IMAGE_USAGE_TRANSFER_DST_BIT | VK_IMAGE_USAGE_TRANSFER_SRC_BIT | VK_IMAGE_USAGE_SAMPLED_BIT;
		VK_CHECK_RESULT(vkCreateImage(device->logicalDevice, &imageCreateInfo, nullptr, &image));
		vkGetImageMemoryRequirements(device->logicalDevice, image, &memReqs);
		memAllocInfo.allocationSize = memReqs.size;
		memAllocInfo.memoryTypeIndex = device->getMemoryType(memReqs.memoryTypeBits, VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT);
		VK_CHECK_RESULT(vkAllocateMemory(device->logicalDevice, &memAllocInfo, nullptr, &deviceMemory));
		VK_CHECK_RESULT(vkBindImageMemory(device->logicalDevice, image, deviceMemory, 0));

		VkCommandBuffer copyCmd = device->createCommandBuffer(VK_COMMAND_BUFFER_LEVEL_PRIMARY, true);

		VkImageSubresourceRange subresourceRange = {};
		subresourceRange.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
		subresourceRange.levelCount = 1;
		subresourceRange.layerCount = 1;

		{
			VkImageMemoryBarrier imageMemoryBarrier{};
			imageMemoryBarrier.sType = VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER;
			imageMemoryBarrier.oldLayout = VK_IMAGE_LAYOUT_UNDEFINED;
			imageMemoryBarrier.newLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
			imageMemoryBarrier.srcAccessMask = 0;
			imageMemoryBarrier.dstAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
			imageMemoryBarrier.image = image;
			imageMemoryBarrier.subresourceRange = subresourceRange;
			vkCmdPipelineBarrier(copyCmd, VK_PIPELINE_STAGE_ALL_COMMANDS_BIT, VK_PIPELINE_STAGE_ALL_COMMANDS_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageMemoryBarrier);
		}

		VkBufferImageCopy bufferCopyRegion = {};
		bufferCopyRegion.imageSubresource.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
		bufferCopyRegion.imageSubresource.mipLevel = 0;
		bufferCopyRegion.imageSubresource.baseArrayLayer = 0;
		bufferCopyRegion.imageSubresource.layerCount = 1;
		bufferCopyRegion.imageExtent.width = width;
		bufferCopyRegion.imageExtent.height = height;
		bufferCopyRegion.imageExtent.depth = 1;

		vkCmdCopyBufferToImage(copyCmd, stagingBuffer, image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &bufferCopyRegion);

		{
			VkImageMemoryBarrier imageMemoryBarrier{};
			imageMemoryBarrier.sType = VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER;
			imageMemoryBarrier.oldLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
			imageMemoryBarrier.newLayout = VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL;
			imageMemoryBarrier.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
			imageMemoryBarrier.dstAccessMask = VK_ACCESS_TRANSFER_READ_BIT;
			imageMemoryBarrier.image = image;
			imageMemoryBarrier.subresourceRange = subresourceRange;
			vkCmdPipelineBarrier(copyCmd, VK_PIPELINE_STAGE_ALL_COMMANDS_BIT, VK_PIPELINE_STAGE_ALL_COMMANDS_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageMemoryBarrier);
		}

		device->flushCommandBuffer(copyCmd, copyQueue, true);

		vkFreeMemory(device->logicalDevice, stagingMemory, nullptr);
		vkDestroyBuffer(device->logicalDevice, stagingBuffer, nullptr);

		// Generate the mip chain (glTF uses jpg and png, so we need to create this manually)
		VkCommandBuffer blitCmd = device->createCommandBuffer(VK_COMMAND_BUFFER_LEVEL_PRIMARY, true);
		for (uint32_t i = 1; i < mipLevels; i++) {
			VkImageBlit imageBlit{};

			imageBlit.srcSubresource.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
			imageBlit.srcSubresource.layerCount = 1;
			imageBlit.srcSubresource.mipLevel = i - 1;
			imageBlit.srcOffsets[1].x = int32_t(width >> (i - 1));
			imageBlit.srcOffsets[1].y = int32_t(height >> (i - 1));
			imageBlit.srcOffsets[1].z = 1;

			imageBlit.dstSubresource.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
			imageBlit.dstSubresource.layerCount = 1;
			imageBlit.dstSubresource.mipLevel = i;
			imageBlit.dstOffsets[1].x = int32_t(width >> i);
			imageBlit.dstOffsets[1].y = int32_t(height >> i);
			imageBlit.dstOffsets[1].z = 1;

			VkImageSubresourceRange mipSubRange = {};
			mipSubRange.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
			mipSubRange.baseMipLevel = i;
			mipSubRange.levelCount = 1;
			mipSubRange.layerCount = 1;

			{
				VkImageMemoryBarrier imageMemoryBarrier{};
				imageMemoryBarrier.sType = VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER;
				imageMemoryBarrier.oldLayout = VK_IMAGE_LAYOUT_UNDEFINED;
				imageMemoryBarrier.newLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
				imageMemoryBarrier.srcAccessMask = 0;
				imageMemoryBarrier.dstAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
				imageMemoryBarrier.image = image;
				imageMemoryBarrier.subresourceRange = mipSubRange;
				vkCmdPipelineBarrier(blitCmd, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_PIPELINE_STAGE_TRANSFER_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageMemoryBarrier);
			}

			vkCmdBlitImage(blitCmd, image, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &imageBlit, VK_FILTER_LINEAR);

			{
				VkImageMemoryBarrier imageMemoryBarrier{};
				imageMemoryBarrier.sType = VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER;
				imageMemoryBarrier.oldLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
				imageMemoryBarrier.newLayout = VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL;
				imageMemoryBarrier.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
				imageMemoryBarrier.dstAccessMask = VK_ACCESS_TRANSFER_READ_BIT;
				imageMemoryBarrier.image = image;
				imageMemoryBarrier.subresourceRange = mipSubRange;
				vkCmdPipelineBarrier(blitCmd, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_PIPELINE_STAGE_TRANSFER_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageMemoryBarrier);
			}
		}

		subresourceRange.levelCount = mipLevels;
		imageLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;

		{
			VkImageMemoryBarrier imageMemoryBarrier{};
			imageMemoryBarrier.sType = VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER;
			imageMemoryBarrier.oldLayout = VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL;
			imageMemoryBarrier.newLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;
			imageMemoryBarrier.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
			imageMemoryBarrier.dstAccessMask = VK_ACCESS_TRANSFER_READ_BIT;
			imageMemoryBarrier.image = image;
			imageMemoryBarrier.subresourceRange = subresourceRange;
			vkCmdPipelineBarrier(blitCmd, VK_PIPELINE_STAGE_ALL_COMMANDS_BIT, VK_PIPELINE_STAGE_ALL_COMMANDS_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageMemoryBarrier);
		}

		device->flushCommandBuffer(blitCmd, copyQueue, true);
	}
	else {
		// Texture is stored in an external ktx file
		std::string filename = path + "/" + gltfimage.uri;

		ktxTexture* ktxTexture;

		ktxResult result = KTX_SUCCESS;
#if defined(__ANDROID__)
		AAsset* asset = AAssetManager_open(androidApp->activity->assetManager, filename.c_str(), AASSET_MODE_STREAMING);
		if (!asset) {
			vks::tools::exitFatal("Could not load texture from " + filename + "\n\nThe file may be part of the additional asset pack.\n\nRun \"download_assets.py\" in the repository root to download the latest version.", -1);
		}
		size_t size = AAsset_getLength(asset);
		assert(size > 0);
		ktx_uint8_t* textureData = new ktx_uint8_t[size];
		AAsset_read(asset, textureData, size);
		AAsset_close(asset);
		result = ktxTexture_CreateFromMemory(textureData, size, KTX_TEXTURE_CREATE_LOAD_IMAGE_DATA_BIT, &ktxTexture);
		delete[] textureData;
#else
		if (!vks::tools::fileExists(filename)) {
			vks::tools::exitFatal("Could not load texture from " + filename + "\n\nThe file may be part of the additional asset pack.\n\nRun \"download_assets.py\" in the repository root to download the latest version.", -1);
		}
		result = ktxTexture_CreateFromNamedFile(filename.c_str(), KTX_TEXTURE_CREATE_LOAD_IMAGE_DATA_BIT, &ktxTexture);
#endif		
		assert(result == KTX_SUCCESS);

		this->device = device;
		width = ktxTexture->baseWidth;
		height = ktxTexture->baseHeight;
		mipLevels = ktxTexture->numLevels;

		ktx_uint8_t* ktxTextureData = ktxTexture_GetData(ktxTexture);
		ktx_size_t ktxTextureSize = ktxTexture_GetSize(ktxTexture);
		// @todo: Use ktxTexture_GetVkFormat(ktxTexture)
		format = VK_FORMAT_R8G8B8A8_UNORM;

		// Get device properties for the requested texture format
		VkFormatProperties formatProperties;
		vkGetPhysicalDeviceFormatProperties(device->physicalDevice, format, &formatProperties);

		VkCommandBuffer copyCmd = device->createCommandBuffer(VK_COMMAND_BUFFER_LEVEL_PRIMARY, true);
		VkBuffer stagingBuffer;
		VkDeviceMemory stagingMemory;

		VkBufferCreateInfo bufferCreateInfo = vks::initializers::bufferCreateInfo();
		bufferCreateInfo.size = ktxTextureSize;
		// This buffer is used as a transfer source for the buffer copy
		bufferCreateInfo.usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT;
		bufferCreateInfo.sharingMode = VK_SHARING_MODE_EXCLUSIVE;
		VK_CHECK_RESULT(vkCreateBuffer(device->logicalDevice, &bufferCreateInfo, nullptr, &stagingBuffer));

		VkMemoryAllocateInfo memAllocInfo = vks::initializers::memoryAllocateInfo();
		VkMemoryRequirements memReqs;
		vkGetBufferMemoryRequirements(device->logicalDevice, stagingBuffer, &memReqs);
		memAllocInfo.allocationSize = memReqs.size;
		memAllocInfo.memoryTypeIndex = device->getMemoryType(memReqs.memoryTypeBits, VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT);
		VK_CHECK_RESULT(vkAllocateMemory(device->logicalDevice, &memAllocInfo, nullptr, &stagingMemory));
		VK_CHECK_RESULT(vkBindBufferMemory(device->logicalDevice, stagingBuffer, stagingMemory, 0));

		uint8_t* data;
		VK_CHECK_RESULT(vkMapMemory(device->logicalDevice, stagingMemory, 0, memReqs.size, 0, (void**)&data));
		memcpy(data, ktxTextureData, ktxTextureSize);
		vkUnmapMemory(device->logicalDevice, stagingMemory);

		std::vector<VkBufferImageCopy> bufferCopyRegions;
		for (uint32_t i = 0; i < mipLevels; i++)
		{
			ktx_size_t offset;
			KTX_error_code result = ktxTexture_GetImageOffset(ktxTexture, i, 0, 0, &offset);
			assert(result == KTX_SUCCESS);
			VkBufferImageCopy bufferCopyRegion = {};
			bufferCopyRegion.imageSubresource.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
			bufferCopyRegion.imageSubresource.mipLevel = i;
			bufferCopyRegion.imageSubresource.baseArrayLayer = 0;
			bufferCopyRegion.imageSubresource.layerCount = 1;
			bufferCopyRegion.imageExtent.width = std::max(1u, ktxTexture->baseWidth >> i);
			bufferCopyRegion.imageExtent.height = std::max(1u, ktxTexture->baseHeight >> i);
			bufferCopyRegion.imageExtent.depth = 1;
			bufferCopyRegion.bufferOffset = offset;
			bufferCopyRegions.push_back(bufferCopyRegion);
		}

		// Create optimal tiled target image
		VkImageCreateInfo imageCreateInfo = vks::initializers::imageCreateInfo();
		imageCreateInfo.imageType = VK_IMAGE_TYPE_2D;
		imageCreateInfo.format = format;
		imageCreateInfo.mipLevels = mipLevels;
		imageCreateInfo.arrayLayers = 1;
		imageCreateInfo.samples = VK_SAMPLE_COUNT_1_BIT;
		imageCreateInfo.tiling = VK_IMAGE_TILING_OPTIMAL;
		imageCreateInfo.sharingMode = VK_SHARING_MODE_EXCLUSIVE;
		imageCreateInfo.initialLayout = VK_IMAGE_LAYOUT_UNDEFINED;
		imageCreateInfo.extent = { width, height, 1 };
		imageCreateInfo.usage = VK_IMAGE_USAGE_SAMPLED_BIT | VK_IMAGE_USAGE_TRANSFER_DST_BIT;
		VK_CHECK_RESULT(vkCreateImage(device->logicalDevice, &imageCreateInfo, nullptr, &image));

		vkGetImageMemoryRequirements(device->logicalDevice, image, &memReqs);
		memAllocInfo.allocationSize = memReqs.size;
		memAllocInfo.memoryTypeIndex = device->getMemoryType(memReqs.memoryTypeBits, VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT);
		VK_CHECK_RESULT(vkAllocateMemory(device->logicalDevice, &memAllocInfo, nullptr, &deviceMemory));
		VK_CHECK_RESULT(vkBindImageMemory(device->logicalDevice, image, deviceMemory, 0));

		VkImageSubresourceRange subresourceRange = {};
		subresourceRange.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
		subresourceRange.baseMipLevel = 0;
		subresourceRange.levelCount = mipLevels;
		subresourceRange.layerCount = 1;

		vks::tools::setImageLayout(copyCmd, image, VK_IMAGE_LAYOUT_UNDEFINED, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, subresourceRange);
		vkCmdCopyBufferToImage(copyCmd, stagingBuffer, image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, static_cast<uint32_t>(bufferCopyRegions.size()), bufferCopyRegions.data());
		vks::tools::setImageLayout(copyCmd, image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL, subresourceRange);
		device->flushCommandBuffer(copyCmd, copyQueue);
		this->imageLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;

		vkFreeMemory(device->logicalDevice, stagingMemory, nullptr);
		vkDestroyBuffer(device->logicalDevice, stagingBuffer, nullptr);

		ktxTexture_Destroy(ktxTexture);
	}

	VkSamplerCreateInfo samplerInfo{};
	samplerInfo.sType = VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO;
	samplerInfo.magFilter = VK_FILTER_LINEAR;
	samplerInfo.minFilter = VK_FILTER_LINEAR;
	samplerInfo.mipmapMode = VK_SAMPLER_MIPMAP_MODE_LINEAR;
	samplerInfo.addressModeU = VK_SAMPLER_ADDRESS_MODE_MIRRORED_REPEAT;
	samplerInfo.addressModeV = VK_SAMPLER_ADDRESS_MODE_MIRRORED_REPEAT;
	samplerInfo.addressModeW = VK_SAMPLER_ADDRESS_MODE_MIRRORED_REPEAT;
	samplerInfo.compareOp = VK_COMPARE_OP_NEVER;
	samplerInfo.borderColor = VK_BORDER_COLOR_FLOAT_OPAQUE_WHITE;
	samplerInfo.maxAnisotropy = 1.0;
	samplerInfo.anisotropyEnable = VK_FALSE;
	samplerInfo.maxLod = (float)mipLevels;
	samplerInfo.maxAnisotropy = 8.0f;
	samplerInfo.anisotropyEnable = VK_TRUE;
	VK_CHECK_RESULT(vkCreateSampler(device->logicalDevice, &samplerInfo, nullptr, &sampler));

	VkImageViewCreateInfo viewInfo{};
	viewInfo.sType = VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO;
	viewInfo.image = image;
	viewInfo.viewType = VK_IMAGE_VIEW_TYPE_2D;
	viewInfo.format = format;
	viewInfo.components = { VK_COMPONENT_SWIZZLE_R, VK_COMPONENT_SWIZZLE_G, VK_COMPONENT_SWIZZLE_B, VK_COMPONENT_SWIZZLE_A };
	viewInfo.subresourceRange.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
	viewInfo.subresourceRange.layerCount = 1;
	viewInfo.subresourceRange.levelCount = mipLevels;
	VK_CHECK_RESULT(vkCreateImageView(device->logicalDevice, &viewInfo, nullptr, &view));

	descriptor.sampler = sampler;
	descriptor.imageView = view;
	descriptor.imageLayout = imageLayout;
*/
}

void vkcr2w::Material::createDescriptorSet(VkDescriptorPool descriptorPool, VkDescriptorSetLayout descriptorSetLayout, uint32_t descriptorBindingFlags)
{
	VkDescriptorSetAllocateInfo descriptorSetAllocInfo{};
	descriptorSetAllocInfo.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO;
	descriptorSetAllocInfo.descriptorPool = descriptorPool;
	descriptorSetAllocInfo.pSetLayouts = &descriptorSetLayout;
	descriptorSetAllocInfo.descriptorSetCount = 1;
	VK_CHECK_RESULT(vkAllocateDescriptorSets(device->logicalDevice, &descriptorSetAllocInfo, &descriptorSet));
	std::vector<VkDescriptorImageInfo> imageDescriptors{};
	std::vector<VkWriteDescriptorSet> writeDescriptorSets{};
	if (descriptorBindingFlags & DescriptorBindingFlags::ImageBaseColor) {
		imageDescriptors.push_back(diffuseTexture->descriptor);
		VkWriteDescriptorSet writeDescriptorSet{};
		writeDescriptorSet.sType = VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET;
		writeDescriptorSet.descriptorType = VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER;
		writeDescriptorSet.descriptorCount = 1;
		writeDescriptorSet.dstSet = descriptorSet;
		writeDescriptorSet.dstBinding = static_cast<uint32_t>(writeDescriptorSets.size());
		writeDescriptorSet.pImageInfo = &diffuseTexture->descriptor;
		writeDescriptorSets.push_back(writeDescriptorSet);
	}
	if (normalTexture && descriptorBindingFlags & DescriptorBindingFlags::ImageNormalMap) {
		imageDescriptors.push_back(normalTexture->descriptor);
		VkWriteDescriptorSet writeDescriptorSet{};
		writeDescriptorSet.sType = VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET;
		writeDescriptorSet.descriptorType = VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER;
		writeDescriptorSet.descriptorCount = 1;
		writeDescriptorSet.dstSet = descriptorSet;
		writeDescriptorSet.dstBinding = static_cast<uint32_t>(writeDescriptorSets.size());
		writeDescriptorSet.pImageInfo = &normalTexture->descriptor;
		writeDescriptorSets.push_back(writeDescriptorSet);
	}
	vkUpdateDescriptorSets(device->logicalDevice, static_cast<uint32_t>(writeDescriptorSets.size()), writeDescriptorSets.data(), 0, nullptr);
}

vkcr2w::Node::Node(vks::VulkanDevice* device, const glm::mat4& matrix)
{
    this->device = device;
    this->uniformBlock.matrix = matrix;
#ifdef USE_VMA
    uniformBuffer = WolvenEngine::create_buffer(vkcr2w::allocator,sizeof(uniformBlock), VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);
    char* data;
    vmaMapMemory(allocator, uniformBuffer._allocation, (void**)&data);
    memcpy(data, &matrix, sizeof(uniformBlock));
    vmaUnmapMemory(allocator, uniformBuffer._allocation);
    descriptor = { uniformBuffer._buffer, 0, sizeof(uniformBlock) };
#else
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT,
        VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT,
        sizeof(uniformBlock),
        &uniformBuffer.buffer,
        &uniformBuffer.memory,
        &uniformBlock));
    VK_CHECK_RESULT(vkMapMemory(device->logicalDevice, uniformBuffer.memory, 0, sizeof(uniformBlock), 0, &uniformBuffer.mapped));
    uniformBuffer.descriptor = { uniformBuffer.buffer, 0, sizeof(uniformBlock) };

    memcpy(uniformBuffer.mapped, &matrix, sizeof(glm::mat4));
#endif
}

vkcr2w::Node::~Node() {
#ifdef USE_VMA
    vmaDestroyBuffer(vkcr2w::allocator, uniformBuffer._buffer, uniformBuffer._allocation);
#else
    vkDestroyBuffer(device->logicalDevice, uniformBuffer.buffer, nullptr);
    vkFreeMemory(device->logicalDevice, uniformBuffer.memory, nullptr);
#endif
}

vkcr2w::TerrainNode::TerrainNode(vks::VulkanDevice* device, const glm::mat4& matrix)
{
    this->device = device;
    this->uniformBlock.matrix = matrix;
#ifdef USE_VMA
    uniformBuffer = WolvenEngine::create_buffer(vkcr2w::allocator, sizeof(uniformBlock), VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT, VMA_MEMORY_USAGE_CPU_TO_GPU);
    char* data;
    vmaMapMemory(allocator, uniformBuffer._allocation, (void**)&data);
    memcpy(data, &matrix, sizeof(uniformBlock));
    vmaUnmapMemory(allocator, uniformBuffer._allocation);
    descriptor = { uniformBuffer._buffer, 0, sizeof(uniformBlock) };
#else
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT,
        VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT,
        sizeof(uniformBlock),
        &uniformBuffer.buffer,
        &uniformBuffer.memory,
        &uniformBlock));
    VK_CHECK_RESULT(vkMapMemory(device->logicalDevice, uniformBuffer.memory, 0, sizeof(uniformBlock), 0, &uniformBuffer.mapped));
    uniformBuffer.descriptor = { uniformBuffer.buffer, 0, sizeof(uniformBlock) };

    memcpy(uniformBuffer.mapped, &matrix, sizeof(glm::mat4));
#endif
}

vkcr2w::TerrainNode::~TerrainNode() {
#ifdef USE_VMA
    vmaDestroyBuffer(vkcr2w::allocator, uniformBuffer._buffer, uniformBuffer._allocation);
    vmaDestroyBuffer(vkcr2w::allocator, vertices._buffer, vertices._allocation);
    vmaDestroyBuffer(vkcr2w::allocator, indices._buffer, indices._allocation);
#else
    vkDestroyBuffer(device->logicalDevice, uniformBuffer.buffer, nullptr);
    vkFreeMemory(device->logicalDevice, uniformBuffer.memory, nullptr);
#endif
}

VkVertexInputBindingDescription vkcr2w::Vertex::vertexInputBindingDescription;
std::vector<VkVertexInputAttributeDescription> vkcr2w::Vertex::vertexInputAttributeDescriptions;
VkPipelineVertexInputStateCreateInfo vkcr2w::Vertex::pipelineVertexInputStateCreateInfo;

VkVertexInputBindingDescription vkcr2w::Vertex::inputBindingDescription(uint32_t binding) {
	return VkVertexInputBindingDescription({ binding, sizeof(Vertex), VK_VERTEX_INPUT_RATE_VERTEX });
}

VkVertexInputAttributeDescription vkcr2w::Vertex::inputAttributeDescription(uint32_t binding, uint32_t location, VertexComponent component) {
	switch (component) {
	case VertexComponent::Position:
		return VkVertexInputAttributeDescription({ location, binding, VK_FORMAT_R32G32B32_SFLOAT, offsetof(Vertex, pos) });
	case VertexComponent::Normal:
		return VkVertexInputAttributeDescription({ location, binding, VK_FORMAT_R32G32B32_SFLOAT, offsetof(Vertex, normal) });
	case VertexComponent::UV:
		return VkVertexInputAttributeDescription({ location, binding, VK_FORMAT_R32G32_SFLOAT, offsetof(Vertex, uv) });
    case VertexComponent::Color:
        return VkVertexInputAttributeDescription({ location, binding, VK_FORMAT_R32G32B32A32_SFLOAT, offsetof(Vertex, color) });
        //case VertexComponent::Tangent:
	//	return VkVertexInputAttributeDescription({ location, binding, VK_FORMAT_R32G32B32A32_SFLOAT, offsetof(Vertex, tangent) });
	default:
		return VkVertexInputAttributeDescription({});
	}
}

std::vector<VkVertexInputAttributeDescription> vkcr2w::Vertex::inputAttributeDescriptions(uint32_t binding, const std::vector<VertexComponent> components) {
	std::vector<VkVertexInputAttributeDescription> result;
	uint32_t location = 0;
	for (VertexComponent component : components) {
		result.push_back(Vertex::inputAttributeDescription(binding, location, component));
		location++;
	}
	return result;
}

/** @brief Returns the default pipeline vertex input state create info structure for the requested vertex components */
VkPipelineVertexInputStateCreateInfo* vkcr2w::Vertex::getPipelineVertexInputState(const std::vector<VertexComponent> components) {
	vertexInputBindingDescription = Vertex::inputBindingDescription(0);
	Vertex::vertexInputAttributeDescriptions = Vertex::inputAttributeDescriptions(0, components);
	pipelineVertexInputStateCreateInfo.sType = VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO;
	pipelineVertexInputStateCreateInfo.vertexBindingDescriptionCount = 1;
	pipelineVertexInputStateCreateInfo.pVertexBindingDescriptions = &Vertex::vertexInputBindingDescription;
	pipelineVertexInputStateCreateInfo.vertexAttributeDescriptionCount = static_cast<uint32_t>(Vertex::vertexInputAttributeDescriptions.size());
	pipelineVertexInputStateCreateInfo.pVertexAttributeDescriptions = Vertex::vertexInputAttributeDescriptions.data();
	return &pipelineVertexInputStateCreateInfo;
}

vkcr2w::Texture* vkcr2w::Model::getTexture(uint32_t index)
{
	if (index < textures.size()) {
		return &textures[index];
	}
	return nullptr;
}

#ifdef USE_VMA
void vkcr2w::Model::cleanUp()
{
    vmaDestroyBuffer(vkcr2w::allocator, vertices._buffer, vertices._allocation);
    vmaDestroyBuffer(vkcr2w::allocator, indices._buffer, indices._allocation);

    for (auto texture : textures) {
        texture.destroy();
    }
    for (auto node : nodes) {
        delete node;
    }
    for (auto node : terrainNodes) {
        delete node;
    }

    if (descriptorSetLayoutUbo != VK_NULL_HANDLE) {
        vkDestroyDescriptorSetLayout(device->logicalDevice, descriptorSetLayoutUbo, nullptr);
        descriptorSetLayoutUbo = VK_NULL_HANDLE;
    }
    if (descriptorSetLayoutImage != VK_NULL_HANDLE) {
        vkDestroyDescriptorSetLayout(device->logicalDevice, descriptorSetLayoutImage, nullptr);
        descriptorSetLayoutImage = VK_NULL_HANDLE;
    }
    vkDestroyDescriptorPool(device->logicalDevice, descriptorPool, nullptr);
}
#endif

vkcr2w::Model::~Model()
{
#ifndef USE_VMA
    vkDestroyBuffer(device->logicalDevice, vertices.buffer, nullptr);
	vkFreeMemory(device->logicalDevice, vertices.memory, nullptr);
	vkDestroyBuffer(device->logicalDevice, indices.buffer, nullptr);
	vkFreeMemory(device->logicalDevice, indices.memory, nullptr);
    vkDestroyBuffer(device->logicalDevice, terrainIndices.buffer, nullptr);
    vkFreeMemory(device->logicalDevice, terrainIndices.memory, nullptr);

	for (auto texture : textures) {
		texture.destroy();
	}
	for (auto node : nodes) {
		delete node;
	}
	if (descriptorSetLayoutUbo != VK_NULL_HANDLE) {
		vkDestroyDescriptorSetLayout(device->logicalDevice, descriptorSetLayoutUbo, nullptr);
		descriptorSetLayoutUbo = VK_NULL_HANDLE;
	}
	if (descriptorSetLayoutImage != VK_NULL_HANDLE) {
		vkDestroyDescriptorSetLayout(device->logicalDevice, descriptorSetLayoutImage, nullptr);
		descriptorSetLayoutImage = VK_NULL_HANDLE;
	}
	vkDestroyDescriptorPool(device->logicalDevice, descriptorPool, nullptr);
#endif
}

bool hasEnding(std::string const& fullString, std::string const& ending)
{
    if (fullString.length() >= ending.length()) {
        return (0 == fullString.compare(fullString.length() - ending.length(), ending.length(), ending));
    }
    else {
        return false;
    }
}

std::shared_ptr<vkcr2w::Mesh> vkcr2w::Model::loadNodes(std::string filename, const glm::vec3& minBounds, const glm::vec3& maxBounds, const WolvenEngine::SBufferInfos& bufferInfo, const std::vector<WolvenEngine::SMeshInfos>& meshInfos, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer, const glm::mat4& matrix)
{
    size_t pos = filename.rfind('\\');
    if (pos == std::string::npos)
        pos = filename.rfind('/');
    std::string meshName = filename.substr(pos + 1);

    std::string bufferFileName = filename + ".1.buffer";
    WolvenEngine::File fp;
    if (!fp.open(bufferFileName.c_str(), "rb"))
        return nullptr;

    glm::mat4 localToWorld = world * matrix; // flipping the world
    vkcr2w::Node* newNode = new Node(device, localToWorld);
    newNode->index = _nodeIndex;

    uint32_t totalVerts = (uint32_t)vertexBuffer.size();
    uint32_t totalIndices = (uint32_t)indexBuffer.size();

    newNode->mesh = std::make_shared<Mesh>();
    newNode->mesh->name = meshName;
    newNode->mesh->dimensions.min = minBounds;
    newNode->mesh->dimensions.max = maxBounds;
    newNode->mesh->dimensions.center = (newNode->mesh->dimensions.min + newNode->mesh->dimensions.max) / 2.0f;
    newNode->mesh->dimensions.radius = glm::distance(newNode->mesh->dimensions.min, newNode->mesh->dimensions.max) / 2.0f;

    for (auto it = meshInfos.begin(); it != meshInfos.end(); it++)
    {
        const WolvenEngine::SMeshInfos& mi = *it;

        WolvenEngine::SVertexBufferInfos vBufferInf;
        uint32_t nbVertices = 0;
        uint32_t firstVertexOffset = 0;
        uint32_t nbIndices = 0;
        uint32_t firstIndexOffset = 0;

        for (size_t i = 0; i < bufferInfo.verticesBuffer.size(); ++i)
        {
            nbVertices += bufferInfo.verticesBuffer[i].nbVertices;
            if (nbVertices > mi.firstVertex)
            {
                vBufferInf = bufferInfo.verticesBuffer[i];
                // the index of the first vertex in the buffer
                firstVertexOffset = mi.firstVertex - (nbVertices - vBufferInf.nbVertices);
                break;
            }
        }

        for (size_t i = 0; i < bufferInfo.verticesBuffer.size(); ++i)
        {
            nbIndices += bufferInfo.verticesBuffer[i].nbIndices;
            if (nbIndices > mi.firstIndex)
            {
                vBufferInf = bufferInfo.verticesBuffer[i];
                firstIndexOffset = mi.firstIndex - (nbIndices - vBufferInf.nbIndices);
                break;
            }
        }

        if (vBufferInf.lod != 1)
            continue;

        uint32_t vertexSize = 8;
        if (mi.vertexType == 1)
            vertexSize += mi.numBonesPerVertex * 2;

        fp.seek(vBufferInf.verticesCoordsOffset + firstVertexOffset * vertexSize, SEEK_SET);

        for (uint32_t j = 0; j < mi.numVertices; ++j)
        {
            uint16_t x = fp.read<uint16_t>();
            uint16_t y = fp.read<uint16_t>();
            uint16_t z = fp.read<uint16_t>();

            fp.seek(sizeof(uint16_t), SEEK_CUR); // skip w

            if (mi.vertexType == 1)
            {
                // skip weighting for now
                fp.seek(mi.numBonesPerVertex * 2, SEEK_CUR);
            }
            vkcr2w::Vertex v;
            v.pos.x = x / 65535.0f;
            v.pos.y = y / 65535.0f;
            v.pos.z = z / 65535.0f;

            v.pos *= bufferInfo.quantizationScale;
            v.pos += bufferInfo.quantizationOffset;

            vertexBuffer.emplace_back(v);
        }

        fp.seek(vBufferInf.uvOffset + firstVertexOffset * 4, SEEK_SET);

        for (uint32_t j = 0; j < mi.numVertices; ++j)
        {
            uint16_t u = fp.read<uint16_t>();
            uint16_t v = fp.read<uint16_t>();

            vkcr2w::Vertex& vert = vertexBuffer[j + totalVerts];

            vert.uv.x = WolvenEngine::halfToFloat(u);
            vert.uv.y = WolvenEngine::halfToFloat(v);
        }

        // there is a lot of unknown data after the uvs and before the indices so just ignore it all...

        fp.seek(bufferInfo.indexBufferOffset + vBufferInf.indicesOffset + firstIndexOffset * 2, SEEK_SET);

        for (uint32_t j = 0; j < mi.numIndices; j += 3)
        {
            uint16_t index0, index1, index2;

            index0 = fp.read<uint16_t>();
            index1 = fp.read<uint16_t>();
            index2 = fp.read<uint16_t>();

            indexBuffer.emplace_back(index0);
            indexBuffer.emplace_back(index1);
            indexBuffer.emplace_back(index2);

            const glm::vec3& v0 = vertexBuffer[index0 + totalVerts].pos;
            const glm::vec3& v1 = vertexBuffer[index1 + totalVerts].pos;
            const glm::vec3& v2 = vertexBuffer[index2 + totalVerts].pos;

            // get the normal for the plane
            glm::vec3 d1 = v0 - v1;
            glm::vec3 d2 = v2 - v0;
            glm::vec3 normal = glm::cross(d2, d1);
            if (normal.x != 0 && normal.y != 0 && normal.z != 0)
                normal = glm::normalize(normal);
            else
                normal = glm::vec3(0.0f, 0.0f, 1.0f);

            vertexBuffer[index0 + totalVerts].normal = normal;
            vertexBuffer[index1 + totalVerts].normal = normal;
            vertexBuffer[index2 + totalVerts].normal = normal;
        }

        //Primitive* newPrimitive = new Primitive(firstIndexOffset, nbIndices, mi.materialID > -1 ? materials[mi.materialID] : materials.back());
        Primitive* newPrimitive = new Primitive(totalIndices, mi.numIndices, materials.back());
        newPrimitive->firstVertex = totalVerts;
        newPrimitive->vertexCount = mi.numVertices;
        newNode->mesh->primitives.push_back(newPrimitive);

        totalVerts += mi.numVertices;
        totalIndices += mi.numIndices;
    }

    if (vertexBuffer.size() > 0)
    {
        glm::vec3 p = newNode->mesh->dimensions.center - newNode->mesh->dimensions.radius * glm::vec3(4.0f, 0, 0);
        p = world * glm::vec4(p, 1.0f);
        glm::vec3 c = world * glm::vec4(newNode->mesh->dimensions.center, 1.0f);
        camera->lookAt(p, c);

        //TODO: can this be an emplace_back?
        nodes.push_back(newNode);
        linearNodes.emplace_back(GUINode(meshName, _nodeIndex++));
        return newNode->mesh;
    }
    else
    {
        assert(false);
        delete newNode;
    }

    return nullptr;
}

void vkcr2w::Model::addTerrain(std::string filename, uint32_t tileRes, float_t highestElevation, float_t lowestElevation, float_t terrainSize, const glm::mat4& origin, uint32_t meshIndex, VkQueue transferQueue)
{
    FILE* fp = nullptr;
    fopen_s(&fp, filename.c_str(), "rb");
    if (fp == nullptr)
        return;

    glm::mat4 localToWorld = world * origin;
    vkcr2w::TerrainNode* newNode = new TerrainNode(device, localToWorld); // flipping the world
    newNode->index = _nodeIndex;
    newNode->mesh = std::make_shared<Mesh>();

    std::vector<Vertex> vertexBuffer;
    std::vector<uint32_t> indexBuffer;

    uint32_t nVertices = tileRes * tileRes;
    uint32_t nIndices = (tileRes - 1) * (tileRes * 2) + (tileRes - 2) * 2;

    uint16_t* values = (uint16_t*)malloc(nVertices * sizeof(uint16_t));
    fread(values, nVertices * sizeof(uint16_t), 1, fp);
    fclose(fp);


    float_t currY = 0.0f;
    float_t stepSize = terrainSize / tileRes;

    float_t r = 0;
    float_t g = 0;
    float_t b = 0;

    float_t minZ = 1.0E9f;
    float_t maxZ = -1.0E9f;

    float_t heightScale = highestElevation - lowestElevation;

    const uint16_t* val = values;
    uint32_t index = 0;

    for (uint32_t y = 0; y < tileRes; ++y)
    {
        float_t currX = 0.0f;

        for (uint32_t x = 0; x < tileRes; ++x, ++index)
        {
            float_t hN = (float_t)(*val++ / 65535.0f);
            float_t h = hN * heightScale + lowestElevation;

            float_t hscaled = h / highestElevation * 2.0f - 1e-05f; // hscaled should range in [0,2)
            uint32_t hi = uint32_t(hscaled); // hi should range in [0,1]
            float_t hfrac = hscaled - float_t(hi); // hfrac should range in [0,1]
            Vertex v;
            v.color = glm::vec4(0, hfrac, hi, 0);
            v.pos.x = currX;
            v.pos.y = currY;
            v.pos.z = h;

            vertexBuffer.emplace_back(v);

            if (h < minZ)
                minZ = h;
            else if (h > maxZ)
                maxZ = h;

            currX += stepSize;
        }

        currY += stepSize;
    }

    // create faces
    index = 0;
    uint32_t row0Index = 0;
    uint32_t row1Index = tileRes;


    for (uint32_t z = 0; z < tileRes - 2; ++z)
    {
        // do two rows at a time to make a triangle strip
        for (uint32_t x = 0; x < tileRes; ++x)
        {
            indexBuffer.push_back(row0Index++);
            indexBuffer.push_back(row1Index++);
        }

        // add degenerate triangle to get to next row
        //TODO: consider a termination value 0xFFFF to indicate end of a row
        indexBuffer.push_back(row1Index - 1);
        indexBuffer.push_back(row0Index);
    }

    // do two rows at a time to make a triangle strip
    for (uint32_t x = 0; x < tileRes; ++x)
    {
        indexBuffer.push_back(row0Index++);
        indexBuffer.push_back(row1Index++);
    }

    for (uint32_t y = 1; y < tileRes - 1; ++y)
    {
        index = y * tileRes + 1;

        for (uint32_t x = 1; x < tileRes - 1; ++x, ++index)
        {
            const Vertex& vback = vertexBuffer[index - tileRes];
            const Vertex& vforward = vertexBuffer[index + tileRes];
            const Vertex& vleft = vertexBuffer[index - 1];
            const Vertex& vright = vertexBuffer[index + 1];

            float_t nX = vleft.pos.x - vright.pos.x;
            float_t nY = vback.pos.y - vforward.pos.y;
            float_t nZ = 100.0f;

            Vertex& vertex = vertexBuffer[index];
            vertex.normal = glm::normalize(-glm::vec3(nX, nY, nZ));
        }
    }
    free(values);

    Primitive* newPrimitive = new Primitive(0, nIndices, materials.back());
    newPrimitive->firstVertex = 0;
    newPrimitive->vertexCount = nVertices;
    newNode->mesh->primitives.push_back(newPrimitive);

    // mesh bounds
    newNode->mesh->dimensions.min = glm::vec3(0.0f, 0.0f, minZ);;
    newNode->mesh->dimensions.max = glm::vec3(terrainSize, terrainSize, maxZ);;
    newNode->mesh->dimensions.center = (newNode->mesh->dimensions.min + newNode->mesh->dimensions.max) / 2.0f;
    newNode->mesh->dimensions.radius = glm::distance(newNode->mesh->dimensions.min, newNode->mesh->dimensions.max) / 2.0f;

    //glm::vec3 p = newNode->mesh->dimensions.center - newNode->mesh->dimensions.radius * glm::vec3(4.0f, 0, 0);
    //p = world * glm::vec4(p, 1.0f);
    //glm::vec3 c = world * glm::vec4(newNode->mesh->dimensions.center, 1.0f);
    //camera->lookAt(p, c);

    //TODO: can this be an emplace_back?
    terrainNodes.push_back(newNode);
    //linearNodes.push_back(newNode);

    std::string meshName = "tile" + std::to_string(meshIndex);
    linearNodes.emplace_back(GUINode(meshName, _nodeIndex++));

    size_t vertexBufferSize = vertexBuffer.size() * sizeof(Vertex);
    size_t indexBufferSize = indexBuffer.size() * sizeof(uint32_t);

#ifdef USE_VMA
    char* data;

    // Create staging buffers
    AllocatedBuffer vertexStaging = WolvenEngine::create_buffer(vkcr2w::allocator, vertexBufferSize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT, VMA_MEMORY_USAGE_CPU_ONLY);
    vmaMapMemory(vkcr2w::allocator, vertexStaging._allocation, (void**)&data);
    memcpy(data, vertexBuffer.data(), vertexBufferSize);
    vmaUnmapMemory(vkcr2w::allocator, vertexStaging._allocation);

    AllocatedBuffer indexStaging = WolvenEngine::create_buffer(vkcr2w::allocator, indexBufferSize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT, VMA_MEMORY_USAGE_CPU_ONLY);
    vmaMapMemory(vkcr2w::allocator, indexStaging._allocation, (void**)&data);
    memcpy(data, indexBuffer.data(), indexBufferSize);
    vmaUnmapMemory(vkcr2w::allocator, indexStaging._allocation);

    // Create device local buffers
    newNode->vertices = WolvenEngine::create_buffer(vkcr2w::allocator, vertexBufferSize, VK_BUFFER_USAGE_VERTEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT, VMA_MEMORY_USAGE_GPU_ONLY);
    newNode->indices = WolvenEngine::create_buffer(vkcr2w::allocator, indexBufferSize, VK_BUFFER_USAGE_INDEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT, VMA_MEMORY_USAGE_GPU_ONLY);

    // Copy from staging buffers
    VkCommandBuffer copyCmd = device->createCommandBuffer(VK_COMMAND_BUFFER_LEVEL_PRIMARY, true);

    VkBufferCopy copyRegion = {};

    copyRegion.size = vertexBufferSize;
    vkCmdCopyBuffer(copyCmd, vertexStaging._buffer, newNode->vertices._buffer, 1, &copyRegion);

    copyRegion.size = indexBufferSize;
    vkCmdCopyBuffer(copyCmd, indexStaging._buffer, newNode->indices._buffer, 1, &copyRegion);

    device->flushCommandBuffer(copyCmd, transferQueue, true);

    vmaDestroyBuffer(vkcr2w::allocator, vertexStaging._buffer, vertexStaging._allocation);
    vmaDestroyBuffer(vkcr2w::allocator, indexStaging._buffer, indexStaging._allocation);
#else
    terrainIndices.count = static_cast<uint32_t>(terrainIndexBuffer.size());
    terrainVertices.count = static_cast<uint32_t>(terrainVertexBuffer.size());

    struct StagingBuffer {
        VkBuffer buffer;
        VkDeviceMemory memory;
    } vertexStaging, indexStaging;

    // Create staging buffers
    // Vertex data
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_TRANSFER_SRC_BIT,
        VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT,
        vertexBufferSize,
        &vertexStaging.buffer,
        &vertexStaging.memory,
        terrainVertexBuffer.data()));
    // Index data
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_TRANSFER_SRC_BIT,
        VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT,
        indexBufferSize,
        &indexStaging.buffer,
        &indexStaging.memory,
        terrainIndexBuffer.data()));

    // Create device local buffers
    // Vertex buffer
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_VERTEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT | memoryPropertyFlags,
        VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT,
        vertexBufferSize,
        &terrainVertices.buffer,
        &terrainVertices.memory));
    // Index buffer
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_INDEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT | memoryPropertyFlags,
        VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT,
        indexBufferSize,
        &terrainIndices.buffer,
        &terrainIndices.memory));

    // Copy from staging buffers
    VkCommandBuffer copyCmd = device->createCommandBuffer(VK_COMMAND_BUFFER_LEVEL_PRIMARY, true);

    VkBufferCopy copyRegion = {};

    copyRegion.size = vertexBufferSize;
    vkCmdCopyBuffer(copyCmd, vertexStaging.buffer, terrainVertices.buffer, 1, &copyRegion);

    copyRegion.size = indexBufferSize;
    vkCmdCopyBuffer(copyCmd, indexStaging.buffer, terrainIndices.buffer, 1, &copyRegion);

    device->flushCommandBuffer(copyCmd, transferQueue, true);

    vkDestroyBuffer(device->logicalDevice, vertexStaging.buffer, nullptr);
    vkFreeMemory(device->logicalDevice, vertexStaging.memory, nullptr);
    vkDestroyBuffer(device->logicalDevice, indexStaging.buffer, nullptr);
    vkFreeMemory(device->logicalDevice, indexStaging.memory, nullptr);
#endif

}

std::shared_ptr<vkcr2w::Mesh> vkcr2w::Model::addMesh(const std::string& filename, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer, const glm::mat4& matrix)
{
    WolvenEngine::File fp;
    if (!fp.open(filename.c_str(), "rb"))
        return nullptr;

    std::vector<std::string> labels;
    std::vector<std::string> fileNames;
    std::vector<WolvenEngine::ContentInfo> contents;

    WolvenEngine::SBufferInfos bufferInfo;
    std::vector<WolvenEngine::SMeshInfos> meshes;

    glm::vec3 minBounds, maxBounds;

    if (readCR2W(fp, labels, fileNames, contents))
    {
        for (size_t i = 0; i < contents.size(); ++i)
        {
            WolvenEngine::ContentInfo& ci = contents[i];

            if (labels[ci.type] == "CMesh")
            {
                fp.seek(ci.address + 1, SEEK_SET);

                WolvenEngine::Variable var;
                while (readVariable(fp, var))
                {
                    if (labels[var.name] == "materials")
                    {
                        uint32_t nbChunks = fp.read<uint32_t>();

                        for (uint32_t j = 0; j < nbChunks; ++j)
                        {
                            uint32_t fileId = fp.read<uint32_t>();
                            fileId = 0xFFFFFFFF - fileId;

                            // read the material
                            if (fileId < fileNames.size())
                            {
                                std::string matName = fileNames[fileId];
#ifdef _DEBUG
                                std::cout << "reading material: " << matName.c_str() << "\n";
#endif

                                char lastChar = matName[matName.length() - 1];
                                switch (lastChar)
                                {
                                case 'i':
                                {
                                    // w2mi
                                    //std::string depot = WolvenEngine::resourcePaths.top();
                                    //std::string w2miFileName = depot + fileNames[fileId];
                                    //readW2miFile(w2miFileName, material);
                                }
                                break;
                                case 'g':
                                    // w2mg
                                    break;
                                case 'm':
                                    // xbm
                                    break;
                                default:
                                    break;
                                }

                                //m_materials.emplace_back(material);

                            }
                        }
                    }
                    else if (labels[var.name] == "chunks")
                    {
                        // read smesh chunk packed property
                        uint32_t nbChunks = fp.read<uint32_t>();

                        WolvenEngine::SMeshInfos smeshInfo;

                        for (uint32_t j = 0; j < nbChunks; ++j)
                        {
                            fp.seek(1, SEEK_CUR);

                            WolvenEngine::Variable chunkVar;
                            while (readVariable(fp, chunkVar))
                            {
                                if (labels[chunkVar.name] == "numVertices")
                                {
                                    smeshInfo.numVertices = fp.read<uint32_t>();
                                }
                                else if (labels[chunkVar.name] == "numIndices")
                                {
                                    smeshInfo.numIndices = fp.read<uint32_t>();
                                }
                                else if (labels[chunkVar.name] == "materialID")
                                {
                                    smeshInfo.materialID = fp.read<uint32_t>();
                                }
                                else if (labels[chunkVar.name] == "firstVertex")
                                {
                                    smeshInfo.firstVertex = fp.read<uint32_t>();
                                }
                                else if (labels[chunkVar.name] == "firstIndex")
                                {
                                    smeshInfo.firstIndex = fp.read<uint32_t>();
                                }
                                else if (labels[chunkVar.name] == "vertexType")
                                {
                                    uint16_t enumStringId = fp.read<uint16_t>();

                                    if (labels[enumStringId] == "MVT_SkinnedMesh")
                                    {
                                        smeshInfo.vertexType = 1;
                                    }
                                }

                                fp.seek(chunkVar.end, SEEK_SET);
                            }

                            // mesh is done
                            meshes.emplace_back(smeshInfo);
                        }
                    }
                    else if (labels[var.name] == "cookedData")
                    {
                        // read information about the buffer containing the geometry data
                        fp.seek(1, SEEK_CUR);

                        WolvenEngine::Variable chunkVar;
                        while (readVariable(fp, chunkVar))
                        {
                            if (labels[chunkVar.name] == "indexBufferSize")
                            {
                                bufferInfo.indexBufferSize = fp.read<uint32_t>();
                            }
                            else if (labels[chunkVar.name] == "indexBufferOffset")
                            {
                                bufferInfo.indexBufferOffset = fp.read<uint32_t>();
                            }
                            else if (labels[chunkVar.name] == "vertexBufferSize")
                            {
                                bufferInfo.vertexBufferSize = fp.read<uint32_t>();
                            }
                            else if (labels[chunkVar.name] == "quantizationScale")
                            {
                                fp.seek(9, SEEK_CUR);
                                bufferInfo.quantizationScale.x = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                bufferInfo.quantizationScale.y = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                bufferInfo.quantizationScale.z = fp.read<float_t>();
                            }
                            else if (labels[chunkVar.name] == "quantizationOffset")
                            {
                                fp.seek(9, SEEK_CUR);
                                bufferInfo.quantizationOffset.x = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                bufferInfo.quantizationOffset.y = fp.read<float_t>();
                                fp.seek(8, SEEK_CUR);
                                bufferInfo.quantizationOffset.z = fp.read<float_t>();
                            }
                            else if (labels[chunkVar.name] == "renderChunks")
                            {
                                fp.seek(sizeof(int32_t), SEEK_CUR);

                                uint8_t nBuffers = fp.read<uint8_t>();

                                for (uint8_t ib = 0; ib < nBuffers; ++ib)
                                {
                                    WolvenEngine::SVertexBufferInfos info;

                                    fp.seek(1, SEEK_CUR);

                                    info.verticesCoordsOffset = fp.read<uint32_t>();
                                    info.uvOffset = fp.read<uint32_t>();
                                    info.normalsOffset = fp.read<uint32_t>();

                                    fp.seek(9, SEEK_CUR);
                                    info.indicesOffset = fp.read<uint32_t>();
                                    fp.seek(1, SEEK_CUR); // 0x1D

                                    info.nbVertices = fp.read<uint16_t>();
                                    info.nbIndices = fp.read<uint32_t>();
                                    fp.seek(3, SEEK_CUR);
                                    info.lod = fp.read<uint8_t>();

                                    bufferInfo.verticesBuffer.emplace_back(info);
                                }
                            }

                            fp.seek(chunkVar.end, SEEK_SET);
                        }
                    }
                    else if (labels[var.name] == "boundingBox")
                    {
                        // min bounds
                        {
                            fp.seek(18, SEEK_CUR);

                            minBounds.x = fp.read<float_t>();
                            fp.seek(8, SEEK_CUR);
                            minBounds.y = fp.read<float_t>();
                            fp.seek(8, SEEK_CUR);
                            minBounds.z = fp.read<float_t>();
                            fp.seek(14, SEEK_CUR); // skip w and then a blank name field
                        }

                        // max bounds
                        {
                            fp.seek(17, SEEK_CUR);

                            maxBounds.x = fp.read<float_t>();
                            fp.seek(8, SEEK_CUR);
                            maxBounds.y = fp.read<float_t>();
                            fp.seek(8, SEEK_CUR);
                            maxBounds.z = fp.read<float_t>();
                            fp.seek(16, SEEK_CUR); // skip w and then a blank name field
                        }
                    }

                    fp.seek(var.end, SEEK_SET);
                }
            }
            else if (labels[ci.type] == "CMaterialInstance")
            {
                fp.seek(ci.address + 1, SEEK_SET);

                while (fp.tell() < (long)ci.end)
                {
                    WolvenEngine::Variable matVar;
                    bool rc = readVariable(fp, matVar);

                    if (labels[matVar.name] == "baseMaterial")
                    {
                        uint32_t fileId = fp.read<uint32_t>();
                        fileId = 0xFFFFFFFF - fileId;

                        // read the material
                        assert(fileId < fileNames.size());
                        std::string matName = fileNames[fileId];
#ifdef _DEBUG
                        std::cout << "reading material: " << matName.c_str() << "\n";
#endif
                        char lastChar = matName[matName.length() - 1];
                        switch (lastChar)
                        {
                        case 'i':
                        {
                            // w2mi
                            //std::string depot = WolvenEngine::resourcePaths.top();
                            //std::string w2miFileName = depot + fileNames[fileId];
                            //readW2miFile(w2miFileName, material);
                        }
                        break;
                        case 'g':
                            // w2mg
                            break;
                        case 'm':
                            // xbm
                            break;
                        default:
                            break;
                        }

                        //m_materials.emplace_back(material);

                        fp.seek(matVar.end, SEEK_SET);
                    }
                    else if (labels[matVar.name] == "enableMask")
                    {
                        fp.seek(matVar.end, SEEK_SET);
                    }
                    else
                    {
                        //vkw2::Material material(m_device);

                        uint32_t nbProperties = fp.read<uint32_t>();

                        if (nbProperties > 0)
                        {
                            for (uint32_t j = 0; j < nbProperties; ++j)
                            {
                                long back = fp.tell();
                                uint32_t propSize = fp.read<uint32_t>();

                                uint16_t propId = fp.read<uint16_t>();
                                uint16_t propTypeId = fp.read<uint16_t>();

                                if (propId >= labels.size())
                                    break;

                                // texture type
                                int32_t textureLayer = -1;
                                if (labels[propId] == "Diffuse")
                                    textureLayer = 0;
                                else if (labels[propId] == "Normal")
                                    textureLayer = 1;

                                if (textureLayer != -1)
                                {
                                    uint8_t texId = fp.read<uint8_t>();
                                    texId = 255 - texId;

                                    if ((size_t)texId < fileNames.size())
                                    {
                                        // load the file!
                                        //std::string depot = WolvenEngine::resourcePaths.top();
                                        //std::string imgFileName = depot + fileNames[texId];

                                        //size_t pos = imgFileName.rfind('\\');
                                        //std::string texName = imgFileName.substr(pos + 1);

                                        //TODO
                                        /*
                                        size_t texIndex = 0;
                                        TextureDictionary::const_iterator ti = m_textureCache.find(texName);
                                        if (ti == m_textureCache.end())
                                        {
                                            vkw2::Texture* texture = new vkw2::Texture();
                                            texture->loadFromXBM(imgFileName, m_device, transferQueue);
                                            m_textureCache.insert(std::pair<std::string, vkw2::Texture*>(texName, texture));

                                            if (textureLayer == 0)
                                                material.baseColorTexture = texture;
                                            else
                                                material.normalTexture = texture;
                                        }
                                        else
                                        {
                                            if (textureLayer == 0)
                                                material.baseColorTexture = ti->second;
                                            else
                                                material.normalTexture = ti->second;
                                        }
                                        */
                                    }
                                }

                                fp.seek(back + propSize, SEEK_SET);
                            }
                        }
                        //m_materials.emplace_back(material);
                    }
                }
            }
            else if (labels[ci.type] == "CMaterialGraph")
            {
                // can't read this so just default to something
                //vkw2::Material material(m_device);
                //m_materials.emplace_back(material);
            }
        }
    }

    // can read mesh buffer file now
    return loadNodes(filename, minBounds, maxBounds, bufferInfo, meshes, vertexBuffer, indexBuffer, matrix);
}

void vkcr2w::Model::addMesh(uint64_t hash, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer, const glm::mat4& matrix)
{
    auto mit = cachedMeshes.find(hash);
    if (mit != cachedMeshes.end())
    {
        // already have a mesh!
        glm::mat4 localToWorld = world * matrix;
        vkcr2w::Node* newNode = new Node(device, localToWorld);
        newNode->index = _nodeIndex;
        newNode->mesh = mit->second;

        nodes.push_back(newNode);
        std::string meshName = newNode->mesh->name + std::to_string(_nodeIndex);
        linearNodes.push_back(GUINode(meshName, _nodeIndex++));
    }
    else
    {
        auto it = PathHashes.find(hash);
        if (it != PathHashes.end())
        {
            std::string depot = WolvenEngine::resourcePaths.top();
            std::string meshPath = depot + it->second;

            // get the model
            std::shared_ptr<vkcr2w::Mesh> m = addMesh(meshPath, vertexBuffer, indexBuffer, matrix);
            if (m != nullptr)
            {
                cachedMeshes.insert(std::pair<uint64_t, std::shared_ptr<vkcr2w::Mesh>>(hash, m));
            }
        }
    }
}

void vkcr2w::Model::addLayer(const std::string& filename, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer)
{
    enum class BlockObjectType
    {
        Invalid = 1,
        Mesh = 2,
        Collision = 3,
        Decal = 4,
        Dimmer = 5,
        PointLight = 6,
        SpotLight = 7,
        RigidBody = 8,
        Cloth = 9,
        Destruction = 10,
        Particles = 11
    };

    constexpr float_t RadiansToFloat = (float_t)(180 / M_PI);

    WolvenEngine::File fp;
    if (!fp.open(filename.c_str(), "rb"))
        return;

    std::cout << "adding layer = " << filename << std::endl;

    std::string depot = WolvenEngine::resourcePaths.top();

    std::vector<std::string> labels;
    std::vector<std::string> fileNames;
    std::vector<WolvenEngine::ContentInfo> contents;

    if (readCR2W(fp, labels, fileNames, contents))
    {
        for (size_t i = 0; i < contents.size(); ++i)
        {
            WolvenEngine::ContentInfo& ci = contents[i];

            if (labels[ci.type] == "CSectorData")
            {
                int32_t objectCount = 0;
                std::vector<uint64_t> hashes;
                struct Object {
                    uint8_t type;
                    uint64_t offset;
                };
                std::vector<Object> objects;

                fp.seek(ci.address, SEEK_SET); // skip all the RED variables

                // read 5 variables
                // Unknown uint64_t
                fp.seek(sizeof(uint64_t), SEEK_CUR);

                // Resources CBufferVLQInt32
                {
                    int32_t elementCount = WolvenEngine::readVLQInt32(fp); //22?
                    for (int32_t j = 0; j < elementCount; ++j)
                    {
                        fp.seek(24, SEEK_CUR);

                        uint64_t hash = fp.read<uint64_t>();

                        hashes.emplace_back(hash);
                    }
                }
                // Objects CBufferVLQInt32
                {
                    objectCount = WolvenEngine::readVLQInt32(fp);
                    for (int32_t j = 0; j < objectCount; ++j)
                    {
                        // read 7 properties
                        Object obj;

                        // type uint8_t
                        obj.type = fp.read<uint8_t>();

                        fp.seek(3, SEEK_CUR);

                        // offset uint64_t
                        obj.offset = fp.read<uint64_t>();
                        objects.emplace_back(obj);

                        fp.seek(sizeof(float_t) * 3, SEEK_CUR);
                    }
                }

                // blocksize CVLQInt32 - ignored

                // BlockData CCompressedBuffer - ignored


                int32_t blockSize = WolvenEngine::readVLQInt32(fp);

                for (int32_t j = 0; j < objectCount; ++j)
                {
                    // read blockdata

                    // rotationMatrix CMatrix3x3
                    const float_t* vals = fp.read<const float_t>(9);
                    glm::mat4 rotation(
                        vals[0], vals[1], vals[2], 0.0f,
                        vals[3], vals[4], vals[5], 0.0f,
                        vals[6], vals[7], vals[8], 0.0f,
                        0.0f, 0.0f, 0.0f, 1.0f);

                    // position SVector3D
                    vals = fp.read<const float_t>(3);
                    glm::vec3 translation(vals[0], vals[1], vals[2]);

                    fp.seek(8, SEEK_CUR);

                    BlockObjectType btype = BlockObjectType(objects[j].type);

                    switch (btype)
                    {
                    case BlockObjectType::Invalid:
                    {
                        // packedObject
                        fp.seek(8, SEEK_CUR);
                    }
                    break;

                    case BlockObjectType::Mesh:
                    {
                        // packedObject
                        uint16_t meshIndex = fp.read<uint16_t>();
                        fp.seek(18, SEEK_CUR);

                        glm::mat4 matrix = glm::translate(glm::mat4(1.0f), translation) * rotation;
                        addMesh(hashes[meshIndex], vertexBuffer, indexBuffer, matrix);

                        /*
                        auto it = PathHashes.find(hashes[meshIndex]);
                        if (it != PathHashes.end())
                        {
                            std::string meshPath = depot + it->second;
                            glm::mat4 matrix = glm::translate(glm::mat4(1.0f), translation) * rotation;

                            // get the model
                            addMesh(meshPath, vertexBuffer, indexBuffer, matrix);
                        }
                        */
                    }
                    break;

                    case BlockObjectType::Collision:
                    {
                        fp.seek(20, SEEK_CUR);
                    }
                    break;

                    case BlockObjectType::Decal:
                    {
                        fp.seek(12, SEEK_CUR);
                    }
                    break;

                    case BlockObjectType::Dimmer:
                    {
                        fp.seek(52, SEEK_CUR);
                    }
                    break;

                    case BlockObjectType::PointLight:
                    {
                        fp.seek(80, SEEK_CUR);
                    }
                    break;

                    case BlockObjectType::SpotLight:
                    {
                        fp.seek(40, SEEK_CUR);
                    }
                    break;

                    case BlockObjectType::RigidBody:
                    {
                        fp.seek(20, SEEK_CUR); // verify
                    }
                    break;

                    case BlockObjectType::Cloth:
                    {
                        fp.seek(20, SEEK_CUR); // verify
                    }
                    break;

                    case BlockObjectType::Destruction:
                    {
                        fp.seek(12, SEEK_CUR);
                    }
                    break;

                    case BlockObjectType::Particles:
                    {
                        fp.seek(20, SEEK_CUR); // verify
                    }
                    break;

                    default:
                        break;
                    }
                }
            }
        }
    }
}

void vkcr2w::Model::addWorld(const std::string& filename, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer, VkQueue transferQueue)
{
    WolvenEngine::File fp;
    if (!fp.open(filename.c_str(), "rb"))
        return;

    std::vector<std::string> labels;
    std::vector<std::string> fileNames;
    std::vector<std::string> tileNames;
    std::vector<WolvenEngine::ContentInfo> contents;

    struct TerrainTileInfo
    {
        uint32_t clipSize;
        uint32_t clipmapSize;
        uint32_t tileRes;
        float_t terrainSize;
        glm::vec3 terrainCorner;
        uint32_t numTilesPerEdge;
        float_t lowestElevation;
        float_t highestElevation;
    };
    TerrainTileInfo terrainInfo;
    _hasTerrain = false;

    std::string depot = WolvenEngine::resourcePaths.top();

    if (readCR2W(fp, labels, fileNames, tileNames, contents))
    {
        for (size_t i = 0; i < contents.size(); ++i)
        {
            WolvenEngine::ContentInfo& ci = contents[i];

            if (labels[ci.type] == "CLayerInfo")
            {
                fp.seek(ci.address + 1, SEEK_SET);

                WolvenEngine::Variable var;
                while (readVariable(fp, var))
                {
                    if (labels[var.name] == "depotFilePath")
                    {
                        uint8_t b = fp.read<uint8_t>();
                        if (b != 0x80 && b != 0x0)
                        {
                            bool nxt = (b & (1 << 6)) != 0;
                            bool widechar = (b & (1 << 7)) == 0;
                            uint32_t len = b & ((1 << 6) - 1); // null terminated?
                            if (nxt)
                            {
                                b = fp.read<uint8_t>();
                                len += 64 * b;
                            }

                            char* depotFilePath = nullptr;
                            if (!widechar)
                            {
                                // read string
                                depotFilePath = fp.read<char>(len);
                                depotFilePath[len] = '\0';
                            }

                            std::string layerFileName = depot;
                            layerFileName += depotFilePath;
                            addLayer(layerFileName, vertexBuffer, indexBuffer);
                        }
                    }

                    fp.seek(var.end, SEEK_SET);
                }
            }
            else if (labels[ci.type] == "CClipMap")
            {
                _hasTerrain = true;
                // terrain
                fp.seek(ci.address + 1, SEEK_SET);

                WolvenEngine::Variable var;
                while (readVariable(fp, var))
                {
                    if (labels[var.name] == "clipSize")
                    {
                        terrainInfo.clipSize = fp.read<uint32_t>();
                    }
                    else if (labels[var.name] == "clipmapSize")
                    {
                        terrainInfo.clipmapSize = fp.read<uint32_t>();
                    }
                    else if (labels[var.name] == "tileRes")
                    {
                        terrainInfo.tileRes = fp.read<uint32_t>();
                    }
                    else if (labels[var.name] == "terrainSize")
                    {
                        terrainInfo.terrainSize = fp.read<float_t>();
                    }
                    else if (labels[var.name] == "terrainCorner")
                    {
                        fp.seek(9, SEEK_CUR);
                        terrainInfo.terrainCorner.x = fp.read<float_t>();
                        fp.seek(8, SEEK_CUR);
                        terrainInfo.terrainCorner.y = fp.read<float_t>();
                        fp.seek(8, SEEK_CUR);
                        terrainInfo.terrainCorner.z = fp.read<float_t>();
                        fp.seek(14, SEEK_CUR); // skip w and then a null name
                    }
                    else if (labels[var.name] == "numTilesPerEdge")
                    {
                        terrainInfo.numTilesPerEdge = fp.read<uint32_t>();
                    }
                    else if (labels[var.name] == "lowestElevation")
                    {
                        terrainInfo.lowestElevation = fp.read<float_t>();
                    }
                    else if (labels[var.name] == "highestElevation")
                    {
                        terrainInfo.highestElevation = fp.read<float_t>();
                    }

                    // numClipmapStackLevels UInt32
                    // tileRes Uint32
                    // colormapStartingMip Int32
                    // material
                    // textureParams 31 elements
                    // minWaterHeight array: 2,0,Float
                    // cookedMipStackHeight DataBuffer
                    // cookedMipStackControl DataBuffer
                    // cookedMipStackColor DataBuffer
                    // cookedData ptr:CClipMapCookedData

                    fp.seek(var.end, SEEK_SET);
                }
            }
            //else if (labels[ci.type] == "CMaterialInstance")
            //{

            //}
        }

        if (_hasTerrain)
        {
            // finish loading the terrain
            float_t terrainSize = terrainInfo.terrainSize / terrainInfo.numTilesPerEdge;

            glm::vec3 dy = glm::vec3(0.0f, terrainSize, 0.0f);
            glm::vec3 dx = glm::vec3(terrainSize, 0.0f, 0.0f);

            uint32_t index = 0;
            glm::vec3 nextColumn = terrainInfo.terrainCorner;

            for (uint32_t y = 0; y < terrainInfo.numTilesPerEdge; ++y)
            {
                glm::vec3 nextPt = nextColumn;

                for (uint32_t x = 0; x < terrainInfo.numTilesPerEdge; ++x, ++index)
                {
                    // read the .wter file to get the LOD we need
                    std::string wterFileName = depot + tileNames[index];
                    uint32_t tileLOD = 0, tileRes = 0;

                    {
                        WolvenEngine::File fpw;
                        if (fpw.open(wterFileName.c_str(), "rb"))
                        {
                            readWTER(fpw, 1, tileLOD, tileRes);
                        }
                    }

                    std::string tileFileName = wterFileName + ".";
                    tileFileName += std::to_string(tileLOD);
                    tileFileName += ".buffer";

                    glm::mat4 matrix = glm::translate(glm::mat4(1.0f), nextPt);
                    addTerrain(tileFileName, tileRes, terrainInfo.highestElevation, terrainInfo.lowestElevation, terrainSize, matrix, index, transferQueue);

                    nextPt += dx;
                }

                nextColumn += dy;
            }
        }
    }
}

void vkcr2w::Model::loadFromFile(std::string asset, vks::VulkanDevice* device, VkQueue transferQueue)
{
    this->device = device;

    std::vector<uint16_t> indexBuffer;
    std::vector<Vertex> vertexBuffer;

    // create a default material
    materials.push_back(Material(device));

    if (hasEnding(asset, "w2w"))
    {
        addWorld(asset, vertexBuffer, indexBuffer, transferQueue);
        camera->setMovementSpeed(100.0f);
    }
    else if (hasEnding(asset, "w2l"))
    {
        addLayer(asset, vertexBuffer, indexBuffer);
    }
    else if (hasEnding(asset, "w2mesh"))
    {
        addMesh(asset, vertexBuffer, indexBuffer, glm::mat4(1.0f));
        camera->setMovementSpeed(5.0f);
    }

#ifdef DUMPOBJ
    {
        std::string objname = asset + ".obj";
        DumpOBJ(objname, vertexBuffer, indexBuffer, glm::mat4(1.0f));
    }
#endif

    size_t vertexBufferSize = vertexBuffer.size() * sizeof(Vertex);
    size_t indexBufferSize = indexBuffer.size() * sizeof(uint16_t);
#ifdef USE_VMA
    char* data;

    // Create staging buffers
    AllocatedBuffer vertexStaging = WolvenEngine::create_buffer(vkcr2w::allocator, vertexBufferSize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT, VMA_MEMORY_USAGE_CPU_ONLY);
    vmaMapMemory(vkcr2w::allocator, vertexStaging._allocation, (void**)&data);
    memcpy(data, vertexBuffer.data(), vertexBufferSize);
    vmaUnmapMemory(vkcr2w::allocator, vertexStaging._allocation);

    AllocatedBuffer indexStaging = WolvenEngine::create_buffer(vkcr2w::allocator, indexBufferSize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT, VMA_MEMORY_USAGE_CPU_ONLY);
    vmaMapMemory(vkcr2w::allocator, indexStaging._allocation, (void**)&data);
    memcpy(data, indexBuffer.data(), indexBufferSize);
    vmaUnmapMemory(vkcr2w::allocator, indexStaging._allocation);

    // Create device local buffers
    vertices = WolvenEngine::create_buffer(vkcr2w::allocator, vertexBufferSize, VK_BUFFER_USAGE_VERTEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT, VMA_MEMORY_USAGE_GPU_ONLY);
    indices = WolvenEngine::create_buffer(vkcr2w::allocator, indexBufferSize, VK_BUFFER_USAGE_INDEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT, VMA_MEMORY_USAGE_GPU_ONLY);

    // Copy from staging buffers
    VkCommandBuffer copyCmd = device->createCommandBuffer(VK_COMMAND_BUFFER_LEVEL_PRIMARY, true);

    VkBufferCopy copyVertsRegion = {};
    copyVertsRegion.size = vertexBufferSize;
    vkCmdCopyBuffer(copyCmd, vertexStaging._buffer, vertices._buffer, 1, &copyVertsRegion);

    VkBufferCopy copyIndicesRegion = {};
    copyIndicesRegion.size = indexBufferSize;
    vkCmdCopyBuffer(copyCmd, indexStaging._buffer, indices._buffer, 1, &copyIndicesRegion);

    device->flushCommandBuffer(copyCmd, transferQueue, true);

    vmaDestroyBuffer(vkcr2w::allocator, vertexStaging._buffer, vertexStaging._allocation);
    vmaDestroyBuffer(vkcr2w::allocator, indexStaging._buffer, indexStaging._allocation);
#else
    indices.count = static_cast<uint32_t>(indexBuffer.size());
    vertices.count = static_cast<uint32_t>(vertexBuffer.size());

    assert((vertexBufferSize > 0) && (indexBufferSize > 0));

    struct StagingBuffer {
        VkBuffer buffer;
        VkDeviceMemory memory;
    } vertexStaging, indexStaging;

    // Create staging buffers
    // Vertex data
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_TRANSFER_SRC_BIT,
        VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT,
        vertexBufferSize,
        &vertexStaging.buffer,
        &vertexStaging.memory,
        vertexBuffer.data()));
    // Index data
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_TRANSFER_SRC_BIT,
        VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VK_MEMORY_PROPERTY_HOST_COHERENT_BIT,
        indexBufferSize,
        &indexStaging.buffer,
        &indexStaging.memory,
        indexBuffer.data()));

    // Create device local buffers
    // Vertex buffer
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_VERTEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT | memoryPropertyFlags,
        VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT,
        vertexBufferSize,
        &vertices.buffer,
        &vertices.memory));
    // Index buffer
    VK_CHECK_RESULT(device->createBuffer(
        VK_BUFFER_USAGE_INDEX_BUFFER_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT | memoryPropertyFlags,
        VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT,
        indexBufferSize,
        &indices.buffer,
        &indices.memory));

    // Copy from staging buffers
    VkCommandBuffer copyCmd = device->createCommandBuffer(VK_COMMAND_BUFFER_LEVEL_PRIMARY, true);

    VkBufferCopy copyRegion = {};

    copyRegion.size = vertexBufferSize;
    vkCmdCopyBuffer(copyCmd, vertexStaging.buffer, vertices.buffer, 1, &copyRegion);

    copyRegion.size = indexBufferSize;
    vkCmdCopyBuffer(copyCmd, indexStaging.buffer, indices.buffer, 1, &copyRegion);

    device->flushCommandBuffer(copyCmd, transferQueue, true);

    vkDestroyBuffer(device->logicalDevice, vertexStaging.buffer, nullptr);
    vkFreeMemory(device->logicalDevice, vertexStaging.memory, nullptr);
    vkDestroyBuffer(device->logicalDevice, indexStaging.buffer, nullptr);
    vkFreeMemory(device->logicalDevice, indexStaging.memory, nullptr);
#endif
    //getSceneDimensions();

    // Setup descriptors
    uint32_t uboCount = (uint32_t)linearNodes.size();
    uint32_t imageCount{ 0 };
    for (auto material : materials) {
        if (material.diffuseTexture != nullptr) {
            imageCount++;
        }
    }
    std::vector<VkDescriptorPoolSize> poolSizes = {
        { VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, uboCount },
    };
    if (imageCount > 0) {
        if (descriptorBindingFlags & DescriptorBindingFlags::ImageBaseColor) {
            poolSizes.push_back({ VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, imageCount });
        }
        if (descriptorBindingFlags & DescriptorBindingFlags::ImageNormalMap) {
            poolSizes.push_back({ VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, imageCount });
        }
    }
    VkDescriptorPoolCreateInfo descriptorPoolCI{};
    descriptorPoolCI.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO;
    descriptorPoolCI.poolSizeCount = static_cast<uint32_t>(poolSizes.size());
    descriptorPoolCI.pPoolSizes = poolSizes.data();
    descriptorPoolCI.maxSets = uboCount + imageCount;
    VK_CHECK_RESULT(vkCreateDescriptorPool(device->logicalDevice, &descriptorPoolCI, nullptr, &descriptorPool));

    // Descriptors for per-node uniform buffers
    {
        // Layout is global, so only create if it hasn't already been created before
        if (descriptorSetLayoutUbo == VK_NULL_HANDLE) {
            std::vector<VkDescriptorSetLayoutBinding> setLayoutBindings = {
                vks::initializers::descriptorSetLayoutBinding(VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER, VK_SHADER_STAGE_VERTEX_BIT, 0),
            };
            VkDescriptorSetLayoutCreateInfo descriptorLayoutCI{};
            descriptorLayoutCI.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO;
            descriptorLayoutCI.bindingCount = static_cast<uint32_t>(setLayoutBindings.size());
            descriptorLayoutCI.pBindings = setLayoutBindings.data();
            VK_CHECK_RESULT(vkCreateDescriptorSetLayout(device->logicalDevice, &descriptorLayoutCI, nullptr, &descriptorSetLayoutUbo));
        }
        for (auto node : nodes) {
            prepareNodeDescriptor(node, descriptorSetLayoutUbo);
        }
        for (auto node : terrainNodes) {
            prepareNodeDescriptor(node, descriptorSetLayoutUbo);
        }
    }

    // Descriptors for per-material images
    {
        // Layout is global, so only create if it hasn't already been created before
        if (descriptorSetLayoutImage == VK_NULL_HANDLE) {
            std::vector<VkDescriptorSetLayoutBinding> setLayoutBindings{};
            if (descriptorBindingFlags & DescriptorBindingFlags::ImageBaseColor) {
                setLayoutBindings.push_back(vks::initializers::descriptorSetLayoutBinding(VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, VK_SHADER_STAGE_FRAGMENT_BIT, static_cast<uint32_t>(setLayoutBindings.size())));
            }
            if (descriptorBindingFlags & DescriptorBindingFlags::ImageNormalMap) {
                setLayoutBindings.push_back(vks::initializers::descriptorSetLayoutBinding(VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, VK_SHADER_STAGE_FRAGMENT_BIT, static_cast<uint32_t>(setLayoutBindings.size())));
            }
            VkDescriptorSetLayoutCreateInfo descriptorLayoutCI{};
            descriptorLayoutCI.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO;
            descriptorLayoutCI.bindingCount = static_cast<uint32_t>(setLayoutBindings.size());
            descriptorLayoutCI.pBindings = setLayoutBindings.data();
            VK_CHECK_RESULT(vkCreateDescriptorSetLayout(device->logicalDevice, &descriptorLayoutCI, nullptr, &descriptorSetLayoutImage));
        }
        for (auto& material : materials) {
            if (material.diffuseTexture != nullptr) {
                material.createDescriptorSet(descriptorPool, vkcr2w::descriptorSetLayoutImage, descriptorBindingFlags);
            }
        }
    }

}

void vkcr2w::Model::bindBuffers(VkCommandBuffer commandBuffer)
{
	const VkDeviceSize offsets[1] = { 0 };

#ifdef USE_VMA
    vkCmdBindVertexBuffers(commandBuffer, 0, 1, &vertices._buffer, offsets);
    vkCmdBindIndexBuffer(commandBuffer, indices._buffer, 0, VK_INDEX_TYPE_UINT16);

    //if (_hasTerrain)
    //{
    //    vkCmdBindVertexBuffers(commandBuffer, 0, 1, &terrainVertices._buffer, offsets);
    //    vkCmdBindIndexBuffer(commandBuffer, terrainIndices._buffer, 0, VK_INDEX_TYPE_UINT32);
    //}
#else
	vkCmdBindVertexBuffers(commandBuffer, 0, 1, &vertices.buffer, offsets);
	vkCmdBindIndexBuffer(commandBuffer, indices.buffer, 0, VK_INDEX_TYPE_UINT16);

    if (_hasTerrain)
    {
        vkCmdBindVertexBuffers(commandBuffer, 0, 1, &terrainVertices.buffer, offsets);
        vkCmdBindIndexBuffer(commandBuffer, terrainIndices.buffer, 0, VK_INDEX_TYPE_UINT32);
    }
#endif
	buffersBound = true;
}

void vkcr2w::Model::drawNode(Node* node, VkCommandBuffer commandBuffer, uint32_t renderFlags, VkPipelineLayout pipelineLayout, uint32_t bindImageSet)
{
	if (node->mesh) {
		for (Primitive* primitive : node->mesh->primitives) {
			//if (renderFlags & RenderFlags::BindImages) {
			//	vkCmdBindDescriptorSets(commandBuffer, VK_PIPELINE_BIND_POINT_GRAPHICS, pipelineLayout, bindImageSet, 1, &material.descriptorSet, 0, nullptr);
			//}
			vkCmdDrawIndexed(commandBuffer, primitive->indexCount, 1, primitive->firstIndex, 0, 0);		
		}
	}
}

/*
void vkcr2w::Model::draw(VkCommandBuffer commandBuffer, uint32_t renderFlags, VkPipelineLayout pipelineLayout, uint32_t bindImageSet)
{
	if (!buffersBound) {
        bindBuffers(commandBuffer);
	}
	for (auto& node : nodes) {
		drawNode(node, commandBuffer, renderFlags, pipelineLayout, bindImageSet);
	}
}
*/

void vkcr2w::Model::getNodeDimensions(Node* node, glm::vec3& min, glm::vec3& max)
{
    /*
	if (node->mesh) {
		for (Primitive* primitive : node->mesh->primitives) {
			glm::vec4 locMin = glm::vec4(primitive->dimensions.min, 1.0f) * node->matrix;
			glm::vec4 locMax = glm::vec4(primitive->dimensions.max, 1.0f) * node->matrix;
			if (locMin.x < min.x) { min.x = locMin.x; }
			if (locMin.y < min.y) { min.y = locMin.y; }
			if (locMin.z < min.z) { min.z = locMin.z; }
			if (locMax.x > max.x) { max.x = locMax.x; }
			if (locMax.y > max.y) { max.y = locMax.y; }
			if (locMax.z > max.z) { max.z = locMax.z; }
		}
	}
    */
}

void vkcr2w::Model::getSceneDimensions()
{
    /*
	dimensions.min = glm::vec3(FLT_MAX);
	dimensions.max = glm::vec3(-FLT_MAX);
	for (auto node : nodes) {
		getNodeDimensions(node, dimensions.min, dimensions.max);
	}
	dimensions.size = dimensions.max - dimensions.min;
	dimensions.center = (dimensions.min + dimensions.max) / 2.0f;
	dimensions.radius = glm::distance(dimensions.min, dimensions.max) / 2.0f;
    */
}

void vkcr2w::Model::prepareNodeDescriptor(vkcr2w::Node* node, VkDescriptorSetLayout descriptorSetLayout) {
    if (node->mesh) {
        VkDescriptorSetAllocateInfo descriptorSetAllocInfo{};
        descriptorSetAllocInfo.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO;
        descriptorSetAllocInfo.descriptorPool = descriptorPool;
        descriptorSetAllocInfo.pSetLayouts = &descriptorSetLayout;
        descriptorSetAllocInfo.descriptorSetCount = 1;
#ifdef USE_VMA
        VK_CHECK_RESULT(vkAllocateDescriptorSets(device->logicalDevice, &descriptorSetAllocInfo, &node->descriptorSet));
#else
        VK_CHECK_RESULT(vkAllocateDescriptorSets(device->logicalDevice, &descriptorSetAllocInfo, &node->uniformBuffer.descriptorSet));
#endif

        VkWriteDescriptorSet writeDescriptorSet{};
        writeDescriptorSet.sType = VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET;
        writeDescriptorSet.descriptorType = VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
        writeDescriptorSet.descriptorCount = 1;
        writeDescriptorSet.dstBinding = 0;
#ifdef USE_VMA
        writeDescriptorSet.dstSet = node->descriptorSet;
        writeDescriptorSet.pBufferInfo = &node->descriptor;
#else
        writeDescriptorSet.dstSet = node->uniformBuffer.descriptorSet;
        writeDescriptorSet.pBufferInfo = &node->uniformBuffer.descriptor;
#endif

        vkUpdateDescriptorSets(device->logicalDevice, 1, &writeDescriptorSet, 0, nullptr);
    }
}

void vkcr2w::Model::prepareNodeDescriptor(vkcr2w::TerrainNode* node, VkDescriptorSetLayout descriptorSetLayout) {
    if (node->mesh) {
        VkDescriptorSetAllocateInfo descriptorSetAllocInfo{};
        descriptorSetAllocInfo.sType = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO;
        descriptorSetAllocInfo.descriptorPool = descriptorPool;
        descriptorSetAllocInfo.pSetLayouts = &descriptorSetLayout;
        descriptorSetAllocInfo.descriptorSetCount = 1;
#ifdef USE_VMA
        VK_CHECK_RESULT(vkAllocateDescriptorSets(device->logicalDevice, &descriptorSetAllocInfo, &node->descriptorSet));
#else
        VK_CHECK_RESULT(vkAllocateDescriptorSets(device->logicalDevice, &descriptorSetAllocInfo, &node->uniformBuffer.descriptorSet));
#endif

        VkWriteDescriptorSet writeDescriptorSet{};
        writeDescriptorSet.sType = VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET;
        writeDescriptorSet.descriptorType = VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
        writeDescriptorSet.descriptorCount = 1;
        writeDescriptorSet.dstBinding = 0;
#ifdef USE_VMA
        writeDescriptorSet.dstSet = node->descriptorSet;
        writeDescriptorSet.pBufferInfo = &node->descriptor;
#else
        writeDescriptorSet.dstSet = node->uniformBuffer.descriptorSet;
        writeDescriptorSet.pBufferInfo = &node->uniformBuffer.descriptor;
#endif

        vkUpdateDescriptorSets(device->logicalDevice, 1, &writeDescriptorSet, 0, nullptr);
    }
}