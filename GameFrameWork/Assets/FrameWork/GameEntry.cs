using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework 
{
    public class GameEntry : MonoBehaviour
    {
        #region 组件属性

        public static DataComponent DataComponent { get; private set; }

        public static DataTableComponent DataTableComponent { get; private set; }

        public static DownloadComponent DownloadComponent { get; private set; }

        public static EventComponent EventComponent { get; private set; }

        public static FsmComponent FsmComponent { get; private set; }

        public static GameObjectComponent GameObjectComponent { get; private set; }

        public static HttpComponent HttpComponent { get; private set; }

        public static LocalizationComponent LocalizationComponent { get; private set; }

        public static PoolComponent PoolComponent { get; private set; }

        public static ProcedureComponent ProcedureComponent { get; private set; }

        public static ResourceComponent ResourceComponent { get; private set; }

        public static SceneComponent SceneComponent { get; private set; }

        public static SettingComponent SettingComponent { get; private set; }

        public static SocketComponent SocketComponent { get; private set; }

        public static TimeComponent TimeComponent { get; private set; }

        public static UIComponent UIComponent { get; private set; }


        #endregion

        #region 基础组件管理
        /// <summary>
        /// 基础组件列表
        /// </summary>
        private static readonly LinkedList<BaseComponent> m_baseComponentList = new LinkedList<BaseComponent>();

        /// <summary>
        /// 注册组件
        /// </summary>
        /// <param name="component"></param>
        internal static void RegisterComponent(BaseComponent component)
        {
            if (m_baseComponentList.Contains(component))
            {
                Debug.Log("不可重复添加组件" + component.GetType().ToString());
                return;
            }
            m_baseComponentList.AddLast(component);
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <param name="component"></param>
        internal static BaseComponent GetBaseComponent(Type type)
        {
            LinkedListNode<BaseComponent> curr = m_baseComponentList.First;

            while (curr != null)
            {
                if (curr.Value.GetType() == type)
                {
                    return curr.Value;
                }
                curr = curr.Next;
            }

            Debug.Log(string.Format("没有找到指定类型type=%s组件，请先注册", type.ToString()));

            return null;
        }

        internal static T GetBaseComponent<T>() where T : BaseComponent
        {
            return (T)GetBaseComponent(typeof(T));
        }

        #endregion

        #region update组件管理

        /// <summary>
        /// 基础组件列表
        /// </summary>
        private static readonly LinkedList<IUpdateComponent> m_updateComponentList = new LinkedList<IUpdateComponent>();

        /// <summary>
        /// 注册update组件
        /// </summary>
        /// <param name="component"></param>
        public static void RegisterUpdateComponent(IUpdateComponent component)
        {
            m_updateComponentList.AddLast(component);
        }

        /// <summary>
        /// 移除update组件  TODO:这里有问题，一边update遍历，一边移除可能会有问题。应该先把需要移除的加入到列表中。在update中移除。
        /// </summary>
        /// <param name="component"></param>
        public static void RemoveUpdateComponent(IUpdateComponent component)
        {
            m_updateComponentList.Remove(component);
        }

        #endregion


        private static void InitBaseComponent()
        {
            DataComponent = GetBaseComponent<DataComponent>();
            DataTableComponent = GetBaseComponent<DataTableComponent>();
            DownloadComponent = GetBaseComponent<DownloadComponent>();
            EventComponent = GetBaseComponent<EventComponent>();
            FsmComponent = GetBaseComponent<FsmComponent>();
            GameObjectComponent = GetBaseComponent<GameObjectComponent>();
            HttpComponent = GetBaseComponent<HttpComponent>();
            LocalizationComponent = GetBaseComponent<LocalizationComponent>();
            PoolComponent = GetBaseComponent<PoolComponent>();
            ProcedureComponent = GetBaseComponent<ProcedureComponent>();
            ResourceComponent = GetBaseComponent<ResourceComponent>();
            SceneComponent = GetBaseComponent<SceneComponent>();
            SettingComponent = GetBaseComponent<SettingComponent>();
            SocketComponent = GetBaseComponent<SocketComponent>();
            TimeComponent = GetBaseComponent<TimeComponent>();
            UIComponent = GetBaseComponent<UIComponent>();
        }

        void Start()
        {
            InitBaseComponent();
        }

        // Update is called once per frame
        void Update()
        {
            // 循环update组件
            for(LinkedListNode<IUpdateComponent> curr = m_updateComponentList.First; curr != null; curr = curr.Next)
            {
                curr.Value.OnUpdate();
            }
        }

        void OnDestroy()
        {
            // 关闭所有基础组件
            for (LinkedListNode<BaseComponent> curr = m_baseComponentList.First; curr != null; curr = curr.Next)
            {
                curr.Value.ShutDown();
            }
        }
    }
}
