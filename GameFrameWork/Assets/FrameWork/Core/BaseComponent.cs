using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 基础组件基类
    /// </summary>
    public abstract class BaseComponent : Component
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterComponent(this);
        }

        public abstract void ShutDown();
    }
}
