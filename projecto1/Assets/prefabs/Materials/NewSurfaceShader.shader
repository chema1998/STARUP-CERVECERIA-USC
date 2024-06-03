Shader "Custom/BeerShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Color ("Base Color", Color) = (1, 0.76, 0.3, 1)
        _FresnelColor ("Fresnel Color", Color) = (1, 1, 1, 1)
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5
        _Metallic ("Metallic", Range(0, 1)) = 0.0
        _Alpha ("Alpha", Range(0, 1)) = 0.5
        _FresnelPower ("Fresnel Power", Range(1, 5)) = 2
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard alpha:fade

        sampler2D _MainTex;
        sampler2D _NormalMap;
        fixed4 _Color;
        fixed4 _FresnelColor;
        half _Smoothness;
        half _Metallic;
        half _Alpha;
        half _FresnelPower;

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Base color
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

            // Normal mapping
            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));

            // Smoothness and metallic
            o.Smoothness = _Smoothness;
            o.Metallic = _Metallic;

            // Fresnel effect
            float fresnel = pow(1.0 - dot(normalize(IN.viewDir), o.Normal), _FresnelPower);
            fixed4 fresnelEffect = _FresnelColor * fresnel;

            o.Albedo += fresnelEffect.rgb;

            // Alpha
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Transparent/Diffuse"
}
