#pragma once
#include <string>
#include <glm/matrix.hpp>

namespace WolvenEngine
{
    class RenderMessage
    {
    public:
        enum class MessageType
        {
            Invalid = 0,
            AddMesh,
            AddTerrain,
            ShowNode,
            HideNode,
            SelectNode,
            DeselectNode,
            HighlightNode,
            MeshesLoaded,
            NUM_MESSAGE_TYPES
        };

        RenderMessage()
        :_type(MessageType::Invalid)
        ,_matrix(1.0f)
        {
        }

#define THREADING_PART2
#ifdef THREADING_PART2
        RenderMessage(MessageType m)
        :_type(m)
        {
        }

        RenderMessage(MessageType m, std::string meshName, std::string material, glm::mat4& matrix)
            :_type(m)
            , _meshName(meshName)
            , _material(material)
            , _matrix(matrix)
        {

        }

        MessageType _type;
        std::string _meshName;
        std::string _material;
        glm::mat4 _matrix;
#else
        RenderMessage(MessageType m, std::string meshPath, glm::mat4& matrix)
            :_type(m)
            , _meshPath(meshPath)
            , _matrix(matrix)
        {
        }

        RenderMessage(MessageType m, std::string meshPath, uint32_t tileRes, float_t maxElevation, float_t minElevation, float_t tileSize, glm::mat4& matrix, uint32_t index)
        :_type(m)
        ,_meshPath(meshPath)
        ,_tileRes(tileRes)
        ,_maxElevation(maxElevation)
        ,_minElevation(minElevation)
        ,_tileSize(tileSize)
        ,_matrix(matrix)
        ,_index(index)
        {

        }

        MessageType _type;
        std::string _meshPath;
        glm::mat4 _matrix;
        uint32_t _tileRes = 0;
        float_t _maxElevation = 0.0f;
        float_t _minElevation = 0.0f;
        float_t _tileSize = 0.0f;
        uint32_t _index = 0;
#endif
    };
}