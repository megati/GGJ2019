using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public Text Building;
    public int breakCount;

    void Start()
    {
        Initialize();
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) { SceneManager.LoadScene("Result"); }
        breakCount = GameManager.GetInstance().GetBreakBuildingCount();
        var asd = GameManager.GetInstance();
        asd.GetBreakBuildingCount();
        
        Building.text = breakCount.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Initialize();
        }
    }

    private void Initialize()
    {
        breakCount = 0;
    }
}
