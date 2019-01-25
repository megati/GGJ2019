using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム管理
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager _singleInstance = new GameManager();

    public static GameManager GetInstance() { return _singleInstance; }

    //ゲーム時間
    float gameTime = 180.0f;

    //演出中か
    bool isPerformance = false;

    /// <summary>
    /// ゲームの時間をカウントする
    /// </summary>
    public void GameTimeCount()
    {
        //演出中なら処理しない
        if (isPerformance) return;
        gameTime -= 1.0f * Time.deltaTime;
    }

    /// <summary>
    /// ゲームの時間を返す
    /// </summary>
    public int GetGameTime() { return (int)gameTime; }

    public int GetGameTimeMinute() { return (int)gameTime / 60; }

    public int GetGameTimeSecond() { return (int)gameTime % 60; }



    /// <summary>
    /// 演出中かどうか返す
    /// </summary>
    public bool IsPerformance() { return isPerformance; }
}
