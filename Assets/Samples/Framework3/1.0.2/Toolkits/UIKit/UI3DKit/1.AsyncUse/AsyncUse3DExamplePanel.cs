// ------------------------------------------------------------
// @file       AsyncUse3DExamplePanel.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.UIKit.Example._1.AsyncUse
{
    using Framework3.Core;
    using UnityEngine;

    public class AsyncUse3DExamplePanel : UIPanel3D
    {
        protected override void Awake()
        {
            base.Awake();
            Debug.Log("AsyncUse3DExamplePanel Awake");
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Debug.Log("AsyncUse3DExamplePanel OnEnable");
        }
        
        protected override void OnDisable()
        {
            base.OnDisable();
            Debug.Log("AsyncUse3DExamplePanel OnDisable");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Debug.Log("AsyncUse3DExamplePanel OnDestroy");
        }

        protected override IArchitecture _Architecture { get; }
    }
}