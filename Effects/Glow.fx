sampler2D screenTexture : register(s0);

float globalTime;      // passed from C#
float glowStrength;    // 0–1 range
float glowSpeed;       // animation speed
float4 glowColor;      // RGB = glow tint

float4 PixelShaderFunction(float4 color : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    // Sample base texture
    float4 baseColor = tex2D(screenTexture, coords);

    // Create animated pulse (0 → 1)
    float pulse = sin(globalTime * glowSpeed) * 0.5 + 0.5;

    // Compute glow intensity
    float glow = pulse * glowStrength;

    // Add glow tint
    baseColor.rgb += glowColor.rgb * glow;

    // Prevent overbright blowout
    baseColor.rgb = saturate(baseColor.rgb);

    return baseColor * color;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}