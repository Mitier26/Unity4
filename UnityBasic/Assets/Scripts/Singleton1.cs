using UnityEngine;

public class Singleton1 : MonoBehaviour
{
    public class Singleton
    {
        // 즉시 초기화 싱글톤
        private static Singleton instance = new Singleton();

        public static Singleton Instance { get { return instance; } }

        // 생성자를 싱글톤 내부에서 만들어 외부에서 새로운 싱글톤을 만들 수 없다.
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
