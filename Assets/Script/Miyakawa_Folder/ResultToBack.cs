using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultToBack : MonoBehaviour
{
    public bool ispush;
    [SerializeField] private SoundChild soundchild;
    [SerializeField] private NekoFade nekoFade;

    enum ResultMove
    {
        RETRY,
        TITLE
    }

    ResultMove resultMove;

    void Start()
    {

    }


    void Update()
    {
        if (ispush && nekoFade.GetFadeMode() == NekoFade.FADE_MODE.FADE_OUT_END)
        {
            if(resultMove == ResultMove.TITLE) SceneManager.LoadScene("StaffRollScene");
            if(resultMove == ResultMove.RETRY) SceneManager.LoadScene("GameScene");
        }
    }

    public void BackToTitle()
    {
        if (ispush == false)
        {
            soundchild.oneshot = true;
            ispush = true;
            resultMove = ResultMove.TITLE;
            nekoFade.StartFade(NekoFade.FADE_MODE.FADE_OUT);
            return;
        }
    }

    public void OnGameBckButton()
    {
        if (ispush == false)
        {
            soundchild.oneshot = true;
            ispush = true;
            resultMove = ResultMove.RETRY;
            nekoFade.StartFade(NekoFade.FADE_MODE.FADE_OUT);
            return;
        }
    }
}
