using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 建物撃破数の表示
/// </summary>
public class BreakBuildingText : MonoBehaviour
{
    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "建物破壊数：" + GameManager.GetInstance().GetBreakBuildingCount().ToString();
    }
}
