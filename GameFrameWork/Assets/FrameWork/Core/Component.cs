using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 组件基类
    /// </summary>
    public class Component : MonoBehaviour
    {
        private void Awake()
        {
            this.OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        private void OnDestroy()
        {
            BeforOnDestroy();
        }

        protected virtual void OnAwake() { }

        protected virtual void OnStart() { }

        protected virtual void BeforOnDestroy() { }

    }
}
