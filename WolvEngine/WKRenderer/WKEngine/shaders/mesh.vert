#version 450

layout (location = 0) in vec3 inPos;
layout (location = 1) in vec3 inNormal;
layout (location = 2) in vec2 inUV;
layout (location = 3) in vec4 inTangent;

layout (binding = 0) uniform UBO 
{
	mat4 projection;
	mat4 model;
	mat4 normal;
	mat4 view;
	vec4 lightPos;
	vec4 viewPos;
} uboScene;

layout(push_constant) uniform PushConsts {
	mat4 model;
} primitive;

layout (location = 0) out vec2 outUV;
layout (location = 1) out vec3 outNormal;
layout (location = 2) out vec3 outEyePos;
layout (location = 3) out vec3 outViewVec;
layout (location = 4) out vec3 outLightVec;
layout (location = 5) out vec4 outTangent;

void main() 
{
	outNormal = normalize(transpose(inverse(mat3(uboScene.view * primitive.model))) * inNormal);
	outUV = inUV;
	outTangent = inTangent;

	gl_Position = uboScene.projection * uboScene.view * primitive.model * vec4(inPos,1.0);	

	vec4 pos = uboScene.view * vec4(inPos, 1.0);
	vec3 lPos = mat3(uboScene.view) * uboScene.lightPos.xyz;
	outLightVec = lPos - pos.xyz;
	outViewVec = -pos.xyz;

	//outEyePos = vec3(uboScene.projection * uboScene.view * primitive.model * vec4(uboScene.viewPos.xyz,1.0));
	//vec4 lightPos = uboScene.projection * uboScene.view * primitive.model * uboScene.lightPos;
	//outLightVec = normalize(lightPos.xyz - outEyePos);
}
