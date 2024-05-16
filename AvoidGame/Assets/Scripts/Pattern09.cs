using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern09 : MonoBehaviour
{
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject[] warningImages;
    [SerializeField]
    private GameObject[] prefabs;
    [SerializeField]
    private int setCount;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        yield return new WaitForSeconds(1);

        int[] numbers = new int[3] { 0, 1, 2 };
        yield return StartCoroutine(SpawnPrefabSet(numbers, 0.5f, 1));
       

        int count = 0;

        while (count < setCount)
        {
            numbers = Utils.RandomNumbers(3, 3);

            yield return StartCoroutine(SpawnPrefabSet(numbers, 0.5f, 1));
            
            count++;
        }

        ground.SetActive(false);

        gameObject.SetActive(false);
    }

    private IEnumerator SpawnPrefabWithWarning(int index, float waitTime)
    {
        warningImages[index].SetActive(true);
        yield return new WaitForSeconds(waitTime);
        warningImages[index].SetActive(false);

        audioSource.Play();

        int spawnType = Random.Range(0, 2);
        int prefecIndex = Random.Range(0, prefabs.Length);
        Vector3 position = new Vector3(spawnType == 0 ? Constants.min.x : Constants.max.x, warningImages[index].transform.position.y, 0);
        GameObject clone = Instantiate(prefabs[prefecIndex], position, Quaternion.identity);

        clone.GetComponent<MovementTransform2D>().MoveTo(spawnType == 0 ? Vector3.right : Vector3.left);
    }

    private IEnumerator SpawnPrefabSet(int[] numbers, float delayTime, float endOfWaitTime = 1)
    {
        int index = 0;

        while (index < numbers.Length)
        {
            StartCoroutine(SpawnPrefabWithWarning(numbers[index], delayTime));

            yield return new WaitForSeconds(delayTime * 0.5f);

            index++;
        }

        yield return new WaitForSeconds(endOfWaitTime);

    }
}
