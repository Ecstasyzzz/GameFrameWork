using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 章节表表实体
/// </summary>
public class ChapterEntity : DataTableEntityBase
{
    /// <summary>
    /// 章名称
    /// </summary>
    public string ChapterName;

    /// <summary>
    /// 拥有的关卡个数
    /// </summary>
    public int GameLevelCount;

    /// <summary>
    /// 背景图
    /// </summary>
    public string BG_Pic;

    /// <summary>
    /// Uvx
    /// </summary>
    public float Uvx;

    /// <summary>
    /// Uvy
    /// </summary>
    public float Uvy;
}
