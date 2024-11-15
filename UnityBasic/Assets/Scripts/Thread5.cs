using System.Threading;
using UnityEngine;

public class Thread5 : MonoBehaviour
{
    private Thread thread1, thread2;

    private void Start()
    {
        thread1 = new Thread(ThreadFunc);
        thread1.Start();
    }

    private void ThreadFunc()
    {
        Debug.Log("쓰레드1 시작");
        thread2 = new Thread(Thread2Func);
        thread2.Start();
        thread2.Join();
        Debug.Log("쓰레드1 끝");
    }

    private void Thread2Func()
    {
        Debug.Log("쓰레드2 시작");
        Thread.Sleep(2000);
        Debug.Log("쓰레드2 끝");
    }

    // 중간에 새로운 쓰레드2 가 있다.
    // 함정이 있는데
    // 쓰레드2가 끝나고 쓰레드1이 끝아는 것이 아니다.
    // 쓰레드는 각자의 흐름이 있다.
    // 쓰레드1은 쓰레드2를 실행해고 그대로 아래 줄을 실행한다.
    // 그러면 쓰레드2가 실행되고 2초 기다리고 끝난다.
    // 함수의 경우에는 내부에 있는 것이 실행되고 다음 것이 실행 되지만
    // 쓰레드는 동시에 실행 된다.

    // Join은 쓰레드2가 완료될 때 까지 기다리는 것이다.
    // 여기서는 쓰레드2가 끝나야 쓰레드1이 끝난다.
}
