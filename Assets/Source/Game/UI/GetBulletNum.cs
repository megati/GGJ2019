using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ビルに表示する入手できる弾の数
/// </summary>
public class GetBulletNum : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> numberList;
    [SerializeField]
    private SpriteRenderer tenNumber;
    [SerializeField]
    private SpriteRenderer oneNumber;
    [SerializeField]
    private BuildingBase buildingBase;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        tenNumber.sprite = numberList[buildingBase.GetRecoveryBulletNum()/10];
        oneNumber.sprite = numberList[buildingBase.GetRecoveryBulletNum()%10];
    }
}
