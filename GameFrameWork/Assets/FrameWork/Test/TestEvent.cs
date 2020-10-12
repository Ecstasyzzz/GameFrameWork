using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using System;

public class TestEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEntry.EventComponent.CommonEvent.AddEveneListener(CommonEventId.RegComplete, OnRegComplete);
    }

    private void OnRegComplete(object data)
    {
        Debug.Log(data);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            GameEntry.EventComponent.CommonEvent.Dispatch(CommonEventId.RegComplete, 123);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("TestEvent OnDestroy");
        GameEntry.EventComponent.CommonEvent.RemoveListener(CommonEventId.RegComplete, OnRegComplete);
    }
}
