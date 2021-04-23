cd shaders
glslangValidator -V -o ../../runtime3/model.vert.spv model.vert
glslangValidator -V -o ../../runtime3/model.frag.spv model.frag
glslangValidator -V -o ../../runtime3/wk_terrain.vert.spv wk_terrain.vert
glslangValidator -V -o ../../runtime3/wk_terrain.frag.spv wk_terrain.frag
cd ..