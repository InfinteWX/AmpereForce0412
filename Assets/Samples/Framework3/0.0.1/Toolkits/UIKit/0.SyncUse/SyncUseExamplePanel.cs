// ------------------------------------------------------------
// @file       BasicExamplePanel.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.UIKit.Example._0.SyncUse
{
    using ActionKit;
    using FluentAPI;
    using Framework.Core;
    using UnityEngine.UI;

    public class SyncUseExamplePanel : UIPanel
    {
        protected void Awake()
        {
            "BtnHide".GetComponentInHierarchy<Button>(gameObject).onClick.AddListener(() =>
            {
                Hide();
                ActionKit.Delay(3, () =>
                {
                    Show();
                })
               .StartCurrentScene();
            });
        }

        protected override IArchitecture _Architecture { get; }
    }
}
