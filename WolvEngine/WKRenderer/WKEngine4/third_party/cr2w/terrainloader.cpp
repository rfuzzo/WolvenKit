#include "terrainloader.h"
#include "glm/glm.hpp"
#include <execution>

#ifdef USE_GAME_BUNDLES
#include "bundlemanager.h"
#endif

//#define USE_PARALLEL

namespace WolvenEngine
{
    bool loadTerrain(const std::string& filename, uint32_t tileRes, float_t highestElevation, float_t lowestElevation, float_t terrainSize, Mesh& mesh)
    {
        uint32_t nVertices = tileRes * tileRes;
        uint32_t nIndices = (tileRes - 1) * (tileRes * 2) + (tileRes - 2) * 2;

        mesh._vertices.resize(nVertices);
        mesh._indices.resize(nIndices);

#ifdef USE_GAME_BUNDLES
        File fp;
        if (!WolvenEngine::BundleManager::instance()->open(filename.c_str(), fp))
        {
            return false;
        }

        uint16_t* values = fp.getBuffer<uint16_t*>();
#else
        FILE* fp = nullptr;
        fopen_s(&fp, filename.c_str(), "rb");
        if (fp == nullptr)
            return false;

        uint16_t* values = (uint16_t*)malloc(nVertices * sizeof(uint16_t));
        fread(values, nVertices * sizeof(uint16_t), 1, fp);
        fclose(fp);
#endif



        float_t currY = 0.0f;
        float_t stepSize = terrainSize / tileRes;

        float_t minZ = 1.0E9f;
        float_t maxZ = -1.0E9f;

        float_t heightScale = highestElevation - lowestElevation;

        // without any omp 4324 ms
#ifdef USE_PARALLEL
        //#pragma omp parallel num_threads( 2 ) // 4612
        //#pragma omp parallel num_threads( 4 ) // 4852
        //#pragma omp parallel num_threads( 8 )
        for (uint32_t y = 0; y < tileRes; ++y)
        {
            //#pragma omp parallel num_threads( 2 )
            //#pragma omp parallel num_threads( 4 )
            #pragma loop( hint_parallel(2) )
            for (uint32_t x = 0; x < tileRes; ++x)
            {
                const uint32_t index = y * tileRes + x;
                Vertex& v = mesh._vertices[index];

                float_t hN = (float_t)(values[index] / 65535.0f);
                float_t h = hN * heightScale + lowestElevation;

                float_t hscaled = h / highestElevation * 2.0f - 1e-05f; // hscaled should range in [0,2)
                uint32_t hi = uint32_t(hscaled); // hi should range in [0,1]
                float_t hfrac = hscaled - float_t(hi); // hfrac should range in [0,1]

                v.color = glm::vec3(0, hfrac * 255, hi * 255);
                v.position.x = x * stepSize;
                v.position.y = y * stepSize;
                v.position.z = h;

                if (h < minZ)
                    minZ = h;
                else if (h > maxZ)
                    maxZ = h;
            }
        }
#else
        const uint16_t* val = values;
        Vertex* v = &mesh._vertices[0];

        uint32_t index = 0;
        for (uint32_t y = 0; y < tileRes; ++y)
        {
            float_t currX = 0.0f;

            for (uint32_t x = 0; x < tileRes; ++x)
            {
                float_t hN = (float_t)(*val++ / 65535.0f);
                float_t h = hN * heightScale + lowestElevation;

                float_t hscaled = h / highestElevation * 2.0f - 1e-05f; // hscaled should range in [0,2)
                uint32_t hi = uint32_t(hscaled); // hi should range in [0,1]
                float_t hfrac = hscaled - float_t(hi); // hfrac should range in [0,1]

                //v->color = glm::vec3(0, hfrac * 255, hi * 255);
                v->color.r = 0;
                v->color.g = (uint8_t)(hfrac * 255);
                v->color.b = (uint8_t)(hi * 255);
                v->position.x = currX;
                v->position.y = currY;
                v->position.z = h;
                ++v;

                if (h < minZ)
                    minZ = h;
                else if (h > maxZ)
                    maxZ = h;

                currX += stepSize;
            }

            currY += stepSize;
        }
#endif

        // create faces
#ifdef USE_PARALLEL
        uint32_t index = 0;
#else
        index = 0;
#endif
        uint32_t row0Index = 0;
        uint32_t row1Index = tileRes;

        for (uint32_t z = 0; z < tileRes - 2; ++z)
        {
            // do two rows at a time to make a triangle strip
            for (uint32_t x = 0; x < tileRes; ++x)
            {
                mesh._indices[index++] = row0Index++;
                mesh._indices[index++] = row1Index++;
            }

            // add degenerate triangle to get to next row
            //TODO: consider a termination value 0xFFFF to indicate end of a row
            mesh._indices[index++] = row1Index - 1;
            mesh._indices[index++] = row0Index;
        }

        // do two rows at a time to make a triangle strip
        for (uint32_t x = 0; x < tileRes; ++x)
        {
            mesh._indices[index++] = row0Index++;
            mesh._indices[index++] = row1Index++;
        }

        for (uint32_t y = 1; y < tileRes - 1; ++y)
        {
            index = y * tileRes + 1;

            for (uint32_t x = 1; x < tileRes - 1; ++x, ++index)
            {
                const Vertex& vback = mesh._vertices[index - tileRes];
                const Vertex& vforward = mesh._vertices[index + tileRes];
                const Vertex& vleft = mesh._vertices[index - 1];
                const Vertex& vright = mesh._vertices[index + 1];

                float_t nX = vleft.position.x - vright.position.x;
                float_t nY = vback.position.y - vforward.position.y;
                float_t nZ = 100.0f;

                Vertex& vertex = mesh._vertices[index];
                vertex.pack_normal_fast(glm::normalize(glm::vec3(nX, nY, nZ)));
            }
        }
#ifndef USE_GAME_BUNDLES
        free(values);
#endif

        // mesh bounds
        mesh.bounds.extents.x = terrainSize / 2.0f;
        mesh.bounds.extents.y = terrainSize / 2.0f;
        mesh.bounds.extents.z = (maxZ - minZ) / 2.0f;
        mesh.bounds.origin.x = mesh.bounds.extents.x;
        mesh.bounds.origin.y = mesh.bounds.extents.y;
        mesh.bounds.origin.z = minZ + mesh.bounds.extents.z;
        mesh.bounds.radius = terrainSize / 2.0f;
        mesh.bounds.valid = true;

        return true;
    }
}