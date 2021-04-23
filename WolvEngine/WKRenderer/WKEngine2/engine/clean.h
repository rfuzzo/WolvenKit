#pragma once
#include <vk_mesh.h>

namespace WolvenEngine
{
    static int RemoveDuplicateVertex(Mesh& m)
    {
        if (m._vertices.size() == 0 || m._ == 0) return 0;

        std::map<VertexPointer, VertexPointer> mp;
        size_t i, j;
        VertexIterator vi;
        int deleted = 0;
        int k = 0;
        size_t num_vert = m.vert.size();
        std::vector<VertexPointer> perm(num_vert);
        for (vi = m.vert.begin(); vi != m.vert.end(); ++vi, ++k)
            perm[k] = &(*vi);

        RemoveDuplicateVert_Compare c_obj;
        std::sort(perm.begin(), perm.end(), c_obj);

        j = 0;
        i = j;
        mp[perm[i]] = perm[j];
        ++i;
        for (; i != num_vert;)
        {
            if ((!(*perm[i]).IsD()) &&
                (!(*perm[j]).IsD()) &&
                (*perm[i]).P() == (*perm[j]).cP())
            {
                VertexPointer t = perm[i];
                mp[perm[i]] = perm[j];
                ++i;
                Allocator<MeshType>::DeleteVertex(m, *t);
                deleted++;
            }
            else
            {
                j = i;
                ++i;
            }
        }

        for (FaceIterator fi = m.face.begin(); fi != m.face.end(); ++fi)
            if (!(*fi).IsD())
                for (k = 0; k < (*fi).VN(); ++k)
                    if (mp.find((typename MeshType::VertexPointer)(*fi).V(k)) != mp.end())
                    {
                        (*fi).V(k) = &*mp[(*fi).V(k)];
                    }


        for (EdgeIterator ei = m.edge.begin(); ei != m.edge.end(); ++ei)
            if (!(*ei).IsD())
                for (k = 0; k < 2; ++k)
                    if (mp.find((typename MeshType::VertexPointer)(*ei).V(k)) != mp.end())
                    {
                        (*ei).V(k) = &*mp[(*ei).V(k)];
                    }

        for (TetraIterator ti = m.tetra.begin(); ti != m.tetra.end(); ++ti)
            if (!(*ti).IsD())
                for (k = 0; k < 4; ++k)
                    if (mp.find((typename MeshType::VertexPointer)(*ti).V(k)) != mp.end())
                        (*ti).V(k) = &*mp[(*ti).V(k)];

        if (RemoveDegenerateFlag) RemoveDegenerateFace(m);
        if (RemoveDegenerateFlag && m.en > 0) {
            RemoveDegenerateEdge(m);
            RemoveDuplicateEdge(m);

        }
        return deleted;
    }
}