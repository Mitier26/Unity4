using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myBody;

    private Vector3 moveDirection = Vector3.down;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(nameof(ChangeMovenent));
    }
    private void Update()
    {
        MoveSpider();
    }
    private void MoveSpider()
    {
        transform.Translate(moveDirection * Time.smoothDeltaTime);
    }

    private IEnumerator ChangeMovenent()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        if(moveDirection == Vector3.down)
        {
            moveDirection = Vector3.up;
        }
        else
        {
            moveDirection = Vector3.down;
        }

        StartCoroutine(nameof(ChangeMovenent));
    }

    private IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.BULLET_TAG)
        {
            anim.Play("SpiderDead");

            myBody.bodyType = RigidbodyType2D.Dynamic;

            StartCoroutine(nameof(SpiderDead));
            StopCoroutine(nameof(ChangeMovenent));
        }

        if(collision.CompareTag(MyTags.PLAYER_TAG))
        {
            collision.GetComponent<PlayerDamage>().DealDamage();
        }
    }
}
