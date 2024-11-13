using UnityEngine;

public class Singleton5 : MonoBehaviour
{
   // 싱글톤이 다른 곳에서 사용하고 있을 때 동시에 싱글톤을 요청하면 오류가 생긴다.
   // 이것을 막기 위해 "더블 체크 락킹 싱글톤" 이라는 것이 사용된다.

    private static Singleton5 instance;
    public static readonly object lockObj = new object();

    public static Singleton5 Instance
    {
        get
        {
            SetupInstance();
            return instance;
        }
    }

    public static void SetupInstance()
    {
        if(instance == null)
        {
            // 멀티 쓰레드를 이용한 순차 처리
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<Singleton5>();
                    if (instance == null)
                    {
                        GameObject gameObj = new GameObject();
                        gameObj.name = typeof(Singleton5).Name;
                        instance = gameObj.AddComponent<Singleton5>();
                        DontDestroyOnLoad(gameObj);
                    }
                }
            }
        }
    }
}
