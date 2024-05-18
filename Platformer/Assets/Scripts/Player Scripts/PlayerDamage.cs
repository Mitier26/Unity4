using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private Text lifeText;
    private int lifeScoreCount;

    private bool canDamage;

    private void Awake()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        lifeScoreCount = 3;
        lifeText.text = "x" + lifeScoreCount;

        canDamage = true;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void DealDamage()
    {
        if(canDamage)
        {
            lifeScoreCount--;

            if (lifeScoreCount >= 0)
            {
                lifeText.text = "x" + lifeScoreCount;
            }

            if (lifeScoreCount == 0)
            {
                Time.timeScale = 0f;
                StartCoroutine(ResetGame());
            }

            canDamage = false;

            StartCoroutine(WaitForDamage());
        }
        
    }
    
    private IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    private IEnumerator ResetGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        // WaitForSecondsRealtime 이것이 중요
        // timeScale이 0 이 되면 WatiForSeconds 는 작동되지 않는다.
        SceneManager.LoadScene("GamePlay");
    }

}
