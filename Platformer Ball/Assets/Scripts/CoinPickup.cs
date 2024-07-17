using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Pickup
{
    [Header("Coin Pickup")]

    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            LevelManager.inst.UpdateCoinCounter(value);
            Destroy(gameObject);
        }
    }

    public new static int CountNumberInscene()
    {
        int totalCoinValue = 0;
        CoinPickup[] coins = FindObjectsOfType<CoinPickup>();

        foreach (CoinPickup coin in coins)
        {
            totalCoinValue += coin.value;
        }

        return totalCoinValue;
    }
}
