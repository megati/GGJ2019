using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = false;
        Invoke("LogoScene", 2.0f);
    }


    void Update()
    {
        
    }

    public void LogoScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
