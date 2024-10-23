Shader "Sid/DefaultColor"
{
    Properties
    {
        _albedoColor ("Albedo Color", Color) = (0, 1, 1, 1)
    }
    SubShader
    {
        CGPROGRAM

        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_MainTex;
        };

        float4 _albedoColor;

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _albedoColor.rgb;
        }
        
        ENDCG
    }
    Fallback "Diffuse"
}