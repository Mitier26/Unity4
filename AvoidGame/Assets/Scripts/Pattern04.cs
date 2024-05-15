using System.Collections;
using UnityEngine;

public class Pattern04 : MonoBehaviour
{
    [SerializeField]
    private MovementTransform2D boss;
    [SerializeField]
    private GameObject bossProjectile;
    [SerializeField]
    private float attackRate = 1;
    [SerializeField]
    private int maxFireCount = 5;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));   
    }

    private void OnDisable()
    {
        boss.GetComponent<MovingEntity>().Reset();

        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        yield return new WaitForSeconds(1);

        // 보스가 아래로 이동
        yield return StartCoroutine(nameof(MoveDown));

        // 보스가 좌우로 이동
        StartCoroutine(nameof(MoveLeftAndRight));

        // 보스 공격
        int count = 0;
        while(count < maxFireCount)
        {
            CircleFire();

            count++;

            yield return new WaitForSeconds(attackRate);
        }

        // 보스 오브젝트 비활성화
        boss.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    private IEnumerator MoveDown()
    {
        // 목표 위치
        float boosDestinationY = 2;

        boss.gameObject.SetActive(true);

        // 보스 위치 검사
        while(true)
        {
            if(boss.transform.position.y <= boosDestinationY)
            {
                boss.MoveTo(Vector3.zero);

                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator MoveLeftAndRight()
    {
        // 보스 오브젝트가 밖으로 가지 않게
        float xWeight = 3;

        boss.MoveTo(Vector3.right);

        while(true)
        {
            if(boss.transform.position.x <= Constants.min.x + xWeight)
            {
                boss.MoveTo(Vector3.right);
            }
            else if(boss.transform.position.x >= Constants.max.x - xWeight)
            {
                boss.MoveTo(Vector3.left);
            }

            yield return null;
        }
    }

    private void CircleFire()
    {
        int count = 30;
        float intervalAngle = 360 / count;

        for(int i = 0; i < count; i++)
        {
            // 총알 생성
            GameObject clone = Instantiate(bossProjectile, boss.transform.position, Quaternion.identity);

            // 총알의 각도
            float angle = intervalAngle * i;

            // 총알의 이동 방향
            float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

            // 총알 이동
            clone.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x, y));
        }
    }
}
