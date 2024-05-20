using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject bloodPrefab;
    private float speed = 1f;

    private Rigidbody rb;

    private bool isAlive;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = Random.Range(1f, 5f);

        isAlive = true;
    }

    private void Update()
    {
        if (isAlive)
        {
            rb.velocity = new Vector3(0f, 0f, -speed);
        }

        if(transform.position.y < -10f)
        {
            gameObject.SetActive(false);
        }
    }

    private void Die()
    {
        isAlive = false;
        rb.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");

        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.z, 0.2f, transform.position.z);
    }

    private void DeactiveGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.CompareTag("Player") || target.gameObject.CompareTag("Bullet"))
        {
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);

            Invoke("DeactiveGameObject", 3f);

            Die();
        }
    }
}
