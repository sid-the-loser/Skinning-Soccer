Shader "Ryan/DefaultColorAmbientLighting"
{
     Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _AmbientIntensity ("Ambient Intensity", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            fixed4 _Color;
            float _AmbientIntensity;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return fixed4(_Color.rgb * _AmbientIntensity, _Color.a);
            }
            ENDCG
        }
    }
}