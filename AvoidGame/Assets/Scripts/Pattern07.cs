using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pattern07 : MonoBehaviour
{
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject doctorKO;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private Collider2D[] laserCollider2D;
    [SerializeField]
    private float rotateTime;
    [SerializeField]
    private int anglePerSeconds;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        // 패턴 시작 대기 시간
        yield return new WaitForSeconds(1);

        ground.SetActive(true);
        doctorKO.SetActive(true);
        laser.SetActive(true);

        for(int i = 0; i < laserCollider2D.Length; i++)
        {
            laserCollider2D[i].enabled = false;
        }

        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < laserCollider2D.Length;i++)
        {
            laserCollider2D[i].enabled=true;
        }

        float time = 0;
        while (time < rotateTime)
        {
            laser.transform.Rotate(Vector3.forward * anglePerSeconds * Time.deltaTime);

            time += Time.deltaTime;

            yield return null;
        }

        ground.SetActive(false);
        doctorKO.SetActive(false);
        laser.SetActive(false);

        gameObject.SetActive(false);
    }
}



