// ------------------------------------------------------------
// @file       MySystem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-16 15:10:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._15.Deinit
{
    using UnityEngine;

    public class MySystem : AbstractSystem
    {
        protected override void OnInit()
        {
            Debug.Log("MySystem OnInit");
        }

        protected override void OnDeinit()
        {
            Debug.Log("MySystem OnDeinit");
        }
    }
}