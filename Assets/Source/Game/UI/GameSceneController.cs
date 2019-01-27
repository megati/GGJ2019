using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    //終了アクション
    bool isTimeEndAction = false;
    //
    bool isBulletEndAction = false;

    bool isBulletColutine = false;

    [SerializeField]
    private Animation timeOverAnimation;

    [SerializeField]
    private Animation bulletNoAnimation;

    [SerializeField]
    private SoundChild soundChild;

    // Start is called before the first frame update
    void Start()
    {
        isBulletEndAction = false;
        isTimeEndAction = false;
        isBulletColutine = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 条件満たしたら、エンドに行く
        if (GameManager.GetInstance().GetGameTime() <= 0.0f && GameManager.GetInstance().IsPerformance() && !isBulletEndAction)
        {
            if (!isTimeEndAction)
            {
                soundChild.oneshot = true;
                isTimeEndAction = true;
                timeOverAnimation.Play();
            }
        }
        if (GameManager.GetInstance().GetBulletNum() <= 0 && !isTimeEndAction)
        {
            if (!isBulletEndAction)
            {
                if (isBulletColutine == false) {
                    isBulletColutine = true;
                    StartCoroutine(test());
                }
            }
        }

        if (isBulletEndAction)
        {
            //アニメーションが終わっている
            if (!bulletNoAnimation.IsPlaying("UpGameOverText"))
            {
                Cursor.visible = true;
                SceneManager.LoadScene("Result");
            }
        }

        if (isTimeEndAction)
        {
            //アニメーションが終わっている
            if (!timeOverAnimation.IsPlaying("DownGameOverText"))
            {
                Cursor.visible = true;
                SceneManager.LoadScene("Result");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Result");
        }
    }
    IEnumerator test()
    {
        int bulletNum = GameManager.GetInstance().GetBulletNum();
        yield return new WaitForSeconds(4.0f);
        if (GameManager.GetInstance().GetBulletNum() == bulletNum)
        {
            soundChild.oneshot = true;
            isBulletEndAction = true;

            bulletNoAnimation.Play();
        }
        isBulletColutine = false;

        
    }

    // ゲームエンド
    /*
    private void aw()
    {
        
    }
    */

}
