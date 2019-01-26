using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間表示
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField]
    //数字の画像
    private List<Sprite> number;

    [SerializeField]
    //時
    private Image minutes;
    [SerializeField]
    //分10桁
    private Image tenSecond;
    [SerializeField]
    //分1桁
    private Image oneSecond;

    void Start(){}
    
    void Update()
    {
        GameManager.GetInstance().GameTimeCount();

        int time = GameManager.GetInstance().GetGameTime();

        minutes.sprite = number[(int)(time / 60)];
        int second = (int)(time % 60);
        tenSecond.sprite = number[second/10];
        oneSecond.sprite = number[second%10];
        var asd = GameManager.GetInstance();
        asd.GetBreakBuildingCount();
    }
}
