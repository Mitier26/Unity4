using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern08 : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private GameObject warningImage;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float spawnCycle;
    [SerializeField]
    private int maxCount;
        

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

        int count = 0;
        while (count < maxCount)
        {
            StartCoroutine (nameof(SpawnPrefab));

            count++;

            yield return new WaitForSeconds(spawnCycle);
        }

        gameObject.SetActive(false);
    }

    private IEnumerator SpawnPrefab()
    {
        GameObject warningClone = Instantiate(warningImage, playerTransform.position, Quaternion.identity);
        warningClone.transform.localScale = Vector3.one;

        yield return new WaitForSeconds(0.5f);
        
        GameObject prefebClone = Instantiate(prefab, warningClone.transform.position, Quaternion.identity); 
        Destroy(warningClone );
        Destroy(prefebClone, 0.5f );
    }
}
