#define _USE_MATH_DEFINES
#include <cmath>
#include <fbxModel.h>
#include <fbxsdk/utils/fbxgeometryconverter.h>
#include <fbxsdk/core/math/fbxvector2.h>
#include <fbxsdk/scene/geometry/fbxmesh.h>
#include <glm/gtc/type_ptr.hpp>

#ifdef _DEBUG
#include <iostream>
#endif

namespace FBX
{
    Model::~Model()
    {
        for (auto it = nodes.begin(); it != nodes.end(); ++it)
        {
            delete *it;
        }
    }

    std::shared_ptr<Mesh> Model::processMesh(FbxMesh* mesh)
    {
        std::string meshName = mesh->GetName();

        auto mit = cachedMeshes.find(meshName);
        if (mit != cachedMeshes.end())
        {
            // already have a mesh!
            return mit->second;
        }

        const int normalCount = mesh->GetElementNormalCount();
        const int polygonCount = mesh->GetPolygonCount();
        //const int tangentCount = mesh->GetElementTangentCount();
        const int uvCount = mesh->GetElementUVCount();
        const bool hasNormal = (normalCount > 0);
        //const bool hasTangent = (tangentCount > 0);
        const bool hasUV = (uvCount > 0);

        int vertexCount = 0;
        for (int polygonIndex = 0; polygonIndex < polygonCount; ++polygonIndex)
            vertexCount += mesh->GetPolygonSize(polygonIndex);

        const int indexCount = (polygonCount * 3) + ((vertexCount - (polygonCount * 3)) * 3);

        std::shared_ptr<Mesh> newMesh = std::make_shared<Mesh>();
        newMesh->_vertices.resize(vertexCount);
        newMesh->_indices.resize(indexCount);

        FbxVector4* controlPoints = mesh->GetControlPoints();

        int vertexIndex = 0;
        Vertex* pv = &(newMesh->_vertices[0]);
        uint32_t* pi = &(newMesh->_indices[0]);

        float_t minX = 1.0E9f;
        float_t maxX = -1.0E9f;

        float_t minY = 1.0E9f;
        float_t maxY = -1.0E9f;

        float_t minZ = 1.0E9f;
        float_t maxZ = -1.0E9f;

        for (int polygonIndex = 0; polygonIndex < polygonCount; ++polygonIndex)
        {
            const int polygonSize = mesh->GetPolygonSize(polygonIndex);
            for (int pVertexIndex = 0; pVertexIndex < polygonSize; ++pVertexIndex, ++pv)
            {
                const int controlPointIndex = mesh->GetPolygonVertex(polygonIndex, pVertexIndex);
                const FbxVector4* vertex = (controlPoints + controlPointIndex);

                pv->position.x = (float)vertex->mData[0];
                pv->position.y = (float)vertex->mData[1];
                pv->position.z = (float)vertex->mData[2];

                if (pv->position.x < minX) minX = pv->position.x;
                if (pv->position.x > maxX) maxX = pv->position.x;

                if (pv->position.y < minY) minY = pv->position.y;
                if (pv->position.y > maxY) maxY = pv->position.y;

                if (pv->position.z < minZ) minZ = pv->position.z;
                if (pv->position.z > maxZ) maxZ = pv->position.z;

                if (pVertexIndex >= 1 && pVertexIndex < (polygonSize - 1))
                {
                    *pi++ = (uint32_t)(vertexIndex - pVertexIndex);
                    *pi++ = (uint32_t)vertexIndex;
                    *pi++ = (uint32_t)(vertexIndex + 1);
                }
                if (hasUV)
                {
                    FbxVector2 vector;
                    bool unmapped;
                    if (mesh->GetPolygonVertexUV(polygonIndex, pVertexIndex, NULL, vector, unmapped)) {
                        pv->uv.x = unmapped ? 0 : vector[0];
                        pv->uv.y = unmapped ? 0 : vector[1];
                    }
                    else {
                        //qWarning(FbxGeometryLoaderLog, "Irregularity encountered while parsing UV element.");
                        pv->uv.x = 0;
                        pv->uv.y = 0;
                    }
                }
                if (hasNormal)
                {
                    FbxVector4 vector;
                    if (mesh->GetPolygonVertexNormal(polygonIndex, pVertexIndex, vector))
                    {
                        glm::vec3 norm = glm::vec3((float)vector.mData[0], (float)vector.mData[1], (float)vector.mData[2]);
                        pv->pack_normal_fast(norm);
                    }
                    else
                    {
                        //qWarning(FbxGeometryLoaderLog, "Irregularity encountered while parsing Normal element.");
                        glm::vec3 norm = glm::vec3(0.0f, 1.0f, 0.0f);
                        pv->pack_normal_fast(norm);
                    }
                }
                /*
                if (hasTangent)
                {
                    int index = -1;
                    for (int tangentIndex = 0; tangentIndex < tangentCount && index == -1; ++tangentIndex) {
                        const FbxGeometryElementTangent* tangent = mesh->GetElementTangent(tangentIndex);
                        if (tangent->GetMappingMode() == FbxGeometryElement::eByPolygonVertex) {
                            switch (tangent->GetReferenceMode()) {
                            case FbxGeometryElement::eDirect:
                                index = vertexIndex;
                                break;
                            case FbxGeometryElement::eIndexToDirect:
                                index = tangent->GetIndexArray().GetAt(vertexIndex);
                                break;
                            default: break;
                            }
                        }
                        if (index != -1) {
                            const FbxVector4 vector = tangent->GetDirectArray().GetAt(index);
                            *vertexData++ = vector[0];
                            *vertexData++ = vector[1];
                            *vertexData++ = vector[2];
                            *vertexData++ = vector[3];
                        }
                    }
                    if (index == -1) {
                        qWarning(FbxGeometryLoaderLog,
                            "Irregularity encountered while parsing Tangent element.");
                        *vertexData++ = 0;
                        *vertexData++ = 0;
                        *vertexData++ = 0;
                        *vertexData++ = 0;
                    }
                }
                */

                ++vertexIndex;
            }
        }

        newMesh->bounds.extents.x = (maxX - minX) * 0.5f;
        newMesh->bounds.extents.y = (maxY - minY) * 0.5f;
        newMesh->bounds.extents.z = (maxZ - minZ) * 0.5f;
        newMesh->bounds.origin.x = (maxX + minX) * 0.5f;;
        newMesh->bounds.origin.y = (maxY + minY) * 0.5f;;
        newMesh->bounds.origin.z = (maxZ + minZ) * 0.5f;;
        newMesh->bounds.radius = glm::distance(glm::vec3(minX, minY, minZ), glm::vec3(maxX, maxY, maxZ)) * 0.5f;
        newMesh->bounds.valid = true;

        return newMesh;
    }

    void Model::processNode(FbxNode* pNode)
    {
        if (!pNode)
            return;

        if (pNode->GetNodeAttribute()->GetAttributeType() == fbxsdk::FbxNodeAttribute::eMesh)
        {
            FbxAMatrix matrix = pNode->EvaluateGlobalTransform();
            glm::dvec4 c0 = glm::make_vec4((double*)matrix.GetColumn(0).Buffer());
            glm::dvec4 c1 = glm::make_vec4((double*)matrix.GetColumn(1).Buffer());
            glm::dvec4 c2 = glm::make_vec4((double*)matrix.GetColumn(2).Buffer());
            glm::dvec4 c3 = glm::make_vec4((double*)matrix.GetColumn(3).Buffer());

            glm::mat4 transform = glm::mat4(c0, c1, c2, c3);

            Node* n = new Node(transform);
            n->mesh = processMesh(pNode->GetMesh());

            // should only be 1 material per mesh since we set the I/O settings to split by material
            FbxSurfaceMaterial* material = (FbxSurfaceMaterial*)pNode->GetSrcObject<FbxSurfaceMaterial>(0);
            if (material != nullptr)
            {
                FbxProperty prop = material->FindProperty(FbxSurfaceMaterial::sDiffuse);

                int layeredTextureCount = prop.GetSrcObjectCount<FbxLayeredTexture>();
                if (layeredTextureCount == 0)
                {
                    FbxFileTexture* texture = FbxCast<FbxFileTexture>(prop.GetSrcObject<FbxFileTexture>(0));
                    if (texture)
                    {
                        // Then, you can get all the properties of the texture, include its name
                        n->diffuseTexture = texture->GetName();
                    }
                }
            }

            nodes.push_back(n);            
        }

        for (int i = 0; i < pNode->GetChildCount(); i++)
        {
            // Call recursive DisplayContent() once for each child of the root node
            processNode(pNode->GetChild(i));
        }
    }

    bool Model::loadFromFile(std::string asset)
    {
        bool rc = false;

        if (asset.ends_with("fbx"))
        {
            FbxManager* manager = FbxManager::Create();
            FbxIOSettings* ios = FbxIOSettings::Create(manager, IOSROOT);
            // configure settings....
            manager->SetIOSettings(ios);

            FbxImporter* importer = FbxImporter::Create(manager, "");
            rc = importer->Initialize(asset.c_str(), -1, manager->GetIOSettings());
            if (rc)
            {
                FbxScene* scene = FbxScene::Create(manager, "scene");
                importer->Import(scene);

                FbxGeometryConverter clsConverter(manager);
                clsConverter.Triangulate(scene, true);
                clsConverter.SplitMeshesPerMaterial(scene, true);

                importer->Destroy();

                // traverse the scene
                FbxNode* root = scene->GetRootNode();
                if (root)
                {
                    for (int i = 0; i < root->GetChildCount(); ++i)
                    {
                        processNode(root->GetChild(i));
                    }
                }
            }
        }

        return rc;
    }

}