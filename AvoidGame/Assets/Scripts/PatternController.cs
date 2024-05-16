using UnityEngine;

public class PatternController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject[] patterns;
    [SerializeField]
    private GameObject hpPotion;
    private GameObject currentPattern;
    private int[] patternIndexs;
    private int current = 0;

    private void Awake()
    {
        // 보유하고 있는 패턴
        patternIndexs = new int[patterns.Length];

        // 처음에는 패턴을 순차적으로 실행
        for(int i = 0; i < patternIndexs.Length; i++)
        {
            patternIndexs[i] = i;
        }
    }

    private void Update()
    {
        if (gameController.IsGamePlay == false) return;

        // 현재 재생중인 패턴이 종료되면
        if(currentPattern.activeSelf == false)
        {
            ChangePattern();
        }
    }

    public void GameStart()
    {
        ChangePattern();
    }

    public void GameOver()
    {
        // 패턴 비활성화
        currentPattern.SetActive(false);
    }

    public void ChangePattern()
    {
        // 현재 패턴 변경
        currentPattern = patterns[patternIndexs[current]];

        // 현재 패턴 활성화
        currentPattern.SetActive (true);

        current++;

        // 4, 3, 3개의 패턴늘 클리오하면 물약등장
        if(current == 4 || current == 7 || current == 10)
        {
            hpPotion.SetActive(true);
        }

        if(current >= patternIndexs.Length)
        {
            patternIndexs = Utils.RandomNumbers(patternIndexs.Length, patternIndexs.Length);
            current = 0;
        }
    }
}
