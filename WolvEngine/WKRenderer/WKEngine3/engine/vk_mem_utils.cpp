#include "vk_mem_utils.h"

namespace WolvenEngine
{
    AllocatedBuffer create_buffer(VmaAllocator allocator, size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage)
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
        VK_CHECK(vmaCreateBuffer(allocator, &bufferInfo, &vmaallocInfo,
            &newBuffer._buffer,
            &newBuffer._allocation,
            nullptr));

        return newBuffer;
    }
}