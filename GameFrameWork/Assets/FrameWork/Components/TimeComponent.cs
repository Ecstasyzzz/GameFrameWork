using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 时间组件
    /// </summary>
    public class TimeComponent : BaseComponent, IUpdateComponent
    {

        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);

            m_TimeManager = new TimeManager();
        }

        #region 定时器
        private TimeManager m_TimeManager;

        /// <summary>
        /// 注册定时器
        /// </summary>
        internal void RegisterTimeAction(TimeAction action)
        {
            m_TimeManager.RegisterTimeAction(action);
        }

        /// <summary>
        /// 移除定时器
        /// </summary>
        internal void RemoveTimeAction(TimeAction action)
        {
            m_TimeManager.RemoveTimeAction(action);
            GameEntry.PoolComponent.ClassObjectEnqueue(action);
        }

        public TimeAction CreateTimeAction()
        {
            return GameEntry.PoolComponent.ClassObjectDequeue<TimeAction>();
        }

        #endregion

        public void OnUpdate()
        {
            //Debug.Log("时间组件update");
            m_TimeManager.OnUpdate();
        }

        public override void ShutDown()
        {
            m_TimeManager.Dispose();
        }
    }
}

