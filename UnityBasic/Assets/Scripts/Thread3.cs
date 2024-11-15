using System.Threading;
using UnityEngine;

public class Thread3 : MonoBehaviour
{
    Thread thread;

    private void Start()
    {
        thread = new Thread(new ParameterizedThreadStart(Temp));
        // ThreadStart가 아닌 다른 것을 사용했다.
        // 매개변수사 있기 때문!!
        thread.Start(10);
    }

    void Temp(object num)
    {
        Debug.Log("쓰레드 시작");
        Debug.Log(thread.ThreadState);
        Thread.Sleep(2000);
        Debug.Log(num);
        Debug.Log("쓰레드 종료");
    }
}
