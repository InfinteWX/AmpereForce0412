// ------------------------------------------------------------
// @file       0.EnumEventExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 16:10:41
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.EventKit.Example._0.EnumEventExample
{
    using UnityEngine;

    public class EnumEventExample : MonoBehaviour
    {
        void Start()
        {
            EnumEventSystem.GLOBAL.Register(TestEventA.Test, OnEventA);
            EnumEventSystem.GLOBAL.Register(TestEventB.Test, OnEventB);
        }

        void OnEventA(TestEventA key, params object[] obj)
        {
            Debug.Log($"TestEventA_{key}: {obj[0]}");
        }
        
        void OnEventB(TestEventB key, params object[] obj)
        {
            Debug.Log($"TestEventB_{key}: {obj[0]}");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("TestEventA", GUILayout.Width(150), GUILayout.Height(50)))
            {
                EnumEventSystem.GLOBAL.Send(TestEventA.Test, "Hello World!");
            }

            if (GUILayout.Button("TestEventB", GUILayout.Width(150), GUILayout.Height(50)))
            {
                EnumEventSystem.GLOBAL.Send(TestEventB.Test, "Hello World!");

            }
        }

        private void OnDestroy()
        {
            EnumEventSystem.GLOBAL.UnRegister(TestEventA.Test, OnEventA);
            EnumEventSystem.GLOBAL.UnRegister(TestEventB.Test, OnEventB);
        }
    }

    public enum TestEventA
    {
        Start,
        Test,
        End,
    }

    public enum TestEventB
    {
        Start,
        Test,
        End,
    }
}