using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    public abstract class FsmBase
    {
        // 状态机编号
        public int FsmId { get; private set; }

        // 状态机拥有者
        public Type Owner { get; private set; }

        // 当前状态类型
        public byte curStateType;

        public FsmBase(int fsmId)
        {
            FsmId = fsmId;
        }

        // 关闭状态机
        public abstract void ShunDown();
    }
}

