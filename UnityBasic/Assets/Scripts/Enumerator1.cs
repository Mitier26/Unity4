using UnityEngine;

public class Enumerator1 : MonoBehaviour
{
    // Enumerator : 열거자
    // 데이터 요소를 하나씩 리턴 하는 기능
    // C#에서는 IEnumerator 인터페이스를 이용해서 구현할 수 있다.

    private void Start()
    {
        int[] list = new int[5] { 1, 2, 3, 4, 5 };

        foreach (var one in list)
            Debug.Log(one);
    }
}
