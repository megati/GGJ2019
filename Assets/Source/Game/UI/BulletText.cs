using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 残弾数
/// </summary>
public class BulletText : MonoBehaviour
{
    [SerializeField]
    private Text nekoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nekoText.text="残ネコ数:" + GameManager.GetInstance().GetBulletNum() + "匹";
    }
}
