// ------------------------------------------------------------
// @file       StringEventSystemExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 16:10:43
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.EventKit.Example._1.StringEventSystemExample
{
    using Framework.Core;
    using UnityEngine;

    public class StringEventSystemExample : MonoBehaviour
    {
        void Start()
        {
            StringEventSystem.GLOBAL.Register<string>(nameof(OnEventA), OnEventA).UnRegisterWhenGameObjectDestroyed(gameObject);

            // 事件 + 参数
            StringEventSystem.GLOBAL.Register<string, int>(nameof(OnEventB), OnEventB).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
        
        private void OnGUI()
        {
            if (GUILayout.Button("TestEventA", GUILayout.Width(150), GUILayout.Height(50)))
            {
                StringEventSystem.GLOBAL.Send<string>(nameof(OnEventA), "OnEventA");
            }

            if (GUILayout.Button("TestEventB", GUILayout.Width(150), GUILayout.Height(50)))
            {
                StringEventSystem.GLOBAL.Send<string, int>(nameof(OnEventB), "OnEventB", 10);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StringEventSystem.GLOBAL.Send("TEST_ONE");
                StringEventSystem.GLOBAL.Send("TEST_TWO", 10);
            }
        }
        
        void OnEventA(string obj)
        {
            Debug.Log($"OnEventA: {obj}");
        }
        
        void OnEventB(string obj, int i)
        {
            Debug.Log($"OnEventB: {obj}, {i}");
        }
    }
}