using UnityEngine;

public class Singleton2 : MonoBehaviour
{
    // 게으른 초기화 싱글톤
    public class Singleton
    {
        private static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        private Singleton() { }

        public void Test() => Debug.Log("Test");
    }

    public class Test : MonoBehaviour
    {
        public void Awake()
        {
            Singleton.Instance.Test();
        }
    }
}
