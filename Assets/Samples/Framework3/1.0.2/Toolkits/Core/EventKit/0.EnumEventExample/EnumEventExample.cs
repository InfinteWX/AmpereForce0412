// ------------------------------------------------------------
// @file       0.EnumEventExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 16:10:41
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.EventKit.Example._0.EnumEventExample
{
    using UnityEngine;

    public class EnumEventExample : MonoBehaviour
    {
        void Start()
        {
            EnumEventSystem.Global.Register(TestEventA.Test, OnEventA);
            EnumEventSystem.Global.Register(TestEventB.Test, OnEventB);
        }

        void OnEventA(TestEventA key, params object[] obj)
        {
            Debug.Log($"TestEventA_{key}: {obj[0]}");
        }
        
        void OnEventB(TestEventB key, params object[] obj)
        {
            Debug.Log($"TestEventB_{key}: {obj[0]}");
        }
        
        public void SendTestEventA()
        {
            EnumEventSystem.Global.Send(TestEventA.Test, "Hello World!");
        }
        
        public void SendTestEventB()
        {
            EnumEventSystem.Global.Send(TestEventB.Test, "Hello World!");
        }

        private void OnDestroy()
        {
            EnumEventSystem.Global.Unregister(TestEventA.Test, OnEventA);
            EnumEventSystem.Global.Unregister(TestEventB.Test, OnEventB);
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