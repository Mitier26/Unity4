using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager inst;

    [Header("UI Feedback")]
    public TextMeshProUGUI timeFeedback;
    public TextMeshProUGUI colorFeedback;

    int coinCounter;
    int totalCoins;

    private void Start()
    {
        inst = this;
        StartCoroutine(TimeTick());
        totalCoins = CoinPickup.CountNumberInscene();
        colorFeedback.text = coinCounter + "/" + totalCoins;
    }

    public void UpdateCoinCounter(int value)
    {
        coinCounter += value;
        colorFeedback.text = coinCounter + "/" + totalCoins;
    }

    IEnumerator TimeTick(int sec = 0, int min = 0)
    {
        while(Time.timeScale != 0)
        {
            yield return new WaitForSeconds(1);

            if (sec == 59)
            {
                sec = 0;
                min++;
            }
            else
            {
                sec++;
            }

            if(sec < 10)
            {
                timeFeedback.text = min + ":0" + sec;
            }
            else
            {
                timeFeedback.text = min + ":" + sec;
            }
        }

        StopCoroutine(TimeTick());
    }
}
