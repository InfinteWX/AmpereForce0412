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

    public class TimerExample : MonoBehaviour
    {
        public void StartTimer1()
        {
            TimerKit.Create(
                (t) => Debug.Log("Timer 1: " + t.TickCount + " Count"),
                1,
                -1);
        }
        
        public void StartTimer2()
        {
            TimerKit.Create(
                (t) => Debug.Log("Timer 2: " + t.TickCount + " Count"),
                2,
                3);
        }
        
        public void StartTimer3()
        {
            TimerKit.Create(
                (t) => Debug.Log("Timer 3: " + t.TickCount + " Count"),
                3,
                3);
        }
    }
}