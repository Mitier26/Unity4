using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplosive : MonoBehaviour
{
    private Explosive explosive;

    private void Awake() {
        explosive = GetComponent<Explosive>();
    }

    private void OnCollisionEnter(Collision other) {
        explosive.TakeDamage(10000);
    }
}
