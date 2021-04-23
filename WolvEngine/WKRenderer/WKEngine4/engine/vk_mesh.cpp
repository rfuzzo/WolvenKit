#include <vk_mesh.h>
#include <iostream>
#include "glm/common.hpp"
#include "glm/detail/func_geometric.inl"
#include "logger.h"

VertexInputDescription Vertex::get_vertex_description()
{
	VertexInputDescription description;

	//we will have just 1 vertex buffer binding, with a per-vertex rate
	VkVertexInputBindingDescription mainBinding = {};
	mainBinding.binding = 0;
	mainBinding.stride = sizeof(Vertex);
	mainBinding.inputRate = VK_VERTEX_INPUT_RATE_VERTEX;

	description.bindings.push_back(mainBinding);

	//Position will be stored at Location 0
	VkVertexInputAttributeDescription positionAttribute = {};
	positionAttribute.binding = 0;
	positionAttribute.location = 0;
	positionAttribute.format = VK_FORMAT_R32G32B32_SFLOAT;
	positionAttribute.offset = offsetof(Vertex, position);

	//Normal will be stored at Location 1
	VkVertexInputAttributeDescription normalAttribute = {};
	normalAttribute.binding = 0;
	normalAttribute.location = 1;
	normalAttribute.format = VK_FORMAT_R8G8_UNORM;//VK_FORMAT_R32G32B32_SFLOAT;
	normalAttribute.offset = offsetof(Vertex, oct_normal);

	//Position will be stored at Location 2
	VkVertexInputAttributeDescription colorAttribute = {};
	colorAttribute.binding = 0;
	colorAttribute.location = 2;
	colorAttribute.format = VK_FORMAT_R8G8B8_UNORM;//VK_FORMAT_R32G32B32_SFLOAT;
	colorAttribute.offset = offsetof(Vertex, color);

	//UV will be stored at Location 2
	VkVertexInputAttributeDescription uvAttribute = {};
	uvAttribute.binding = 0;
	uvAttribute.location = 3;
	uvAttribute.format = VK_FORMAT_R32G32_SFLOAT;
	uvAttribute.offset = offsetof(Vertex, uv);


	description.attributes.push_back(positionAttribute);
	description.attributes.push_back(normalAttribute);
	description.attributes.push_back(colorAttribute);
	description.attributes.push_back(uvAttribute);
	return description;
}

static const glm::vec2 ones = glm::vec2(1.0f, 1.0f);
static const glm::vec2 tiny = glm::vec2(1.0E-35f, 1.0E-35f);
static const glm::vec2 half = glm::vec2(127.5f, 127.5f);

void Vertex::pack_normal_fast(const glm::vec3& n)
{
	glm::vec3 an = glm::abs(n);
	glm::vec3 m = n / (an.x + an.y + an.z);
    
	glm::vec2 oct = m.xy();
	if (m.z < 0.0f)
		oct = (ones - glm::abs(m.yx())) * glm::sign(m.xy() + tiny);
    oct *= half;
    oct += half;

	oct_normal.x = (uint8_t)oct.x;
	oct_normal.y = (uint8_t)oct.y;
}


using namespace glm;
vec2 OctNormalWrap(vec2 v)
{
	vec2 wrap;
	wrap.x = (1.0f - glm::abs(v.y)) * (v.x >= 0.0f ? 1.0f : -1.0f);
	wrap.y = (1.0f - glm::abs(v.x)) * (v.y >= 0.0f ? 1.0f : -1.0f);
	return wrap;
}

vec2 OctNormalEncode(vec3 n)
{
	n /= (glm::abs(n.x) + glm::abs(n.y) + glm::abs(n.z));

	vec2 wrapped = OctNormalWrap(n);

	vec2 result;
	result.x = n.z >= 0.0f ? n.x : wrapped.x;
	result.y = n.z >= 0.0f ? n.y : wrapped.y;

	result.x = result.x * 0.5f + 0.5f;
	result.y = result.y * 0.5f + 0.5f;

	return result;
}

void Vertex::pack_normal(glm::vec3 n)
{
#if 1
	pack_normal_fast(n);
	glm::vec<2, uint8_t> o = oct_normal;

	vec2 oct = OctNormalEncode(n);
    oct_normal.x = uint8_t(oct.x * 255);
    oct_normal.y = uint8_t(oct.y * 255);

	assert(oct_normal == o);
#else
    vec2 oct = OctNormalEncode(n);

    oct_normal.x = uint8_t(oct.x * 255);
    oct_normal.y = uint8_t(oct.y * 255);
#endif
}

glm::vec3 OctNormalDecode(glm::vec2 encN)
{
	encN = encN * 2.0f - 1.0f;

	// https://twitter.com/Stubbesaurus/status/937994790553227264
	glm::vec3 n = glm::vec3(encN.x, encN.y, 1.0f - abs(encN.x) - abs(encN.y));
	float t = glm::clamp(-n.z, 0.0f, 1.0f);

	n.x += n.x >= 0.0f ? -t : t;
	n.y += n.y >= 0.0f ? -t : t;

	n = glm::normalize(n);
	return (n);
}


void Vertex::pack_color(glm::vec3 c)
{
	color.r = static_cast<uint8_t>(c.x * 255);
	color.g = static_cast<uint8_t>(c.y * 255);
	color.b = static_cast<uint8_t>(c.z * 255);
}
