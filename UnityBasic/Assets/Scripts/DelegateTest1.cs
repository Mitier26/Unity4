using UnityEngine;

public class DelegateTest1 : MonoBehaviour
{
    // 델리게이트 정의
    public delegate void MyDelegate();

    // 선언한 델리게이트 변수 선언
    public MyDelegate _myDelegate;

    #region 2
    public delegate int MyDelegate2(int num);
    public MyDelegate2 _myDelegate2;
    #endregion

    public void TestFunction()
    {
        Debug.Log("Test");
    }

    public int TestFunction2(int num)
    {
        return num;
    }

    private void Start()
    {
        // 1.0 버전
        //_myDelegate = new MyDelegate(TestFunction);

        // 2.0 버전
        _myDelegate = TestFunction;

        // 사용법
        _myDelegate();
    }
}