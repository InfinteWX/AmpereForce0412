// ------------------------------------------------------------
// @file       AsyncUse2DExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-12 21:12:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.UIKit.Example._1.AsyncUse
{
    using UnityEngine;

    public class AsyncUse2DExample : MonoBehaviour
    {
        private void OnEnable()
        {
            // 可指定名称加载
            UI2DKit.LoadPanelAsync<AsyncUse2DExamplePanel>("myPanel2D", panel =>
            {
                Debug.Log("AsyncUse2DExamplePanel loaded");
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UI2DKit.ShowPanelAsync<AsyncUse2DExamplePanel>("myPanel2D");
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                UI2DKit.HidePanel<AsyncUse2DExamplePanel>("myPanel2D");
            }
        }

        private void OnDisable()
        {
            UI2DKit.UnloadPanel<AsyncUse2DExamplePanel>("myPanel2D");
        }
    }
}
