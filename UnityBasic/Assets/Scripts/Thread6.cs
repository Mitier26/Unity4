using System.Threading;
using UnityEngine;

public class Thread6 : MonoBehaviour
{
    private Thread thread;

    private void Start()
    {
        thread = new Thread(ThreadFunc);
    }

    void ThreadFunc()
    {
        try
        {
            Debug.Log("쓰레드 시작");
            Thread.Sleep(5000);
            Debug.Log("쓰레드 종료");
        }
        catch (ThreadAbortException)
        {
            Debug.Log("쓰레드 강제 종료");
        }
        catch (ThreadInterruptedException)
        {
            Debug.Log("쓰레드 기다림");
        }
    }

    private void Update()
    {
        // 씬이 시작되고 2초 후
        if(Time.timeSinceLevelLoad > 2f)
        {
            // 쓰지 않는 것이 좋은 '강제 종료'
            thread.Abort();

            // 이것도 강제종료
            thread.Interrupt();

            // Abort : 바로 종료
            // Interroup : Sleep, Wait, Join 시 종료.
        }
    }
}
