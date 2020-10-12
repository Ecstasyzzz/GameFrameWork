using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    public class ProcedureLaunch : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("OnEnter ProcedureLaunch");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            Debug.Log("OnLeave ProcedureLaunch");
        }

        public override void OnDestory()
        {
            base.OnDestory();
        }
    }
}

