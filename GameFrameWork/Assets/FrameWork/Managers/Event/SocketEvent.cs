using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameFramework
{
    /// <summary>
    /// socket 事件中心
    /// </summary>
    public class SocketEvent : IDisposable
    {
        // 触发事件的委托
        public delegate void OnActionHandler(byte[] buffer);

        // 事件对应的回调列表
        public Dictionary<ushort, List<OnActionHandler>> dic;

        // 构造
        public SocketEvent()
        {
            dic = new Dictionary<ushort, List<OnActionHandler>>();
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        /// <param name="key">消息id</param>
        /// <param name="handler">委托回调</param>
        public void AddEveneListener(ushort key, OnActionHandler handler)
        {
            List<OnActionHandler> handlerList = null;

            dic.TryGetValue(key, out handlerList);

            if (handlerList == null)
            {
                handlerList = new List<OnActionHandler>();
                dic.Add(key, handlerList);
            }

            handlerList.Add(handler);
        }

        /// <summary>
        /// 移除监听
        /// </summary>
        public void RemoveListener(ushort key, OnActionHandler handler)
        {
            List<OnActionHandler> handlerList = null;

            if (dic.TryGetValue(key, out handlerList))
            {
                handlerList.Remove(handler);

                if (handlerList.Count == 0) dic.Remove(key);
            }
            else
            {
                UnityEngine.Debug.Log(string.Format("key = %s的事件暂时没有绑定回调", key));
            }
        }

        /// <summary>
        /// 派发
        /// </summary>
        public void Dispatch(ushort key, byte[] buffer)
        {
            List<OnActionHandler> handlerList = null;

            if (dic.TryGetValue(key, out handlerList))
            {
                int listCount = handlerList.Count;

                for (int i = 0; i < listCount; i++)
                {
                    var handler = handlerList[i];
                    if (handler != null && handler.Target != null)
                    {
                        handler(buffer);
                    }
                }
            }
        }

        public void Dispatch(ushort key)
        {
            Dispatch(key, null);
        }

        public void Dispose()
        {
            dic.Clear();
        }
    }
}

