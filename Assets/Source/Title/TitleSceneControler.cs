using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameStartButton()
    {
        //GameManager.GetInstance().
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    public void OnGameEndButton()
    {
        Application.Quit();
    }

}
