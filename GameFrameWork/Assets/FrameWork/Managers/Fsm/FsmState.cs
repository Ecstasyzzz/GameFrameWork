using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    public abstract class FsmState<T> where T : class
    {
        // 对应的状态机
        public Fsm<T> Fsm;

        // 进入
        public virtual void OnEnter() { }

        // update
        public virtual void OnUpdate() { }

        // 离开
        public virtual void OnLeave() { }

        // 销毁
        public virtual void OnDestory() { }
    }
}

