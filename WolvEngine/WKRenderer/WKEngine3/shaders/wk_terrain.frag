//glsl version 4.5
#version 450

layout (location = 0) in vec3 inNormal;
layout (location = 1) in vec3 inColor;
layout (location = 2) in vec3 inViewVec;
layout (location = 3) in vec3 inLightVec;

layout (location = 0) out vec4 outFragColor;

void main() 
{
	vec3 N = normalize(inNormal);
	vec3 L = normalize(inLightVec);
	vec3 V = normalize(inViewVec);
	vec3 R = reflect(-L, N);
	vec3 ambient = vec3(0.1);
	vec3 diffuse = max(dot(N, L), 0.0) * vec3(1.0);
	vec3 specular = pow(max(dot(R, V), 0.0), 16.0) * vec3(0.75);

    float height = inColor.x;
    float hfrac = inColor.y;
    uint hi = uint(round(inColor.z));
    
    vec3 color = 
        mix(
            vec3(0.18,0.827,0.85),
            mix( vec3(mix(0.1,0.4,hfrac),mix(0.3,0.8,hfrac),mix(0.1,0.4,hfrac)), vec3(mix(0.4,1.0,hfrac),mix(0.8,1.0,hfrac),mix(0.4,1.0,hfrac)), hi),
            uint(height > 0)
        );
    outFragColor = vec4((ambient + diffuse) * color, 1.0);
}