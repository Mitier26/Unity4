using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private Vector3 sizeDelta = Vector3.one;

    [SerializeField]
    private float spawnTime = 5f;
    [SerializeField]
    private int maxCubeCount = 10;
    private int currentCubeCount = 0;

    private IEnumerator Start()
    {
        Vector3 fieldSize = transform.localScale;

        while(currentCubeCount< maxCubeCount)
        {
            float x = Random.Range(-fieldSize.x * 0.5f + sizeDelta.x, fieldSize.x * 0.5f - sizeDelta.x);
            float z = Random.Range(-fieldSize.z * 0.5f + sizeDelta.z, fieldSize.z * 0.5f - sizeDelta.z);

            Instantiate(cubePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);

            currentCubeCount++;

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
