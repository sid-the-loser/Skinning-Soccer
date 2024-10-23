Shader "Sid/ToonShader"
{
    Properties
    {
        _albedoColor ("Albedo Color", Color) = (1, 1, 1, 1)
        _rampTexture ("Ramp Texture", 2D) = "white" {}
    }
    SubShader
    {
        CGPROGRAM

        #pragma surface surf ToonRamp

        float4 _albedoColor;
        sampler2D _rampTexture;

        struct Input
        {
            float2 uv_MainTex;
        };

        float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            float diff = dot(s.Normal, lightDir);
            float h = diff * 0.5 + 0.5;
            float2 rh = h;
            float3 ramp = tex2D(_rampTexture, rh).rgb;

            float4 c;
            c.rgb = s.Albedo * _LightColor0 * ramp;
            c.a = s.Alpha;
            return c;
        }
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _albedoColor.rgb;
        }
        
        ENDCG
    }
    Fallback "Diffuse"
}