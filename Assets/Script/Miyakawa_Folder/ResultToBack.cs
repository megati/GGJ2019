using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultToBack : MonoBehaviour
{
    public bool ispush;

    void Start()
    {

    }


    void Update()
    {

    }

    public void BackToTitle()
    {
        if (ispush == false)
        {
            ispush = true;
            SceneManager.LoadScene("StaffRollScene");
            return;
        }
    }

    public void OnGameBckButton()
    {
        if (ispush == false)
        {
            ispush = true;
            SceneManager.LoadScene("GameScene");
            return;
        }
    }
}
