using UnityEngine;

public class Lamda2 : MonoBehaviour
{
    delegate int TestDelegate(int num1, int num2);

    private void Start()
    {
        TestDelegate testDelegate;

        testDelegate = delegate (int num1, int num2)
        {
            return num1 + num2;
        };

        int result = testDelegate(1, 2);
        Debug.Log(result);
    }
}
