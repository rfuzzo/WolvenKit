#include <taskflow/taskflow.hpp>
#include "engine/concurrentqueue.h"
#include <vector>
#include <string>
#include <unordered_map>

/*
namespace WolvenEngine
{
    struct Mesh
    {
        std::string name;
    };

    struct RenderObject
    {
        Mesh* mesh = nullptr;
        // world transform
    };

    struct Material
    {
        moodycamel::ConcurrentQueue<RenderObject> queue;
        std::vector<Mesh> meshes;
        // VkPipeline
        // VkPipelineLayout
        // Command buffer
        // Command pool
    };

    class Engine
    {
    private:
        std::unordered_map<std::string, WolvenEngine::Material> _renderBuckets;
        bool quit = false;

    public:
        void init()
        {

        }

        //I/O
        void loadworld()
        {
            tf::Executor executor;
            // load 2000 layers
        }

        void loadLayer()
        {
            // load 100 - 1000 meshes
        }

        void loadMesh()
        {
            tf::Executor executor;

            // create 1 - 10 meshes (since each distinct material will be a mesh)
            int N = std::rand() % 10;
            for (int i = 0; i < N; ++i)
            {
                // put a mesh onto the list
                executor.silent_async([&]() {
                    std::string name = "mesh_" + std::to_string(i);
                    uploadMesh(name, "default");
                    });


                // TODO: create 2 textures per material (some will already exist)
            }


        }

        // Rendering
        void uploadMesh(const std::string& name, const std::string& materialName)
        {
            Mesh m;
            m.name = name;
            //m.transform = matrix;  // etc

            // loading the device with data
            // adding to the list
            auto it = _renderBuckets.find(materialName);
            if (it != _renderBuckets.end())
            {
                // add render object to the bucket
                it->second.meshes.emplace_back(m);
            }
            else
            {
                // new bucket!
                WolvenEngine::Material mat;

                //auto result = _renderBuckets.insert(std::pair<std::string, WolvenEngine::Material>(materialName, mat));
                //result.first->second.meshes.emplace_back(m);
            }

        }

        void process_inputs()
        {
            // quit after a while...
        }

        void prepare()
        {
            // go through the meshes and cull
            // add visible to material queues
            tf::Taskflow taskflow;
            // lots of stuff to draw in the difference material buckets
            taskflow.for_each(_renderBuckets.begin(), _renderBuckets.end(), [](auto it) {
                tf::Taskflow cullTask;
                // lots of stuff to draw on the queue
                cullTask.for_each(it.second.meshes.begin(), it.second.meshes.end(), [&](Mesh& m) {
                    // if within the camera frustum, add to queue
                    int show = std::rand() % 10;
                    if (show == 0)
                    {
                        RenderObject ro;
                        ro.mesh = &m;
                        it.second.queue.enqueue(ro);
                    }
                    });
                });
        }

        void submit()
        {
            // gather all the commands and submit to the gpu
        }

        void draw()
        {
            tf::Taskflow taskflow;
            // lots of stuff to draw in the difference material buckets
            taskflow.for_each(_renderBuckets.begin(), _renderBuckets.end(), [](auto it) {
                // bind the material pipeline and pipeline layout
                std::cout << "drawing render material " << it->first << '\n';

                tf::Taskflow renderDraws;
                // lots of stuff to draw on the queue
                renderDraws.for_each(it->second._queue.begin(), it->second._queue.end(), [](RenderObject ro) {
                    // drawing to the material command buffer
                    std::cout << "drawing render object " << ro.mesh->name << '\n';
                    });
                });
        }

        void drawUI()
        {
            // single command buffer
        }

        void render()
        {
            prepare();

            draw();
            drawUI();

            submit();
        }

        void run()
        {
            while (!quit)
            {
                process_inputs();
                render();
            }
        }
    };
}

int main() {

    tf::Executor executor;

    WolvenEngine::Engine engine;

    engine.init();

    // load world
    executor.silent_async([&]() {
        engine.loadworld();
    });

    engine.run();

    return 0;
}
*/

int main() {
    return 0;
}
