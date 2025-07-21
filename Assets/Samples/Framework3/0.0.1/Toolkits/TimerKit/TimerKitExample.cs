// ------------------------------------------------------------
// @file       TimerKitExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-14 16:11:42
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.TimerKit.Example
{
    using System;
    using UnityEngine;

    public class TimerKitExample : MonoBehaviour
    {
        private void Start()
        {
            
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Timer 1", GUILayout.Width(150), GUILayout.Height(50)))
            {
                TimerKit.Create(
                    (t) => Debug.Log("Timer 1: " + t.TickCount + " clicked"),
                    1,
                    -1);
            }

            if (GUILayout.Button("Timer 2", GUILayout.Width(150), GUILayout.Height(50)))
            {
                TimerKit.Create(
                    (t) => Debug.Log("Timer 2: " + t.TickCount + " clicked"),
                    2,
                    3);
            }
            
            if (GUILayout.Button("Timer 3", GUILayout.Width(150), GUILayout.Height(50)))
            {
                TimerKit.Create(
                    (t) => Debug.Log("Timer 3: " + t.TickCount + " clicked"),
                    3,
                    3);
            }
        }
    }
}