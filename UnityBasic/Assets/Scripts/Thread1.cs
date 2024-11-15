using System.Threading;
using UnityEngine;

public class Thread1 : MonoBehaviour
{

    private void Start()
    {
        // CurrentThread : 코드가 실행되고 있는 현재의 쓰레드 반환
        Thread thread = Thread.CurrentThread;
        // 현재 쓰레드 상태를 출력
        Debug.Log(thread.ThreadState);

        // 쓰레드를 만들지 않았지만 쓰레드의 상태를 확인하면 쓰레드가 실행되고 있다.
    }

    
}
