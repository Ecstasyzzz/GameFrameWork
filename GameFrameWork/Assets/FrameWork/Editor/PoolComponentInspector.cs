using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace GameFramework
{
    [CustomEditor(typeof(PoolComponent))]
    public class PoolComponentInspector : Editor
    {
        private SerializedProperty clearInterval = null;
        private SerializedProperty gameObjectPoolGroup = null;

        void OnEnable()
        {
            clearInterval = serializedObject.FindProperty("clearInterval");
            gameObjectPoolGroup = serializedObject.FindProperty("gameObjectPoolGroup");

            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            PoolComponent component = base.target as PoolComponent;

            // 绘制滑动条
            int interval = (int)EditorGUILayout.Slider("清空类对象池间隔", clearInterval.intValue, 10, 1800);
            if (interval != clearInterval.intValue)
            {
                component.clearInterval = interval;
            }
            else
            {
                clearInterval.intValue = interval;
            }

            //===================类对象池===================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("类名");
            GUILayout.Label("池中数量", GUILayout.Width(50));
            GUILayout.Label("常驻数量", GUILayout.Width(50));
            GUILayout.EndHorizontal();

            if (component != null && component.PoolManager != null)
            {
                var retainDic = component.PoolManager.ClassObjectPool.RetainCountDic;

                foreach (var item in component.PoolManager.ClassObjectPool.InspectorDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));

                    int key = item.Key.GetHashCode();
                    byte count = 0;
                    retainDic.TryGetValue(key, out count);
                    GUILayout.Label(count.ToString(), GUILayout.Width(50));
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();

            //===================变量计数===================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("变量");
            GUILayout.Label("数量", GUILayout.Width(50));
            GUILayout.EndHorizontal();

            if (component != null)
            {

                foreach (var item in component.VarObjectInpsectorDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();

            GUILayout.Space(10);
            EditorGUILayout.PropertyField(gameObjectPoolGroup, true);

            serializedObject.ApplyModifiedProperties();
            Repaint();
        }
    }
}
