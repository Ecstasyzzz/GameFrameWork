using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    public abstract class VariableBase
    {
        /// <summary>
        /// 获取变量类型
        /// </summary>
        public abstract Type Type { get; }

        /// <summary>
        /// 引用计数
        /// </summary>
        public byte ReferenceCount { get; private set; }

        /// <summary>
        /// 保留对象
        /// </summary>
        public void Retain()
        {
            ReferenceCount++;
        }

        /// <summary>
        /// 移除
        /// </summary>
        public void Release()
        {
            ReferenceCount--;

            if (ReferenceCount <= 0)
            {
                GameEntry.PoolComponent.EnqueueVarObject(this);
            }
        }
    }
}

