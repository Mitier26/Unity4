using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    private GameController gameController;

    private MovementRigidbody2D movement2D;

    private PlayerHP playerHP;

    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();
        playerHP = GetComponent<PlayerHP>();
    }

    private void Update()
    {
        if(!gameController.IsGamePlay) return;

        UpdateMove();
        UpdateJump();
    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");

        movement2D.MoveTo(x);
    }

    private void UpdateJump()
    {
        if(Input.GetKeyDown(jumpKey))
        {
            movement2D.JumpTo();
        }
        else if(Input.GetKey(jumpKey))
        {
            movement2D.IsLongJump = true;
        }
        else if(Input.GetKeyUp(jumpKey))
        {
            movement2D.IsLongJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            bool isDie = playerHP.TakeDamage();

            if(isDie)
            {
                GetComponent<Collider2D>().enabled = false;
                gameController.GameOver();
            }
        }
        else if (collision.CompareTag("HPPotion"))
        {
            collision.gameObject.SetActive(false);
            playerHP.RecoveryHP();
        }
    }
}
