using PathologicalGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 对象池实体
    /// </summary>
    [Serializable]
    public class GameObjectPoolEntity
    {
        // 对象池编号
        public byte ID;

        // 对象池名字
        public string Name;

        // 是否开启缓存池自动清理
        public bool CullDespawned = true;

        // 保留对象数量
        public int CullAbove;

        // 多久清理一次
        public int CullDelay;

        // 每次清理几个
        public int CullMaxPerPase;

        // 对应的游戏物体对象池
        public SpawnPool Pool;
    }
}

