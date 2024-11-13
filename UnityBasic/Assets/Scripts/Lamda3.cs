using UnityEngine;

public class Lamda3 : MonoBehaviour
{
    delegate void TestDelegate();

    private void Start()
    {
        TestDelegate testDelegate;
        testDelegate = () => Debug.Log("Test Lamda");

        testDelegate.Invoke();
    }
}
