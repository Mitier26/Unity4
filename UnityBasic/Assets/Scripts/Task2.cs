using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    private void Start()
    {
        ThreadPool.QueueUserWorkItem((obj) =>
        {
            Debug.Log("쓰레드풀 실행");
        });

        Task task = new Task(() =>
        {
            Debug.Log("Task 실행");
        });

        task.Start();
        task.Wait();

        // 쓰레드풀은 Start가 없다.
        // task는 Wait도 있다.

        Task task1 = new Task(SleepTask);
        task1.Start();
        task1.Wait();
        // 5초 기다리고 다음 것을 실행한다.


        // Wait가 끝나면 실행한다.
        task1.ContinueWith((obj) =>
        {
            Debug.Log("Task 종료");
        });
    }

    void SleepTask()
    {
        Thread.Sleep(5000);
    }
}
