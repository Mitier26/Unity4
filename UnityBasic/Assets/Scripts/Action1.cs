using System;
using UnityEngine;

public class Action1 : MonoBehaviour
{
    Action action;

    private void Start()
    {
        action = () => Debug.Log("Action1");
        action += () => Debug.Log("Action2");
        action += () => Debug.Log("Action3");

        action.Invoke();
    }
}
