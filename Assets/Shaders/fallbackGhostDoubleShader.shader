Shader "Custom/FallbackGhostDoubleShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Texture2("Other Texture", 2D) = "white" {}
		_BumpMap("Normal Map", 2D) = "bump" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Scale("Scale", Float) = 2.0
		_SpotAngle("Spot Angle", Float) = 60.0
		_Range("Range", Float) = 20
		_Contrast("Contrast", Range(20.0, 80.0)) = 50.0
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows vertex:vert

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _BumpMap;
			sampler2D _Texture2;

			struct Input {
				float3 coords;
				float3 normal;
				float2 uv_MainTex;
				float3 worldPos;
			};

			half _Glossiness;
			half _Metallic;
			half _Scale;
			fixed4 _Color;

			uniform float4 _LightPos; // light world position - set via script
			uniform float4 _LightDir; // light world direction - set via script
			uniform float _LightInt; // light world direction - set via script
			uniform float _SpotAngle; // spotlight angle
			uniform float _Range; // spotlight range
			uniform float _Contrast; // adjusts contrast

			void vert(inout appdata_full v, out Input o) {
				UNITY_INITIALIZE_OUTPUT(Input, o);
				o.coords = mul(unity_ObjectToWorld, v.vertex) * _Scale;
				o.normal = mul((float3x3)unity_ObjectToWorld, v.normal);
			}

			void surf(Input IN, inout SurfaceOutputStandard o) {
				o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));

				fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
				fixed4 c2 = tex2D(_Texture2, IN.uv_MainTex);

				float3 lightDir = IN.worldPos - _LightPos.xyz;
				float dist = saturate(1 - (length(lightDir) / _Range)); // get distance factor
				float cosLightDir = dot(normalize(lightDir), normalize(_LightDir)); // get light angle
				float ang = cosLightDir - cos(radians(_SpotAngle / 2)); // calculate angle factor
				float back = saturate(-dot(lightDir, IN.normal));
				float alpha = saturate(dist * ang * _Contrast * back * _LightInt); // combine distance, angle and contrast

				o.Albedo = lerp(c, c2, alpha).rgb;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}