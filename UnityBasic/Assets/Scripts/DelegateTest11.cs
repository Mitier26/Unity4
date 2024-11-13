using System;
using UnityEngine;

public class EventTest2 : EventArgs
{
    private EventHandler _eventHandler;
    public event EventHandler evnetHandler
    {
        add
        {
            Debug.Log("ADD");
            _eventHandler += value;
        }
        remove
        {
            Debug.Log("REMOVE");
            _eventHandler -= value;
        }
    }

    public void StartEvent()
    {
        _eventHandler.Invoke(this, EventArgs.Empty);
    }
}

public class DelegateTest11 : MonoBehaviour
{
    private void Start()
    {
        EventTest2 eventTest = new EventTest2();

        eventTest.evnetHandler += Test;
        eventTest.StartEvent();
    }

    void Test(object sender, EventArgs e)
    {
        Debug.Log("Test");
    }
}
