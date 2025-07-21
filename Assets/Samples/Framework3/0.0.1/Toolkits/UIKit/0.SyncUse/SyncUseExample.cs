// ------------------------------------------------------------
// @file       BasicExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.UIKit.Example._0.SyncUse
{
    using ResKit;
    using UnityEngine;

    public class SyncUseExample : MonoBehaviour
    {
        private SyncUseExamplePanel _panel;
        
        private void OnEnable()
        {
            _panel = UIKit.LoadPanel<SyncUseExamplePanel>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UIKit.ShowPanel<SyncUseExamplePanel>();
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _panel.Hide();
            }
        }

        private void OnDisable()
        {
            UIKit.UnloadPanel<AsyncUseExamplePanel>();
        }
    }
}
