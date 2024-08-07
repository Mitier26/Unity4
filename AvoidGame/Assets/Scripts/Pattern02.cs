using System.Collections;
using UnityEngine;

public class Pattern02 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImages;
    [SerializeField]
    private GameObject[] playerObjects;
    [SerializeField]
    private float spawnCycle = 1;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        // 위치 초기화
        for(int i = 0; i < playerObjects.Length; i++)
        {
            playerObjects[i].SetActive(false);
            playerObjects[i].GetComponent<MovingEntity>().Reset();
        }

        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        yield return new WaitForSeconds(1);

        int[] numbers = Utils.RandomNumbers(3, 3);

        int index = 0;

        while(index < numbers.Length)
        {
            StartCoroutine(nameof(SpawnPlayer), numbers[index]);

            index++;

            yield return new WaitForSeconds(spawnCycle);
        }

        yield return new WaitForSeconds(1);

        // 패턴이 완료되면 비활성화
        gameObject.SetActive(false);
    }

    private IEnumerator SpawnPlayer(int index)
    {
        warningImages[index].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImages[index].SetActive(false);

        playerObjects[index].SetActive(true);
    }
}
