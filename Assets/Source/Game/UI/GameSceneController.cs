using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 条件満たしたら、エンドに行く
        GameManager.GetInstance().GameEnd();
    }

    // ゲームエンド
    /*
    private void aw()
    {
        
    }
    */

}
