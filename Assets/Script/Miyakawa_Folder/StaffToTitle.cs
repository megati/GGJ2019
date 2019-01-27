using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaffToTitle : MonoBehaviour
{

    void Start()
    {
        Invoke("StaffRollScene", 3.0f);
    }


    void Update()
    {
        
    }

    void StaffRollScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
