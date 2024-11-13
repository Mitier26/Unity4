using System;
using UnityEngine;

public class Func1 : MonoBehaviour
{
    Func<int> func;

    private void Start()
    {
        func = () =>
        {
            int num2 = 3;
            Debug.Log(num2);
            return num2;
        };

        func += () =>
        {
            Debug.Log(int.MinValue);
            return int.MinValue;
        };

        func += Test1;

        int num1 = func.Invoke();
    }

    public int Test1()
    {
        int num2 = 3;
        return num2;
    }
}
