// ------------------------------------------------------------
// @file       SimpleArchitecture.cs
// @brief
// @author     zheliku
// @Modified   2024-10-16 15:10:36
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._15.Deinit
{
    using UnityEngine;

    public class SimpleArchitecture : AbstractArchitecture<SimpleArchitecture>
    {
        protected override void Init()
        {
            Debug.Log("SimpleArchitecture Init");

            this.RegisterModel(new MyModel());
            this.RegisterSystem(new MySystem());
        }

        protected override void OnDeinit()
        {
            Debug.Log("SimpleArchitecture Deinit");
        }
    }
}