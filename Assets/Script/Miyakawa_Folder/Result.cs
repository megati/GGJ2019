using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{

    void Start()
    {
        int resultbreakBuildingCount = GameManager.GetInstance().GetBreakBuildingCount();
    }


    void Update()
    {
        
    }
}
