using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NekoFade : MonoBehaviour
{
    public enum FADE_MODE
    {
        FADE_IN,
        FADE_IN_END,
        FADE_OUT,
        FADE_OUT_END,
        MAX
    };

    private FADE_MODE mode = FADE_MODE.MAX;

    [SerializeField]
    private Image texture;
    [SerializeField]
    private Animator fadeAnimation;

    private float alpha = 0;
    [SerializeField]
    private float fadeTimer = 0;
    [SerializeField]
    private float counter = 0;

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case FADE_MODE.FADE_IN:
                counter += Time.deltaTime;

                texture.color = new Color(0, 0, 0, 1 - (counter / fadeTimer));

                if (counter >= fadeTimer)
                {
                    texture.color = new Color(0, 0, 0, 0);
                    mode = FADE_MODE.FADE_IN_END;
                }
                break;

            case FADE_MODE.FADE_OUT:
                counter += Time.deltaTime;

                texture.color = new Color(0, 0, 0, counter / fadeTimer);

                if (counter >= fadeTimer)
                {
                    texture.color = new Color(0, 0, 0, 1);
                    mode = FADE_MODE.FADE_OUT_END;
                }
                break;
        }
    }

    /// <summary>
    /// フェードする
    /// </summary>
    /// <param name="Mode">フェードのモード</param>
    /// <param name="time">フェードの時間</param>
    public void StartFade(FADE_MODE Mode)
    {
        mode = Mode;
        fadeTimer = 2f;
        counter = 0;
        if (Mode != FADE_MODE.FADE_IN) fadeAnimation.SetTrigger("IsOut");
    }

    /// <summary>
    /// フェード状態
    /// </summary>
    /// <returns></returns>
    public FADE_MODE GetFadeMode()
    {
        return mode;
    }
}
