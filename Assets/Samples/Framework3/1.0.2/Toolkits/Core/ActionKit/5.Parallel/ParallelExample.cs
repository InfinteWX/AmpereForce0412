// ------------------------------------------------------------
// @file       Parallel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-29 10:10:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class ParallelExample : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Parallel Start:" + Time.time);

            ActionKit.Parallel()
                     .Delay(1.0f, () => { Debug.Log(Time.time); })
                     .Delay(2.0f, () => { Debug.Log(Time.time); })
                     .Delay(3.0f, () => { Debug.Log(Time.time); })
                     .Start(this, () =>
                      {
                          Debug.Log("Parallel Finish:" + Time.time);
                      });
        }
    }
}