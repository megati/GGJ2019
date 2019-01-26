using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text _colontext;
    public Text _minuteText;
    public Text _secondText;


    void Start()
    {
       
    }
    
    void Update()
    {
        GameManager.GetInstance().GameTimeCount();
        GameManager gameManager = GameManager.GetInstance();

        int time = gameManager.GetGameTime();
        int minuteTime = gameManager.GetGameTimeMinute();
        int secondTime = gameManager.GetGameTimeSecond();


        _minuteText.text = minuteTime.ToString("00") + ":";
        _secondText.text = secondTime.ToString("00");

    }
}
