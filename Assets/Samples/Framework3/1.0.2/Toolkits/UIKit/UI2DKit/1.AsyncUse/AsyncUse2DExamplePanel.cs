// ------------------------------------------------------------
// @file       AsyncUse2DExamplePanel.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.UIKit.Example._1.AsyncUse
{
    using ActionKit;
    using FluentAPI;
    using Framework3.Core;
    using UnityEngine;
    using UnityEngine.UI;

    public class AsyncUse2DExamplePanel : UIPanel2D
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
            
            Debug.Log("AsyncUse2DExamplePanel Awake");
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Debug.Log("AsyncUse2DExamplePanel OnEnable");
        }
        
        protected override void OnDisable()
        {
            base.OnDisable();
            Debug.Log("AsyncUse2DExamplePanel OnDisable");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Debug.Log("AsyncUse2DExamplePanel OnDestroy");
        }

        protected override IArchitecture _Architecture { get; }
    }
}