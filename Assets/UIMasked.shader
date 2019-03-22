Shader "IndieYP/UIMasked"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite", 2D) = "white" {}
		_MainColor("Tint", Color) = (1,1,1,1)
	}

		SubShader
		{
			Tags
		{
			"Queue" = "Transparent+2"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"CanUseSpriteAtlas" = "True"
		}

			Cull Off
			Lighting Off
			ZWrite Off
			Fog
			{
				Mode Off
			}
			Blend One SrcAlpha
			Pass
	{

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			fixed4 _MainColor;
			sampler2D _MainTex;

			struct v2f 
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			float4 _MainTex_ST;

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 texcol = tex2D(_MainTex, i.uv);
				return texcol * _MainColor;
			}
			ENDCG
			}
	}

}