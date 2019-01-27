using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 大砲処理
/// </summary>
public class Cannon : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField]
    //次が打てるまでの時間
    private float coolTime = 1.0f;
    [SerializeField]
    // カメラの回転速度を格納する変数
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.1f);
    [SerializeField]
    //大砲が右に向く角度
    private float maxSideAngle = -60.0f;
    [SerializeField]
    //大砲が左に向く角度
    private float minSideAngle = -120.0f;
    [SerializeField]
    //大砲が上がる最大角度
    private float maxUpAngle = 50.0f;
    [SerializeField]
    //大砲が上がる最小角度
    private float minDownAngle = 0;

    [Header("Object")]
    [SerializeField]
    //弾のオブジェクト
    private BulletBase bulletObject=null;

    [Header("Angle")]
    [SerializeField]
    //縦の角度
    private Transform lengthAngle;


    //弾がうてるまでのリロード時間
    private float reloadTime=0.0f;

    // マウス座標を格納する変数
    private Vector2 lastMousePosition;
    // カメラの角度を格納する変数（初期値に0,0を代入）
    private Vector2 newAngle = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        lastMousePosition = Input.mousePosition;
        //カーソルをウィンドウ内に
        Cursor.lockState = CursorLockMode.Confined;

        //初期化
        maxSideAngle = transform.eulerAngles.y + 30;
        minSideAngle = transform.eulerAngles.y - 30;
        maxUpAngle = lengthAngle.eulerAngles.z + 50;
        minDownAngle = lengthAngle.eulerAngles.z;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //演出中なら
        if (GameManager.GetInstance().IsPerformance()) return;

        //撃った後はクールタイム
        if (reloadTime > 0.0f)
        {
            reloadTime -= 1.0f * Time.deltaTime;
        }
        else
        {
            //動かす
            Move();

            //クリックで弾を飛ばす
            if (Input.GetMouseButtonDown(0))
            {
                reloadTime = coolTime;
                GameManager.GetInstance().CutBackBulletNum();
                //オブジェクトを生成
                if (bulletObject != null)
                {
                    Vector3 lockPosition = this.transform.position + (lengthAngle.transform.forward * 3);
                    lockPosition.y = this.transform.position.y;
                    //Quaternion rotate = Quaternion.LookRotation( lockPosition, Vector3.up );
                    var rotate = lengthAngle.transform.GetChild(0).rotation;

                    BulletBase bullet = Instantiate(bulletObject, gameObject.transform.position, rotate) as BulletBase;
                    //bullet.SetQuaternion();
                }
                else
                {
                    Debug.LogError("No Object Bullet.");
                }
            }
        }
    }

    /// <summary>
    /// 動かす
    /// </summary>
    private void Move()
    {
        // Y軸の回転：マウスドラッグ方向に視点回転
        // マウスの水平移動値に変数"rotationSpeed"を掛ける
        //（座標とマウス座標の現在値の差分値）
        transform.eulerAngles =new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y, transform.eulerAngles.z);
        // X軸の回転：マウスドラッグ方向に視点回転
        // マウスの垂直移動値に変数"rotationSpeed"を掛ける
        //（クリック時の座標とマウス座標の現在値の差分値）
        lengthAngle.eulerAngles = new Vector3(lengthAngle.eulerAngles.x, lengthAngle.eulerAngles.y, lengthAngle.eulerAngles.z + (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x);
        // マウス座標を変数"lastMousePosition"に格納
        lastMousePosition = Input.mousePosition;
        //補正
        if (transform.eulerAngles.y > maxSideAngle) transform.eulerAngles = new Vector3(transform.eulerAngles.x, maxSideAngle, transform.eulerAngles.z);
        if (transform.eulerAngles.y < minSideAngle) transform.eulerAngles = new Vector3(transform.eulerAngles.x, minSideAngle, transform.eulerAngles.z);
        if (lengthAngle.eulerAngles.z > maxUpAngle) lengthAngle.eulerAngles = new Vector3(lengthAngle.eulerAngles.x, lengthAngle.eulerAngles.y, maxUpAngle);
        if (lengthAngle.eulerAngles.z < minDownAngle) lengthAngle.eulerAngles = new Vector3(lengthAngle.eulerAngles.x, lengthAngle.eulerAngles.y, minDownAngle);
    }
}
