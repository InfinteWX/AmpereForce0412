// ------------------------------------------------------------
// @file       SyncUse2DExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.UIKit.Example._0.SyncUse
{
    using UnityEngine;

    public class SyncUse2DExample : MonoBehaviour
    {
        private SyncUse2DExamplePanel _panel;
        
        private void OnEnable()
        {
            // 默认加载名为 nameof(SyncUse2DExamplePanel) 的 prefab 并获取挂载在其上的 SyncUse2DExamplePanel 组件
            _panel = UI2DKit.LoadPanel<SyncUse2DExamplePanel>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UI2DKit.ShowPanel<SyncUse2DExamplePanel>();
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _panel.Hide();
            }
        }

        private void OnDisable()
        {
            UI2DKit.UnloadPanel<SyncUse2DExamplePanel>();
        }
    }
}
