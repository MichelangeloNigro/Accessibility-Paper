Shader "Unlit/BlackAndWhite"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _LineThickness ("Line thickness", float) = 0.001
        _LineColor ("Line Color", Color) = (1,1,1,1)
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

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _LineColor;
            float _LineThickness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float cutLevel = (_SinTime.w + 1) / 2;
                if(i.uv.x < cutLevel - _LineThickness)
                {
                    return col;
                }
                if(i.uv.x > cutLevel + _LineThickness)
                {
                    float mid = (col.x + col.y + col.z) / 3;
                    return fixed4(mid, mid, mid, 1);
                }
                return _LineColor;
            }
            ENDCG
        }
    }
}
