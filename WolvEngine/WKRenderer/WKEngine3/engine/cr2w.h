#pragma once

#include <string>
#include <vector>
#include "file.h"

#define GLM_FORCE_RADIANS
#define GLM_FORCE_DEPTH_ZERO_TO_ONE
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

namespace WolvenEngine
{
    union Float
    {
        unsigned __int32 u32;
        float_t f32;
        struct // single precision floating point (binary32) format IEEE 754-2008
        {
            unsigned __int32 frac : 23;
            unsigned __int32 exp : 8;
            unsigned __int32 sign : 1;
        };
    };

    union Half
    {
        unsigned short u16;
        struct // half (binary16) format IEEE 754-2008
        {
            unsigned short frac : 10;
            unsigned short exp : 5;
            unsigned short sign : 1;
        };
        Float toFloat()
        {
            Float f;
            f.sign = sign;
            switch (exp)
            {
            case 0: // subnormal : (-1)^sign * 2^-14 * 0.frac
                if (frac) // subnormals but non-zeros -> normals in float32
                {
                    f.exp = -15 + 127;
                    unsigned __int32 _frac(frac);
                    while (!(_frac & 0x200)) { _frac <<= 1; f.exp--; }
                    f.frac = (_frac & 0x1FF) << 14;
                }
                else { f.frac = 0; f.exp = 0; } // ± 0 -> ± 0
                break;
            case 31: // infinity or NaNs : frac ? NaN : (-1)^sign * infinity
                f.exp = 255;
                f.frac = frac ? 0x200000 : 0; // signaling Nan or zero
                break;
            default: // normal : (-1)^sign * 2^(exp-15) * 1.frac
                f.exp = exp - 15 + 127;
                f.frac = ((unsigned __int32)frac) << 13;
            }
            return f;
        }
    };

    inline float_t halfToFloat(unsigned short val)
    {
        Half h;
        h.u16 = val;

        return h.toFloat().f32;
    }

    struct SMeshInfos
    {
        SMeshInfos() : numVertices(0), numIndices(0), numBonesPerVertex(4), firstVertex(0), firstIndex(0), vertexType(0), materialID(0) {}

        uint32_t numVertices;
        uint32_t numIndices;
        uint32_t numBonesPerVertex;
        uint32_t firstVertex;
        uint32_t firstIndex;
        uint32_t vertexType;
        uint32_t materialID;
    };

    // Informations about the .buffer file
    struct SVertexBufferInfos
    {
        SVertexBufferInfos() : verticesCoordsOffset(0), uvOffset(0), normalsOffset(0), indicesOffset(0), nbVertices(0), nbIndices(0), lod(1) {}

        uint32_t verticesCoordsOffset;
        uint32_t uvOffset;
        uint32_t normalsOffset;
        uint32_t indicesOffset;
        uint32_t nbIndices;
        uint16_t nbVertices;
        uint8_t lod;
        uint8_t unused = 0;
    };

    struct SBufferInfos
    {
        SBufferInfos() : vertexBufferOffset(0), vertexBufferSize(0), indexBufferOffset(0), indexBufferSize(0),
            quantizationScale(glm::vec3(1, 1, 1)), quantizationOffset(glm::vec3(0, 0, 0)) {}

        uint32_t vertexBufferOffset;
        uint32_t vertexBufferSize;
        uint32_t indexBufferOffset;
        uint32_t indexBufferSize;

        glm::vec3 quantizationScale;
        glm::vec3 quantizationOffset;

        std::vector<SVertexBufferInfos> verticesBuffer;
    };

    struct ContentInfo
    {
        uint32_t type;
        uint32_t address;
        uint32_t end;
    };

    bool readCR2W(File& fp, std::vector<std::string>& labels, std::vector<std::string>& fileNames, std::vector<ContentInfo>& contents);
    bool readCR2W(File& fp, std::vector<std::string>& labels, std::vector<std::string>& fileNames, std::vector<std::string>& tileNames, std::vector<ContentInfo>& contents);
    bool readWTER(File& fp, uint32_t lod, uint32_t& tileLOD, uint32_t& tileResolution);

    struct Variable
    {
        uint16_t name;
        uint16_t type;
        uint32_t end;
    };

    bool readVariable(File& fp, Variable& var);
    template <class T>
    T readVariable(File& fp);

    int32_t readVLQInt32(File& fp);
}
