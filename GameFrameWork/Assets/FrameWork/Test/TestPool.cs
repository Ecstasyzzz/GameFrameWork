using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public class Account
    {
        public int index;

        public string name;

        public Account()
        {

        }

        public Account(int index, string name)
        {
            this.index = index;
            this.name = name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            var account = GameEntry.PoolComponent.ClassObjectDequeue<Account>(new object[] { 10, "test" });

            GameEntry.PoolComponent.SetRetainCount<Account>(3);

            Debug.Log("index = " + account.index);
            Debug.Log("name = " + account.name);

            GameEntry.PoolComponent.ClassObjectEnqueue(account);
        }
    }
}
