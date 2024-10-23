Shader "Sid/HologramShader"
{
    Properties
    {
        _hologramColor ("Hologram Color", Color) = (0, 0.5, 0.5, 0.0)
        _hologramPower ("Hologram Power", Range(0.5, 0.8)) = 0.3
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
        }
        
        Pass
        {
            ZWrite On
            ColorMask 0
        }
        
        CGPROGRAM

        #pragma surface surf Lambert alpha:fade

        struct Input
        {
            float3 viewDir;
        };

        float4 _hologramColor;
        float _hologramPower;

        void surf(Input IN, inout SurfaceOutput o)
        {
            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
            o.Emission = _hologramColor.rgb * pow(rim, _hologramPower) * 10;
            o.Alpha = pow(rim, _hologramPower);
        }

        ENDCG
    }
    Fallback "Diffuse"
}