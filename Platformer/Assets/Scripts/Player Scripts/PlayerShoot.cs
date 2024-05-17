using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireBullet;


    private void Update()
    {
        ShootBullet();
    }

    private void ShootBullet()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            GameObject bullet = Instantiate(fireBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<fireBullet>().Speed *= transform.lossyScale.x;
        }
    }
}
