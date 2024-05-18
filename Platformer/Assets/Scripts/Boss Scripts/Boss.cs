using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject stone;
    public Transform attackInstantiate;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(nameof(StartAttack));
    }

    public void DeactiveBoss()
    {
        StopCoroutine(nameof(StartAttack));
        enabled = false;
    }

    private void BackToIdle()
    {
        anim.Play("BossIdle");
    }

    private void Attack()
    {
        GameObject obj = Instantiate(stone, attackInstantiate.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f, -700f), 0f));
    }

    private IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        anim.Play("BossAttack");
        StartCoroutine(nameof(StartAttack));
    }
}
