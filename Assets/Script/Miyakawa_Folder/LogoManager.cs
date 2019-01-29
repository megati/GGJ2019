using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{
    [SerializeField]
    private Fade fade;

    bool isMove = false;

    void Start()
    {
        fade.StartFade(Fade.FADE_MODE.FADE_IN,2);
        Cursor.visible = false;
        Invoke("LogoScene", 4.0f);
    }


    void Update()
    {
        if (fade.GetFadeMode() == Fade.FADE_MODE.FADE_OUT_END && !isMove)
        {
            isMove = true;
            Invoke("TitleMove", 1.5f);
        }
    }

    public void LogoScene()
    {
        if (fade.GetFadeMode() == Fade.FADE_MODE.FADE_IN_END) fade.StartFade(Fade.FADE_MODE.FADE_OUT, 2);
    }

    private void TitleMove()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
