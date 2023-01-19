Shader "Unlit/Finish"
{
    Properties
    {
        NoiseTex ("Noise Texture", 2D) = "gray" {}
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 normal : TEXCOORD1;
            };
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = v.normal;
                return o;
            }

            sampler2D NoiseTex;
            fixed4 frag (v2f i) : SV_Target
            {
                float noise = float4(tex2D(NoiseTex, i.uv * float2(1, 0.2) + float2(1, 0) * _Time.y / 5).rgb, 0.6);
                float noise2 = float4(tex2D(NoiseTex, i.uv * float2(1, 0.1) + float2(0.5, 0.5) * _Time.y / 5).rgb, 0.6);
                noise *= noise2 * 2.6;
                float gradient = 1.3 - i.uv.y * 2;

                return float4(1,1,0,saturate(gradient + noise) * 0.7 * (1 - abs(i.normal.y)));
            }
            ENDCG
        }
    }
}
