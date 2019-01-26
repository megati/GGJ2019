using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public void SetQuaternion(Quaternion quaternion)
    {
        this.transform.rotation = quaternion;
    }
}
