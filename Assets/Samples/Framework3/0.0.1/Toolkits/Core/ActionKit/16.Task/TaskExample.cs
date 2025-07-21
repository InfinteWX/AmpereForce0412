// ------------------------------------------------------------
// @file       TaskExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-30 20:10:28
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using System;
    using UnityEngine;
    using Task = System.Threading.Tasks.Task;

    public class TaskExample : MonoBehaviour
    {
        private DateTime _startTime;
        private float    _startSecond;
        
        private void Start()
        {
            // ActionKit.Task(SomeTask).Start(this);

            // SomeTask().ToAction().Start(this);

            ActionKit.Sequence()
                     .Task(SomeTask)
                     .Start(this);
            
            Debug.Log("Ready to wait 3s...");
        }

        private async Task SomeTask()
        {
            _startTime   = DateTime.Now;
            _startSecond = Time.time;
            
            await Task.Delay(TimeSpan.FromSeconds(3.0f)); // Time.time 有启动时间误差
            
            Debug.Log("DateTime: " + (DateTime.Now - _startTime).ToString("ss") + "." + (DateTime.Now - _startTime).ToString("fff") + "s");
            Debug.Log("Time.time: " + (Time.time - _startSecond) + "s");
        }
    }
}