using UnityEngine;

public class DelegateTest2 : MonoBehaviour
{
    public delegate void TestDelegate();

    TestDelegate _testDelegate;

    private void Start()
    {
        _testDelegate = TargetF;

        Do(_testDelegate);
    }

    void Do(TestDelegate del)
    {
        // 실행 방법
        del();
        del.Invoke();
    }

    void TargetF()
    {
        Debug.Log("Target Function");
    }
}
