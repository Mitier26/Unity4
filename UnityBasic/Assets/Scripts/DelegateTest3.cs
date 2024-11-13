using UnityEngine;

public class DelegateTest3 : MonoBehaviour
{
    // 델리게이트를 정의 한다.
    public delegate void TestDelegate();
    // 델리게이트 타입으로 변수를 만든다.
    TestDelegate _testDelegate;

    private void Start()
    {
        // 델리게이트 타입의 변수에 Do라는 함수의 결과를 넣는다.
        TestDelegate result = Do();

        result.Invoke();
    }

    TestDelegate Do()
    {
        // 델리게이트 타입을 반환
        // 델리게이트는 함수의 주소를 가지고 있다.
        // 그러므러 함수를 반환 하는 것과 같다.
        // 반환될 함수가 필요!
        return _testDelegate = TargetF;
    }

    void TargetF()
    {
        Debug.Log("Target Function");
    }
}
