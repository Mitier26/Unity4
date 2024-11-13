using System;
using UnityEngine;

public class DelegateTest6 : MonoBehaviour
{
    // 델리게이트 체인
    // 여러개의 함수를 동시에 여러개 참조

    private delegate void TestDelegate();
    private TestDelegate testDelegate;

    void Chain1() { Debug.Log("체인1"); }
    void Chain2() { Debug.Log("체인2"); }
    void Chain3() { Debug.Log("체인3"); }

    private void Start()
    {
        TestDelegate test1 = new TestDelegate(Chain1);
        TestDelegate test2 = new TestDelegate(Chain2);
        TestDelegate test3 = new TestDelegate(Chain3);

        testDelegate = Delegate.Combine(test1, test2) as TestDelegate;
        testDelegate = Delegate.Combine(testDelegate, test3) as TestDelegate ;

        testDelegate.Invoke();
    }
}
