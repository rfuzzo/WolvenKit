//glsl version 4.5
#version 450

//shader input
layout (location = 0) in vec3 inColor;
layout (location = 1) in vec2 texCoord;
layout (location = 2) in vec3 inNormal;
layout (location = 3) in vec3 inViewVec;
layout (location = 4) in vec3 inLightVec;

//output write
layout (location = 0) out vec4 outFragColor;

layout(set = 0, binding = 1) uniform  SceneData{   
    vec4 fogColor; // w is for exponent
	vec4 fogDistances; //x for min, y for max, zw unused.
	vec4 ambientColor;
	vec4 sunlightDirection; //w for sun power
	vec4 sunlightColor; //alpha for shadow blend, 0 to disable shadows
	mat4 sunlightShadowMatrix;
} sceneData;


//layout(set = 0, binding = 2) uniform sampler2DShadow  shadowSampler;
#define SHADOW_FACTOR 0.1

layout(set = 2, binding = 0) uniform sampler2D tex1;

void main() 
{
/*
	vec3 color = texture(tex1,texCoord).xyz;

	float lightAngle = clamp(dot(inNormal, -sceneData.sunlightDirection.xyz),0.f,1.f);

	vec3 lightColor = sceneData.sunlightColor.xyz * lightAngle;
	vec3 ambient = color * sceneData.ambientColor.xyz;
	vec3 diffuse = lightColor * color;

	outFragColor = vec4(diffuse+ ambient,1.0);
*/

	vec3 N = normalize(inNormal);
	vec3 L = normalize(inLightVec);
	vec3 V = normalize(inViewVec);
	vec3 R = reflect(-L, N);
	vec3 ambient = texture(tex1,texCoord).xyz;
	vec3 diffuse = max(dot(N, L), 0.0) * vec3(1.0);
	vec3 specular = pow(max(dot(R, V), 0.0), 16.0) * vec3(0.75);

    float height = inColor.x;
    float hfrac = inColor.y;

    uint hi = uint(round(inColor.z));
    
    vec3 color = 
        mix(
			mix(vec3(0.0,0.0,0.1), vec3(0.0,0.25,0.5), hfrac),
            mix( vec3(mix(0.1,0.4,hfrac),mix(0.3,0.8,hfrac),mix(0.1,0.4,hfrac)), vec3(mix(0.4,1.0,hfrac),mix(0.8,1.0,hfrac),mix(0.4,1.0,hfrac)), hi),
            uint(height > 0)
        );
    outFragColor = vec4((ambient + diffuse) * color, 1.0);
}