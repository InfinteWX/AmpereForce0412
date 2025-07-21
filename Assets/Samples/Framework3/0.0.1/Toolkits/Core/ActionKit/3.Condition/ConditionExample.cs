// ------------------------------------------------------------
// @file       ConditionExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-26 12:10:23
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class ConditionExample : MonoBehaviour
    {
        private void Start()
        {
            ActionKit.Sequence()
                     .Callback(() => Debug.Log("Before Condition"))
                     .Condition(() => Input.GetMouseButtonDown(0))
                     .Callback(() => Debug.Log("Mouse Clicked"))
                     .Start(this);
        }
    }
}