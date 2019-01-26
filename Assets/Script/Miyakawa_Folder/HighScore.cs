using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text Score;
    public Text HighScoreText;
    private int score;
    private int highScore;
    private string key = "HIGH SCORE";

    void Start()
    {
        highScore = PlayerPrefs.GetInt(key, 0);
        HighScoreText.text =  highScore.ToString();
    }
    
    void Update()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(key, highScore);
            HighScoreText.text = highScore.ToString();
        }
    }
}
