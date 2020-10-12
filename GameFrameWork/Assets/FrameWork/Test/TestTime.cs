using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            TimeAction action = GameEntry.TimeComponent.CreateTimeAction();
            action.Init(5, 1, 8, () => { Debug.Log("开始循环"); }, (int loop) => { UnityEngine.Debug.Log("剩余次数=" + loop); }, () => { Debug.Log("结束循环"); }).Run();
        }
    }
}
