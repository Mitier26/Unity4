using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        transform.localScale = Vector3.one;

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldHeight = Camera.main.orthographicSize * 2f;
        // 월드 좌표에서 orth의 size는 카메라의 중심을 기준으로 높이를 나타낸다.
        // 인스펙터에 5라고 되어 있다면 카메라 중심에서 아래로 5, 위로 5 라는 것이다.

        // 유니티는 화면을 그릴 때
        // 구역당 100개의 픽셀 단위로 계산한다. 픽셀 100 개가 1개의 공간
        // 화면의 넓이가 1280 이라면 유니티 상에서 넓이는 1280 / 100 을 한 12.8 이다.
        float worldWidth = worldHeight / Screen.height * Screen.width;

        Vector3 tempScale = transform.localScale;
        tempScale.x = worldWidth / width + 0.1f;
        tempScale.y = worldHeight / height + 0.1f;

        transform.localScale = tempScale;
    }
}
