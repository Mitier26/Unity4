using UnityEngine;

public class LerpTest : MonoBehaviour
{
    // 시작 위치
    Vector3 startPos;
    // 목표 위치
    Vector3 targetPos = new Vector3(0, 5, 0);
    // 시작과 목표 사이를 선형보간하는 t
    float currentTime = 0;

    public float moveTime = 5.0f;

    private void Start()
    {
        // 시작 위치를 정한다.
        startPos = transform.position;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        transform.position = Vector3.Lerp(startPos, targetPos, currentTime / moveTime);
    }
}
