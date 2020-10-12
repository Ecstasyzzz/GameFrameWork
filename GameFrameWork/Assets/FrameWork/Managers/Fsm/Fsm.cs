using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace GameFramework
{
    public class Fsm<T> : FsmBase where T : class
    {
        // 当前状态
        private FsmState<T> curState;

        // 状态字典
        private Dictionary<byte, FsmState<T>> statesDic;

        // 参数字典 这里的参数什么时候释放（暂且认为是状态机销毁的时候才进行释放）
        private Dictionary<string, VariableBase> paramDic;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fsmId">状态机编号</param>
        /// <param name="owner">拥有者</param>
        /// <param name="states">状态数组</param>
        public Fsm(int fsmId, T owner, FsmState<T>[] states) : base(fsmId)
        {
            statesDic = new Dictionary<byte, FsmState<T>>();
            paramDic = new Dictionary<string, VariableBase>();

            int len = states.Length;
            for (int i = 0; i < len; i++)
            {
                var statu = states[i];
                statu.Fsm = this;
                statesDic[(byte)i] = statu;
            }

            curStateType = 0;
            curState = statesDic[1];
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        public FsmState<T> GetState(byte statuType)
        {
            FsmState<T> state = null;
            statesDic.TryGetValue(statuType, out state);
            return state;
        }

        // 刷新
        public void OnUpdate()
        { 
            if (curState != null)
            {
                curState.OnUpdate();
            }
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="newStateType"></param>
        public void ChangeState(byte newStateType)
        {
            if (curStateType == newStateType) return; // 不允许重复进入相同的状态

            if (curState != null)
            {
                curState.OnLeave();
            }

            curStateType = newStateType;
            curState = statesDic[curStateType];
            curState.OnEnter();
        }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <typeparam name="TData">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData<TData>(string key, TData value) where TData : VariableBase
        {
            VariableBase variableBase = null;

            if (paramDic.TryGetValue(key, out variableBase))
            {
                Variable<TData> variable = variableBase as Variable<TData>;
                variable.Value = value;
                paramDic[key] = variable;
            }
            else
            {
                Variable<TData> variable = new Variable<TData>();
                variable.Value = value;
                paramDic[key] = variable;
            }
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TData GetData<TData>(string key)
        {
            VariableBase variableBase = null;

            if (paramDic.TryGetValue(key, out variableBase))
            {
                Variable<TData> variable = variableBase as Variable<TData>;
                return variable.Value;
            }

            return default(TData);
        }

        /// <summary>
        /// 停止状态机
        /// </summary>
        public override void ShunDown()
        {
            if (curState != null)
            {
                curState.OnLeave();
            }

            foreach (var item in statesDic)
            {
                item.Value.OnDestory();
            }

            statesDic.Clear();
            paramDic.Clear();
        }
    }
}

