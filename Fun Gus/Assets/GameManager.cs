using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text coinText;
    private int coinCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(int coin)
    {
        coinCount += coin;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        Debug.Log("Coin collected: " + coinCount);
       // coinText.text = "Coins: " + coinCount;
    }
    public void DisableCoin(GameObject coin, float respawnTime)
    {
        StartCoroutine(DisableAndReenable(coin, respawnTime));
    }

    private IEnumerator DisableAndReenable(GameObject coin, float respawnTime)
    {
        coin.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        coin.SetActive(true);
    }
}
