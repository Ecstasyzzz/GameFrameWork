using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// UI组件
    /// </summary>
    public class UIComponent : BaseComponent, IUpdateComponent
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
        }

        public void OnUpdate()
        {
        }

        public override void ShutDown()
        {
        }
    }
}
