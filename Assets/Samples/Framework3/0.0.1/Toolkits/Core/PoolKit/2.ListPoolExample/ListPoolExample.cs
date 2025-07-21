// ------------------------------------------------------------
// @file       ListPoolExample.cs
// @brief
// @author     zheliku
// @Modified   2025-05-16 01:19:45
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.PoolKit.Example._0.ObjectPoolExample
{
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class ListPoolExample : MonoBehaviour
    {
        [ShowInInspector]
        public List<List<int>> Lists = new();

        [ShowInInspector]
        public ObjectPool<List<int>> ListPool = ListPool<int>.POOL;

        private void OnGUI()
        {
            if (GUILayout.Button("Get List", GUILayout.Width(150), GUILayout.Height(50)))
            {
                Lists.Add(ListPool<int>.Get());
            }

            if (GUILayout.Button("Release List", GUILayout.Width(150), GUILayout.Height(50)))
            {
                Lists[0].Release2Pool();
                Lists.RemoveAt(0);
            }

            if (GUILayout.Button("Clear GameObject", GUILayout.Width(150), GUILayout.Height(50)))
            {
                Lists.Clear();
            }
        }
    }
}