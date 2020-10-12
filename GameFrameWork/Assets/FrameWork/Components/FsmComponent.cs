using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    /// <summary>
    /// 状态机组件
    /// </summary>
    public class FsmComponent : BaseComponent
    {
        private int testFsmId = 0;

        private FsmManager fsmManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            fsmManager = new FsmManager();
        }

        /// <summary>
        /// 创建状态机
        /// </summary>
        public Fsm<T> CreatFsm<T>(int fsmId, T owner, FsmState<T>[] states) where T : class
        {
            return fsmManager.CreatFsm<T>(testFsmId++, owner, states);
        }

        /// <summary>
        /// 销毁状态机
        /// </summary>
        public void DestoryFsm(int fsmId)
        {
            fsmManager.DestoryFsm(fsmId);
        }

        public override void ShutDown()
        {
            fsmManager.Dispose();
        }
    }
}