using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの建物作成情報
/// </summary>
public class StageData : MonoBehaviour
{
    //ビル生成時の生成データ
    [System.Serializable]
    public struct BuildingData
    {
        public int number;
        public ModelType createNumber;
        public int recoveryBulletNum;
        public int life;
    }

    //ビルのタイプ
    public enum ModelType
    {
        NOMAL_HIGH = 0,
        NOMAL_MIDDLE = 1,
        NOMAL_LOW = 2
    };

    [SerializeField]
    //生成データ
    private List<BuildingData> buildingDataList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// ステージの作成データ
    /// </summary>
    /// <returns></returns>
    public List<BuildingData> GetBuildingDataList() { return buildingDataList; }
}
