using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 类对象池，其中类有以下注意事项
    ///     1、使用前需要重置
    ///     2、不能使用带有参数的构造函数，会覆盖默认的构造函数
    /// </summary>
    public class ClassObjectPool : IDisposable
    {
        // 类对象池存储 以类型的hashcode为key
        private Dictionary<int, Queue<object>> dic;

        // 类对象常驻数量字典
        private Dictionary<int, byte> retainCountDic;

        // 属性
        public Dictionary<int, byte> RetainCountDic
        {
            get { return retainCountDic; }
        }

#if UNITY_EDITOR
        // 监视器面板信息
        public Dictionary<Type, int> InspectorDic = new Dictionary<Type, int>();
#endif

        public ClassObjectPool()
        {
            dic = new Dictionary<int, Queue<object>>();
            retainCountDic = new Dictionary<int, byte>();
        }

        /// <summary>
        /// 取出一个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns></returns>
        public T Dequeue<T>(params object[] args) where T : class
        {
            lock (dic)
            {
                int key = typeof(T).GetHashCode();

                Queue<object> queue = null;

                dic.TryGetValue(key, out queue);

                if (queue == null)
                {
                    queue = new Queue<object>();
                    dic.Add(key, queue);
                }

                if (queue.Count > 0)
                {
                    Debug.Log("对象" + key + "从池中获取");

#if UNITY_EDITOR
                    Type type = typeof(T);
                    if (InspectorDic.ContainsKey(type))
                    {
                        InspectorDic[type]--;
                    }
                    else
                    {
                        InspectorDic[type] = 0;
                    }
#endif

                    return (T)queue.Dequeue();
                }
                else
                {
                    Debug.Log("对象" + key + "不存在，进行实例化");
                    return (T)Activator.CreateInstance(typeof(T), args);
                }
            }
        }

        /// <summary>
        /// 对象回池
        /// </summary>
        /// <param name="obj"></param>
        public void Enqueue(object obj)
        {
            lock (dic)
            {
                int key = obj.GetType().GetHashCode();

                Queue<object> queue = null;

                dic.TryGetValue(key, out queue);

#if UNITY_EDITOR
                var type = obj.GetType();
                if (InspectorDic.ContainsKey(type))
                {
                    InspectorDic[type]++;
                }
                else
                {
                    InspectorDic[type] = 1;
                }
#endif

                if (queue != null)
                {
                    Debug.Log("对象" + key + "回池了");
                    queue.Enqueue(obj);
                }
            }
        }

        /// <summary>
        /// 设置类对象的常驻数量
        /// </summary>
        public void SetRetainCount<T>(byte count) where T : class
        {
            int key = typeof(T).GetHashCode();
            retainCountDic[key] = count;
        }

        /// <summary>
        /// 释放对象池
        /// </summary>
        public void Clear()
        {
            lock (dic)
            {
                Debug.Log("释放类对象池");
                List<int> keys = new List<int>(dic.Keys);

                int count = keys.Count;

                int queueCount = 0; // 对列数量

                for (int i = 0; i < count; i++)
                {
                    int key = keys[i];

                    Queue<object> queue = dic[key];

#if UNITY_EDITOR
                    Type type = null;
#endif

                    queueCount = queue.Count; // 当前对列中的数量

                    byte retainCount = 0; // 常驻数量
                    retainCountDic.TryGetValue(key, out retainCount);

                    while (queueCount > retainCount)
                    {
                        object obj = queue.Dequeue(); // 从对列中取出，这个对象没有任何引用，等待GC回收
                        queueCount--;

#if UNITY_EDITOR
                        type = obj.GetType();
                        InspectorDic[type]--;
#endif
                    }

                    if (queueCount == 0)
                    {
                        // 这里不清空池
                        //if (retainCount == 0)
                        //{
                        //    queue = null;
                        //    dic.Remove(key);
                        //}

#if UNITY_EDITOR
                        if (type != null)
                        {
                            InspectorDic.Remove(type);
                        }
#endif
                    }
                }

                // 整个项目中有且仅有一次
                GC.Collect();
            }
        }

        public void Dispose()
        {
            dic.Clear();
        }
    }
}

