using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    public float springForce = 9f;
    public float activationForce = 0f;
    public float cooldown = 0.3f;
    public LayerMask affectedLayer = ~0;

    float currentCoolDown = 0;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentCoolDown > 0) return;

        if ((affectedLayer & (1 << collision.gameObject.layer)) == 0) return;

        Rigidbody2D target = collision.GetComponent<Rigidbody2D>();

        if(!target.isKinematic && target)
        {
            float reboundStrength = Vector2.Dot(target.velocity, transform.up);

            if (-reboundStrength < activationForce) return;

            anim.SetTrigger("Hit");

            target.AddForce(transform.up * (springForce - reboundStrength), ForceMode2D.Impulse);

            currentCoolDown = cooldown;
        }
    }
}
