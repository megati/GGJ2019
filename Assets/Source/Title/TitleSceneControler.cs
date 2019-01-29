using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneControler : MonoBehaviour
{

    [SerializeField] private SoundChild soundChild;
    [SerializeField] private NekoFade nekoFade;

    enum TitleMove
    {
        RULE,
        END
    }

    TitleMove titleMove;

    // Start is called before the first frame update
    void Start(){
        nekoFade.StartFade(NekoFade.FADE_MODE.FADE_IN);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (nekoFade.GetFadeMode() == NekoFade.FADE_MODE.FADE_OUT_END)
        {
            if (titleMove == TitleMove.RULE) SceneManager.LoadScene("RuleScene");
            if (titleMove == TitleMove.END) Application.Quit();
        }
    }

    public void OnGameStartButton()
    {
        if (nekoFade.GetFadeMode() == NekoFade.FADE_MODE.FADE_OUT) return;

        soundChild.oneshot = true;
        titleMove = TitleMove.RULE;
        nekoFade.StartFade(NekoFade.FADE_MODE.FADE_OUT);
    }

    public void OnGameEndButton()
    {
        if (nekoFade.GetFadeMode() == NekoFade.FADE_MODE.FADE_OUT) return;

        soundChild.oneshot = true;
        titleMove = TitleMove.END;
        nekoFade.StartFade(NekoFade.FADE_MODE.FADE_OUT);
    }

}
