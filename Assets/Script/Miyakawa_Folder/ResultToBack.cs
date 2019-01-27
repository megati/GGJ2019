using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultToBack : MonoBehaviour
{
    public bool ispush;
    [SerializeField] private SoundChild soundchild;

    void Start()
    {

    }


    void Update()
    {

    }

    public void BackToTitle()
    {
        soundchild.oneshot = true;
        if (ispush == false)
        {
            ispush = true;
            SceneManager.LoadScene("StaffRollScene");
            return;
        }
    }

    public void OnGameBckButton()
    {
        soundchild.oneshot = true;
        if (ispush == false)
        {
            ispush = true;
            SceneManager.LoadScene("GameScene");
            return;
        }
    }
}
