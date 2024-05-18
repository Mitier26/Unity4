using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private void Start()
    {
        Invoke("Deactivate", 4f);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == MyTags.PLAYER_TAG)
        {
            target.GetComponent<PlayerDamage>().DealDamage();
            gameObject.SetActive(false);
        }
    }
}
