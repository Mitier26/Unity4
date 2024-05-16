using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern05 : MonoBehaviour
{
    [SerializeField]
    private GameObject warningImage;
    [SerializeField]
    private GameObject doctorKO;
    [SerializeField]
    private Vector3[] spawnPositions;
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
        yield return new WaitForSeconds(1);


        warningImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImage.SetActive(false);

        int count = 0;
        while (count < maxCount)
        {
            int spawnType = Random.Range(0, 2);

            GameObject clone = Instantiate(doctorKO, spawnPositions[spawnType], Quaternion.identity); ;

            clone.GetComponent<SpriteRenderer>().flipX = spawnType == 0 ? false : true;

            clone.GetComponent<MovementTransform2D>().MoveTo((spawnType == 0 ? Vector3.right : Vector3.left));

            count++;

            yield return new WaitForSeconds(spawnCycle);
        }

        gameObject.SetActive(false);
    }
}
