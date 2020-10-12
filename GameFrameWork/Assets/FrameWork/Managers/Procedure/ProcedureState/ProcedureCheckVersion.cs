using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    public class ProcedureCheckVersion : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("OnEnter ProcedureCheckVersion");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            Debug.Log("OnLeave ProcedureCheckVersion");
        }

        public override void OnDestory()
        {
            base.OnDestory();
        }
    }
}

