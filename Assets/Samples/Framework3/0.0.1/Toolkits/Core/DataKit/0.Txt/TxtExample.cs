// ------------------------------------------------------------
// @file       TxtExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-06 23:12:34
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework.Toolkits.Core.DataKit.Example._0.Txt
{
    using System;
    using Toolkits.DataKit;

    public class TxtExample : MonoBehaviour
    {
        private void OnGUI()
        {
            if (GUILayout.Button("SaveTxt", GUILayout.Width(160), GUILayout.Height(60)))
            {
                DataKit.SaveTxt("example", "hello");
            }
            
            if (GUILayout.Button("LoadTxt", GUILayout.Width(160), GUILayout.Height(60)))
            {
                var txt = DataKit.LoadTxt("example");
                Debug.Log(txt);
            }
        }
    }
}
