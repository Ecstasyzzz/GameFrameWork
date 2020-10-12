using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameFramework
{
    /// <summary>
    /// 状态机管理器
    /// </summary>
    public class FsmManager : ManagerBase, IDisposable
    {
        // 状态机字典
        private Dictionary<int, FsmBase> fsmDic;

        public FsmManager()
        {
            fsmDic = new Dictionary<int, FsmBase>();
        }

        // 创建状态机
        public Fsm<T> CreatFsm<T>(int fsmId, T owner, FsmState<T>[] states) where T : class
        {
            Fsm<T> fsm = new Fsm<T>(fsmId, owner, states);
            fsmDic.Add(fsmId, fsm);
            return fsm;
        }

        // 销毁状态机
        public void DestoryFsm(int fsmId)
        {
            FsmBase fsm = null;

            if (fsmDic.TryGetValue(fsmId, out fsm))
            {
                fsm.ShunDown();
                fsmDic.Remove(fsmId);
            }
            else
            {
                Debug.Log("没找到对应的状态机");
            }
        }

        public void Dispose()
        {
            foreach (var item in fsmDic)
            {
                item.Value.ShunDown();
            }
            fsmDic.Clear();
        }
    }
}
