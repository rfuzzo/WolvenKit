//glsl version 4.5
#version 450

//shader input
layout (location = 0) in vec3 inNormal;
layout (location = 1) in vec4 inUV;

//output write
layout (location = 0) out vec4 outFragColor;

layout(set = 0, binding = 1) uniform  SceneData{   
    vec4 fogColor; // w is for exponent
	vec4 fogDistances; //x for min, y for max, zw unused.
	vec4 ambientColor;
	vec4 sunlightDirection; //w for sun power
	vec4 sunlightColor;
} sceneData;


void main() 
{
	vec3 N = normalize(inNormal);
	vec3 L = normalize(sceneData.sunlightDirection.xyz);
	vec3 ambient = sceneData.ambientColor.xyz;
	vec3 diffuse = max(dot(N, L), 0.0) * vec3(1.0);

    float hfrac = inUV.z;
    uint hi = uint(round(inUV.w));
    float height = inUV.y;
    
    vec3 color = 
        mix(
            vec3(0.18,0.827,0.85),
            mix( vec3(mix(0.1,0.4,hfrac),mix(0.3,0.8,hfrac),mix(0.1,0.4,hfrac)), vec3(mix(0.4,1.0,hfrac),mix(0.8,1.0,hfrac),mix(0.4,1.0,hfrac)), hi),
            uint(height > 0)
        );
    outFragColor = vec4((ambient + diffuse) * color, 1.0);
}