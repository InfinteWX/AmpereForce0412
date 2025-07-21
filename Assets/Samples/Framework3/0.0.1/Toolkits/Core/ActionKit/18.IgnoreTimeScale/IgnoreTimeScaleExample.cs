// ------------------------------------------------------------
// @file       IgnoreTimeScaleExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-31 15:10:07
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class IgnoreTimeScaleExample : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 0.25f;
            Debug.Log("Launch Scaled Time: " + Time.time);
            Debug.Log("Launch Unscaled Time: " + Time.unscaledTime);
            ActionKit.Sequence()
                     .Delay(3.0f)
                     .Callback(() =>
                      {
                          Debug.Log("Scaled Time: " + Time.time);           // 理论值为 0.75，实际值是 0.3 左右，因为会把引擎启动的时间计算进去
                          Debug.Log("Unscaled Time: " + Time.unscaledTime); // 理论值为 3.0，实际值是 3.0，较为精准
                      })
                     .Start(this)
                     .IgnoreTimeScale();
        }
    }
}