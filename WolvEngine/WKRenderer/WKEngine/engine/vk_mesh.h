#pragma once

#include <vk_types.h>
#include <vector>
#include <string>
#include <glm/vec3.hpp>
#include <glm/vec2.hpp>

namespace WolvenEngine
{
	struct VertexInputDescription {
		std::vector<VkVertexInputBindingDescription> bindings;
		std::vector<VkVertexInputAttributeDescription> attributes;

		VkPipelineVertexInputStateCreateFlags flags = 0;
	};


	struct Vertex {

		glm::vec3 position;
		glm::vec3 normal;
		glm::vec3 color;
		glm::vec2 uv;
		static VertexInputDescription get_vertex_description();
	};

	struct Mesh {
		std::vector<Vertex> _vertices;
		std::vector<uint16_t> _indices;

		glm::vec3 _min = glm::vec3(FLT_MAX);
		glm::vec3 _max = glm::vec3(-FLT_MAX);
		glm::vec3 _center = glm::vec3(0);
		float_t _radius = 0.0f;

		AllocatedBuffer _vertexBuffer;
		AllocatedBuffer _indexBuffer;

#ifdef USE_OBJ
		bool load_from_obj(const char* filename);
#endif
	};

	struct TerrainMesh {
		std::vector<Vertex> _vertices;
		std::vector<uint32_t> _indices;

		glm::vec3 _min = glm::vec3(FLT_MAX);
		glm::vec3 _max = glm::vec3(-FLT_MAX);
		glm::vec3 _center = glm::vec3(0);
		float_t _radius = 0.0f;

		AllocatedBuffer _vertexBuffer;
		AllocatedBuffer _indexBuffer;
	};

#ifdef _DEBUG
	void write_obj(std::string filename, const Mesh& mesh);
#endif

}