// ------------------------------------------------------------
// @file       SyncUse3DExamplePanel.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.UIKit.Example._0.SyncUse
{
    using Framework3.Core;
    using UnityEngine;

    public class SyncUse3DExamplePanel : UIPanel3D
    {
        protected override void Awake()
        {
            base.Awake();
            
            Debug.Log("SyncUse3DExamplePanel Awake");
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Debug.Log("SyncUse3DExamplePanel OnEnable");
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Debug.Log("SyncUse3DExamplePanel OnDisable");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Debug.Log("SyncUse3DExamplePanel OnDestroy");
        }

        protected override IArchitecture _Architecture { get; }
    }
}