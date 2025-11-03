// ------------------------------------------------------------
// @file       DelayExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-24 23:10:17
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class DelayExample : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Start Time: " + Time.time);

            ActionKit.Delay(2, () =>
            {
                Debug.Log("End Time: " + Time.time);
            }).Start(this);
        }
    }
}