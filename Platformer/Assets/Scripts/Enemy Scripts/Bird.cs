using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;

    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;

    public GameObject birdEgg;
    public LayerMask playerLayer;
    private bool attacked;

    private bool canMove;
    private float speed = 3f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;

        movePosition = transform.position;
        movePosition.x -= 6f;

        canMove = true;
    }

    private void Update()
    {
        MoveTheBird();
        DropTheEgg();
    }

    private void MoveTheBird()
    {
        if (canMove)
        {
            transform.Translate(moveDirection * speed * Time.smoothDeltaTime);

            if(transform.position.x >= originPosition.x)
            {
                movePosition = Vector3.left;
                ChangeDirection(0.5f);
            }
            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
                ChangeDirection(-0.5f);
                // 0.5는 새의 기본 크기
            }
        }
    }

    private void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    private void DropTheEgg()
    {
        if(!attacked)
        {
            if(Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer))
            {
                Instantiate(birdEgg, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
                attacked = true;
                anim.Play("BirdFly");
            }
        }
    }

    private IEnumerator BirdDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.BULLET_TAG)
        {
            anim.Play("BirdDead");
            GetComponent<BoxCollider2D>().isTrigger = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;

            canMove = false;

            StartCoroutine(BirdDead());
        }
    }
}
