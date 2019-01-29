using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleToGame : MonoBehaviour
{
    public bool ispush;

    [SerializeField]
    private NekoFade nekoFade;

    //[SerializeField]
    //private SoundChild soundchild;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GoToGame();
        }
        if (ispush && nekoFade.GetFadeMode() == NekoFade.FADE_MODE.FADE_OUT_END)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void GoToGame()
    {
        //soundchild.oneshot = true;
        if (ispush == false)
        {
            ispush = true;
            nekoFade.StartFade(NekoFade.FADE_MODE.FADE_OUT);
            return;
        }
    }
}
