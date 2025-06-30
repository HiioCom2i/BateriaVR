Shader "Custom/CilindroShader"
{
    Properties
    {
        _TopColor ("Top Color", Color) = (1,0,0,1)  // Vermelho
        _SideColor ("Side Color", Color) = (0,0,1,1)  // Azul
        _Shininess ("Shininess", Range(0, 1)) = 0.5   // Controla o brilho
        _AmbientLight ("Ambient Light", Color) = (0.1, 0.1, 0.1, 1)  // Luz ambiente mais suave
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            float4 _TopColor;
            float4 _SideColor;
            float _Shininess;
            float4 _AmbientLight;  // Luz ambiente

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz; // Posição no mundo
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Definir a cor base
                fixed4 color = (abs(i.normal.y) > 0.9) ? _TopColor : _SideColor;

                // Calcular iluminação difusa
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz); // Direção da luz
                float diff = max(0, dot(i.normal, lightDir)); // Cálculo de iluminação difusa
                fixed4 litColor = color * diff;

                // Adicionar luz ambiente suavizada apenas onde não há luz direta
                // Isso ajuda a evitar que as áreas sombreadas fiquem cinza ou escuras demais
                litColor += _AmbientLight * (1 - diff);

                // Efeito de brilho (specular)
                float3 viewDir = normalize(_WorldSpaceCameraPos - i.worldPos); // Direção da câmera
                float3 reflectDir = reflect(-lightDir, i.normal); // Reflexão da luz
                float spec = pow(max(dot(viewDir, reflectDir), 0.0), 16.0); // Brilho
                fixed4 specColor = fixed4(1, 1, 1, 1) * spec * _Shininess; // Brilho ajustado

                // Combina iluminação difusa e brilho, retornando o valor final
                return litColor + specColor;
            }
            ENDCG
        }
    }
}
