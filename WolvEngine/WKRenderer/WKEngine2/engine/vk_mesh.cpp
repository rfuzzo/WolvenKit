#include <vk_mesh.h>
#ifdef USE_OBJ
#include <tiny_obj_loader.h>
#endif
#include <iostream>

namespace WolvenEngine
{
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
		normalAttribute.format = VK_FORMAT_R32G32B32_SFLOAT;
		normalAttribute.offset = offsetof(Vertex, normal);

		//Position will be stored at Location 2
		VkVertexInputAttributeDescription colorAttribute = {};
		colorAttribute.binding = 0;
		colorAttribute.location = 2;
		colorAttribute.format = VK_FORMAT_R32G32B32_SFLOAT;
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

#ifdef USE_OBJ
	bool Mesh::load_from_obj(const char* filename)
	{
		//attrib will contain the vertex arrays of the file
		tinyobj::attrib_t attrib;
		//shapes contains the info for each separate object in the file
		std::vector<tinyobj::shape_t> shapes;
		//materials contains the information about the material of each shape, but we wont use it.
		std::vector<tinyobj::material_t> materials;

		//error and warning output from the load function
		std::string warn;
		std::string err;

		//load the OBJ file
		tinyobj::LoadObj(&attrib, &shapes, &materials, &warn, &err, filename,
			nullptr);
		//make sure to output the warnings to the console, in case there are issues with the file
		if (!warn.empty()) {
			std::cout << "WARN: " << warn << std::endl;
		}
		//if we have any error, print it to the console, and break the mesh loading. 
		//This happens if the file cant be found or is malformed
		if (!err.empty()) {
			std::cerr << err << std::endl;
			return false;
		}

		// Loop over the vertices
		size_t numVertices = attrib.vertices.size() / 3; // vector is floats for each coordinate (x,y,z)

		for (size_t i = 0; i < numVertices; ++i) {
			tinyobj::real_t vx = attrib.vertices[3 * i + 0];
			tinyobj::real_t vy = attrib.vertices[3 * i + 1];
			tinyobj::real_t vz = attrib.vertices[3 * i + 2];
			//vertex normal
			tinyobj::real_t nx = attrib.normals[3 * i + 0];
			tinyobj::real_t ny = attrib.normals[3 * i + 1];
			tinyobj::real_t nz = attrib.normals[3 * i + 2];

			//vertex uv
			tinyobj::real_t ux = attrib.texcoords[2 * i + 0];
			tinyobj::real_t uy = attrib.texcoords[2 * i + 1];

			//copy it into our vertex
			Vertex new_vert;
			new_vert.position.x = vx;
			new_vert.position.y = vy;
			new_vert.position.z = vz;

			new_vert.normal.x = nx;
			new_vert.normal.y = ny;
			new_vert.normal.z = nz;

			new_vert.uv.x = ux;
			new_vert.uv.y = 1 - uy;

			//we are setting the vertex color to red
			new_vert.color = glm::vec3(1.0f, 0.0f, 0.0f);

			_vertices.emplace_back(new_vert);
		}

		// Loop over shapes
		for (size_t s = 0; s < shapes.size(); s++) {

			// Loop over faces(polygon)
			size_t index_offset = 0;
			for (size_t f = 0; f < shapes[s].mesh.num_face_vertices.size(); f++) {

				tinyobj::index_t idx0 = shapes[s].mesh.indices[index_offset + 0];
				tinyobj::index_t idx1 = shapes[s].mesh.indices[index_offset + 1];
				tinyobj::index_t idx2 = shapes[s].mesh.indices[index_offset + 2];

				_indices.push_back(idx0.vertex_index);
				_indices.push_back(idx1.vertex_index);
				_indices.push_back(idx2.vertex_index);

				index_offset += 3;
			}
		}

		return true;
	}
#endif

#ifdef _DEBUG
	void write_obj(std::string filename, const Mesh& mesh)
    {
        FILE* fp = nullptr;
        fopen_s(&fp, filename.c_str(), "wt");
        if (fp == nullptr)
            return;

        fprintf(fp, "# %d vertices, %d indices\n", (uint32_t)mesh._vertices.size(), (uint32_t)mesh._indices.size());

        for (size_t i = 0; i < mesh._vertices.size(); ++i)
        {
            const Vertex& v = mesh._vertices[i];

            fprintf(fp, "v %g %g %g\n", v.position.x, v.position.y, v.position.z);
            //fprintf(fp, "vt %g %g\n", v.uv.x, v.uv.y);
            //fprintf(fp, "vn %g %g %g\n", v.normal.x, v.normal.y, v.normal.z);
        }

        for (size_t i = 0; i < mesh._indices.size();)
        {
            uint32_t v0 = mesh._indices[i++] + 1;
            uint32_t v1 = mesh._indices[i++] + 1;
            uint32_t v2 = mesh._indices[i++] + 1;
            //fprintf(fp, "f %d/%d/%d %d/%d/%d %d/%d/%d\n", v0, v0, v0, v1, v1, v1, v2, v2, v2);
			fprintf(fp, "f %d %d %d\n", v0, v1, v2);
        }

        fclose(fp);
    }
#endif
}