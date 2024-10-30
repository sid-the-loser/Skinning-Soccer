Shader "Ryan/StandardTexture"
{
    Properties
    {
        _TintColor ("Tint Color", Color) = (1, 1, 1, 1)
        _Texture ("Texture", 2D) = "white" {}
    }
    SubShader
    {
           CGPROGRAM

           #pragma surface surf Lambert

           sampler2D _Texture;
           float4 _TintColor;
           
           struct Input
           {
               float2 uv_Texture;
           };

           void surf(Input IN, inout SurfaceOutput o)
           {
               o.Albedo = tex2D(_Texture, IN.uv_Texture).rgb*_TintColor.rgb;
           }
           
           ENDCG
    }
    Fallback "Diffuse"
}