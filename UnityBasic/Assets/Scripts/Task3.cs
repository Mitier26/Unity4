using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    private Task task1, task2, task3;
    private Stopwatch stopwatch;

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();

        // Run : Start 하지 않아도 바로 실행된다.
        task1 = Task.Run(TaskFunc);

        task2 = Task.Run(() =>
        {
            Thread.Sleep(3000);
        });

        // Task1, Task2가 모드 완료 되면 실행한다.
        task3 = Task.WhenAll(task1, task2);
    }

    private void Update()
    {
        if (task3.IsCompleted)
        {
            stopwatch.Stop();
            UnityEngine.Debug.Log("모든 작업이 완료되었습니다.");
            UnityEngine.Debug.Log("경과시간 : " + stopwatch.Elapsed.TotalSeconds + "초");
        }
    }

    void TaskFunc()
    {
        Thread.Sleep(3000);
    }
}
