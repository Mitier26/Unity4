using System;
using UnityEngine;

public class Func2 : MonoBehaviour
{
    private void Start()
    {
        Func<int> func1 = () =>
        {
            return 1;
        };

        Func<int, int> func2 = (int num) =>
        {
            return num;
        };

        Func<int, int, int> func3 = Test;

        int result1 = func1.Invoke();
        int result2 = func2.Invoke(3);
        int result3 = func3.Invoke(3, 4);

        Debug.Log(result1);
        Debug.Log(result2);
        Debug.Log(result3);

    }

    public int Test(int num2, int num3)
    {
        return num2 + num3;
    }
}
