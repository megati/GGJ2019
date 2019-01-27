using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleToGame : MonoBehaviour
{
    public bool ispush;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void GoToGame()
    {
        if (ispush == false)
        {
            ispush = true;
            SceneManager.LoadScene("GameScene");
            return;
        }
    }
}
