using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private float explosionDelayTime = 0.01f;
    [SerializeField]
    private float explosionRadius = 10f;
    [SerializeField]
    private float explosionForce = 500f;
    [SerializeField]
    private int maxHP = 100;

    private int currentHP ;
    private bool isExploded = false;

    private void Awake() {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage) {
        currentHP -= damage;

        if(currentHP <= 0 && isExploded == false) {
            StartCoroutine(nameof(OnExplosion));
        }
    }

    private IEnumerator OnExplosion() {
        yield return new WaitForSeconds(explosionDelayTime);

        isExploded = true;

        if(explosionPrefab != null) {
            Bounds bounds = GetComponent<Collider>().bounds;
            Instantiate(explosionPrefab, bounds.center, transform.rotation);
        }

        Collider[] colliders= Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider hit in colliders){
            if(hit.TryGetComponent<Rigidbody>(out var rigidbody)) {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Destroy(gameObject);
    }
}
