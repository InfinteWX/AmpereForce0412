// ------------------------------------------------------------
// @file       ListPoolExample.cs
// @brief
// @author     zheliku
// @Modified   2025-05-16 01:19:45
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.PoolKit.Example._0.ObjectPoolExample
{
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class ListPoolExample : MonoBehaviour
    {
        [ShowInInspector]
        public List<List<int>> Lists = new();

        [ShowInInspector]
        public ObjectPool<List<int>> ListPool = ListPool<int>.Pool;

        public void GetList()
        {
            Lists.Add(ListPool<int>.Get());
        }
        
        public void ReleaseList()
        {
            Lists[0].Release2Pool();
            Lists.RemoveAt(0);
        }
        
        public void ClearList()
        {
            ListPool<int>.Clear();
        }
    }
}