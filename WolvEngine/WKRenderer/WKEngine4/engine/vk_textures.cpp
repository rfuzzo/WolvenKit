#include <vk_textures.h>
#include <iostream>

#include <vk_initializers.h>
#include <cr2w/cr2w.h>

#define STBI_NO_GIF
#define STBI_NO_PNM
#define STBI_NO_PIC
#define STBI_NO_TGA
#define STBI_NO_PSD
#define STB_IMAGE_IMPLEMENTATION
#include <stb_image/stb_image.h>

#ifdef _DEBUG
#include "logger.h"
#endif

#ifdef USE_GAME_BUNDLES
#include "cr2w/bundlemanager.h"
#endif

bool vkutil::load_imported_image(VulkanEngine& engine, const char* file, AllocatedImage& outImage)
{
    int texWidth, texHeight, texChannels;

    stbi_uc* pixels = stbi_load(file, &texWidth, &texHeight, &texChannels, STBI_rgb_alpha);

    if (!pixels) {
        std::cout << "Failed to load texture file " << file << std::endl;
        return false;
    }

    void* pixel_ptr = pixels;
    VkDeviceSize imageSize = texWidth * texHeight * 4;

    VkFormat image_format = VK_FORMAT_R8G8B8A8_UNORM;

    AllocatedBufferUntyped stagingBuffer = engine.create_generic_buffer(imageSize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT, VMA_MEMORY_USAGE_CPU_ONLY);

    void* data;
    vmaMapMemory(engine._allocator, stagingBuffer._allocation, &data);

    memcpy(data, pixel_ptr, static_cast<size_t>(imageSize));

    vmaUnmapMemory(engine._allocator, stagingBuffer._allocation);

    stbi_image_free(pixels);

    outImage = upload_image(texWidth, texHeight, image_format, engine, stagingBuffer);

    vmaDestroyBuffer(engine._allocator, stagingBuffer._buffer, stagingBuffer._allocation);

	return true;
}

bool vkutil::load_direct_image_from_file(VulkanEngine& engine, const char* file, AllocatedImage& outImage)
{
    // only load xbm
    WolvenEngine::File fp;
    if (!fp.open(file, "rb"))
    {
        return false;
    }

    uint32_t texWidth, texHeight, texSize, mipsCount;
    WolvenEngine::Format format;
    uint8_t* pixels = readXBM(fp, texHeight, texWidth, texSize, mipsCount, format);
    if (pixels == nullptr)
    {
        return false;
    }

    VkDeviceSize imageSize = texSize;
    std::vector<MipmapInfo> mips;
    size_t offset = 0;

    VkFormat image_format = VkFormat::VK_FORMAT_BC1_RGB_UNORM_BLOCK;

    if (format == WolvenEngine::Format::DXT5)
    {
        image_format = VkFormat::VK_FORMAT_BC3_UNORM_BLOCK;

        uint32_t w = texWidth;
        uint32_t h = texHeight;
        for (uint32_t i = 0; i < mipsCount; ++i)
        {
            MipmapInfo mip;
            mip.dataOffset = offset;
            mip.dataSize = ((w + 3) / 4) * ((h + 3) / 4) * 16;
            mips.push_back(mip);

            offset += mip.dataSize;

            w = w >> 1;
            h = h >> 1;
            if (w < 4) w = 4;
            if (h < 4) h = 4;
        }
    }
    else // BC1
    {
        uint32_t w = texWidth;
        uint32_t h = texHeight;
        for (uint32_t i = 0; i < mipsCount; ++i)
        {
            MipmapInfo mip;
            mip.dataOffset = offset;
            mip.dataSize = ((w + 3) / 4) * ((h + 3) / 4) * 8;;
            mips.push_back(mip);

            offset += mip.dataSize;
            w = w >> 1;
            h = h >> 1;
            if (w < 4) w = 4;
            if (h < 4) h = 4;
        }
    }

    assert(offset == imageSize);

    AllocatedBufferUntyped stagingBuffer = engine.create_generic_buffer(imageSize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT, VMA_MEMORY_USAGE_CPU_ONLY);

    void* data;
    vmaMapMemory(engine._allocator, stagingBuffer._allocation, &data);
    memcpy(data, pixels, static_cast<size_t>(imageSize));
    vmaUnmapMemory(engine._allocator, stagingBuffer._allocation);

    delete[] pixels;

    outImage = upload_image_mipmapped(texWidth, texHeight, image_format, engine, stagingBuffer, (uint32_t)mips.size());
    outImage.mipLevels = (int)mips.size();
    vmaDestroyBuffer(engine._allocator, stagingBuffer._buffer, stagingBuffer._allocation);

    return true;
}

bool vkutil::load_image_from_file(VulkanEngine& engine, const char* file, AllocatedImage & outImage)
{
	// only load xbm
    WolvenEngine::File fp;
#ifdef USE_GAME_BUNDLES
    if (!WolvenEngine::BundleManager::instance()->open(file, fp))
    {
        return false;
    }
#else
	if (!fp.open(file, "rb"))
	{
		return false;
	}
#endif
	uint32_t texWidth, texHeight, texSize, mipsCount;
	WolvenEngine::Format format;
	uint8_t* pixels = readXBM(fp, texHeight, texWidth, texSize, mipsCount, format);
	if (pixels == nullptr)
	{
		return false;
	}

    VkDeviceSize imageSize = texSize;
    std::vector<MipmapInfo> mips;
    size_t offset = 0;

    VkFormat image_format = VkFormat::VK_FORMAT_BC1_RGB_UNORM_BLOCK;

	if (format == WolvenEngine::Format::DXT5)
	{
		image_format = VkFormat::VK_FORMAT_BC3_UNORM_BLOCK;

		uint32_t w = texWidth;
		uint32_t h = texHeight;
        for (uint32_t i = 0; i < mipsCount; ++i)
        {
            MipmapInfo mip;
            mip.dataOffset = offset;
            mip.dataSize = ((w + 3) / 4) * ((h + 3) / 4) * 16;
            mips.push_back(mip);

            offset += mip.dataSize;

			w = w >> 1;
			h = h >> 1;
            if (w < 4) w = 4;
			if (h < 4) h = 4;
        }
	}
	else // BC1
	{
        uint32_t w = texWidth;
        uint32_t h = texHeight;
        for (uint32_t i = 0; i < mipsCount; ++i)
        {
            MipmapInfo mip;
            mip.dataOffset = offset;
            mip.dataSize = ((w + 3) / 4) * ((h + 3) / 4) * 8;;
            mips.push_back(mip);

            offset += mip.dataSize;
			w = w >> 1;
			h = h >> 1;
			if (w < 4) w = 4;
			if (h < 4) h = 4;
        }
	}

	assert(offset == imageSize);

    AllocatedBufferUntyped stagingBuffer = engine.create_generic_buffer(imageSize, VK_BUFFER_USAGE_TRANSFER_SRC_BIT, VMA_MEMORY_USAGE_CPU_ONLY);

    void* data;
    vmaMapMemory(engine._allocator, stagingBuffer._allocation, &data);
	memcpy(data, pixels, static_cast<size_t>(imageSize));
	vmaUnmapMemory(engine._allocator, stagingBuffer._allocation);

	delete[] pixels;

    outImage = upload_image_mipmapped(texWidth, texHeight, image_format, engine, stagingBuffer, (uint32_t)mips.size());
	outImage.mipLevels = (int)mips.size();
	vmaDestroyBuffer(engine._allocator, stagingBuffer._buffer, stagingBuffer._allocation);

	return true;
}

AllocatedImage vkutil::upload_image(int texWidth, int texHeight, VkFormat image_format, VulkanEngine& engine, AllocatedBufferUntyped& stagingBuffer)
{
	VkExtent3D imageExtent;
	imageExtent.width = static_cast<uint32_t>(texWidth);
	imageExtent.height = static_cast<uint32_t>(texHeight);
	imageExtent.depth = 1;

	VkImageCreateInfo dimg_info = vkinit::image_create_info(image_format, VK_IMAGE_USAGE_SAMPLED_BIT | VK_IMAGE_USAGE_TRANSFER_DST_BIT, imageExtent);
    dimg_info.samples = VK_SAMPLE_COUNT_1_BIT;

	AllocatedImage newImage;

	VmaAllocationCreateInfo dimg_allocinfo = {};
	dimg_allocinfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

	//allocate and create the image
	vmaCreateImage(engine._allocator, &dimg_info, &dimg_allocinfo, &newImage._image, &newImage._allocation, nullptr);

	//transition image to transfer-receiver	
	engine.immediate_submit([&](VkCommandBuffer cmd) {
		VkImageSubresourceRange range;
		range.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
		range.baseMipLevel = 0;
		range.levelCount = 1;
		range.baseArrayLayer = 0;
		range.layerCount = 1;

		VkImageMemoryBarrier imageBarrier_toTransfer = {};
		imageBarrier_toTransfer.sType = VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER;

		imageBarrier_toTransfer.oldLayout = VK_IMAGE_LAYOUT_UNDEFINED;
		imageBarrier_toTransfer.newLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
		imageBarrier_toTransfer.image = newImage._image;
		imageBarrier_toTransfer.subresourceRange = range;

		imageBarrier_toTransfer.srcAccessMask = 0;
		imageBarrier_toTransfer.dstAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;

		//barrier the image into the transfer-receive layout
		vkCmdPipelineBarrier(cmd, VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT, VK_PIPELINE_STAGE_TRANSFER_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageBarrier_toTransfer);

		VkBufferImageCopy copyRegion = {};
		copyRegion.bufferOffset = 0;
		copyRegion.bufferRowLength = 0;
		copyRegion.bufferImageHeight = 0;

		copyRegion.imageSubresource.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
		copyRegion.imageSubresource.mipLevel = 0;
		copyRegion.imageSubresource.baseArrayLayer = 0;
		copyRegion.imageSubresource.layerCount = 1;
		copyRegion.imageExtent = imageExtent;

		//copy the buffer into the image
		vkCmdCopyBufferToImage(cmd, stagingBuffer._buffer, newImage._image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &copyRegion);

		VkImageMemoryBarrier imageBarrier_toReadable = imageBarrier_toTransfer;

		imageBarrier_toReadable.oldLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
		imageBarrier_toReadable.newLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;

		imageBarrier_toReadable.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
		imageBarrier_toReadable.dstAccessMask = VK_ACCESS_SHADER_READ_BIT;

		//barrier the image into the shader readable layout
		vkCmdPipelineBarrier(cmd, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageBarrier_toReadable);
		});

	//build a default imageview
	VkImageViewCreateInfo view_info = vkinit::imageview_create_info(image_format, newImage._image, VK_IMAGE_ASPECT_COLOR_BIT);
	vkCreateImageView(engine._device, &view_info, nullptr, &newImage._defaultView);

	engine._mainDeletionQueue.push_function([=, &engine]() {

		vmaDestroyImage(engine._allocator, newImage._image, newImage._allocation);
        vkDestroyImageView(engine._device, newImage._defaultView, nullptr);
	});

	newImage.mipLevels = 1;// mips.size();
	return newImage;
}

AllocatedImage vkutil::upload_image_mipmapped(int texWidth, int texHeight, VkFormat image_format, VulkanEngine& engine, AllocatedBufferUntyped& stagingBuffer, uint32_t mipLevels)
{
    VkExtent3D imageExtent;
    imageExtent.width = static_cast<uint32_t>(texWidth);
    imageExtent.height = static_cast<uint32_t>(texHeight);
    imageExtent.depth = 1;

    VkImageCreateInfo dimg_info = vkinit::image_create_info(image_format, VK_IMAGE_USAGE_SAMPLED_BIT | VK_IMAGE_USAGE_TRANSFER_DST_BIT, imageExtent);
	dimg_info.mipLevels = mipLevels;

    AllocatedImage newImage;

    VmaAllocationCreateInfo dimg_allocinfo = {};
    dimg_allocinfo.usage = VMA_MEMORY_USAGE_GPU_ONLY;

    //allocate and create the image
    vmaCreateImage(engine._allocator, &dimg_info, &dimg_allocinfo, &newImage._image, &newImage._allocation, nullptr);

    //transition image to transfer-receiver	
    engine.immediate_submit([&](VkCommandBuffer cmd) {
        VkImageSubresourceRange range;
        range.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
        range.baseMipLevel = 0;
        range.levelCount = 1;
        range.baseArrayLayer = 0;
        range.layerCount = 1;

        VkImageMemoryBarrier imageBarrier_toTransfer = {};
        imageBarrier_toTransfer.sType = VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER;

        imageBarrier_toTransfer.oldLayout = VK_IMAGE_LAYOUT_UNDEFINED;
        imageBarrier_toTransfer.newLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
        imageBarrier_toTransfer.image = newImage._image;
        imageBarrier_toTransfer.subresourceRange = range;

        imageBarrier_toTransfer.srcAccessMask = 0;
        imageBarrier_toTransfer.dstAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;

        //barrier the image into the transfer-receive layout
        vkCmdPipelineBarrier(cmd, VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT, VK_PIPELINE_STAGE_TRANSFER_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageBarrier_toTransfer);

        VkBufferImageCopy copyRegion = {};
        copyRegion.bufferOffset = 0;
        copyRegion.bufferRowLength = 0;
        copyRegion.bufferImageHeight = 0;

        copyRegion.imageSubresource.aspectMask = VK_IMAGE_ASPECT_COLOR_BIT;
        copyRegion.imageSubresource.mipLevel = 0;
        copyRegion.imageSubresource.baseArrayLayer = 0;
        copyRegion.imageSubresource.layerCount = 1;
        copyRegion.imageExtent = imageExtent;

        //copy the buffer into the image
        vkCmdCopyBufferToImage(cmd, stagingBuffer._buffer, newImage._image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &copyRegion);

        VkImageMemoryBarrier imageBarrier_toReadable = imageBarrier_toTransfer;

        imageBarrier_toReadable.oldLayout = VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL;
        imageBarrier_toReadable.newLayout = VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL;

        imageBarrier_toReadable.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
        imageBarrier_toReadable.dstAccessMask = VK_ACCESS_SHADER_READ_BIT;

        //barrier the image into the shader readable layout
        vkCmdPipelineBarrier(cmd, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT, 0, 0, nullptr, 0, nullptr, 1, &imageBarrier_toReadable);
        });

    //build a default imageview
    VkImageViewCreateInfo view_info = vkinit::imageview_create_info(image_format, newImage._image, VK_IMAGE_ASPECT_COLOR_BIT);
    vkCreateImageView(engine._device, &view_info, nullptr, &newImage._defaultView);

    engine._mainDeletionQueue.push_function([=, &engine]() {

        vmaDestroyImage(engine._allocator, newImage._image, newImage._allocation);
        vkDestroyImageView(engine._device, newImage._defaultView, nullptr);
        });

    newImage.mipLevels = mipLevels;
    return newImage;
}
