using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 对象池组件
    /// </summary>
    public class PoolComponent : BaseComponent, IUpdateComponent
    {
        public PoolManager PoolManager { get; private set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            PoolManager = new PoolManager();
            GameEntry.RegisterUpdateComponent(this);

            nextClearTime = Time.time;
        }

        #region 变量对象池

#if UNITY_EDITOR
        public Dictionary<Type, int> VarObjectInpsectorDic = new Dictionary<Type, int>();
#endif

        // 取出一个变量对象
        public T DequeueVarObject<T>() where T : VariableBase, new()
        {
            T item = ClassObjectDequeue<T>();

#if UNITY_EDITOR
            Type t = item.GetType();

            if (VarObjectInpsectorDic.ContainsKey(t))
            {
                VarObjectInpsectorDic[t]++;
            }
            else
            {
                VarObjectInpsectorDic[t] = 1;
            }
#endif
            return item;
        }

        // 变量对象回池
        public void EnqueueVarObject<T>(T item) where T : VariableBase
        {
            ClassObjectEnqueue(item);

#if UNITY_EDITOR
            Type t = item.GetType();

            if (VarObjectInpsectorDic.ContainsKey(t))
            {
                VarObjectInpsectorDic[t]--;
                if (VarObjectInpsectorDic[t] == 0)
                {
                    VarObjectInpsectorDic.Remove(t);
                }
            }
#endif
        }

        #endregion

        #region 类对象池

        /// <summary>
        /// 取出一个对象
        /// </summary>
        public T ClassObjectDequeue<T>(params object[] args) where T : class, new()
        {
            return PoolManager.ClassObjectPool.Dequeue<T>(args);
        }

        /// <summary>
        /// 对象回池
        /// </summary>
        public void ClassObjectEnqueue(object obj)
        {
            PoolManager.ClassObjectPool.Enqueue(obj);
        }

        /// <summary>
        /// 设置类对象的常驻数量
        /// </summary>
        public void SetRetainCount<T>(byte count) where T : class
        {
            PoolManager.ClassObjectPool.SetRetainCount<T>(count);
        }

#endregion

        // 释放间隔
        [HideInInspector]
        public int clearInterval = 30;

        // 下次运行时间
        private float nextClearTime = 0f;

        public void OnUpdate()
        {
            if (Time.time > nextClearTime + clearInterval)
            {
                nextClearTime = Time.time;
                PoolManager.ClearClassObjectPool();
            }
        }

        // 对象池分组
        public GameObjectPoolEntity[] gameObjectPoolGroup;

        public override void ShutDown()
        {
            PoolManager.Dispose();
        }
    }
}
