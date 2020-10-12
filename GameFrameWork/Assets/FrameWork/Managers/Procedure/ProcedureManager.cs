using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameFramework
{
    /// <summary>
    /// 流程状态枚举
    /// </summary>
    public enum ProcedureState
    {
        Lanuch = 0,
        CheckVersion = 1,
        Preload = 2,
        ChangeScene = 3,
        LogOn = 4,
        SelectRole = 5,
        EnterGame = 6,
        WorldMap = 7,
        GameLevel = 8
    }

    /// <summary>
    /// 流程管理器
    /// </summary>
    public class ProcedureManager : ManagerBase, IDisposable
    {
        private Fsm<ProcedureManager> curFsm;

        public Fsm<ProcedureManager> CurFsm
        {
            get { return curFsm; }
        }

        /// <summary>
        /// 当前流程状态枚举
        /// </summary>
        internal ProcedureState CurProcedureState
        {
            get { return (ProcedureState)curFsm.curStateType; }
        }

        /// <summary>
        /// 当前流程
        /// </summary>
        internal FsmState<ProcedureManager> CurProcedure
        {
            get { return curFsm.GetState(curFsm.curStateType); }
        }

        public ProcedureManager()
        {
            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            FsmState<ProcedureManager>[] states = new FsmState<ProcedureManager>[]
            {
                new ProcedureLaunch(),
                new ProcedureCheckVersion(),
                new ProcedurePreload(),
                new ProcedureChangeScene(),
                new ProcedureLogOn(),
                new ProcedureSelectRole(),
                new ProcedureEnterGame(),
                new ProcedureWorldMap(),
                new ProcedureGameLevel()
            };

            curFsm = GameEntry.FsmComponent.CreatFsm<ProcedureManager>(0, this, states);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(ProcedureState state)
        {
            curFsm.ChangeState((byte)state);
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnUpdate()
        {
            curFsm.OnUpdate();
        }

        public void Dispose()
        {
            curFsm.ShunDown();
        }
    }
}