// ------------------------------------------------------------
// @file       TypeEventSystemUnregisterExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 15:10:17
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._2.TypeEventSystem._2._2.Unregister
{
    using UnityEngine;
    using TypeEventSystem = Core.TypeEventSystem;

    public class TypeEventSystemUnregisterExample : MonoBehaviour
    {
        public struct EventA
        { }

        public struct EventB
        { }

        private void Start()
        {
            TypeEventSystem.Global.Register<EventA>(OnEventA); // 需要手动注销事件
            TypeEventSystem.Global.Register<EventB>(b =>
            {
                Debug.Log("EventB received");
            }).UnregisterWhenGameObjectDestroyed(this); // 自动注销事件
            
            // 发送事件
            TypeEventSystem.Global.Send(new EventA());
            TypeEventSystem.Global.Send(new EventB());
        }

        void OnEventA(EventA e)
        {
            Debug.Log("EventA received");
        }

        private void OnDestroy()
        {
            TypeEventSystem.Global.Unregister<EventA>(OnEventA); // 在 OnDestroy 中手动注销事件
        }
    }
}