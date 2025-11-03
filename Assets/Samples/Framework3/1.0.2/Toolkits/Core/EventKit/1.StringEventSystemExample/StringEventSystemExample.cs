// ------------------------------------------------------------
// @file       StringEventSystemExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 16:10:43
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.EventKit.Example._1.StringEventSystemExample
{
    using Framework3.Core;
    using UnityEngine;

    public class StringEventSystemExample : MonoBehaviour
    {
        void Start()
        {
            StringEventSystem.Global.Register<string>(nameof(OnEventA), OnEventA)
               .UnregisterWhenGameObjectDestroyed(gameObject);

            // 事件 + 参数
            StringEventSystem.Global.Register<string, int>(nameof(OnEventB), OnEventB)
               .UnregisterWhenGameObjectDestroyed(gameObject);
        }

        public void SendOnEventA()
        {
            StringEventSystem.Global.Send<string>(nameof(OnEventA), "Hello World!");
        }

        public void SendOnEventB()
        {
            StringEventSystem.Global.Send<string, int>(nameof(OnEventB), "Hello World!", 111);
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