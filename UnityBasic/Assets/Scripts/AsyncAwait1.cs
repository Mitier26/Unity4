using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwait1 : MonoBehaviour
{
    async void Start()
    {
        Debug.Log("메인쓰레드 시작");
        await SumAsync(10, 20);
        Debug.Log("메인쓰레드 진행 중");
    }

    async Task SumAsync(int num1, int num2)
    {
        await Task.Delay(3000);
        int num3 = num1 + num2;
        Debug.Log("오래걸리는 작업 완료");
        Debug.Log("비동기 작업 결과 : " + num3);
    }

    // async, await 로 만드려면 반환값은
    // Task 또는 Task<T> 로 해야한다.
    // EventHandler 때문에 void도 가능
    // 단, void는 예외처리가 힘들다.
}
