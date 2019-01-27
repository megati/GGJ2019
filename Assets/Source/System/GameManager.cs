using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム管理
/// </summary>
public class GameManager
{
    private static GameManager _singleInstance = new GameManager();

    public static GameManager GetInstance() { return _singleInstance; }

    //ゲーム時間
    private float gameTime = 60.0f;

    //演出中か
    private bool isPerformance = false;

    //弾の残段数
    private int bulletNum = 30;

    //壊れたビルカウント
    private int breakBuildingCount = 0;

    /// <summary>
    /// ゲーム初期化
    /// </summary>
    public void GameInit()
    {
        gameTime = 60.0f;
        bulletNum = 30;
        breakBuildingCount = 0;
    }

    /// <summary>
    /// ゲームの時間をカウントする
    /// </summary>
    public void GameTimeCount()
    {
        //演出中なら処理しない
        if (isPerformance) return;
        
        if (gameTime <= 0f)
        {
            //カーソルを表示する
            Cursor.visible = true;
            SceneChange("Result");
        }
        else gameTime -= 1.0f * Time.deltaTime;
    }

    /// <summary>
    /// ゲームの時間を返す
    /// </summary>
    public int GetGameTime() { return (int)gameTime; }

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

    /// <summary>
    /// タイトルからゲームシーンへ
    /// </summary>
    public bool ispush = false;
    public void GameStart()
    {
        if (ispush == false)
        {
            ispush = true;
            SceneChange("GameScene");
            return;
        }
    }

    /// <summary>
    /// タイム制限でリザルト画面へ
    /// </summary>
    public void GameEnd()
    {
        if (gameTime <= 0f)
        {
            SceneChange("Result");
        }
        if (bulletNum == 0)
        {
            SceneChange("Result");
        }
    }

    /// <summary>
    /// リザルト画面からタイトルへ
    /// </summary>
    public void BackToTitle()
    {
        if (ispush == false)
        {
            ispush = true;
            SceneChange("TitleScene");
            return;
        }
    }

    /// <summary>
    /// タイトルからゲーム終了へ
    /// </summary>
    public void QuitGame()
    {
        if (ispush == false)
        {
            ispush = true;
            Application.Quit();
            return;
        }
        else
        {
            return;
        }
    }

    // シーン入れ替え
    void SceneChange(string sceneName)
    {
        Cursor.visible = true;
        SceneManager.LoadScene(sceneName);
    }

    /// 壊れたビルの数を返す
    /// </summary>
    public int GetBreakBuildingCount() { return breakBuildingCount; }

    /// <summary>
    /// 壊れたビルをカウント
    /// </summary>
    public void plusBreakBuildingCount() { breakBuildingCount += 1; }
}
