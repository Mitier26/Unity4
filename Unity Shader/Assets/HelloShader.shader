Shader "molkang/HelloShader"
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

            // half : 숫자를 저장, 메모리는 float의 절반
            half4 _BaseColor;
            half _Scale;

            // 버텍스 함수에게 전달할 입력
            struct VertexInput 
            {
                // 3D 모델의 각 정점의 위치를 가진다.
                // : 뒤에 시멘틱 추가해야 한다. 변수에 대한 추가 정보 제공
                // 문번 / 키워드
                // POSITION - 버텍스 함수의 입력으로 사용할 오브젝트 정점을 표시
                float3 objectSpacePosition : POSITION;
            };

            // 프레그먼트 함수에게 전달할 입력
            // 버텍스 함수의 출력이기도 하다.
            struct FragmentInput 
            {
                // 화면상의 위치
                // x,y - 화면 위치 , z - 깊이, w - 동차 좌표계
                // SV_POSITION - 프래그먼트 함수의 입력으로 사용할 화면상의 정점을 표시하는데 사용
                float4 screenPosition : SV_POSITION;
            };

            FragmentInput vert(VertexInput input) 
            {
                half3 objectSpacePosition = input.objectSpacePosition;
                objectSpacePosition *= _Scale;

                // 오브젝트 공간의 정점을 월드 공간으로 변화ㅏㄴ
                half3 worldPosition = TransformObjectToWorld(objectSpacePosition);
                // 월드 공간에 있는 정점을 뷰 공간으로 변환
                half3 viewPosition = TransformWorldToView(worldPosition);
                // 뷰 공간에 있는 정범을 클립공간 (동차 클립 좌표계 Homobeneous Clip Space)
                half4 clipPosition = TransformWViewToHClip(viewPosition);

                FragmentInput output;
                // vert -> screenPosition - HClip 위치 클립 공간 위치
                // --> 래스터라이저 --> frag : screenPosition 화면상의 좌표 위치로 변환 된것을 받는다.
                output.screenPosition = clipPosition;
                return output;
            }

            half4 frag(FragmentInput input) : SV_Target0
            {
                return _BaseColor;
            }

            ENDHLSL
        }
    }
}