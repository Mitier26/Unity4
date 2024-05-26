using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    private bool isLookAt = true;

    private void Update()
    {
        if (isLookAt == false) return;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // 카메라의 위치에서 마우스의 위치로 발사되는 레이저

        Plane plane = new(Vector3.up, Vector3.up);

        if (plane.Raycast(ray, out float distance))
        {
            // ray와 plane이 충돌하면 ray의 시작점에서 plane까지의 거리를 distance로 반환
            Vector3 direction = ray.GetPoint(distance) - transform.position;
            // ray.GetPoint(distance) 광선의 시작점에서 distance거리의 좌표
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            // 계산된 방향으로 회전
        }
    }
}
