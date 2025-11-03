// ------------------------------------------------------------
// @file       GridExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-01 13:11:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.GridKit.Example._0.Grid
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

        public void Fill()
        {
            _grid.Fill("Empty");
        }
        
        public void SetValue()
        {
            _grid[2, 3] = "@@@ Hello @@@";
        }
        
        public void LogAll()
        {
            _grid.ForEach((i, j, value) => Debug.Log($"({i}, {j}) = {value}"));
        }
        
        public void Resize()
        {
            _grid.Resize(1, 5, (i, j) => "New Value");
        }
    }
}