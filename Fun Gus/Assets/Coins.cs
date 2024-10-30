using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAmount;
    public float coinRespawnTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin Collected");
            GameManager.instance.AddCoin(coinAmount);
            GameManager.instance.DisableCoin(gameObject, coinRespawnTime);
        }
    }

}
