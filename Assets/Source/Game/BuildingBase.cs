using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建物のベース
/// </summary>
public class BuildingBase : MonoBehaviour
{
    //補充される玉の数
    protected int recoveryBulletNum = 0;
    //耐久度
    protected int life=1;

    protected enum State
    {
        Alive,
        breaking,
        broken,
    };

    protected State state;

    [SerializeField]
    private GameObject particleObject;
    


    //初期化
    public void Init(int life, int bulletNum)
    {
        this.life = life;
        this.recoveryBulletNum = bulletNum;

    }

    /// <summary>
    /// 弾の数を増やす
    /// </summary>
    public void plusBulletNum()
    {
        GameManager.GetInstance().RecoveryBulletNum(recoveryBulletNum);
    }

    /// <summary>
    /// 破壊されているか
    /// </summary>
    /// <returns></returns>
    public bool IsBroken()
    {
        if (state == State.broken)
        {
            return false;
        }
        Debug.Log("life:" + life);
        return life <= 0;
    }

    public void DeleteHingeJointsChildren()
    {
        var hingeJoints = GetComponentsInChildren<HingeJoint>();
        
        foreach ( var hingeJoint in hingeJoints)
        {
            if (hingeJoint.connectedBody != null)
            {
                //Debug.Log("lllll" + hingeJoint.connectedBody.gameObject.name);
                Instantiate(particleObject, hingeJoint.connectedBody.position, Quaternion.identity);
                hingeJoint.connectedBody.gameObject.SetActive(false);
                hingeJoint.connectedBody = null;
                //
                
            }
        }
    }
    /// <summary>
    /// 回復できる弾の数を返す
    /// </summary>
    public int GetRecoveryBulletNum() { return recoveryBulletNum; }

    public int GetLife() { return life; }

    public bool IsStateBroken() { return (state == State.broken); }

    public void StateBroken() { state = State.broken; }
}
