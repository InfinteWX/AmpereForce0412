// ------------------------------------------------------------
// @file       PassIntervalTimeExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-14 16:11:42
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.TimerKit.Example
{
    using UnityEngine;

    public class PassIntervalTimeExample : MonoBehaviour
    {
        private void Update()
        {
            // 每隔0.5秒打印一次
            if (TimerKit.PassIntervalTime(this, 0.5f))
            {
                Debug.Log("PassIntervalTime: 0.5s");
            }
            
            // 每隔100帧打印一次
            if (TimerKit.PassIntervalFrame(this, 100))
            {
                Debug.Log($"Passed 100 Frames: 100frames");
            }
        }
    }
}