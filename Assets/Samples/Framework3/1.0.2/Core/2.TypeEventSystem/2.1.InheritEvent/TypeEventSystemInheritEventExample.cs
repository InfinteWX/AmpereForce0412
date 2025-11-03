// ------------------------------------------------------------
// @file       TypeEventSystemInheritEventExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 15:10:54
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._2.TypeEventSystem._2._1.InheritEvent
{
    using UnityEngine;
    using TypeEventSystem = Core.TypeEventSystem;

    public class TypeEventSystemInheritEventExample : MonoBehaviour
    {
        public interface IEventA
        { }

        public struct EventB : IEventA
        {
            public override string ToString() { return $"{nameof(EventB)}"; }
        }

        private void Start()
        {
            TypeEventSystem.Global.Register<IEventA>(Debug.Log)
                           .UnregisterWhenGameObjectDestroyed(gameObject);
        }

        public void SendEventBByNew()
        {
            TypeEventSystem.Global.Send<IEventA>(new EventB());
        }

        public void SendEventBInvalid()
        {
            // 无效，因为注册的是 EasyEvent<IEventA>，而不是 EasyEvent<EventB>
            TypeEventSystem.Global.Send<EventB>();
        }
    }
}