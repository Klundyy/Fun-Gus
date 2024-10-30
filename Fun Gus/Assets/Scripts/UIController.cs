using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public void Update(){
        int playerScore = ScoreController.instance.GetScore();
        scoreText.text = playerScore.ToString();
    }

}
