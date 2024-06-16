using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 0.2f;      // ��ĭ �̵��� �ҿ�Ǵ� �ð�
    private bool isMove = false;        // ������Ʈ �̵�, ��� ����

    public bool MoveTo(Vector3 moveDirection)
    {
        // �̵� ���̸� �̵� ���� �ʰ� �����.
        if (isMove) return false;

        // ���� ��ġ���� �̵��ϴ� �ڷ�ƾ
        StartCoroutine(SmoothGridMovement(transform.position + moveDirection));

        return true;
    }

    private IEnumerator SmoothGridMovement(Vector3 endPosition)
    {
        Vector2 startPosition = transform.position;
        float percent = 0;

        // �̵� �ð� ���� 
        isMove = true;

        while(percent < 1)
        {
            percent += Time.deltaTime / moveTime;

            transform.position = Vector2.Lerp(startPosition, endPosition, percent);

            yield return null;
        }

        isMove = false;
    }
}
