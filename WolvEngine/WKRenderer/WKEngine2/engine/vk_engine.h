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

#include <vector>
#include <functional>
#include <deque>
#include <unordered_map>
#include <chrono>

#include <vk_types.h>
#include <vk_mesh.h>
#include "VulkanUIOverlay.h"
#include "camera.hpp"
#include "hashdictionary.h"
#include "concurrentqueue.h"
#include "rendermessage.h"
#include "frustum.hpp"

#include <glm/glm.hpp>
#include <glm/gtx/transform.hpp>

#define NUM_BOUNDING_BOX_VERTICES 17
namespace WolvenEngine
{
	class PipelineBuilder {
	public:
		std::vector<VkPipelineShaderStageCreateInfo> _shaderStages;
		VkPipelineVertexInputStateCreateInfo _vertexInputInfo;
		VkPipelineInputAssemblyStateCreateInfo _inputAssembly;
		VkViewport _viewport;
		VkRect2D _scissor;
		VkPipelineRasterizationStateCreateInfo _rasterizer;
		VkPipelineColorBlendAttachmentState _colorBlendAttachment;
		VkPipelineMultisampleStateCreateInfo _multisampling;
		VkPipelineLayout _pipelineLayout;
		VkPipelineDepthStencilStateCreateInfo _depthStencil;
		VkPipeline build_pipeline(VkDevice device, VkRenderPass pass);
	};

	struct DeletionQueue
	{
		std::deque<std::function<void()>> deletors;

		void push_function(std::function<void()>&& function) {
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
		//glm::vec4 data;
		glm::mat4 render_matrix;
	};

	struct Material {
		VkDescriptorSet textureSet{ VK_NULL_HANDLE };
		VkPipeline pipeline;
		VkPipelineLayout pipelineLayout;
	};

	struct Texture {
		AllocatedImage image;
		VkImageView imageView;
	};

	struct RenderObject {
		Mesh* mesh;
		//Material* material;
		glm::mat4 transformMatrix;
	};

    struct RenderBucket {
        std::vector<RenderObject> renderObjects;
        Material material;
    };

    struct TerrainRenderObject {
        TerrainMesh* mesh;
        //Material* material;
        glm::mat4 transformMatrix;
    };

    struct TerrainRenderBucket {
        std::vector<TerrainRenderObject> renderObjects;
        Material material;
    };

	struct FrameData {
		VkSemaphore _presentSemaphore, _renderSemaphore;
		VkFence _renderFence;

		DeletionQueue _frameDeletionQueue;

		VkCommandPool _commandPool;
		VkCommandBuffer _mainCommandBuffer;

		AllocatedBuffer cameraBuffer;
		VkDescriptorSet globalDescriptor;

		AllocatedBuffer objectBuffer;
		VkDescriptorSet objectDescriptor;
	};

	struct UploadContext {
		VkFence _uploadFence;
		VkCommandPool _commandPool;
	};

	struct GPUSceneData {
		glm::vec4 fogColor; // w is for exponent
		glm::vec4 fogDistances; //x for min, y for max, zw unused.
		glm::vec4 ambientColor;
		glm::vec4 sunlightDirection; //w for sun power
		glm::vec4 sunlightColor;
	};

	struct GPUObjectData {
		glm::mat4 modelMatrix;
	};

	constexpr unsigned int FRAME_OVERLAP = 2;

	class VulkanEngine {
	public:

		VulkanEngine();
		~VulkanEngine();

        void init();        
        void load(std::string asset);
        void cleanup();
        void run();

		void handleMessages(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
        HWND setupWindow(HINSTANCE hinstance, WNDPROC wndproc);

        VmaAllocator _allocator; //vma lib allocator
        AllocatedBuffer create_buffer(size_t allocSize, VkBufferUsageFlags usage, VmaMemoryUsage memoryUsage);

        void immediate_submit(std::function<void(VkCommandBuffer cmd)>&& function);
        DeletionQueue _mainDeletionQueue;

		// make sure that this class cannot be copied
		VulkanEngine(VulkanEngine const&) {} // can't delete this as the allocator needs it but don't copy the renderQueue for sure
		VulkanEngine& operator=(VulkanEngine const&) = delete;

	private:
        PFN_vkCmdBeginConditionalRenderingEXT vkCmdBeginConditionalRenderingEXT;
        PFN_vkCmdEndConditionalRenderingEXT vkCmdEndConditionalRenderingEXT;

        std::vector<int32_t> _conditionalVisibility;
        AllocatedBuffer _conditionalBuffer;
		size_t _conditionalBufferSize;
		bool _allMeshesLoaded;
		bool _conditionalVisibilityPrepared;

		void prepareConditionalRendering();
		void draw_objects_conditional(VkCommandBuffer cmd);

        /** @brief Example settings that can be changed e.g. by command line arguments */
        struct Settings {
            /** @brief Activates validation layers (and message output) when set to true */
            bool validation = false;
            /** @brief Set to true if fullscreen mode has been requested via command line */
            bool fullscreen = false;
            /** @brief Set to true if v-sync will be forced for the swapchain */
            bool vsync = false;
            /** @brief Enable UI overlay */
            bool overlay = false;
        } settings;

		moodycamel::ConcurrentQueue<RenderMessage> _renderQueue;
		HashDictionary m_pathHashes;

        void setupConsole(std::string title);
        void setupDPIAwareness();
		void setupDepthStencil();

		void processRenderQueue();
		void windowResize();
		void handleMouseMove(int32_t x, int32_t y);
        void draw();
		void nextFrame();
        std::string getWindowTitle();
		void updateOverlay();
		void drawUI(const VkCommandBuffer commandBuffer);

        std::string title = "Wolven Engine";
        std::string name = "wolvenEngine";

        HWND _window;
        HINSTANCE _windowInstance;

        uint32_t destWidth;
        uint32_t destHeight;
        bool resizing = false;

        Camera _camera;
        glm::vec2 mousePos;
        struct {
            bool left = false;
            bool right = false;
            bool middle = false;
        } mouseButtons;

        // View frustum for culling invisible objects
        vks::Frustum _frustum;

        bool prepared = false;
        bool resized = false;
        bool paused = false;

        vks::UIOverlay UIOverlay;
        VkExtent2D _windowExtent{ 1280 , 720 };

        // Frame counter to display fps
        uint32_t frameCounter = 0;
        uint32_t lastFPS = 0;
        std::chrono::time_point<std::chrono::high_resolution_clock> lastTimestamp;
		float frameTimer = 1.0f;
        // Defines a frame rate independent timer value clamped from -1.0...1.0
        // For use in animations, rotations, etc.
        float timer = 0.0f;
        // Multiplier for speeding up (or slowing down) the global timer
        float timerSpeed = 0.25f;

		bool _isInitialized{ false };
		uint32_t _frameNumber{ 0 };
		int _selectedShader{ 0 };

		VkInstance _instance;
		VkDebugUtilsMessengerEXT _debug_messenger;
		VkPhysicalDevice _chosenGPU;
		VkDevice _device;

		VkPhysicalDeviceProperties _gpuProperties;
		VkPhysicalDeviceMemoryProperties _memoryProperties;

		FrameData _frames[FRAME_OVERLAP];
		VkCommandBuffer _uiCommandBuffer;
		VkCommandPool _uiCommandPool;
		VkFence _uiFence;

		VkQueue _graphicsQueue;
		uint32_t _graphicsQueueFamily;

		VkRenderPass _renderPass;

		VkSurfaceKHR _surface;
		VkSwapchainKHR _swapchain;
		VkFormat _swachainImageFormat;

		std::vector<VkFramebuffer> _framebuffers;
		std::vector<VkImage> _swapchainImages;
		std::vector<VkImageView> _swapchainImageViews;

		//depth resources
		VkImageView _depthImageView;
		AllocatedImage _depthImage;

		//the format for the depth image
		VkFormat _depthFormat;

		VkDescriptorPool _descriptorPool;

		VkDescriptorSetLayout _globalSetLayout;
		VkDescriptorSetLayout _objectSetLayout;
		VkDescriptorSetLayout _singleTextureSetLayout;

		// terrain
        VkPipeline _terrainPipeline;
		VkPipelineLayout _terrainPipeLayout;

		VkPipeline _texPipeline;
		VkPipelineLayout _texturedPipeLayout;

		GPUSceneData _sceneParameters;
		AllocatedBuffer _sceneParameterBuffer;

		UploadContext _uploadContext;

		FrameData& get_current_frame();
		FrameData& get_last_frame();

		//default array of renderable objects
		//std::vector<RenderObject> _renderables;
        //std::vector<TerrainRenderObject> _terrainRenderables;
        //std::unordered_map<std::string, Material> _materials;

		std::unordered_map<std::string, RenderBucket> _renderBuckets;
		std::unordered_map<std::string, TerrainRenderBucket> _terrainRenderBuckets;

		std::unordered_map<std::string, TerrainMesh> _terrainMeshes;
		std::unordered_map<std::string, Mesh> _meshes;
		std::unordered_map<std::string, Texture> _loadedTextures;
		//functions

		//create material and add it to the map
		//Material* create_material(VkPipeline pipeline, VkPipelineLayout layout, const std::string& name);
		RenderBucket* create_material(VkPipeline pipeline, VkPipelineLayout layout, const std::string& name);
		TerrainRenderBucket* create_terrain_material(VkPipeline pipeline, VkPipelineLayout layout, const std::string& name);

		//returns nullptr if it cant be found
		Material* get_material(const std::string& name);

		//returns nullptr if it cant be found
		Mesh* get_mesh(const std::string& name);
		TerrainMesh* get_terrainMesh(const std::string& name);

		//our draw function
		void draw_objects(VkCommandBuffer cmd);

		size_t pad_uniform_buffer_size(size_t originalSize);

		void init_vulkan();
		void init_swapchain();
		void init_default_renderpass();
		void init_framebuffers();
		void init_commands();
		void init_sync_structures();
		void init_pipelines();
		void init_descriptors();
		void prepareMultiThreadedRenderer();

		//loads a shader module from a spir-v file. Returns false if it errors
		VkPipelineShaderStageCreateInfo load_shader(std::string fileName, VkShaderStageFlagBits stage);
		bool load_shader_module(const char* filePath, VkShaderModule* outShaderModule);

		void addWorld(std::string filename);
		void addLayer(std::string filename);
		void addMesh(std::string filename, const glm::mat4& matrix);
		void addTerrain(std::string filename, uint32_t tileRes, float_t highestElevation, float_t lowestElevation, float_t terrainSize, const glm::mat4& origin, uint32_t index);
        void loadAssets(std::string asset);

#ifdef THREADING_PART2
		void render_addMesh(std::string meshName, std::string materialName, const glm::mat4& matrix);
		void render_addTerrain(std::string meshName, std::string materialName, const glm::mat4& matrix);

        void upload_mesh(Mesh* mesh);
        void upload_mesh(TerrainMesh* mesh);
#else
        void upload_mesh(Mesh& mesh);
        void upload_mesh(TerrainMesh& mesh);
#endif
		void addOrInsert(std::string materialName, RenderObject& ro);
		glm::mat4 _world;

#ifdef _DEBUG
		VkPipeline _debugPipeline;
		VkPipelineLayout _debugPipelineLayout; 
#endif
	};
}