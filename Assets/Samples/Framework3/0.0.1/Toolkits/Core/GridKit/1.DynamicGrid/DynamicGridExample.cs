// ------------------------------------------------------------
// @file       DynamicGridExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-01 13:11:44
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.GridKit.Example._1.DynamicGrid
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class DynamicGridExample : MonoBehaviour
    {
        [ShowInInspector]
        private DynamicGrid<string> _grid;

        private void Start()
        {
            _grid = new DynamicGrid<string>();
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Set (2, 3)", GUILayout.Width(120), GUILayout.Height(50)))
            {
                _grid[2, 3] = "@@@ Hello @@@";
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Log", GUILayout.Width(120), GUILayout.Height(50)))
            {
                _grid.ForEach((i, j, value) => Debug.Log($"({i}, {j}) = {value}"));
            }

            GUILayout.EndHorizontal();
        }
    }
}