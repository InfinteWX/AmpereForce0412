// ------------------------------------------------------------
// @file       TypeEventSystemInheritEventExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 15:10:54
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._2.TypeEventSystem._2._1.InheritEvent
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
            TypeEventSystem.GLOBAL.Register<IEventA>(Debug.Log)
                           .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Send<IEventA>(new EventB())", GUILayout.Width(200), GUILayout.Height(50)))
            {
                TypeEventSystem.GLOBAL.Send<IEventA>(new EventB());
            }

            if (GUILayout.Button("Send<EventB>()", GUILayout.Width(200), GUILayout.Height(50)))
            {
                // 无效，因为注册的是 EasyEvent<IEventA>，而不是 EasyEvent<EventB>
                TypeEventSystem.GLOBAL.Send<EventB>();
            }
        }
    }
}