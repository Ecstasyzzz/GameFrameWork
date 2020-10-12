using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 流程组件
    /// </summary>
    public class ProcedureComponent : BaseComponent, IUpdateComponent
    {
        private ProcedureManager procedureManager;

        /// <summary>
        /// 当前流程状态枚举
        /// </summary>
        public ProcedureState CurProcedureState
        {
            get { return procedureManager.CurProcedureState; }
        }

        /// <summary>
        /// 当前流程
        /// </summary>
        public FsmState<ProcedureManager> CurProcedure
        {
            get { return procedureManager.CurProcedure; }
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            procedureManager = new ProcedureManager();
            GameEntry.RegisterUpdateComponent(this);
        }

        protected override void OnStart()
        { 
            procedureManager.Init();
        }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <typeparam name="TData">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData<TData>(string key, TData value) where TData : VariableBase
        {
            procedureManager.CurFsm.SetData<TData>(key, value);
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TData GetData<TData>(string key)
        {
            return procedureManager.CurFsm.GetData<TData>(key);
        }

        public void OnUpdate()
        {
            procedureManager.OnUpdate();
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(ProcedureState state)
        {
            procedureManager.ChangeState(state);
        }

        public override void ShutDown()
        {
            procedureManager.Dispose();
        }
    }
}
