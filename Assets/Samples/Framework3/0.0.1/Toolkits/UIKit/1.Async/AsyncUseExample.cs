// ------------------------------------------------------------
// @file       BasicExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.UIKit.Example._1.Async
{
    using _0.SyncUse;
    using UnityEngine;

    public class AsyncUseExample : MonoBehaviour
    {
        private void OnEnable()
        {
            UIKit.LoadPanelAsync<AsyncUseExamplePanel>(panel =>
            {
                Debug.Log("AsyncUseExamplePanel loaded");
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UIKit.ShowPanelAsync<AsyncUseExamplePanel>();
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                UIKit.HidePanel<AsyncUseExamplePanel>();
            }
        }

        private void OnDisable()
        {
            UIKit.UnloadPanel<AsyncUseExamplePanel>();
        }
    }
}
