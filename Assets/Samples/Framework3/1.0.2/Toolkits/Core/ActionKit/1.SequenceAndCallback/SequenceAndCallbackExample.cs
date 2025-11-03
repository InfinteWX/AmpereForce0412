// ------------------------------------------------------------
// @file       SequenceAndCallbackExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-25 22:10:42
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class SequenceAndCallbackExample : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Sequence Start:" + Time.time);

            ActionKit.Sequence()
                     .Callback(() => Debug.Log("Delay Start: " + Time.time))
                     .Delay(1.0f)
                     .Callback(() => Debug.Log("Delay Finish: " + Time.time))
                     .Delay(1.0f)
                     .Callback(() => Debug.Log("Delay Finish: " + Time.time))
                     .Start(this, _ => { Debug.Log("Sequence Finish: " + Time.time); });
        }
    }
}