// ------------------------------------------------------------
// @file       SyncUse2DExamplePanel.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.UIKit.Example._0.SyncUse
{
    using ActionKit;
    using FluentAPI;
    using Framework3.Core;
    using UnityEngine;
    using UnityEngine.UI;

    public class SyncUse2DExamplePanel : UIPanel2D
    {
        protected override void Awake()
        {
            base.Awake();
            "BtnHide".GetComponentInHierarchy<Button>(gameObject).onClick.AddListener(() =>
            {
                Hide();
                ActionKit.Delay(3, Show)
                   .StartCurrentScene();
            });
            
            Debug.Log("SyncUse2DExamplePanel Awake");
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Debug.Log("SyncUse2DExamplePanel OnEnable");
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Debug.Log("SyncUse2DExamplePanel OnDisable");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Debug.Log("SyncUse2DExamplePanel OnDestroy");
        }

        protected override IArchitecture _Architecture { get; }
    }
}