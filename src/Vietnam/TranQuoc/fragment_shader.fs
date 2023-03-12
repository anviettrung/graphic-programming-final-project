#version 330 core
out vec4 FragColor;

in vec3 Normal;  
in vec3 FragPos;
in vec2 TexCoords;

uniform vec3 lightPos; 
uniform vec3 lightColor;
uniform vec3 objectColor;

uniform vec3 sunDirection; 
uniform float sunIntensity;
uniform vec3 skyColor;

uniform sampler2D texture_diffuse1;

void main()
{    
    // ambient
    // float ambientStrength = 0.1;
    // vec3 ambient = ambientStrength * lightColor;

    // diffuse 
    vec3 norm = normalize(Normal);
  	float intensity = max(dot(norm, sunDirection), 0.0);
    vec3 lightColor = vec3(sunIntensity, sunIntensity, sunIntensity);
    vec3 finalColor = skyColor + lightColor * intensity;
    vec4 texColor = texture(texture_diffuse1, TexCoords);

    FragColor = vec4(finalColor * texColor.rgb, texColor.a);;

    // vec3 lightDir = normalize(lightPos - FragPos);
    // float diff = max(dot(norm, lightDir), 0.0);
    // vec3 diffuse = min(diff, 0.5) * lightColor;     
    // vec3 result = ambient + diffuse;

    
}