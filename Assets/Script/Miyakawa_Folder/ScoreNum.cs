using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreNum : MonoBehaviour
{
    public Text Score;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
    
    void Update()
    {
        
    }
}
