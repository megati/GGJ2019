﻿using System.Collections;
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
}
