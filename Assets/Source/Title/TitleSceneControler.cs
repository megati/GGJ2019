using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneControler : MonoBehaviour
{

    [SerializeField] private SoundChild soundChild;

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
        soundChild.oneshot = true;
        //GameManager.GetInstance().
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void OnGameEndButton()
    {
        soundChild.oneshot = true;
        Application.Quit();
    }

}
