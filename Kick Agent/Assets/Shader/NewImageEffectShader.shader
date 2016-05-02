Shader "Custom/NewImageEffectShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_CloudTex ("Texture",2D) = "white" {}
		_Color ("Main color", Color) =  (1,1,1,0)
		_Radius("Circle radius",Float ) = 0
		_Opacity("Opacity", float) = 0

	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha

		Tags{"Queue" = "Transparent" "RenderType" = "Transparent"}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
//			#pragma fragment2 frag2
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;

//
//				float2 mn : TEXTCOORD0;
			
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
					float elevation : TEXCOORD1;

//					float2 mn : TEXTCOORD0;


			};

			v2f vert (appdata v)
			{
				float4 position = v.vertex;
//				float elevation = sin(_Time * 100.0 + v.vertex.x *20 + v.vertex.z * 30) ;
//				position.y += elevation;

				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, position);
				o.uv = v.uv;

//				o.elevation = elevation * 0.5 + 0.5;
				return o;

//				float4 position2 = n.vertex;
//
//				v2f q;
//				q.vertex = mul(UNITY_MATRIX_MVP, position2);
//				q.mn = n.mn
//				return q;
			}
			
			sampler2D _MainTex;
			sampler2D _CloudTex;
			uniform float4 _Color;
			uniform float _Radius;
			uniform float _Opacity;

			fixed4 frag (v2f i) : SV_Target
			{

			// FIRST TEST 
				float x = i.uv.x - 0.35f;
				float y = i.uv.y - 0.65f;
				float r2 = x*x + y*y;
				float r = sqrt(r2);
//
//
				if(r<_Radius)
					return tex2D(_MainTex, i.uv);
				return fixed4(0,0,0,0);


			
// 			SMOOTHING REBORD DU CERCLE 
//			float x = i.uv.x - 0.5f;
//				float y = i.uv.y - 0.5f;
//				float r2 = x*x + y*y;
//				float r = sqrt(r2);
//
//				float level = smoothstep (0.4, 0.5,r);
//				return fixed4(level, level, level, 1);


				//Opacity qui change
			fixed4 color = tex2D(_MainTex, i.uv);
			float opacity = tex2D(_CloudTex, i.uv).r;
			color.a = opacity + _Opacity;
			return color;


		// VAGUE colorée
//		return lerp(
//			fixed4(0,1,0,1),
//			fixed4(1,0,0,1),
//			i.elevation 
//			);
			}
			ENDCG
		}
	}
}
