using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetScore()
    {
        score = GameManager.GetInstance().GetBreakBuildingCount();
    }

    /// <summary>
    /// スコアを返す
    /// </summary>
    public int GetScore() { return score; }
}
