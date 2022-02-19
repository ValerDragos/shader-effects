Shader "VGD/TV Static"
{
    Properties
    {
        _XMultiplier("X Multiplier", float) = 1.2     // Got good results
        _YMultiplier("Y Multiplier", float) = 17.24   // with these values.
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Random.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float _XMultiplier;
            float _YMultiplier;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float seed = i.vertex.x * _XMultiplier + i.vertex.y * _YMultiplier;
                float random = GetRandom(1, seed);
                return fixed4(random, random, random, 1);
            }

            ENDCG
        }
    }
}
