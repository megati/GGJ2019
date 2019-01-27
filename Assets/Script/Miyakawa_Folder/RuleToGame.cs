using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleToGame : MonoBehaviour
{
    public bool ispush;

    [SerializeField]
    private SoundChild soundchild;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void GoToGame()
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
