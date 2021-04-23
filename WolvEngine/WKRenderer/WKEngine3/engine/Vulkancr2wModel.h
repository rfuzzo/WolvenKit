#pragma once

#include <stdlib.h>
#include <string>
#include <fstream>
#include <vector>

#include "vulkan/vulkan.h"
#include "VulkanDevice.h"
#include "hashdictionary.h"
#include "cr2w.h"
#include "camera.hpp"

#ifdef USE_VMA
#include "vk_types.h"
#endif

extern WolvenEngine::HashDictionary PathHashes;

namespace vkcr2w
{
    enum DescriptorBindingFlags {
        ImageBaseColor = 0x00000001,
        ImageNormalMap = 0x00000002
    };

#ifdef USE_VMA
    extern VmaAllocator allocator;
#endif

    extern glm::mat4 world;
    extern VkDescriptorSetLayout descriptorSetLayoutImage;
    extern VkDescriptorSetLayout descriptorSetLayoutUbo;
    extern VkMemoryPropertyFlags memoryPropertyFlags;
    extern uint32_t descriptorBindingFlags;

    struct Node;

    struct Texture {
        vks::VulkanDevice* device;
        VkImage image;
        VkImageLayout imageLayout;
        VkDeviceMemory deviceMemory;
        VkImageView view;
        uint32_t width, height;
        uint32_t mipLevels;
        uint32_t layerCount;
        VkDescriptorImageInfo descriptor;
        VkSampler sampler;
        void updateDescriptor();
        void destroy();
        void fromXBMImage(const uint8_t* image, std::string path, vks::VulkanDevice* device, VkQueue copyQueue);
    };

    struct Material {
        vks::VulkanDevice* device;
        vkcr2w::Texture* diffuseTexture = nullptr;
        vkcr2w::Texture* normalTexture = nullptr;

        VkDescriptorSet descriptorSet = VK_NULL_HANDLE;

        Material(vks::VulkanDevice* device) : device(device) {};
        void createDescriptorSet(VkDescriptorPool descriptorPool, VkDescriptorSetLayout descriptorSetLayout, uint32_t descriptorBindingFlags);
    };

    struct Primitive {
        uint32_t firstIndex;
        uint32_t indexCount;
        uint32_t firstVertex;
        uint32_t vertexCount;
        Material& material;

        Primitive(uint32_t firstIndex, uint32_t indexCount, Material& material) : firstIndex(firstIndex), indexCount(indexCount), material(material) {};
    };

    struct Mesh {
        //vks::VulkanDevice* device;

        std::vector<Primitive*> primitives;
        std::string name;

        struct Dimensions {
            glm::vec3 min = glm::vec3(FLT_MAX);
            glm::vec3 max = glm::vec3(-FLT_MAX);
            glm::vec3 center;
            float radius;
        } dimensions;
    };

    struct Node {
        uint32_t index;
        glm::mat4 matrix;
        std::shared_ptr<Mesh> mesh;
        Node(vks::VulkanDevice* device, const glm::mat4& matrix);
        ~Node();

        vks::VulkanDevice* device;

#ifdef USE_VMA
        AllocatedBuffer uniformBuffer;
        VkDescriptorSet descriptorSet = VK_NULL_HANDLE;
        VkDescriptorBufferInfo descriptor;
#else
        struct UniformBuffer {
            VkBuffer buffer;
            VkDeviceMemory memory;
            VkDescriptorSet descriptorSet = VK_NULL_HANDLE;
            VkDescriptorBufferInfo descriptor;
            void* mapped;
        } uniformBuffer;
#endif
        struct UniformBlock {
            glm::mat4 matrix;
        } uniformBlock;
    };

    struct TerrainNode {
        uint32_t index;
        glm::mat4 matrix;
        std::shared_ptr<Mesh> mesh;
        TerrainNode(vks::VulkanDevice* device, const glm::mat4& matrix);
        ~TerrainNode();

        vks::VulkanDevice* device;

#ifdef USE_VMA
        AllocatedBuffer uniformBuffer;
        VkDescriptorSet descriptorSet = VK_NULL_HANDLE;
        VkDescriptorBufferInfo descriptor;
        AllocatedBuffer vertices;
        AllocatedBuffer indices;
#else
        struct UniformBuffer {
            VkBuffer buffer;
            VkDeviceMemory memory;
            VkDescriptorSet descriptorSet = VK_NULL_HANDLE;
            VkDescriptorBufferInfo descriptor;
            void* mapped;
        } uniformBuffer;
#endif
        struct UniformBlock {
            glm::mat4 matrix;
        } uniformBlock;
    };

    //enum class VertexComponent { Position, Normal, UV, Tangent };
    enum class VertexComponent { Position, Normal, UV, Color };

    struct Vertex {
        glm::vec3 pos;
        glm::vec3 normal;
        glm::vec2 uv;
        glm::vec4 color;
        //glm::vec4 tangent;
        static VkVertexInputBindingDescription vertexInputBindingDescription;
        static std::vector<VkVertexInputAttributeDescription> vertexInputAttributeDescriptions;
        static VkPipelineVertexInputStateCreateInfo pipelineVertexInputStateCreateInfo;
        static VkVertexInputBindingDescription inputBindingDescription(uint32_t binding);
        static VkVertexInputAttributeDescription inputAttributeDescription(uint32_t binding, uint32_t location, VertexComponent component);
        static std::vector<VkVertexInputAttributeDescription> inputAttributeDescriptions(uint32_t binding, const std::vector<VertexComponent> components);
        /** @brief Returns the default pipeline vertex input state create info structure for the requested vertex components */
        static VkPipelineVertexInputStateCreateInfo* getPipelineVertexInputState(const std::vector<VertexComponent> components);
    };

    class Model {
    private:
        vkcr2w::Texture* getTexture(uint32_t index);        

        std::shared_ptr<vkcr2w::Mesh> loadNodes(std::string filename, const glm::vec3& minBounds, const glm::vec3& maxBounds, const WolvenEngine::SBufferInfos& bufferInfo, const std::vector<WolvenEngine::SMeshInfos>& meshInfos, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer, const glm::mat4& matrix);
        void addWorld(const std::string& asset, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer, VkQueue transferQueue);
        void addLayer(const std::string& asset, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer);
        std::shared_ptr<vkcr2w::Mesh> addMesh(const std::string& asset, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer, const glm::mat4& matrix);
        void addTerrain(std::string filename, uint32_t tileRes, float_t highestElevation, float_t lowestElevation, float_t terrainSize, const glm::mat4& origin, uint32_t index, VkQueue transferQueue);
        void addMesh(uint64_t hash, std::vector<Vertex>& vertexBuffer, std::vector<uint16_t>& indexBuffer, const glm::mat4& matrix);

        uint32_t _nodeIndex;

    public:
        bool _hasTerrain;
        Camera* camera;
        vks::VulkanDevice* device;
        VkDescriptorPool descriptorPool;

#ifdef USE_VMA
        AllocatedBuffer vertices;
        AllocatedBuffer indices;
        //AllocatedBuffer terrainVertices;
        //AllocatedBuffer terrainIndices;
#else
        struct Vertices {
            int count;
            VkBuffer buffer;
            VkDeviceMemory memory;
        } vertices;
        struct Indices {
            int count;
            VkBuffer buffer;
            VkDeviceMemory memory;
        } indices;

        Vertices terrainVertices;
        Indices terrainIndices;
#endif

        std::vector<Node*> nodes;
        std::vector<TerrainNode*> terrainNodes;

        struct GUINode
        {
            GUINode(const std::string& n, uint32_t i)
            :name(n), index(i) {}

            std::string name;
            uint32_t index;
        };
        std::vector<GUINode> linearNodes;

        std::vector<Texture> textures;
        std::vector<Material> materials;

        std::unordered_map<uint64_t, std::shared_ptr<vkcr2w::Mesh>> cachedMeshes;

        struct Dimensions {
            glm::vec3 min = glm::vec3(FLT_MAX);
            glm::vec3 max = glm::vec3(-FLT_MAX);
            glm::vec3 center;
            float radius;
        } dimensions;

        bool buffersBound = false;

#ifdef USE_VMA
        Model() :_nodeIndex(0), _hasTerrain(false) {};
        void setAllocator(VmaAllocator allocator) { vkcr2w::allocator = allocator; }
        void cleanUp();
#else
        Model():_nodeIndex(0), _hasTerrain(false){};
#endif
        ~Model();
        //void loadImages(tinygltf::Model& gltfModel, vks::VulkanDevice* device, VkQueue transferQueue);
        //void loadMaterials(tinygltf::Model& gltfModel);
        void loadFromFile(std::string filename, vks::VulkanDevice* device, VkQueue transferQueue);
        void bindBuffers(VkCommandBuffer commandBuffer);
        void drawNode(Node* node, VkCommandBuffer commandBuffer, uint32_t renderFlags = 0, VkPipelineLayout pipelineLayout = VK_NULL_HANDLE, uint32_t bindImageSet = 1);
        //void draw(VkCommandBuffer commandBuffer, uint32_t renderFlags = 0, VkPipelineLayout pipelineLayout = VK_NULL_HANDLE, uint32_t bindImageSet = 1);
        void getNodeDimensions(Node* node, glm::vec3& min, glm::vec3& max);
        void getSceneDimensions();
        void prepareNodeDescriptor(vkcr2w::Node* node, VkDescriptorSetLayout descriptorSetLayout);
        void prepareNodeDescriptor(vkcr2w::TerrainNode* node, VkDescriptorSetLayout descriptorSetLayout);
    };

}