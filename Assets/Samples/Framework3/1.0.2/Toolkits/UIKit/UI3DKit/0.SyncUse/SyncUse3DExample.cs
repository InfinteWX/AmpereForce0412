// ------------------------------------------------------------
// @file       SyncUse3DExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.UIKit.Example._0.SyncUse
{
    using UnityEngine;

    public class SyncUse3DExample : MonoBehaviour
    {
        private SyncUse3DExamplePanel _panel;
        
        private void OnEnable()
        {
            // 默认加载名为 nameof(SyncUse3DExamplePanel) 的 prefab 并获取挂载在其上的 SyncUse3DExamplePanel 组件
            _panel = UI3DKit.LoadPanel<SyncUse3DExamplePanel>();
            _panel.Canvas.worldCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UI3DKit.ShowPanel<SyncUse3DExamplePanel>();
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _panel.Hide();
            }
        }

        private void OnDisable()
        {
            UI3DKit.UnloadPanel<SyncUse3DExamplePanel>();
        }
    }
}
