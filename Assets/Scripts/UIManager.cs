using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;

    public LevelManager levelManager;

    public void UpdateScore()
    {
        scoreText.text = levelManager.GetScore().ToString();
    }
}
