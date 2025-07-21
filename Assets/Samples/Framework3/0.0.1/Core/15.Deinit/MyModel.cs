// ------------------------------------------------------------
// @file       MyModel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-16 15:10:00
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._15.Deinit
{
    using Model;
    using UnityEngine;

    public class MyModel : AbstractModel
    {
        protected override void OnInit()
        {
            Debug.Log("MyModel.OnInit");
        }

        protected override void OnDeinit()
        {
            Debug.Log("MyModel.OnDeinit");
        }
    }
}