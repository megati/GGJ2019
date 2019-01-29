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

    [SerializeField]
    private NekoFade nekoFade;

    bool isGameStart = false;
    bool isResultMove = false;

    // Start is called before the first frame update
    void Start()
    {
        nekoFade.StartFade(NekoFade.FADE_MODE.FADE_IN);

        isBulletEndAction = false;
        isTimeEndAction = false;
        isBulletColutine = false;
    }

    // Update is called once per frame
    void Update()
    {
        //タイトル演出
        if (nekoFade.GetFadeMode() == NekoFade.FADE_MODE.FADE_IN_END && !isGameStart)
        {
            GameManager.GetInstance().Performance(false);
            isGameStart = true;
        }

        //リザルトいく演出
        if (isResultMove)
        {
            if(nekoFade.GetFadeMode()==NekoFade.FADE_MODE.FADE_OUT_END) SceneManager.LoadScene("Result");
            return;
        }

        // 条件満たしたら、エンドに行く
        if (GameManager.GetInstance().GetGameTime() <= 0.0f && GameManager.GetInstance().IsPerformance() && !isBulletEndAction)
        {
            if (!isTimeEndAction)
            {
                soundChild.oneshot = true;
                isTimeEndAction = true;
                timeOverAnimation.Play();
                GameManager.GetInstance().Performance(true);
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
                isResultMove = true;
                GameManager.GetInstance().Performance(true);
                nekoFade.StartFade(NekoFade.FADE_MODE.FADE_OUT);
            }
        }

        if (isTimeEndAction)
        {
            //アニメーションが終わっている
            if (!timeOverAnimation.IsPlaying("DownGameOverText"))
            {
                Cursor.visible = true;
                isResultMove = true;
                GameManager.GetInstance().Performance(true);
                nekoFade.StartFade(NekoFade.FADE_MODE.FADE_OUT);
            }
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
            GameManager.GetInstance().Performance(true);
        }
        isBulletColutine = false;

        
    }

    /// <summary>
    /// ゲームスタート演出
    /// </summary>
    void GameStartEffect()
    {

    }

    // ゲームエンド
    /*
    private void aw()
    {
        
    }
    */

}
