// ------------------------------------------------------------
// @file       InterfaceEventModeExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 15:10:38
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._2.TypeEventSystem._2._3.InterfaceEventMode
{
    using UnityEngine;
    using TypeEventSystem = Core.TypeEventSystem;

    // 最好使用 struct 声明，减少 GC
    public class InterfaceEventA
    {
        public override string ToString() { return $"{nameof(InterfaceEventA)}"; }
    }

    public struct InterfaceEventB
    {
        public override string ToString() { return $"{nameof(InterfaceEventB)}"; }
    }

    public class InterfaceEventModeExample : MonoBehaviour
                                           , IOnEvent<InterfaceEventA> // 快捷监听事件 InterfaceEventA
                                           , IOnEvent<InterfaceEventB>
    {
        public void OnEvent(InterfaceEventA e) // InterfaceEventA 事件监听函数
        {
            Debug.Log(e);
        }

        public void OnEvent(InterfaceEventB e)
        {
            Debug.Log(e);
        }

        private void Start()
        {
            this.RegisterEvent<InterfaceEventA>()               // 注册监听，默认注册到 TypeEventSystem.GLOBAL 中
                .UnRegisterWhenGameObjectDestroyed(gameObject); // 自动注销

            this.RegisterEvent<InterfaceEventB>();
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<InterfaceEventB>(); // 手动注销
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Send<InterfaceEventA>()", GUILayout.Width(200), GUILayout.Height(50)))
            {
                TypeEventSystem.GLOBAL.Send<InterfaceEventA>();
            }

            if (GUILayout.Button("Send<InterfaceEventB>()", GUILayout.Width(200), GUILayout.Height(50)))
            {
                TypeEventSystem.GLOBAL.Send<InterfaceEventB>();
            }
        }
    }
}