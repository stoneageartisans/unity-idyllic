Shader "Unlit/TransparentScrolling"
{
	Properties
	{
	    _MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	    _ScrollSpeedX("X Scroll Speed", Range(-100, 100)) = 0
    	_ScrollSpeedY("Y Scroll Speed", Range(-100, 100)) = 0
	}

	SubShader {
	    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	    LOD 100

	    ZWrite Off
	    Blend SrcAlpha OneMinusSrcAlpha

	    Pass
	    {
	        CGPROGRAM
	            #pragma vertex vert
	            #pragma fragment frag
	            #pragma target 2.0
	            #pragma multi_compile_fog

	            #include "UnityCG.cginc"

	            struct appdata_t
	            {
	                float4 vertex : POSITION;
	                float2 texcoord : TEXCOORD0;
	                UNITY_VERTEX_INPUT_INSTANCE_ID
	            };

	            struct v2f
	            {
	                float4 vertex : SV_POSITION;
	                float2 texcoord : TEXCOORD0;
	                UNITY_FOG_COORDS(1)
	                UNITY_VERTEX_OUTPUT_STEREO
	            };

	            sampler2D _MainTex;
	            float4 _MainTex_ST;
	            fixed _ScrollSpeedX;
        		fixed _ScrollSpeedY;

	            v2f vert(appdata_t v)
	            {
	                v2f o;
	                UNITY_SETUP_INSTANCE_ID(v);
	                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
	                o.vertex = UnityObjectToClipPos(v.vertex);
	                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
	                UNITY_TRANSFER_FOG(o,o.vertex);
	                return o;
	            }

	            fixed4 frag(v2f i) : SV_Target
	            {
	            	fixed2 uvTexCoord = i.texcoord;
            		fixed scrollValueX = _ScrollSpeedX * _Time;
            		fixed scrollValueY = _ScrollSpeedY * _Time;
            		uvTexCoord += fixed2(scrollValueX, scrollValueY);
	                fixed4 col = tex2D(_MainTex, uvTexCoord);
	                UNITY_APPLY_FOG(i.fogCoord, col);
	                return col;
	            }
	        ENDCG
	    }
	}
}
