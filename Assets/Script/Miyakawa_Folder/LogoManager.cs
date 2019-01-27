using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{

    void Start()
    {
        Invoke("LogoScene", 3.0f);
    }


    void Update()
    {
        
    }

    public void LogoScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
