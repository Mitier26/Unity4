using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public float moveSpeed = 1f;

    private Rigidbody2D myBody;
    private Animator anim;

    public LayerMask playerLayer;

    private bool moveLeft;

    private bool canMove;
    private bool stunned;

    public Transform left_Collision, right_Collsion, top_Collision, down_Collisioin;
    private Vector3 left_Collision_Pos, right_Collision_Pos;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // 달팽이가 좌우로 움직이기 때문에 필요하다.
        // 달팽이를 발로 차는 것이 있는데 달팽이가 회전하면 반대로 날아간다.
        left_Collision_Pos = left_Collision.position;
        right_Collision_Pos = right_Collsion.position;
    }

    private void Start()
    {
        moveLeft = true;
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            if (moveLeft)
            {
                myBody.velocity = new Vector3(-moveSpeed, myBody.velocity.y);
            }
            else
            {
                myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y);
            }
        }

        CheckCollision();
    }

    void CheckCollision()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(left_Collision.position, Vector2.left, 0.1f, playerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right_Collsion.position, Vector2.right, 0.1f, playerLayer);

        Collider2D topHit = Physics2D.OverlapCircle(top_Collision.position, 0.2f, playerLayer);

        if(topHit != null)
        {
            if(topHit.gameObject.CompareTag(MyTags.PLAYER_TAG))
            {
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);

                    canMove = false;
                    myBody.velocity = new Vector2(0,0);

                    anim.Play("Stunned");
                    stunned = true;

                    // 벌레 부분은 여기
                    // 달팽이와는 다르게 공으로 변하지 않는다.
                    if (gameObject.CompareTag(MyTags.BEETLE_TAG))
                    {
                        anim.Play("Stunned");
                        StartCoroutine(Dead(0.5f));
                    }
                }
            }
        }
        if(leftHit)
        {
            if (leftHit.collider.gameObject.CompareTag(MyTags.PLAYER_TAG))
            {
                if (!stunned)
                {
                    // 플레이어 대미지
                }
                else
                {
                    // 달팽이 민다.
                    if(!gameObject.CompareTag(MyTags.BEETLE_TAG))
                    {
                        myBody.velocity = new Vector2(15f, myBody.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }
        
        if(rightHit)
        {
            if (rightHit.collider.gameObject.CompareTag(MyTags.PLAYER_TAG))
            {
                if (!stunned)
                {

                }
                else
                {
                    if (!gameObject.CompareTag(MyTags.BEETLE_TAG))
                    {
                        myBody.velocity = new Vector2(-15f, myBody.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }
       

        if (!Physics2D.Raycast(down_Collisioin.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        moveLeft = !moveLeft;

        Vector3 tempScale = transform.localScale;

        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);

            left_Collision.position = right_Collision_Pos;
            right_Collsion.position = left_Collision_Pos;
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
            left_Collision.position = right_Collision_Pos;
            right_Collsion.position = left_Collision_Pos;
        }

        transform.localScale = tempScale;
    }


    private IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(MyTags.BULLET_TAG))
        {
            if(CompareTag(MyTags.BEETLE_TAG))
            {
                anim.Play("Stunned");

                canMove = false;
                myBody.velocity = Vector3.zero;

                StartCoroutine(Dead(0.4f));
            }

            if(CompareTag(MyTags.SNAIL_TAG))
            {
                if (!stunned)
                {
                    anim.Play("Stunned");
                    stunned = true;
                    canMove = false;
                    myBody.velocity = Vector3.zero;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
