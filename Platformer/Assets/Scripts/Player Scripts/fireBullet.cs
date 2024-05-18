using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    private float speed = 10f;
    private Animator anim;

    private bool canMove;

    public float Speed {  
        get 
        {
            return speed; 
        } 
        set 
        {
            speed = value; 
        } 
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        canMove = true;
        StartCoroutine(DisableBullet(5f));
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if(canMove)
        {
            Vector3 temp = transform.position;
            temp.x += Speed * Time.deltaTime;
            transform.position = temp;
        }
        
    }

    private IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(MyTags.BEETLE_TAG) 
            || collision.gameObject.CompareTag(MyTags.SNAIL_TAG)
            || collision.gameObject.CompareTag(MyTags.SPIDER_TAG)
            || collision.gameObject.CompareTag(MyTags.BOSS_TAG))
        {
            anim.Play("Explode");
            canMove = false;
            StartCoroutine(DisableBullet(0.2f));
        }
    }
}
