using UnityEngine;

public class TestDele
{
    public delegate void TestEvent();
    public event TestEvent testEvent;

    // 이벤트 키워드가 있으면 외부에서 사용할 수 없어 내부에서 사용해야 한다.
    public void StartEvent()
    {
        testEvent.Invoke();
    }
}

public class DelegateTest8 : MonoBehaviour
{
    private void Start()
    {
        TestDele testDele = new TestDele();
        testDele.testEvent += Test1;
        testDele.testEvent += Test2;
        testDele.testEvent += Test3;

        // 일반 적인 델리게이트는 여기에서 사용할 수 있다.
        //testDele.testEvent.Invoke();
        // 그러나, event 키워드가 추가되면 외부에서 사용할 수 없게 되어 사용할 수 없다.

        testDele.StartEvent();
        // 안정적인 이벤트 기반 프로그레밍을 할 수 있다.
    }

    public void Test1() { Debug.Log("Test1"); }
    public void Test2() { Debug.Log("Test2"); }
    public void Test3() { Debug.Log("Test3"); }
}
