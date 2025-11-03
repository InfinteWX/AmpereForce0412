// ------------------------------------------------------------
// @file       AsyncUse3DExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.UIKit.Example._1.AsyncUse
{
    using UnityEngine;

    public class AsyncUse3DExample : MonoBehaviour
    {
        private void OnEnable()
        {
            // 可指定名称加载
            UI3DKit.LoadPanelAsync<AsyncUse3DExamplePanel>("myPanel3D", panel =>
            {
                panel.Canvas.worldCamera = Camera.main;
                Debug.Log("AsyncUse3DExamplePanel loaded");
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UI3DKit.ShowPanelAsync<AsyncUse3DExamplePanel>("myPanel3D");
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                UI3DKit.HidePanel<AsyncUse3DExamplePanel>("myPanel3D");
            }
        }

        private void OnDisable()
        {
            UI3DKit.UnloadPanel<AsyncUse3DExamplePanel>("myPanel3D");
        }
    }
}
