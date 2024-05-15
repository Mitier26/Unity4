using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    //private GameObject pattern01;
    private PatternController patterController;

    private readonly float scoreScale = 20;

    public float CurrentScore { get; private set; } = 0;

    public bool IsGamePlay { get; private set; } = false;

    public void GameStart()
    {
        uiController.GameStart();

        //pattern01.SetActive(true);
        patterController.GameStart();

        IsGamePlay = true;
    }

    public void GameExit()
    {
        #if UNITY_EDITOR    
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void GameOver()
    {
        uiController.GameOver();
        //pattern01.SetActive(false);
        patterController.GameOver();
        IsGamePlay = false;
    }

    private void Update()
    {
        if (!IsGamePlay) return;

        CurrentScore += Time.deltaTime * scoreScale;
    }
}
