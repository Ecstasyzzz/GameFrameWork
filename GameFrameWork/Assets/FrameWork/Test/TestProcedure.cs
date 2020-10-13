using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;

public class TestProcedure : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            ChapterDBModel dr = new ChapterDBModel();
            dr.LoadData();

            List<ChapterEntity> lst = dr.GetList();
            int len = lst.Count;

            for (int i = 0; i < len; i++)
            {
                ChapterEntity entity = lst[i];

                Debug.Log("name = " + entity.ChapterName);
            }
        }
    }
}
