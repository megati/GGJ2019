using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ビル作成管理
/// </summary>
public class BuildingController : MonoBehaviour
{
    [SerializeField]
    //生成するオブジェクト
    private List<GameObject> buildingObjectList;

    [SerializeField]
    //生成ポイント
    private List<BuildingPoint> pointList;

    [SerializeField]
    //ステージの建物作成データ
    private List<StageData> stageDataList;

    //生成した建物情報リスト
    private List<BuildingBase> createBuildingList=new List<BuildingBase>();

    

    // Start is called before the first frame update
    void Start()
    {
        //最初は１番目のステージ
        foreach (var buildingData in stageDataList[0].GetBuildingDataList())
        {
            Transform point = GetPointTransform(buildingData.number);
            if (point==null) continue;
            var obj = Instantiate(buildingObjectList[(int)buildingData.createNumber], point) as GameObject;
            obj.transform.localScale = new Vector3(1,1,1);
            var building = obj.GetComponent<BuildingBase>();
            building.Init(buildingData.life, buildingData.recoveryBulletNum);
            createBuildingList.Add(building);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 生成する場所のトランスフォームを返す
    /// </summary>
    /// <param name="number">生成場所</param>
    private Transform GetPointTransform(int number)
    {
        foreach (var point in pointList)
        {
            if (point.GetNumber() == number) return point.gameObject.transform;
        }

        Debug.LogError("No building point. number=" + number);

        return null;
    }
}
