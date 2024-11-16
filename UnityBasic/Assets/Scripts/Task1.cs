using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    private void Start()
    {
        Task task = new Task(BackgroundTask);
        task.Start();

        // Task는 쓰레드와 쓰레드풀의 단점을 보완한것

        // Task도 쓰레드 풀을 이용하고 백그라운드 쓰레드다.
    }

    void BackgroundTask()
    {
        bool isBackground = Thread.CurrentThread.IsBackground;
        Debug.Log(isBackground);

        bool isThreadPool = Thread.CurrentThread.IsThreadPoolThread;
        Debug.Log(isThreadPool);
    }

}
