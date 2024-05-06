Shader "molkang/SimpleShader"
{
    // 머터리얼 프로퍼티 목록이 온다.
    // 머터리얼 프로퍼티의 값음 셰이더 내부의 변수로 전달된다.
    Properties
    {
        // 머터리얼 프로퍼티의 이름(셰이더 변수명과 같은것), 인스펙터에 보이는 변수명, 타입
        _BaseColor ("Color", Color) = (1,1,1,1)
        _Scale("Scale", Float) = 1
    }

    // 하드웨어에 따라 지원 제한이 있을 때
    // 셰이더를 테스트 하고 작동하면 해당 셰이더를 사용한다.
    // 테스트에 실패하면 다음 SubShader를 테스트 한다.
    SubShader 
    {
        // 해당 셰이더가 어떻게 작동할 지, 어떻게 사용해야 할 지, 추가 정보를 넣는 부분
        Tags 
        {
            // UniversalRenderPipeline에서 작동하는 부분이다.
            "RenderPipeline" = "UniversalRenderPipeline"
            // 미리보기 할 때 어떤것을 사용할 것인가.
            "PreviewType" = "Spaher"
        }
        // 게임 오브젝트 그리기 한번에 대응, 여러개 만드는 것 가능
        // 카툰 렌더링에서 외곽선을 그릴 때 2개 의 pass 를 사용한다.
        // 보통은 1개의 pass 를 사용한다.
        pass {
            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            // 컴파일러에서 옵션을 알려 줄 때 사용한다.
            // 우리가 작성할 버텍스 세이더와 프로그먼테 셰이더 함수의 이름을 결정
            #pragma vertex vert
            #pragma fragment frag

            struct FragmentInput
            {
                float4 vertex : SV_POSITION;
                float3 vertexColor : TEXCOORD0;
            };

            // (float3 verter : 여기부분) : vertex가 어떤 데이터인지 알려 주는 부분
            float4 vert(float3 vertex : POSITION, out float3 vertexColor : TEXCOORD0) : SV_POSITION
            {
                vertexColor = vertex;
                return TransformObjectToHClip(vertex);
            };

            half3 frag(float4 input : SV_POSITION, float3 color : TEXCOORD0) : SV_Target0
            {
                return color;
            };

            ENDHLSL
        }
    }
}