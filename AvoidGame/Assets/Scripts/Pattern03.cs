using System;
using System.Collections;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    [SerializeField]
    private GameObject warningImage;
    [SerializeField]
    private Transform boom;
    [SerializeField]
    private GameObject boomEffect;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        boom.GetComponent<MovingEntity>().Reset();

        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        yield return new WaitForSeconds(1);

        warningImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImage.SetActive(false);

        yield return StartCoroutine(nameof(MoveUp));

        boomEffect.SetActive(true);
        yield return new WaitForSeconds(1);
        boomEffect.SetActive(false);

        // 패턴이 완료되면 비활성화
        gameObject.SetActive(false);
    }

    private IEnumerator MoveUp()
    {
        // 목표 위치
        float boomDestinationY = 0;

        // 폭탄 오브젝트를 활성화
        boom.gameObject.SetActive(true);

        while (true)
        {
            if (boom.transform.position.y >= boomDestinationY)
            {
                boom.gameObject.SetActive(false);

                yield break;
            }

            yield return null;
        }
    }
}
