using System;
using UnityEngine;

public class EventTest : EventArgs
{
    public string _name;

    public EventTest(string name)
    {
        _name = name;
    }
}

public class DelegateTest10 : MonoBehaviour
{
    public event EventHandler eventHandler;

    private void Start()
    {
        EventTest eventTest = new EventTest("이벤트 테스트");

        eventHandler += Test;
        eventHandler.Invoke(this, (EventArgs)eventTest);
    }

    void Test(object sender, EventArgs e)
    {
        Debug.Log("테스트");
        Debug.Log(((EventTest)e)._name);
    }
}
