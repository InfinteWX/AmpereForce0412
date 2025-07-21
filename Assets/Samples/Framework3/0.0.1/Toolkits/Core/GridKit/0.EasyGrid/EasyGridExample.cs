// ------------------------------------------------------------
// @file       GridExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-01 13:11:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.GridKit.Example._0.Grid
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class EasyGridExample : MonoBehaviour
    {
        [ShowInInspector]
        private EasyGrid<string> _grid;

        private void Start()
        {
            _grid = new EasyGrid<string>(3, 4);
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Fill", GUILayout.Width(120), GUILayout.Height(50)))
            {
                _grid.Fill("Empty");
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Set (2, 3)", GUILayout.Width(120), GUILayout.Height(50)))
            {
                _grid[2, 3] = "@@@ Hello @@@";
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Log", GUILayout.Width(120), GUILayout.Height(50)))
            {
                _grid.ForEach((i, j, value) => Debug.Log($"({i}, {j}) = {value}"));
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Resize", GUILayout.Width(120), GUILayout.Height(50)))
            {
                _grid.Resize(1, 5, (i, j) => "New Value");
            }

            GUILayout.EndHorizontal();
        }
    }
}