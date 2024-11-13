using System;
using UnityEngine;

public class DelegateTest9 : MonoBehaviour
{
    public event EventHandler eventHandler;
    // public delegate void EventHandler(object sender, EventArgs e);
    // EventHandler는 델리게이트로 정의 되어 있다.

    private void Start()
    {
        eventHandler += Test;

        eventHandler.Invoke(this, EventArgs.Empty);
    }

    void  Test(object o, EventArgs e)
    {
        Debug.Log("테스트");
    }
}
