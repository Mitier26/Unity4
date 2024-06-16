using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 0.2f;      // 한칸 이동에 소요되는 시간
    private bool isMove = false;        // 오브젝트 이동, 대기 제어

    public bool MoveTo(Vector3 moveDirection)
    {
        // 이동 중이면 이동 하지 않게 만든다.
        if (isMove) return false;

        // 현재 위치에서 이동하는 코루틴
        StartCoroutine(SmoothGridMovement(transform.position + moveDirection));

        return true;
    }

    private IEnumerator SmoothGridMovement(Vector3 endPosition)
    {
        Vector2 startPosition = transform.position;
        float percent = 0;

        // 이동 시간 동안 
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
