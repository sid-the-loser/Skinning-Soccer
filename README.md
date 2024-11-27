# Skinning-Soccer

> **Note:**
> This documentation is old and is for `cg1.0.0` the latest version is `cg2.0.0`, the documentation for it shall be done soon!

Assignment done by: Sidharth Suresh (100938544) and Ryan Cheng (100920050)

[Assignment 1 Video](https://youtu.be/IbArj4pltgk)

# Heres the explanation of all the shaders:
## `DefaultColor.shader`
```c
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
```

This shader uses a color and applies it to the albedo of the surface of the object.
This was mainly used for basic objects that didn't require much detail.

## `StandardTexture.shader`
```c
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
```
This shader was used to give object's surface a texture, which is an image file that is passed through the albedo and is given a tint as well.
This was used for most objects in the game since they all needed unique textures to identify them.

## `ToonShader.shader`
```c
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
```
This shader replaces the lighting on the surface of the object and uses a ramp texture instead.
This was only used on the ball as a skin that you can equip.

## `Hologram.shader`
```c
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
```
This shader combines both rim shading at the same time makes the objects surface of the object away from the rims more transparent, thereby giving the object a hologram look.
This was only used on the ball and the players as a skin that you can equip.

# External Assets
The textures for the materials taken from: [https://3dtextures.me/](https://3dtextures.me/) & [https://www.kenney.nl/assets/voxel-pack](https://www.kenney.nl/assets/voxel-pack)
