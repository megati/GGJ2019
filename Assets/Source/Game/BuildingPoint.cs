using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ビル生成場所管理
/// </summary>
public class BuildingPoint : MonoBehaviour
{
    [SerializeField]
    //生成場所番号
    private int number = 0;

    /// <summary>
    /// 生成場所番号を返す
    /// </summary>
    public int GetNumber() { return number; }
}
