cd ../shaders
glslangValidator -V -o wk_mesh.vert.spv wk_mesh.vert
glslangValidator -V -o wk_default_lit.frag.spv wk_default_lit.frag
glslangValidator -V -o wk_textured_lit.frag.spv wk_textured_lit.frag
cd ../WKEngine