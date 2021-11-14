//https://forum.unity3d.com/threads/invert-colors-shader.205244/#post-2200398

Shader "Custom/AlterShape" {
	Properties
	{
		_Color("Tint Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white"{}
	}



		SubShader
	{
		Tags{ "Queue" = "Transparent" }

		Pass
	{
		ZWrite On
		ColorMask 0
	}



		Pass
	{
		Blend OneMinusDstColor OneMinusSrcColor //invert blending, so long as FG color is 1,1,1,1
		BlendOp Add
		SetTexture[_MainTex]
	{
		constantColor[_Color]
		combine texture * constant
	}
	}

	}//end subshader
}//end shader