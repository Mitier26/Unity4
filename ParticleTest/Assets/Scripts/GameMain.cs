using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickPlayBGM()
    {
        audio.PlayNextBGM();
    }

    public void PlayBGM(int idx)
    {
        audio.PlayBGM(idx);
    }

    public void PlaySound(int idx)
    {
        audio.PlaySound(idx);
    }
}