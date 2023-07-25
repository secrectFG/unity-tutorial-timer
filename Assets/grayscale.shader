Shader "Custom/grayscale"
{
     Properties
    {
        [HideInInspector] _MainTex ("Texture", 2D) = "white" {}
        _Brightness ("Brightness", Range(-1,1)) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
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
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Brightness;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                //取出纹理颜色
                fixed4 col = tex2D(_MainTex, i.uv);
                //转换为灰度
                float grayscale = dot(col.rgb, fixed3(0.299, 0.587, 0.114));
                //调整亮度
                grayscale += _Brightness;
                //返回去色并调整亮度后的颜色，保持原图的透明度
                return fixed4(grayscale, grayscale, grayscale, col.a);
            }
            ENDCG
        }
    }
}
