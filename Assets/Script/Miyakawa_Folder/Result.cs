using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;

    [SerializeField]
    private Text newText;

    SaveData saveData=null;
    int score=0;

    const string highScoreKey = "highScore";

    void Start()
    {
        GameObject obj=GameObject.FindGameObjectWithTag("saveData");
        int highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        score = highScore;
        if (obj != null)
        {
            saveData=obj.GetComponent<SaveData>();
            scoreText.text = saveData.GetScore().ToString();
            score = saveData.GetScore();
            if (highScore < saveData.GetScore())
            {
                highScoreText.text = saveData.GetScore().ToString();
                PlayerPrefs.SetInt(highScoreKey, saveData.GetScore());
                PlayerPrefs.Save();
                newText.gameObject.SetActive(true);
            }
            else
            {
                highScoreText.text = highScore.ToString();
            }
            Destroy(obj);
        }
        else
        {
            scoreText.text="0";
            highScoreText.text = highScore.ToString();
        }
    }

    void Update()
    {

    }

    /// <summary>
    /// ツイッター投稿
    /// </summary>
    public void OnTwitter()
    {
        string message="";
        if (score >= 0 && score <= 5) message = "猫を飛ばすだけの人%0a";
        else if (score >= 6 && score <= 15) message = "猫シューター%0a";
        else if (score >= 16 && score <= 25) message = "稀に見る猫使い%0a";
        else if (score >= 26 && score <= 40) message = "猫まっしぐらの猫人%0a";
        else if (score >= 41) message = "スーパー猫マスター%0a";

        string scoreUpdate = "";
        if (newText.gameObject.activeSelf) scoreUpdate = "ハイスコア更新!";

        string gameUrl = "https://globalgamejam.org/2019/games/%E3%81%AD%E3%81%93%E3%81%B1%E3%82%8B%E3%81%A8%EF%BC%88neko-pult%EF%BC%89";
        Application.OpenURL("https://twitter.com/intent/tweet?text=" + "GGJ2019作品ネコパルト%0a" + scoreUpdate + "最高ビル破壊数は" + highScoreText.text + "ビル%0a" + message  + gameUrl + "%0a" + "&hashtags=GGJ2019");
    }
}
