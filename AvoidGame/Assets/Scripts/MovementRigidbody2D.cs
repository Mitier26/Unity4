using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementRigidbody2D : MonoBehaviour
{
    [Header("Move Horizontal")]
    [SerializeField] 
    private float moveSpeed = 8;

    [Header("Move Vectical (Jump)")]
    [SerializeField]
    private float jumpForce = 10;       // 점프 힘
    [SerializeField]
    private float lowGravity = 2;       // 점프키를 오래 누르고 있을 때
    [SerializeField]
    private float highGravity = 3;      // 일반 중력
    [SerializeField]
    private int maxJumpCount = 2;       // 연속 점프 가능 횟수
    private int currentJumpCount;       // 현재 점프 수

    [Header("Collision")]
    [SerializeField]
    private LayerMask groundLayer;      // 바닥 충돌 체트를 위한 레이어

    private bool isGounded;
    private Vector2 footPosition;       // 바닥 체크를 위한 발의 위치
    private Vector2 footArea;           // 바닥 체크를 위한 발의 범위

    private Rigidbody2D rigid2D;
    private new Collider2D collider2D;

    public bool IsLongJump { set; get; } = false;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        // 바닥을 인식하기
        Bounds bounds = collider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        footArea = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);
        isGounded = Physics2D.OverlapBox(footPosition, footArea, 0, groundLayer);

        if(isGounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
        }

        // 낮은 점프 높은 점프
        if(IsLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = lowGravity;
        }
        else
        {
            rigid2D.gravityScale = highGravity;
        }
    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(transform.position.x, Constants.min.x, Constants.max.x);  
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveTo(float x)
    {
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public bool JumpTo()
    {
        if(currentJumpCount > 0)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
            currentJumpCount--;

            return true;
        }

        return false;
    }
}
