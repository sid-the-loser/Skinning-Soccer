// Written by Sidharth S, referenced from Canvas

// This shader is for toon shading and color grading. It makes its own lighting system to make the sharp shade changes-
// the toon shading possible!

Shader "Sid/ToonShaderWOutline"
{
    Properties
    {
        _MainTex ("Albedo Texture", 2D) = "white" {} 
        _RampTex ("Ramp Texture", 2D) = "white" {} // texture that we will be using as the shadow
        _ColorTint ("Color Tint", Color) = (1, 1, 1, 1) // displays a color selector in unity editor
        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 0)
        _Outline ("Outline Width", Range(0.002, 1)) = 0.005
    }
    SubShader
    {
        
        CGPROGRAM

        #pragma surface surf ToonRamp

        float4 _Color; // getting the color from properties 
        float4 _ColorTint; // getting the color tint from properties
        sampler2D _RampTex; // getting the ramp texture from properties
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex; // Gets the uv of the player texture (however, we are not using this at all in this-
                               // shader)
        };

        float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed atten) // defining our custom toon shader-
                                                                               // lighting
        {
            float diff = dot(s.Normal, lightDir); // gets the dot product between the normal of the surface of the-
                                                  // object and the direction of the light
            float2 rh = diff * 0.5 + 0.5; // gets a uv value that will be taken from the ramp texture and used to blend-
                                          // the color of the object to look shaded
            float3 ramp = tex2D(_RampTex, rh).rgb; // gets the particular uv from the ramp texture and stores it in-
                                                   // "ramp"

            float4 c; // c is used to keep track of the color of the pixel on the object surface
            c.rgb = s.Albedo * _LightColor0.rgb * ramp; // all of the values are blended together to form the final-
                                                        // pixel color
            c.a = s.Alpha; // the alpha is set directly from the surface
            return c;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _ColorTint.rgb; // The albedo/diffuse color of the surface is set to the value we-
                                                    // get from properties and the tint color is multiplied to it to-
                                                    // add the tint/color grading effect
        }
        
        ENDCG

        Pass {
            Cull Front

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };

            float _Outline;
            float4 _OutlineColor;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
                float2 offset = TransformViewToProjection(norm.xy);

                o.pos.xy += offset * o.pos.z * _Outline;
                o.color = _OutlineColor;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                return i.color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse" // fallback, in case something breaks in the shader that we wrote
}