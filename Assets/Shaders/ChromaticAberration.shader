Shader "Custom/ChromaticAberration" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
	}
		SubShader
	{
		Pass
	{

		CGPROGRAM
		#pragma vertex vert_img
		#pragma fragment frag
		#pragma fragmentoption ARB_precision_hint_fastest
		#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
		uniform float _AberrationOffsetRedX;
		uniform float _AberrationOffsetRedY;
		uniform float _AberrationOffsetGreenX;
		uniform float _AberrationOffsetGreenY;
		uniform float _AberrationOffsetBlueX;
		uniform float _AberrationOffsetBlueY;

		float4 frag(v2f_img i) : COLOR
		{

			float2 coords = i.uv.xy;

			_AberrationOffsetRedX /= 360.0f;
			_AberrationOffsetRedY /= 360.0f;
			_AberrationOffsetGreenX /= 360.0f;
			_AberrationOffsetGreenY /= 360.0f;
			_AberrationOffsetBlueX /= 360.0f;
			_AberrationOffsetBlueY /= 360.0f;

			//Red Channel
			float2 redCoords = coords.xy;
			redCoords.x = redCoords.x - _AberrationOffsetRedX;
			redCoords.y = redCoords.y + _AberrationOffsetRedY;
			float4 red = tex2D(_MainTex , redCoords);
			//Green Channel
			float2 greenCoords = coords.xy;
			greenCoords.x = greenCoords.x - _AberrationOffsetGreenX;
			greenCoords.y = greenCoords.y + _AberrationOffsetGreenY;
			float4 green = tex2D(_MainTex, greenCoords);
			//Blue Channel
			float2 blueCoords = coords.xy;
			blueCoords.x = blueCoords.x - _AberrationOffsetBlueX;
			blueCoords.y = blueCoords.y + _AberrationOffsetBlueY;
			float4 blue = tex2D(_MainTex, blueCoords);

			float4 finalColor = float4(red.r, green.g, blue.b, 1.0f);
			return finalColor;

		}

		ENDCG

		}
	}
}