using System.Collections;
using UnityEngine;

public class Pattern01 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private int maxEnemyCount;
    [SerializeField]
    private float spawnCycle;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 해당 오브젝트가 켜지면 작동되게 한다.
    private void OnEnable()
    {
        StartCoroutine(nameof(SpawnEnemys));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(SpawnEnemys));
    }

    private IEnumerator SpawnEnemys()
    {
        // 1초 후에 실행
        float waitTime = 1;
        yield return new WaitForSeconds(waitTime);

        int count = 0;
        // 반복
        while (count < maxEnemyCount)
        {
            // 사운드 출력이 끝나면 다시 사운드를 실행한다.
            if(audioSource.isPlaying == false)
            {
                audioSource.Play();
            }

            // 생성 위치
            Vector3 position = new Vector3(Random.Range(Constants.min.x, Constants.max.x), Constants.max.y, 0);

            // 생성
            Instantiate(enemyPrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(spawnCycle);

            count++;
        }

        // 패턴 비활성화
        gameObject.SetActive(false);
    }
}
