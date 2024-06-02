using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    private Vector3 direction;

    public void Setup(Vector3 direction)
    {
        this.direction = direction;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        direction = Vector3.Reflect(direction, collision.GetContact(0).normal);
    }
}
