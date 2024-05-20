using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anim;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    private void ResetShooting()
    {
        playerController.canShoot = true;
        anim.Play("Idle");
    }
}
