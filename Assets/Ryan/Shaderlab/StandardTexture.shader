Shader "Ryan/StandardTexture"
{
    Properties
    {
        _TintColor ("Tint Color", Color) = (1, 1, 1, 1)
        _Texture ("Texture", 2D) = "white" {}
        _SpeccColor ("Specular Color", Color) = (1,1,1,1)
        _Gloss ("Glossiness", Range(0.0, 1.0)) = 0.5
    }
    SubShader
    {
           CGPROGRAM

           #pragma surface surf BlinnPhong

           sampler2D _Texture;
           float4 _TintColor;
           fixed4 _SpeccColor;
           float _Gloss;
           
           struct Input
           {
               float2 uv_Texture;
           };

           void surf(Input IN, inout SurfaceOutput o)
           {
               o.Albedo = tex2D(_Texture, IN.uv_Texture).rgb*_TintColor.rgb;
               o.Specular = _SpecColor.rgb;
               o.Gloss = _Gloss;
           }
           
           ENDCG
    }
    Fallback "Diffuse"
}