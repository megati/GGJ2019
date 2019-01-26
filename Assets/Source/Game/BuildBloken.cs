using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建物破壊演出
/// </summary>
public class BuildBloken : MonoBehaviour
{

    [SerializeField]
    private GameObject build = null;

    [SerializeField]
    private AnimationCurve animationCurveX = null;

    [SerializeField]
    private ParticleSystem particle = null;

    [SerializeField]
    //爆発地点
    private Transform explosion;
    [SerializeField]
    //ビルの一番上
    private Transform buildingTop;

    [SerializeField]
    //ビル情報
    private BuildingBase buildingBase;

    private Vector3 firstPosition = new Vector3();
    private float animationTime = 0;
    private float buildMoveY = 0;
   
    const float buildSpeedY = 2;


    // Start is called before the first frame update
    void Start()
    {
        firstPosition = build.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z)) OnBloken();
    }

    /// <summary>
    /// 破壊
    /// </summary>
    public void OnBloken()
    {
        //particle.Play(true);
        StartCoroutine(StartBlokenAnimation());
    }

    /// <summary>
    /// 落下アニメーション
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartBlokenAnimation()
    {
        GameObject aoki=Instantiate(particle.gameObject, explosion,false) as GameObject;
        aoki.transform.position -= new Vector3(0,0.5f,0);
        ParticleSystem particleSystem= aoki.GetComponent<ParticleSystem>();
        particleSystem.Play();

        //ビルの破壊数をカウント
        GameManager.GetInstance().plusBreakBuildingCount();

        while (explosion.transform.position.y < buildingTop.position.y) {
            //build.transform.position = firstPosition + new Vector3(animationCurveX.Evaluate(animationTime), buildMoveY);
            build.transform.position = firstPosition + new Vector3(Mathf.Sin(Mathf.Rad2Deg*animationTime) * 1, buildMoveY);

            animationTime += Time.deltaTime;
            buildMoveY -= buildSpeedY * Time.deltaTime;
            if (animationTime > 1) animationTime = 0;
            yield return null;
        }
        particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //猫カウント
        buildingBase.plusBulletNum();

        yield return null;

    }

}
