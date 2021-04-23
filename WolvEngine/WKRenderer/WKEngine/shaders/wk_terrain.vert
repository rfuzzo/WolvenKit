#version 460

layout (location = 0) in vec3 vPosition;
layout (location = 1) in vec3 vNormal;
layout (location = 2) in vec3 vColor;
layout (location = 3) in vec2 vTexCoord;

layout (location = 0) out vec3 outNormal;
layout (location = 1) out vec4 outUV;

layout(set = 0, binding = 0) uniform  CameraBuffer{   
    mat4 view;
    mat4 proj;
	mat4 viewproj; 
} cameraData;

struct ObjectData{
	mat4 model;
}; 

//all object matrices
layout(std140,set = 1, binding = 0) readonly buffer ObjectBuffer{   

	ObjectData objects[];
} objectBuffer;

//push constants block
layout( push_constant ) uniform constants
{
    mat4 render_matrix;
} PushConstants;

void main() 
{	
	gl_Position = cameraData.proj * cameraData.view * PushConstants.render_matrix * vec4(vPosition, 1.0f);

	//outNormal = vNormal;
	outNormal = -normalize(transpose(inverse(mat3(cameraData.view * PushConstants.render_matrix))) * vNormal);

	//outUV.xy = vTexCoord.xy;
	outUV.y = vPosition.z;
	outUV.zw = vColor.xy;
}
