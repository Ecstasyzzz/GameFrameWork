using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;

public class TestProcedure : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VarInt a = VarInt.Alloc(10);
        int x = a;
        StartCoroutine(test1(a));
    }

    IEnumerator test1(VarInt a)
    {
        yield return new WaitForSeconds(5.0f);
        a.Release();
    }

    // Update is called once per frame
    void Update()
    { 
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    Debug.Log("当前的流程" + GameEntry.ProcedureComponent.CurProcedure);
        //}

        //if (Input.GetKeyUp(KeyCode.B))
        //{
        //    GameEntry.ProcedureComponent.ChangeState(ProcedureState.CheckVersion);
        //}

        //if (Input.GetKeyUp(KeyCode.C))
        //{
        //    GameEntry.ProcedureComponent.ChangeState(ProcedureState.EnterGame);
        //}
    }
}
