using UnityEngine;

public class Lamda1 : MonoBehaviour
{

    // ���ٽ�
    // �͸� �޼ҵ�
    // ��������Ʈ�� ���޵Ǵ� �޼ҵ尡 ��ȭ������ �ʿ��� �� ���

    delegate void TestDelegate();

    private void Start()
    {
        TestDelegate testDelegate;

        //testDelegate = TestFunction;

        testDelegate = delegate ()
        {
            Debug.Log("�͸� �޼ҵ�");
        };

        // ���� �Ͱ� ������ ����

        testDelegate.Invoke();
    }

    void TestFunction()
    {
        Debug.Log("Test Function");
    }
}
