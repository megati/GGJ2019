using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    /// <summary>
    /// ゲームの時間を返す
    /// </summary>
    public float GetGameTime() { return gameTime; }

    /// <summary>
    /// 演出中かどうか返す
    /// </summary>
    public bool IsPerformance() { return isPerformance; }
}
