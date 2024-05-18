using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text coinTextScore;
    private AudioSource audioManager;
    private int scoreCount;

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    private void Start()
    {
        coinTextScore = GameObject.Find("CoinText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(MyTags.COIN_TAG))
        {
            collision.gameObject.SetActive(false);
            scoreCount++;

            coinTextScore.text="x" + scoreCount.ToString();

            audioManager.Play();
        }
    }
}
