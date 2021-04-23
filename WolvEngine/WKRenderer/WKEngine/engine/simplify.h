#pragma once
#include <vk_mesh.h>

namespace Simplify
{
    class SymetricMatrix {

    public:

        // Constructor

        SymetricMatrix(double c = 0) { memset(&m[0], 0, sizeof(double) * 10); }

        SymetricMatrix(double m11, double m12, double m13, double m14,
            double m22, double m23, double m24,
            double m33, double m34,
            double m44) {
            m[0] = m11;  m[1] = m12;  m[2] = m13;  m[3] = m14;
            m[4] = m22;  m[5] = m23;  m[6] = m24;
            m[7] = m33;  m[8] = m34;
            m[9] = m44;
        }

        // Make plane

        SymetricMatrix(double a, double b, double c, double d)
        {
            m[0] = a * a;  m[1] = a * b;  m[2] = a * c;  m[3] = a * d;
            m[4] = b * b;  m[5] = b * c;  m[6] = b * d;
            m[7] = c * c; m[8] = c * d;
            m[9] = d * d;
        }

        double operator[](int c) const { return m[c]; }

        // Determinant

        double det(int a11, int a12, int a13,
            int a21, int a22, int a23,
            int a31, int a32, int a33)
        {
            double det = m[a11] * m[a22] * m[a33] + m[a13] * m[a21] * m[a32] + m[a12] * m[a23] * m[a31]
                - m[a13] * m[a22] * m[a31] - m[a11] * m[a23] * m[a32] - m[a12] * m[a21] * m[a33];
            return det;
        }

        const SymetricMatrix operator+(const SymetricMatrix& n) const
        {
            return SymetricMatrix(m[0] + n[0], m[1] + n[1], m[2] + n[2], m[3] + n[3],
                m[4] + n[4], m[5] + n[5], m[6] + n[6],
                m[7] + n[7], m[8] + n[8],
                m[9] + n[9]);
        }

        SymetricMatrix& operator+=(const SymetricMatrix& n)
        {
            m[0] += n[0];   m[1] += n[1];   m[2] += n[2];   m[3] += n[3];
            m[4] += n[4];   m[5] += n[5];   m[6] += n[6];   m[7] += n[7];
            m[8] += n[8];   m[9] += n[9];
            return *this;
        }

        double m[10];
    };

    struct Ref {
        uint32_t tid;
        uint32_t tvertex;
    };
    std::vector<Ref> refs;

    struct Triangle {
        uint32_t v[3];
        double err[4];
        int deleted = 0;
        int dirty; 
        glm::vec3 n; 
    };

    struct Vertex {
        glm::vec3 p;
        uint32_t tstart;
        uint32_t tcount;
        SymetricMatrix q;
        int border;
    };

    double vertex_error(SymetricMatrix q, double x, double y, double z);
    double calculate_error(int id_v1, int id_v2);
    double calculate_error(int id_v1, int id_v2, glm::vec3& result);
    bool flipped(glm::vec3 p, int i0, int i1, Vertex& v0, Vertex& v1, std::vector<int>& deleted);
    void update_triangles(int i0, Vertex& v, std::vector<int>& deleted, size_t& deleted_triangles);
    void update_mesh(int iteration);
    void compact_mesh();

    std::vector<Triangle> triangles;
    std::vector<Vertex> vertices;

    void simplify_mesh(WolvenEngine::Mesh& src, WolvenEngine::Mesh& dest)
    {
        // aggressiveness : sharpness to increase the threshold.
        //                 5..8 are good numbers
        //                 more iterations yield higher quality
        constexpr double aggressiveness = 2.0;

        // target = 50% decimation
        size_t target_count = src._vertices.size() / 2;

        for (size_t i = 0; i < src._vertices.size(); ++i)
        {
            Vertex v;
            v.p = src._vertices[i].position;
            vertices.emplace_back(v);
        }

        for (size_t i = 0; i < src._indices.size();)
        {
            Triangle t;
            t.v[0] = src._indices[i++];
            t.v[1] = src._indices[i++];
            t.v[2] = src._indices[i++];
            triangles.emplace_back(t);
        }

        std::vector<int> deleted0, deleted1;
        size_t triangle_count = triangles.size();
        size_t deleted_triangles = 0;
        double err = 1.0E9;

        for (int iteration = 0; iteration < 10; ++iteration)
        {
            if (triangle_count - deleted_triangles <= target_count)
                break;

            // update mesh once in a while
            if (iteration % 5 == 0)
            {
                update_mesh(iteration);
            }

            // clear dirty flag
            size_t nTriangles = triangles.size();
            for (size_t i = 0; i < nTriangles; ++i)
                triangles[i].dirty = 0;

            //
            // All triangles with edges below the threshold will be removed
            //
            // The following numbers works well for most models.
            // If it does not, try to adjust the 3 parameters
            //
            double threshold = 0.000000001 * pow(double(iteration + 3), aggressiveness);

            // remove vertices & mark deleted triangles			
            for (size_t i = 0; i < nTriangles; ++i)
            {
                Triangle& t = triangles[i];
                if (t.err[3] > threshold) continue;
                if (t.deleted) continue;
                if (t.dirty) continue;

                for (int j = 0; j < 3; ++j)
                {
                    if (t.err[j] < threshold)
                    {
                        int i0 = t.v[j]; Vertex& v0 = vertices[i0];
                        int i1 = t.v[(j + 1) % 3]; Vertex& v1 = vertices[i1];

                        // Border check
                        if (v0.border != v1.border)  continue;

                        // Compute vertex to collapse to
                        glm::vec3 p;
                        err = calculate_error(i0, i1, p);
#ifdef _DEBUG
                        std::cout << err << std::endl;
#endif

                        deleted0.resize(v0.tcount); // normals temporarily
                        deleted1.resize(v1.tcount); // normals temporarily

                        // don't remove if flipped
                        if (flipped(p, i0, i1, v0, v1, deleted0)) continue;
                        if (flipped(p, i1, i0, v1, v0, deleted1)) continue;

                        // not flipped, so remove edge												
                        v0.p = p;
                        v0.q = v1.q + v0.q;
                        uint32_t tstart = (uint32_t)refs.size();

                        update_triangles(i0, v0, deleted0, deleted_triangles);
                        update_triangles(i0, v1, deleted1, deleted_triangles);

                        uint32_t tcount = (uint32_t)refs.size() - tstart;

                        if (tcount <= v0.tcount)
                        {
                            // save ram
                            if (tcount)
                                memcpy(&refs[v0.tstart], &refs[tstart], tcount * sizeof(Ref));
                        }
                        else
                            // append
                            v0.tstart = tstart;

                        v0.tcount = tcount;
                        break;
                    }
                    // done?
                    if (triangle_count - deleted_triangles <= target_count)
                        break;

                }
            }

        }

        // clean up mesh
        compact_mesh();

        // store result
        dest._center = src._center;
        dest._max = src._max;
        dest._min = src._min;
        
        dest._vertices.reserve(vertices.size());
        for (size_t i = 0; i < vertices.size(); ++i)
        {
            WolvenEngine::Vertex v;
            v.position = vertices[i].p;

            dest._vertices.emplace_back(v);
        }

        for (size_t i = 0; i < triangles.size(); ++i)
        {
            if (!triangles[i].deleted)
            {
                dest._indices.push_back(triangles[i].v[0]);
                dest._indices.push_back(triangles[i].v[1]);
                dest._indices.push_back(triangles[i].v[2]);
            }
        }
    }

    // Check if a triangle flips when this edge is removed

    bool flipped(glm::vec3 p, int i0, int i1, Vertex& v0, Vertex& v1, std::vector<int>& deleted)
    {
        int bordercount = 0;
        for (size_t k = 0; k < v0.tcount; ++k)
        {
            Triangle& t = triangles[refs[v0.tstart + k].tid];
            if (t.deleted)continue;

            int s = refs[v0.tstart + k].tvertex;
            int id1 = t.v[(s + 1) % 3];
            int id2 = t.v[(s + 2) % 3];

            if (id1 == i1 || id2 == i1) // delete ?
            {
                bordercount++;
#ifdef _DEBUG
                std::cout << "---------- deleting ------------" << std::endl;
#endif
                deleted[k] = 1;
                continue;
            }
            glm::vec3 d1 = glm::normalize(vertices[id1].p - p);
            glm::vec3 d2 = glm::normalize(vertices[id2].p - p);
            if (fabs(glm::dot(d1,d2)) > 0.999) return true;
            glm::vec3 n = glm::cross(d1, d2); // should already be normalized
            //glm::normalize(n);
            deleted[k] = 0;
            if (glm::dot(n,t.n) < 0.2) return true;
        }
        return false;
    }

    // Update triangle connections and edge error after a edge is collapsed
    void update_triangles(int i0, Vertex& v, std::vector<int>& deleted, size_t& deleted_triangles)
    {
        glm::vec3 p;
        for (size_t k = 0; k < v.tcount; ++k)
        {
            Ref& r = refs[v.tstart + k];
            Triangle& t = triangles[r.tid];
            if (t.deleted)continue;
            if (deleted[k])
            {
                t.deleted = 1;
                deleted_triangles++;
                continue;
            }
            t.v[r.tvertex] = i0;
            t.dirty = 1;
            t.err[0] = calculate_error(t.v[0], t.v[1], p);
            t.err[1] = calculate_error(t.v[1], t.v[2], p);
            t.err[2] = calculate_error(t.v[2], t.v[0], p);
            t.err[3] = std::min(t.err[0], std::min(t.err[1], t.err[2]));
            refs.push_back(r);
        }
    }

    // compact triangles, compute edge error and build reference list

    void update_mesh(int iteration)
    {
        if (iteration > 0) // compact triangles
        {
            int dst = 0;
            for (size_t i = 0; i < triangles.size(); ++i)
            {
                if (!triangles[i].deleted)
                {
                    triangles[dst++] = triangles[i];
                }
            }
            triangles.resize(dst);
        }
        //
        // Init Quadrics by Plane & Edge Errors
        //
        // required at the beginning ( iteration == 0 )
        // recomputing during the simplification is not required,
        // but mostly improves the result for closed meshes
        //
        if (iteration == 0)
        {
            for (size_t i = 0; i < vertices.size(); ++i)
            {
                vertices[i].q = SymetricMatrix(0.0);
            }

            for (size_t i = 0; i < triangles.size(); ++i)
            {
                Triangle& t = triangles[i];
                glm::vec3 p[3];
                p[0] = vertices[t.v[0]].p;
                p[1] = vertices[t.v[1]].p;
                p[2] = vertices[t.v[2]].p;

                glm::vec3 n = glm::normalize(glm::cross(p[1] - p[0], p[2] - p[0]));
                t.n = n;

                // TODO optimize this...
                vertices[t.v[0]].q = vertices[t.v[0]].q + SymetricMatrix(n.x, n.y, n.z, -glm::dot(n, p[0]));
                vertices[t.v[1]].q = vertices[t.v[1]].q + SymetricMatrix(n.x, n.y, n.z, -glm::dot(n, p[0]));
                vertices[t.v[2]].q = vertices[t.v[2]].q + SymetricMatrix(n.x, n.y, n.z, -glm::dot(n, p[0]));
            }

            //TODO can this loop be merged into the above?
            for (size_t i = 0; i < triangles.size(); ++i)
            {
                Triangle& t = triangles[i];
                t.err[0] = calculate_error(t.v[0], t.v[(1) % 3]);
                t.err[1] = calculate_error(t.v[1], t.v[(2) % 3]);
                t.err[2] = calculate_error(t.v[2], t.v[(3) % 3]);
                t.err[3] = std::min(t.err[0], std::min(t.err[1], t.err[2]));
            }
        }

        // Init Reference ID list	
        for(size_t i=0; i < vertices.size(); ++i)
        {
            vertices[i].tstart = 0;
            vertices[i].tcount = 0;
        }

        for(size_t i=0; i < triangles.size(); ++i)
        {
            Triangle& t = triangles[i];
            vertices[t.v[0]].tcount++;
            vertices[t.v[1]].tcount++;
            vertices[t.v[2]].tcount++;
        }

        uint32_t tstart = 0;
        for (size_t i = 0; i < vertices.size(); ++i)
        {
            Vertex& v = vertices[i];
            v.tstart = tstart;
            tstart += v.tcount;
            v.tcount = 0;
        }

        // Write References
        refs.resize(triangles.size() * 3);
        for (size_t i = 0; i < triangles.size(); ++i)
        {
            Triangle& t = triangles[i];

            Vertex& v0 = vertices[t.v[0]];
            refs[v0.tstart + v0.tcount].tid = (uint32_t)i;
            refs[v0.tstart + v0.tcount].tvertex = 0;
            v0.tcount++;

            Vertex& v1 = vertices[t.v[1]];
            refs[v1.tstart + v1.tcount].tid = (uint32_t)i;
            refs[v1.tstart + v1.tcount].tvertex = 1;
            v1.tcount++;

            Vertex& v2 = vertices[t.v[2]];
            refs[v2.tstart + v2.tcount].tid = (uint32_t)i;
            refs[v2.tstart + v2.tcount].tvertex = 2;
            v2.tcount++;
        }

        // Identify boundary : vertices[].border=0,1 
        if (iteration == 0)
        {
            std::vector<int> vcount, vids;

            for (size_t i = 0; i < vertices.size(); ++i)
                vertices[i].border = 0;

            for (size_t i = 0; i < vertices.size(); ++i)
            {
                Vertex& v = vertices[i];
                vcount.clear();
                vids.clear();
                for(size_t j=0; j < v.tcount; ++j)
                {
                    int tindx = refs[v.tstart + j].tid;
                    Triangle& t = triangles[tindx];
                    
                    for(int k=0; k < 3; ++k)
                    {
                        int ofs = 0, id = t.v[k];
                        while (ofs < vcount.size())
                        {
                            if (vids[ofs] == id)break;
                            ofs++;
                        }
                        if (ofs == vcount.size())
                        {
                            vcount.push_back(1);
                            vids.push_back(id);
                        }
                        else
                            vcount[ofs]++;
                    }
                }
                for (size_t j = 0; j < vcount.size(); ++j)
                {
                    if (vcount[j] == 1)
                        vertices[vids[j]].border = 1;
                }
            }
        }
    }

    // Finally compact mesh before exiting

    void compact_mesh()
    {
        int dst = 0;
        for (size_t i = 0; i < vertices.size(); ++i)
        {
            vertices[i].tcount = 0;
        }

        for (size_t i = 0; i < triangles.size(); ++i)
        {
            if (!triangles[i].deleted)
            {
                Triangle& t = triangles[i];
                triangles[dst++] = t;
                vertices[t.v[0]].tcount = 1;
                vertices[t.v[1]].tcount = 1;
                vertices[t.v[2]].tcount = 1;
            }
        }

        triangles.resize(dst);
        dst = 0;

        for (size_t i = 0; i < vertices.size(); ++i)
        {
            if (vertices[i].tcount)
            {
                vertices[i].tstart = dst;
                vertices[dst].p = vertices[i].p;
                dst++;
            }
        }

        for (size_t i = 0; i < triangles.size(); ++i)
        {
            Triangle& t = triangles[i];
            t.v[0] = vertices[t.v[0]].tstart;
            t.v[1] = vertices[t.v[1]].tstart;
            t.v[2] = vertices[t.v[2]].tstart;
        }
        vertices.resize(dst);
    }

    // Error between vertex and Quadric

    double vertex_error(SymetricMatrix q, double x, double y, double z)
    {
        return   q[0] * x * x + 2 * q[1] * x * y + 2 * q[2] * x * z + 2 * q[3] * x + q[4] * y * y
            + 2 * q[5] * y * z + 2 * q[6] * y + q[7] * z * z + 2 * q[8] * z + q[9];
    }

    // Error for one edge

    double calculate_error(int id_v1, int id_v2)
    {
        // compute interpolated vertex 

        SymetricMatrix q = vertices[id_v1].q + vertices[id_v2].q;
        bool   border = vertices[id_v1].border & vertices[id_v2].border;
        double error = 0;
        double det = q.det(0, 1, 2, 1, 4, 5, 2, 5, 7);

        if (det != 0 && !border)
        {
            // q_delta is invertible
            glm::vec3 p_result;
            p_result.x = (float_t)(-1 / det * (q.det(1, 2, 3, 4, 5, 6, 5, 7, 8)));	// vx = A41/det(q_delta) 
            p_result.y = (float_t)(1 / det * (q.det(0, 2, 3, 1, 5, 6, 2, 7, 8)));	// vy = A42/det(q_delta) 
            p_result.z = (float_t)(-1 / det * (q.det(0, 1, 3, 1, 4, 6, 2, 5, 8)));	// vz = A43/det(q_delta) 
            error = vertex_error(q, p_result.x, p_result.y, p_result.z);
        }
        else
        {
            // det = 0 -> try to find best result
            glm::vec3 p1 = vertices[id_v1].p;
            glm::vec3 p2 = vertices[id_v2].p;
            glm::vec3 p3 = (p1 + p2) / 2.0f;
            double error1 = vertex_error(q, p1.x, p1.y, p1.z);
            double error2 = vertex_error(q, p2.x, p2.y, p2.z);
            double error3 = vertex_error(q, p3.x, p3.y, p3.z);
            error = std::min(error1, std::min(error2, error3));
        }
        return error;
    }

    double calculate_error(int id_v1, int id_v2, glm::vec3& p_result)
    {
        // compute interpolated vertex 

        SymetricMatrix q = vertices[id_v1].q + vertices[id_v2].q;
        bool   border = vertices[id_v1].border & vertices[id_v2].border;
        double error = 0;
        double det = q.det(0, 1, 2, 1, 4, 5, 2, 5, 7);

        if (det != 0 && !border)
        {
            // q_delta is invertible
            p_result.x = (float_t)(-1 / det * (q.det(1, 2, 3, 4, 5, 6, 5, 7, 8)));	// vx = A41/det(q_delta) 
            p_result.y = (float_t)(1 / det * (q.det(0, 2, 3, 1, 5, 6, 2, 7, 8)));	// vy = A42/det(q_delta) 
            p_result.z = (float_t)(-1 / det * (q.det(0, 1, 3, 1, 4, 6, 2, 5, 8)));	// vz = A43/det(q_delta) 
            error = vertex_error(q, p_result.x, p_result.y, p_result.z);
        }
        else
        {
            // det = 0 -> try to find best result
            glm::vec3 p1 = vertices[id_v1].p;
            glm::vec3 p2 = vertices[id_v2].p;
            glm::vec3 p3 = (p1 + p2) / 2.0f;
            double error1 = vertex_error(q, p1.x, p1.y, p1.z);
            double error2 = vertex_error(q, p2.x, p2.y, p2.z);
            double error3 = vertex_error(q, p3.x, p3.y, p3.z);
            error = std::min(error1, std::min(error2, error3));
            if (error1 == error) p_result = p1;
            if (error2 == error) p_result = p2;
            if (error3 == error) p_result = p3;
        }
        return error;
    }
}