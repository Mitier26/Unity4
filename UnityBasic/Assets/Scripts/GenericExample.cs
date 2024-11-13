using UnityEngine;

public class GenericExample : MonoBehaviour
{
    // 제네릭
    // 특수한 개념에서 공통된 개념을 찾아 묶는 것

    public void Copy(int[] source, int[] target)
    {
        for(int i = 0; i< source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    public void Copy(float[] source, float[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    public void Copy(string[] source, string[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    // 같은 함수에서 입력값의 타입만 다를 때 여러개의 함수를 만들 수도 있지만
    // 1.0 버전의 경우에는 object 타입으로 모든 타입을 받을 수 있었다.
    // 하지만, objcet 타입은 무거운 타입이라 성능에 문제가 생길 수 있다.
    // object 타입은 박싱과 언박싱에 문제가 있다.

    public void Copy(object[] source, object[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    // 형식 매개변수 : 자료형을 알려주기 위한 것
    // 제네릭은 박싱, 언박싱 문제가 없다.
    public void Copy<T>(T[] source, T[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }
}
