// ------------------------------------------------------------
// @file       TypeEventSystemUnRegisterExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 15:10:17
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._2.TypeEventSystem._2._2.UnRegister
{
    using UnityEngine;
    using TypeEventSystem = Core.TypeEventSystem;

    public class TypeEventSystemUnRegisterExample : MonoBehaviour
    {
        public struct EventA
        { }

        public struct EventB
        { }

        private void Start()
        {
            TypeEventSystem.GLOBAL.Register<EventA>(OnEventA);                                         // 需要手动注销事件
            TypeEventSystem.GLOBAL.Register<EventB>(b => { }).UnRegisterWhenGameObjectDestroyed(this); // 自动注销事件
        }

        void OnEventA(EventA e) { }

        private void OnDestroy()
        {
            TypeEventSystem.GLOBAL.UnRegister<EventA>(OnEventA); // 在 OnDestroy 中手动注销事件
        }
    }
}