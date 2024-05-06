Shader "Molkang/SimpleTextureShader"
{
    Properties
    {
        // 미리 만들어져 있는 프로퍼티를 사용하면 간편하게 작성 할 수 있다.
        // 2D 라는 것을 지정하고 기본색을 하얀색으로 한다.
        _BaseMap("Base Map", 2D) = "white"
    }
    SubShader
    {
        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            Texture2D _BaseMap;
            SamplerState sampler_BaseMap;

            struct VertexInput 
            {
                float3 position : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct FragmentInput
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            FragmentInput vert(VertexInput input)
            {
                FragmentInput output;
                output.position = TransformObjectToHClip(input.position);
                output.uv = input.uv;

                return output;
            }

            half4 frag(FragmentInput input) : SV_Target
            {
                return _BaseMap.Sample(sampler_BaseMap, input.uv);

            }

            ENDHLSL
        }
    }
}
