using UnityEngine;

public class DelegateTest7 : MonoBehaviour
{
    private delegate void TestDelegate();
    private TestDelegate testDelegate;

    void Chain1() { Debug.Log("체인1"); }
    void Chain2() { Debug.Log("체인2"); }
    void Chain3() { Debug.Log("체인3"); }

    private void Start()
    {
        //testDelegate = new TestDelegate(Chain1) + new TestDelegate(Chain2) + new TestDelegate(Chain3);

        //testDelegate += new TestDelegate(Chain1);
        //testDelegate += new TestDelegate(Chain2);
        //testDelegate += new TestDelegate(Chain3);

        testDelegate = Chain1;
        testDelegate += Chain2;
        testDelegate += Chain3;

        testDelegate.Invoke();
    }
}