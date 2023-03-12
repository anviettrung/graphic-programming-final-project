#version 330 core
out vec4 FragColor;

in vec3 Normal;  
in vec3 FragPos;
in vec2 TexCoords;

uniform vec3 lightPos; 
uniform vec3 lightColor;
uniform vec3 objectColor;

uniform sampler2D texture_diffuse1;

void main()
{    
    // ambient
    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;
  	
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = min(diff, 0.5) * lightColor;
            
    // vec3 result = ambient + diffuse;

    FragColor = vec4(diffuse, 1.0) * texture(texture_diffuse1, TexCoords);
}