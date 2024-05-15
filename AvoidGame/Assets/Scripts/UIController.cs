using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [Header("Main UI")]
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private TextMeshProUGUI textMainGrade;

    [Header("Game UI")]
    [SerializeField] 
    private GameObject gamePanel;
    [SerializeField]
    private TextMeshProUGUI textScore;

    [Header("Result UI")]
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private TextMeshProUGUI textResultScore;
    [SerializeField]
    private TextMeshProUGUI textResultGrade;
    [SerializeField]
    private TextMeshProUGUI textResultTalk;
    [SerializeField]
    private TextMeshProUGUI textResultHighScore;

    [Header("Result UI Animation")]
    [SerializeField]
    private ScaleEffect effectGameOver;
    [SerializeField]
    private CountingEffect effectResultScore;
    [SerializeField]
    private FadeEffect effectResultGrade;

    private void Awake()
    {
        textMainGrade.text = PlayerPrefs.GetString("HIGHGRADE");
    }
    public void GameStart()
    {
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void GameOver()
    {
        int currentScore = (int)gameController.CurrentScore;

        textResultScore.text = currentScore.ToString();

        CalculateGradeAndTalk(currentScore);
        CalculateScore(currentScore);

        gamePanel.SetActive(false);
        resultPanel.SetActive(true);

        // 게임 오버 텍스트 크기 변경
        effectGameOver.Play(500, 200);

        // 점수를 0 부터
        // 카운팅 에니메이션이 종료되고 페이드인 실행
        effectResultScore.Play(0, currentScore, effectResultGrade.FadeIn);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToYoutube()
    {
        Application.OpenURL("주소");
    }

    private void Update()
    {
        // "F0" 자리수 없는 실수
        textScore.text = gameController.CurrentScore.ToString("F0");
    }

    private void CalculateGradeAndTalk(int score)
    {
        if (score < 2000)
        {
            textResultGrade.text = "F";
            textResultTalk.text = "조금 더 \n노력해봅시다";
        }
        else if (score < 3000)
        {
            textResultGrade.text = "D";
            textResultTalk.text = "더욱 잘\n할수 있어요";
        }
        else if (score < 4000)
        {
            textResultGrade.text = "C";
            textResultTalk.text = "발전하는 모습이\n멋져요";
        }
        else if (score < 5000)
        {
            textResultGrade.text = "B";
            textResultTalk.text = "A가\n눈앞!";
        }
        else 
        {
            textResultGrade.text = "A";
            textResultTalk.text = "유니티를\n마스터하는\n그날까지";
        }
    }

    private void CalculateScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");

        if(score > highScore)
        {
            PlayerPrefs.SetString("HIGHGRADE", textResultGrade.text);
            PlayerPrefs.SetInt("HIGHSCORE", score);

            textResultHighScore.text = score.ToString();
        }
        else
        {
            textResultHighScore.text = highScore.ToString();
        }
    }
}
