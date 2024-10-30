using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAmount;
    public float coinRespawnTime;
    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            Debug.Log("Coin Collected");
            GameManager.instance.DisableCoin(gameObject, coinRespawnTime);
            ScoreController.instance.AddScore(coinAmount);
        }
    }

    public void ResetCoin()
    {
        isCollected = false;
    }

}
