using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameFramework
{
    /// <summary>
    /// 对象池管理器
    /// </summary>
    public class PoolManager : ManagerBase, IDisposable
    {
        public ClassObjectPool ClassObjectPool { get; private set; }

        public PoolManager()
        {
            ClassObjectPool = new ClassObjectPool();
        }

        public void ClearClassObjectPool()
        {
            ClassObjectPool.Clear();
        }

        public void Dispose()
        {
            ClassObjectPool.Dispose();
        }
    }
}