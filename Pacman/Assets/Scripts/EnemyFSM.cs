using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    [SerializeField]
    private LayerMask tileLayer;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private float delayTime = 3f;

    private Vector2 moveDirection = Vector2.right;
    private Direction direction = Direction.Right;
    private Direction nextDirection = Direction.None;
    private float rayDistance = 0.55f;

    private Movement2D movement2D;
    private AroundWrap aroundWrap;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        aroundWrap = GetComponent<AroundWrap>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        SetMoveDirectionByRandom();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, rayDistance, tileLayer);

        if(hit.transform == null)
        {
            movement2D.MoveTo(moveDirection);
            aroundWrap.UpdateAroundWrap();
        }    
        else
        {
            SetMoveDirectionByRandom();
        }

    }

    private void SetMoveDirection(Direction direction)
    {
        this.direction = direction;

        moveDirection = Vector3FromEnum(this.direction);

        spriteRenderer.sprite = sprites[(int)this.direction];

        StopAllCoroutines();

        StartCoroutine(nameof(SetMoveDirectionByTime));
    }

    private void SetMoveDirectionByRandom()
    {
        direction = (Direction)Random.Range(0, (int)Direction.Count);

        SetMoveDirection(direction);
    }

    private IEnumerator SetMoveDirectionByTime()
    {
        yield return new WaitForSeconds(delayTime);

        // 현재 이동 방향이 Rigint 또는 left 이면 direction % 2 는 0
        // 현재 이동 방향이 up 또는 down 이면 direction % 2 는 1

        nextDirection = (Direction)(Random.Range(0,2)* 2 + 1 - (int)direction % 2);

        StartCoroutine(nameof(CheckBlockNextMoveDirection));
    }

    private IEnumerator CheckBlockNextMoveDirection()
    {
        while (true)
        {
            Vector3[] directions = new Vector3[3];
            bool[] isPossibleMvoe = new bool[3];

            directions[0] = Vector3FromEnum(nextDirection);

            if (directions[0].x != 0)
            {
                directions[1] = directions[0] + new Vector3(0, 0.65f, 0);
                directions[2] = directions[0] + new Vector3(0, -0.65f, 0);
            }
            else if (directions[0].y != 0) {
                directions[1] = directions[0] + new Vector3(-0.65f, 0, 0);
                directions[2] = directions[0] + new Vector3(0.65f, 0, 0);
            }

            int possibleCount = 0;

            for(int i = 0; i < 3; ++i)
            {
                if (i == 0)
                {
                    isPossibleMvoe[i] = Physics2D.Raycast(transform.position, directions[i], 0.5f, tileLayer);
                    Debug.DrawLine(transform.position, transform.position + directions[i] * 0.5f, Color.yellow);
                }
                else
                {
                    isPossibleMvoe[i] = Physics2D.Raycast(transform.position, directions[i], 0.7f, tileLayer);
                    Debug.DrawLine(transform.position, transform.position + directions[i] * 0.7f, Color.yellow);
                }

                if (isPossibleMvoe[i] == false)
                {
                    possibleCount++;
                }
            }

            if (possibleCount == 3)
            {
                if (transform.position.x > stageData.LimitMin.x && transform.position.x < stageData.LimitMax.x &&
                    transform.position.y > stageData.LimitMin.y & transform.position.y < stageData.LimitMax.y)
                {
                    SetMoveDirection(nextDirection);
                    nextDirection = Direction.None;
                    break;
                }
            }

            yield return null;
        }
    }

    private Vector3 Vector3FromEnum(Direction state)
    {
        Vector3 direction = Vector3.zero;

        switch (state)
        {
            case Direction.Up: direction = Vector3.up; break;
            case Direction.Down: direction = Vector3.down; break;
            case Direction.Left: direction = Vector3.left; break;
            case Direction.Right: direction = Vector3.right; break;
        }

        return direction; 
    }
}
