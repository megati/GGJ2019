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

    [SerializeField]
    private Animation cameraAnimation;

    //生成した建物情報リスト
    private List<BuildingBase> createBuildingList = new List<BuildingBase>();

    bool isEffect = false;

    float pointY = 0;

    // Start is called before the first frame update
    void Start()
    {
        //最初は１番目のステージ
        foreach (var buildingData in stageDataList[0].GetBuildingDataList())
        {
            Transform point = GetPointTransform(buildingData.number);
            if (point == null) continue;
            pointY = point.position.y;
            var obj = Instantiate(buildingObjectList[(int)buildingData.createNumber], point) as GameObject;
            obj.transform.localScale = buildingObjectList[(int)buildingData.createNumber].transform.localScale;
            obj.transform.position = point.transform.position;
            var building = obj.GetComponent<BuildingBase>();
            building.Init(buildingData.life, buildingData.recoveryBulletNum);
            createBuildingList.Add(building);
        }
    }

    bool isAllBroken = false;
    // Update is called once per frame
    void Update()
    {
        if (!isEffect)
        {
            isAllBroken = true;
            foreach (var createBuilding in createBuildingList)
            {
                if (!createBuilding.IsStateBroken()) isAllBroken = false;
            }
        }

        //全部破壊
        if (isAllBroken)
        {
            if (!isEffect)
            {
                GameManager.GetInstance().Performance(true);
                cameraAnimation.Play();
                RandomStageCreate();
                //StartCoroutine(YurasuAnimation());
            }
            isEffect = true;
        }

        if (isEffect)
        {
            Debug.Log("check");
            if (!cameraAnimation.IsPlaying("Yurasu"))
            {
                Debug.Log("Hit");
                foreach (var createBuilding in createBuildingList)
                {
                    createBuilding.gameObject.transform.position = new Vector3(createBuilding.gameObject.transform.position.x, pointY, createBuilding.gameObject.transform.position.z);
                }
                GameManager.GetInstance().Performance(false);
                isEffect = false;
            }
        }
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

    /// <summary>
    /// 生成する場所のトランスフォームを返す
    /// </summary>
    void RandomStageCreate()
    {
        foreach (var createBuilding in createBuildingList) { Destroy(createBuilding.gameObject); }
        createBuildingList.Clear();

        foreach (var buildingData in stageDataList[Random.Range(0, stageDataList.Count)].GetBuildingDataList())
        {
            Transform point = GetPointTransform(buildingData.number);
            if (point == null) continue;
            var obj = Instantiate(buildingObjectList[(int)buildingData.createNumber], point) as GameObject;
            obj.transform.localScale = buildingObjectList[(int)buildingData.createNumber].transform.localScale;
            obj.transform.position = point.transform.position + new Vector3(0,-5.0f,0);
            var building = obj.GetComponent<BuildingBase>();
            building.Init(buildingData.life, buildingData.recoveryBulletNum);
            createBuildingList.Add(building);
        }
    }

    private float animationTime = 0;
    private float buildMoveY = 0;
    float buildSpeedY = 1.0f;
    /// <summary>
    /// ゆらすアニメーション
    /// </summary>
    /// <returns></returns>
    private IEnumerator YurasuAnimation()
    {
        Vector3 firstPosition = createBuildingList[0].transform.position;

        while (createBuildingList[0].transform.position.y < pointY)
        {
            foreach (var createBuilding in createBuildingList)
            {
                createBuilding.transform.position = firstPosition + new Vector3(Mathf.Sin(Mathf.Rad2Deg * animationTime) * 1, buildMoveY);

                animationTime += Time.deltaTime;
                buildMoveY -= buildSpeedY * Time.deltaTime;
                if (animationTime > 1) animationTime = 0;
            }
            
            yield return null;
        }

        isEffect = false;
        yield return null;
    }
}