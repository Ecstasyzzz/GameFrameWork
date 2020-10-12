using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 事件组件
    /// </summary>
    public class EventComponent : BaseComponent
    {
        private EventManager m_EventManager;

        // socket事件中心
        public SocketEvent SocketEvent
        {
            get; private set;
        }

        // 通用事件中心
        public CommonEvent CommonEvent
        {
            get; private set;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            m_EventManager = new EventManager();
            SocketEvent = m_EventManager.SocketEvent;
            CommonEvent = m_EventManager.CommonEvent;
        }

        public override void ShutDown()
        {
            m_EventManager.Dispose();
            Debug.Log("关闭事件组件");
        }
    }
}
