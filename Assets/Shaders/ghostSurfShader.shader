Shader "Custom/ghostSurfShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.0
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_SpotAngle("Spot Angle", Float) = 60.0
		_Range("Range", Float) = 20
		_Contrast("Contrast", Range(20.0, 80.0)) = 50.0
	}
	SubShader {
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True"}
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float3 worldNormal;
		};

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

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float3 lightDir = IN.worldPos - _LightPos.xyz;
			half dist = saturate(1 - (length(lightDir) / _Range)); // get distance factor
			half cosLightDir = dot(normalize(lightDir), normalize(_LightDir)); // get light angle
			half ang = cosLightDir - cos(radians(_SpotAngle / 2)); // calculate angle factor
			half back = saturate(-dot(lightDir, IN.worldNormal));
			half alpha = saturate(dist * ang * _Contrast * back * _LightInt); // combine distance, angle and contrast
			
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = alpha * c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
