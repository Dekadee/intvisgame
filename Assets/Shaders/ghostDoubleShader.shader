Shader "Custom/ghostDoubleShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}	
		_Texture2("Albedo 2(RGB)", 2D) = "white" {}
		_BumpMap("Bump Map", 2D) = "bump" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.0
		_Metallic("Metallic", Range(0,1)) = 0.0
		_SpotAngle("Spot Angle", Float) = 60.0
		_Range("Range", Float) = 20
		_Contrast("Contrast", Range(20.0, 80.0)) = 50.0
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
//#pragma enable_d3d11_debug_symbols
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows vertex:vert//alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0


	struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
		float3 worldPos;
		float3 normal;
	};

	void vert(inout appdata_full v, out Input o) {
		UNITY_INITIALIZE_OUTPUT(Input, o);
		o.normal = mul((float3x3)unity_ObjectToWorld, v.normal);
	}

	sampler2D _MainTex;
	sampler2D _BumpMap;
	sampler2D _Texture2;

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;
	uniform float4 _LightPos; // light world position - set via script
	uniform float4 _LightDir; // light world direction - set via script
	uniform float _LightInt; // light world direction - set via script
	uniform float _SpotAngle; // spotlight angle
	uniform float _Range; // spotlight range
	uniform float _Contrast; // adjusts contrast
	
							 // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
							 // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
							 // #pragma instancing_options assumeuniformscaling
	UNITY_INSTANCING_BUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

	void surf(Input IN, inout SurfaceOutputStandard o) {
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));

		float3 lightDir = IN.worldPos - _LightPos.xyz;
		half dist = saturate(1 - (length(lightDir) / _Range)); // get distance factor
		half cosLightDir = dot(normalize(lightDir), normalize(_LightDir)); // get light angle
		half ang = cosLightDir - cos(radians(_SpotAngle / 2)); // calculate angle factor
		half back = saturate(-dot(lightDir, IN.normal));
		half alpha = saturate(dist * ang * _Contrast * back * _LightInt); // combine distance, angle and contrast
																		  // Albedo comes from a texture tinted by color
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		fixed4 c2 = tex2D(_Texture2, IN.uv_MainTex) * _Color;
		o.Albedo = lerp(c, c2, alpha).rgb;
		
		// Metallic and smoothness come from slider variables
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		o.Alpha = 1.;
	}
	ENDCG
	}
		FallBack "Diffuse"
}
