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

/*
layout(set = 0, binding = 2) uniform sampler2DShadow  shadowSampler;
#define SHADOW_FACTOR 0.1

float textureProj(vec4 P, vec2 offset)
{
	float shadow = 1.0;
	vec4 shadowCoord = P / P.w;
	shadowCoord.st = shadowCoord.st * 0.5 + 0.5;
	
	if (shadowCoord.z > -1.0 && shadowCoord.z < 1.0) 
	{
		vec3 sc = vec3(vec2(shadowCoord.st + offset),shadowCoord.z);
		shadow =  texture(shadowSampler, sc);		
	}
	return shadow;
}
// 9 imad (+ 6 iops with final shuffle)
uvec3 pcg3d(uvec3 v) {

    v = v * 1664525u + 1013904223u;

    v.x += v.y*v.z;
    v.y += v.z*v.x;
    v.z += v.x*v.y;

    v ^= v >> 16u;

    v.x += v.y*v.z;
    v.y += v.z*v.x;
    v.z += v.x*v.y;

    return v;
}

float filterPCF(vec4 sc)
{
	ivec2 texDim = textureSize(shadowSampler, 0);
	float scale = 2;
	float dx = scale * 1.0 / float(texDim.x);
	float dy = scale * 1.0 / float(texDim.y);

	float shadowFactor = 0.0;
	int count = 0;
	int range = 2;

	vec2 s = gl_FragCoord.xy;
	
	uvec4 u = uvec4(s, uint(s.x) ^ uint(s.y), uint(s.x) + uint(s.y));
    vec3 rand = pcg3d(u.xyz);//vec3(1,0,0);//
	rand = normalize(rand);


	//sc.x += dx * rand.z;
    //sc.y += dy * rand.y;
	vec2 dirA = normalize(rand.xy);
	vec2 dirB = normalize(vec2(-dirA.y,dirA.x));
	
	dirA *= dx;
	dirB *= dy;
	for (int x = -range; x <= range; x++)
	{
		for (int y = -range; y <= range; y++)
		{
			shadowFactor += textureProj(sc,dirA*x + dirB*y);
			count++;
		}	
	}
	return shadowFactor / count;

}
*/

layout(set = 2, binding = 0) uniform sampler2D tex1;

void main() 
{
	vec3 color = texture(tex1,texCoord).xyz;

	vec3 N = normalize(inNormal);
	vec3 L = normalize(inLightVec);
	vec3 V = normalize(inViewVec);
	vec3 R = reflect(-L, N);
	vec3 ambient = vec3(0.1);
	vec3 diffuse = max(dot(N, L), 0.0) * color;
	vec3 specular = pow(max(dot(R, V), 0.0), 16.0) * vec3(0.75);

	//outFragColor = vec4((ambient + diffuse) * sceneData.sunlightColor.xyz + specular, 1.0);		
	outFragColor = vec4(diffuse,1.0);
	
}