using UnityEngine;

public class GenericExample3 : MonoBehaviour
{
    public class return_int
    {
        private int num;
        public int Return()
        {
            return num;
        }
    }

    public class return_float
    {
        private float num;
        public float Return()
        {
            return num;
        }
    }

    public class return_Generic<T>
    {
        private T num;
        public T Retuen()
        {
            return num;
        }
    }

    // T 에는 모든 것을 전부 넣을 수 있다.

    public void Start()
    {
        return_int re_int = new return_int();

        return_Generic<int> intGeneric = new return_Generic<int>();
        return_Generic<float> floatGeneric = new return_Generic<float>();
    }
}
