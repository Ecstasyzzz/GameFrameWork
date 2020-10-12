using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameFramework
{
    /// <summary>
    /// 时间管理器
    /// </summary>
    public class TimeManager : ManagerBase, IDisposable
    {
        // 定时器列表
        private LinkedList<TimeAction> m_TimeActionList;

        public TimeManager()
        {
            m_TimeActionList = new LinkedList<TimeAction>();
        }

        /// <summary>
        /// 注册定时器
        /// </summary>
        internal void RegisterTimeAction(TimeAction action)
        {
            m_TimeActionList.AddLast(action);
        }

        /// <summary>
        /// 移除定时器
        /// </summary>
        internal void RemoveTimeAction(TimeAction action)
        {
            m_TimeActionList.Remove(action);
        }

        public void OnUpdate()
        {
            for(var curr = m_TimeActionList.First; curr != null; curr = curr.Next)
            {
                curr.Value.OnUpdate();
            }
        }

        public void Dispose()
        {
            m_TimeActionList.Clear();
        }
    }
}