using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator anim;
    private int health = 1;

    private bool canDamage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
    }

    public IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canDamage)
        {
            if (collision.CompareTag(MyTags.BULLET_TAG))
            {
                health--;
                canDamage = false;

                if (health <= 0)
                {
                    GetComponent<Boss>().DeactiveBoss();
                    anim.Play("BossDead");
                }

                StartCoroutine(WaitForDamage());
            }
        }
    }
}
