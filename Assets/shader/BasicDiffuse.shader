Shader "CookBookShaders/BasicDiffuse" {
	Properties {

		_EmissiveColor ("Emissive Color",color)=(1,1,1,1)
		_AmbientColor ("Ambient Color",color)=(1,1,1,1)
		_MySliderValue ("this is a slider",Range(0,10))=2.5

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
//		#pragma surface surf Standard fullforwardshadows
		
		// Use shader model 3.0 target, to get nicer looking lighting
//		#pragma target 3.0

		#pragma surface surf BasicDiffuse

		float4 _EmissiveColor;
		float4 _AmbientColor;
		float4 _MySliderValue;


		struct Input {
			float2 uv_MainTex;
		};

//		inline float4 LightingBasicDiffuse(SurfaceOutput s,fixed3 lightDir,fixed atten)
//		{
//			float diflight=max(0,dot(s.Normal,lightDir));
//
//			float4 col;
//			col.rgb=s.Albedo* _LightColor0.rgb*(difLight*atten*2);
//			col.a=s.Alpha;
//			return col;
//		}




		void surf (Input IN, inout SurfaceOutput o) {

			float4 c;
			c=pow((_EmissiveColor+_AmbientColor),_MySliderValue);
			o.Albedo=c.rgb;
			o.Alpha=c.a;

		
		}

		inline float4 LightingBasicDiffuse(SurfaceOutput s,fixed3 lightDir,fixed atten){
			float difLight=max(0,dot(s.Normal,lightDir));

			float4 col;
			col.rgb=s.Albedo*_LightColor0.rgb*(difLight*atten*2);
			col.a=s.Alpha;
			return col;
		}

		ENDCG
	}
	FallBack "Diffuse"
}
