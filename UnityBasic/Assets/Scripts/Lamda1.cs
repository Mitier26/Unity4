using UnityEngine;

public class Lamda1 : MonoBehaviour
{

    // 람다식
    // 익명 메소드
    // 델리게이트에 전달되는 메소드가 일화성으로 필요할 때 사용

    delegate void TestDelegate();

    private void Start()
    {
        TestDelegate testDelegate;

        //testDelegate = TestFunction;

        testDelegate = delegate ()
        {
            Debug.Log("익명 메소드");
        };

        // 위에 것과 내용은 같다

        testDelegate.Invoke();
    }

    void TestFunction()
    {
        Debug.Log("Test Function");
    }
}
