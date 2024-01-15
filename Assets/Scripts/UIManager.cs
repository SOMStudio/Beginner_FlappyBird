using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image scoreTextPanel1;
    public Image scoreTextPanel2;
    public Sprite[] numberSprites; 

    public LevelManager levelManager;

    public void UpdateScore()
    {
        //scoreText.text = levelManager.GetScore().ToString();

        int currentScore = levelManager.GetScore();
        
        if (currentScore <= 9)
        {
            scoreTextPanel1.sprite = numberSprites[levelManager.GetScore()];
        }
        else
        {
            string currentScoreText = levelManager.GetScore().ToString();
            int currentScore1 = int.Parse(currentScoreText[0].ToString());
            int currentScore2 = int.Parse(currentScoreText[1].ToString());
            
            scoreTextPanel1.sprite = numberSprites[currentScore1];
            scoreTextPanel2.sprite = numberSprites[currentScore2];
            scoreTextPanel2.gameObject.SetActive(true);
        }
    }
}
