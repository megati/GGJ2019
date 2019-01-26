using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleChange : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GameEnd()
    {

    }
}
