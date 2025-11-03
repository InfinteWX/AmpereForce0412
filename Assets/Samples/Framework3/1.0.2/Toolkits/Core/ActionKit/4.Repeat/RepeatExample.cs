// ------------------------------------------------------------
// @file       RepeatExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-26 12:10:27
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class RepeatExample : MonoBehaviour
    {
        private void Start()
        {
            ActionKit.Repeat() // 无限次重复
                     .Condition(() => Input.GetMouseButtonDown(0))
                     .Callback(() => Debug.Log("Mouse Clicked"))
                     .Start(this);


            ActionKit.Repeat(5) // 重复 5 次
                     .Condition(() => Input.GetMouseButtonDown(1))
                     .Callback(() => Debug.Log("Mouse right clicked"))
                     .Start(this, () =>
                      {
                          Debug.Log("Right click finished");
                      });
        }
    }
}