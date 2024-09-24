using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    const float SPEED_JUMP = 5.0f;
    const float SPEED_MOVE = 3.0f;

    Rigidbody2D rb;
    bool leftPressed = false;
    bool rightPressed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rb != null)
        {
            float dist = SPEED_MOVE * Time.deltaTime;
            Vector2 pos = transform.position;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                leftPressed = false;
            }
            if (leftPressed)
            {
                pos.x -= dist;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                rightPressed = false;
            }
            if (rightPressed)
            {
                pos.x += dist;
            }

            transform.position = pos;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButton(0))
            {
                Vector2 moveVelocity = rb.velocity;
                moveVelocity.y = SPEED_JUMP;
                rb.velocity = moveVelocity;
            }

            if (Input.GetMouseButton(1))
            {
                Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = newPos;
                rb.velocity = Vector2.zero;
            }
        }
    }
}
