using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    //終了アクション
    bool isEndAction = false;

    [SerializeField]
    private Animation timeOverAnimation;

    [SerializeField]
    private Animation bulletNoAnimation;

    [SerializeField]
    private SoundChild soundChild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 条件満たしたら、エンドに行く
        if (GameManager.GetInstance().GetGameTime() <= 0.0f && GameManager.GetInstance().IsPerformance())
        {
            if (!isEndAction)
            {
                soundChild.oneshot = true;
                isEndAction = true;
                timeOverAnimation.Play();
            }
            else
            {
                //アニメーションが終わっている
                if (!timeOverAnimation.IsPlaying("DownGameOverText"))
                {
                    Cursor.visible = true;
                    SceneManager.LoadScene("Result");
                }
            }
        }
        else if (GameManager.GetInstance().GetBulletNum() <= 0)
        {
            if (!isEndAction)
            {
                soundChild.oneshot = true;
                isEndAction = true;
                bulletNoAnimation.Play();
            }
            else
            {
                //アニメーションが終わっている
                if (!bulletNoAnimation.IsPlaying("UpGameOverText"))
                {
                    Cursor.visible = true;
                    SceneManager.LoadScene("Result");
                }
            }
        }
    }

    // ゲームエンド
    /*
    private void aw()
    {
        
    }
    */

}
