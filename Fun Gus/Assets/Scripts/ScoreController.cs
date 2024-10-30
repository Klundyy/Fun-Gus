using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    [SerializeField] private int score = 0;

    private void Awake()
    {
        if(instance != null && instance != this){
            Destroy(gameObject);
        } else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public int GetScore(){
        return score;
    }
    public void SetScore(int amount){
        score = amount;
    }
}
