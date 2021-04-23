// vulkan_guide.h : Include file for standard system include files,
// or project specific include files.

#pragma once

#include <vk_types.h>
#include <vector>
#include <functional>
#include <chrono>
#include <deque>
#include <memory>
#include <vk_mesh.h>
#include <vk_scene.h>
#include <vk_shaders.h>
#include <vk_pushbuffer.h>
#include <vk_uioverlay.h>
#include <camera.hpp>
#include <unordered_map>
#include <material_system.h>

#include <glm/glm.hpp>
#include <glm/gtx/transform.hpp>
#include <vkbootstrap/VkBootstrap.h>
#include <frustum_cull.h>

#define USE_MULTITHREADING

#ifdef USE_MULTITHREADING
#include "threadpool.hpp"
#endif

namespace vkutil { struct Material; }
namespace assets { struct PrefabInfo; }


//forward declarations
namespace vkutil {
	class DescriptorLayoutCache;
	class DescriptorAllocator;
}

struct DeletionQueue
{
    std::deque<std::function<void()>> deletors;

	template<typename F>
    void push_function(F&& function) {
		static_assert(sizeof(F) < 200, "DONT CAPTURE TOO MUCH IN THE LAMBDA");
        deletors.push_back(function);
    }

    void flush() {
        // reverse iterate the deletion queue to execute all the functions
        for (auto it = deletors.rbegin(); it != deletors.rend(); it++) {
            (*it)(); //call functors
        }

        deletors.clear();
    }
};

struct MeshPushConstants {
	glm::vec4 data;
	glm::mat4 render_matrix;
};

namespace assets {

	enum class TransparencyMode :uint8_t;
}

struct Texture {
	AllocatedImage image;
	VkImageView imageView;
};

struct MeshObject {
	Mesh* mesh{ nullptr };

	vkutil::Material* material;
	uint32_t customSortKey = 0;
	glm::mat4 transformMatrix;

	RenderBounds bounds;

	uint32_t bDrawForwardPass : 1;
	uint32_t bDrawShadowPass : 1;
};

#ifndef USE_MULTITHREADING
struct FrameData {
	VkSemaphore _presentSemaphore, _renderSemaphore;
	VkFence _renderFence;

	DeletionQueue _frameDeletionQueue;

	VkCommandPool _commandPool;
	VkCommandBuffer _mainCommandBuffer;
	
	vkutil::PushBuffer dynamicData;

	vkutil::DescriptorAllocator* dynamicDescriptorAllocator;
};
#endif

struct UploadContext {
	VkFence _uploadFence;
	VkCommandPool _commandPool;	
};

struct GPUCameraData{
	glm::mat4 view;
	glm::mat4 proj;
	glm::mat4 viewproj;
};


struct GPUSceneData {
	glm::vec4 fogColor; // w is for exponent
	glm::vec4 fogDistances; //x for min, y for max, zw unused.
	glm::vec4 ambientColor;
	glm::vec4 sunlightDirection; //w for sun power
	glm::vec4 sunlightColor;
	glm::mat4 sunlightShadowMatrix;
};

struct GPUObjectData {
	glm::mat4 modelMatrix;
	glm::vec4 origin_rad; // bounds
	glm::vec4 extents;  // bounds
};

struct EngineStats {
	float frametime;
	int objects;
	int drawcalls;
	int draws;
	int triangles;
};

struct DrawCullData
{
	glm::mat4 viewMat;
	float P00, P11, znear, zfar; // symmetric projection parameters
	float frustum[4]; // data for left/right/top/bottom frustum planes
	float lodBase, lodStep; // lod distance i = base * pow(step, i)
	float pyramidWidth, pyramidHeight; // depth pyramid size in texels

	uint32_t drawCount;

	int cullingEnabled;
	int lodEnabled;
	int occlusionEnabled;
	int distanceCheck;	
};

struct DirectionalLight {
	glm::vec3 lightPosition;
	glm::vec3 lightDirection;
	glm::vec3 shadowExtent;
	glm::mat4 get_projection();

	glm::mat4 get_view();
};
struct CullParams {
	glm::mat4 viewmat;
	glm::mat4 projmat;
	bool occlusionCull;
	bool frustrumCull;
	float drawDist;
};

constexpr unsigned int FRAME_OVERLAP = 2;

class VulkanEngine {
private:
	bool _isInitialized{ false };
#ifndef USE_MULTITHREADING
	int _frameNumber {0};
#endif

	float _frameTimer = 1.0f;
	uint32_t _frameCounter = 0;
	uint32_t _lastFPS = 0;
	std::chrono::time_point<std::chrono::high_resolution_clock> _lastTimestamp;
	std::chrono::time_point<std::chrono::high_resolution_clock> _clickStart;

	VkExtent2D _windowExtent{ 1700 , 900 };
    VkClearValue _clearValue;
    VkClearValue _depthClear;

	vkb::Instance vkb_inst;
	VkInstance _instance;
	VkPhysicalDevice _chosenGPU; 

	VkPhysicalDeviceProperties _gpuProperties;
	VkPhysicalDeviceMemoryProperties _memProperties;
	
	VkQueue _graphicsQueue;
	uint32_t _graphicsQueueFamily;

#ifndef USE_MULTITHREADING
    FrameData _frames[FRAME_OVERLAP];
	VkRenderPass _copyPass;
    VkFormat _renderFormat;
    AllocatedImage _rawRenderImage;
    VkFramebuffer _forwardFramebuffer;
    VkSampler _smoothSampler;
#endif

	VkSurfaceKHR _surface;
	VkSwapchainKHR _swapchain;
	VkFormat _swachainImageFormat;

	std::vector<VkFramebuffer> _framebuffers;
	std::vector<VkImage> _swapchainImages;
	std::vector<VkImageView> _swapchainImageViews;	

#ifdef USE_PICKING
	// picking
	AllocatedImage _pickImage;
	VkRenderPass _pickPass;
	VkFramebuffer _pickFramebuffer;
    VkPipeline _pickPipeline;
    VkPipelineLayout _pickLayout;
#endif
	//depth resources
	
	AllocatedImage _depthImage;
	AllocatedImage _depthPyramid;
	int depthPyramidWidth ;
	int depthPyramidHeight;
	int depthPyramidLevels;
	
	//the format for the depth image
	VkFormat _depthFormat;
	
	vkutil::MaterialSystem* _materialSystem;

	GPUSceneData _sceneParameters;

	std::vector<VkBufferMemoryBarrier> uploadBarriers;
	std::vector<VkBufferMemoryBarrier> cullReadyBarriers;
	std::vector<VkBufferMemoryBarrier> postCullBarriers;

	UploadContext _uploadContext;

	Camera _camera;
    glm::vec2 mousePos;
    struct {
        bool left = false;
        bool right = false;
        bool middle = false;
		bool leftclick = false;
    } mouseButtons;

	DirectionalLight _mainLight;

	VkPipeline _cullPipeline;
	VkPipelineLayout _cullLayout;

	VkPipeline _sparseUploadPipeline;
	VkPipelineLayout _sparseUploadLayout;

	VkSampler _depthSampler;
	VkImageView depthPyramidMips[16] = {};

	RenderScene _renderScene;

#ifndef USE_MULTITHREADING
    VkPipeline _blitPipeline;
    VkPipelineLayout _blitLayout;
    
	FrameData& get_current_frame();
    FrameData& get_last_frame();
#endif

	struct GUINode
	{
		std::string label;
		Handle<RenderObject> handle;
		std::list<GUINode> children;
		bool selected;
		bool visible;

		GUINode() :selected(false), visible(true) {}
	};
	GUINode _rootNode;
	GUINode* _selectedItem = nullptr;
	glm::vec3 _selectedOrigin = glm::vec3(0, 0, 0);

	void setRootNode(std::string label);
	GUINode* addParentNode(GUINode* parent, std::string label);
	void addChildNode(GUINode* parent, std::string label, Handle<RenderObject> handle);
	void focusCamera();

    std::list<Mesh> _meshes;
    std::unordered_map<std::string, Texture> _loadedTextures;

	void ready_mesh_draw(VkCommandBuffer cmd);
    void forward_pass(VkCommandBuffer cmd);
#ifdef OPT1
	void forward_pass(VkCommandBuffer cmd, uint32_t start, uint32_t end);
#endif

	WolvenEngine::UIOverlay _gui;
	void update_overlay();
	void update_secondaryBuffers(VkCommandBufferInheritanceInfo inheritanceInfo);    // Inheritance info for the secondary command buffers
	VkCommandBuffer _guiCommandBuffer;
	VkCommandPool _guiCommandPool;

#ifdef USE_MULTITHREADING
#ifdef USE_MULTISAMPLING
	struct {
        VkImage image;
        VkImageView view;
        VkDeviceMemory memory;
	} _multisampleImage;
#endif
    VkCommandBuffer _primaryCommandBuffer;
    VkCommandPool _primaryCommandPool;
	VkFence _renderFence;
	VkSemaphore _presentSemaphore, _renderSemaphore;
    vkutil::PushBuffer _dynamicData;
    vkutil::DescriptorAllocator* _dynamicDescriptorAllocator;
	DeletionQueue _frameDeletionQueue;

    VkPipelineStageFlags _waitStage = VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
    
#ifdef OPT1
	struct ThreadData
	{
		VkCommandPool commandPool;
		VkCommandBuffer commandBuffer;
	};
	std::vector<ThreadData> _threadData;
    VkDescriptorSet _GlobalSet;
    VkDescriptorSet _ObjectDataSet;
    uint32_t _scene_data_offset;
    uint32_t _camera_data_offset;

	void prep_draw_objects(RenderScene::MeshPass& pass);
#else
    VkCommandPool _threadCommandPool;
    VkCommandBuffer _threadCommandBuffer;
#endif
	uint32_t _numThreads;

    vks::ThreadPool _threadPool;

	void updateCommandBuffers(VkFramebuffer frameBuffer);
	void threadRenderCode(uint32_t threadIndex, uint32_t start, uint32_t end, VkCommandBufferInheritanceInfo inheritanceInfo);
#endif

public:
	~VulkanEngine() { cleanup(); }
    VmaAllocator _allocator; //vma lib allocator
    ShaderCache _shaderCache;
    VkDevice _device;
    VkRenderPass _renderPass;
    vkutil::DescriptorAllocator* _descriptorAllocator;
    vkutil::DescriptorLayoutCache* _descriptorLayoutCache;
    VkSampleCountFlagBits _msaaSamples = VK_SAMPLE_COUNT_1_BIT;
    DeletionQueue _mainDeletionQueue;

	//initializes everything in the engine
	void init(HINSTANCE hInstance, uint32_t width, uint32_t height, const std::string& asset);
	void init(HINSTANCE hInstance, HWND hWnd, uint32_t width, uint32_t height, const std::string& asset);
	bool importModel(const std::string& asset);

	//shuts down the engine
	void cleanup();

	//draw loop
	void draw();
	
	//run main loop
	void run();
	
	//our draw function
	void draw_objects_forward(VkCommandBuffer cmd, RenderScene::MeshPass& pass);
    void execute_draw_commands(VkCommandBuffer cmd, RenderScene::MeshPass& pass, VkDescriptorSet ObjectDataSet, std::vector<uint32_t> dynamic_offsets, VkDescriptorSet GlobalSet);
#ifdef OPT1
	void draw_objects_forward(VkCommandBuffer cmd, RenderScene::MeshPass& pass, uint32_t start, uint32_t end);
    void execute_draw_commands(VkCommandBuffer cmd, RenderScene::MeshPass& pass, uint32_t start, uint32_t end, VkDescriptorSet ObjectDataSet, std::vector<uint32_t> dynamic_offsets, VkDescriptorSet GlobalSet);
#endif
	void execute_compute_cull(VkCommandBuffer cmd, RenderScene::MeshPass& pass,CullParams& params);
	void ready_cull_data(RenderScene::MeshPass& pass, VkCommandBuffer cmd);

	AllocatedBufferUntyped create_generic_buffer(size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage, VkMemoryPropertyFlags required_flags = 0);

	template <class T>
	AllocatedBuffer<T> create_buffer(size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage, VkMemoryPropertyFlags required_flags = 0)
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
        AllocatedBuffer<T> newBuffer;

        //allocate the buffer
        vmaCreateBuffer(_allocator, &bufferInfo, &vmaallocInfo,
            &newBuffer._buffer,
            &newBuffer._allocation,
            nullptr);
        newBuffer._size = allocSize;
        return newBuffer;
    }
	void reallocate_buffer(AllocatedBufferUntyped&buffer,size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage, VkMemoryPropertyFlags required_flags = 0);

	size_t pad_uniform_buffer_size(size_t originalSize);

	void immediate_submit(std::function<void(VkCommandBuffer cmd)>&& function);

	static std::string asset_path(std::string_view path);
	
	static std::string shader_path(std::string_view path);
	void refresh_renderbounds(MeshObject* object);

	template<typename T>
	T* map_buffer(AllocatedBuffer<T> &buffer);
	
	void unmap_buffer(AllocatedBufferUntyped& buffer);

	bool load_compute_shader(const char* shaderPath, VkPipeline& pipeline, VkPipelineLayout& layout);
	void handleMessages(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam); 
private:

	void handleMouseMove(int32_t x, int32_t y);
	void setupWindow(HINSTANCE hinstance, HWND hWnd);
	void windowResize();
    std::string _title = "Wolven Engine";
    std::string _name = "wolvenEngine";

    HWND _window;
    HINSTANCE _windowInstance;

    uint32_t _destWidth;
    uint32_t _destHeight;
    bool _resizing = false;
	//bool _prepared = false;

	void init_vulkan();

	void init_swapchain();

	void init_forward_renderpass();

#ifndef USE_MULTITHREADING
	void init_copy_renderpass();
#endif

#ifdef USE_PICKING
	void init_pick_renderpass();
#endif

	void init_framebuffers();

	void init_commands();

	void init_sync_structures();

	void init_pipelines();

	void init_scene(const std::string& asset);

	void init_descriptors();

	void init_imgui();	

	void load_images();

	bool load_image_to_cache(const char* name, const char* path);
	bool load_direct_image_to_cache(const char* name, const char* path);

	void upload_mesh(Mesh& mesh);

#ifndef USE_MULTITHREADING
	void copy_render_to_swapchain(uint32_t swapchainImageIndex, VkCommandBuffer cmd);
#endif
};

template<typename T>
T* VulkanEngine::map_buffer(AllocatedBuffer<T>& buffer)
{
	void* data;
	vmaMapMemory(_allocator, buffer._allocation, &data);
	return(T*)data;
}
