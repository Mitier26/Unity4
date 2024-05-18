using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Animator anim;

    private bool animation_Started;
    private bool animation_Finished;

    private int jumpedTimes;
    private bool jumpLeft = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(nameof(FrogJump));
    }

    private void LateUpdate()
    {
        if(animation_Finished && animation_Started)
        {
            animation_Started = false;

            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    private IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        animation_Started = true;
        animation_Finished = false;

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }

        StartCoroutine(nameof(FrogJump));
    }
    
    void AnimationFinished()
    {
        animation_Finished = true;

        jumpedTimes++;

        if(jumpLeft)
        {
            anim.Play("FrogIdleLeft");
        }
        else
        {
            anim.Play("FrogIdleRight");
        }

        if (jumpedTimes == 2)
        {
            jumpedTimes = 0;

            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;

            jumpLeft = !jumpLeft;
        }
    }
}
