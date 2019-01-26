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
    private float gameTime = 180.0f;

    //演出中か
    private bool isPerformance = false;

    //弾の残段数
    private int bulletNum = 30;

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
    /// 現在の弾の数を返す
    /// </summary>
    public int GetBulletNum() { return bulletNum; }

    /// <summary>
    /// 弾を回復
    /// </summary>
    public void RecoveryBulletNum(int recoveryBulletNum){ bulletNum += recoveryBulletNum; }

    /// <summary>
    /// 弾を減らす
    /// </summary>
    public void CutBackBulletNum(){ bulletNum -= 1; }

    /// <summary>
    /// 演出中かどうか返す
    /// </summary>
    public bool IsPerformance() { return isPerformance; }
}
