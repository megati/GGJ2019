﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GUIText scoreGUIText;
    public GUIText highScoreGUIText;

    private int score;
    private int highScore;
    private int high_score = 120;
    private string highScoreKey = "highScore";

    void Start()
    {
        Initialize();
    }
    
    void Update()
    {
        if(highScore < score)
        {
            highScore = score;
        }
        scoreGUIText.text = score.ToString();
        highScoreGUIText.text = "HighScore:" + highScore.ToString();
    }

    private void Initialize()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    public void AddPoint(int point)
    {
        score = score + point;
    }

    public void Save()
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        Initialize();
    }
}
