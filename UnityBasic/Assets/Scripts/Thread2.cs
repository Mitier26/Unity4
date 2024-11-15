using System.Threading;
using UnityEngine;

public class Thread2 : MonoBehaviour
{
    Thread thread;

    private void Start()
    {
        // 쓰레드가 시작 될 때 사용할 메서드를 넣어 준다.
        thread = new Thread(new ThreadStart(Temp));
        thread.Start();
    }

    void Temp()
    {
        Debug.Log("쓰레드 시작");
        Debug.Log(thread.ThreadState);
        Thread.Sleep(2000);
        Debug.Log("쓰레드 종료");
    }
}
