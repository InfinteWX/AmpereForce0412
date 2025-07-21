// ------------------------------------------------------------
// @file       LerpExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-30 10:10:15
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using FluentAPI;
    using UnityEngine;

    public class LerpExample : MonoBehaviour
    {
        void Start()
        {
            ActionKit.Lerp(0, 360, 5.0f, (v) =>
            {
                this.SetRotation(Quaternion.Euler(0, 0, v));
            }).Start(this);
        }
    }
}