using System.Threading;
using UnityEngine;

public class Thread4 : MonoBehaviour
{
    // 쓰레드는 매개변수를 1개만 받을 수 있다.
    // 매개변수를 여러개 넘겨줄 수 있는 방법은 없는 것인가?
    // 쓰레드의 매개변수 타입이 object인 것에 주목하자.
    // 클래스를 이용하는 방법이 있다.
    public class Param
    {
        public int value1;
        public int value2;
    }

    Thread thread;

    private void Start()
    {
        
        thread = new Thread(new ParameterizedThreadStart(Temp));

        Param param = new Param();
        param.value1 = 10;
        param.value2 = 20;

        thread.Start((object)param);
    }

    void Temp(object num)
    {
        Debug.Log("쓰레드 시작");
        Debug.Log(thread.ThreadState);
        Thread.Sleep(2000);
        Param param = (Param)num;
        Debug.Log(param.value1);
        Debug.Log(param.value2);
        Debug.Log("쓰레드 종료");
    }
}
