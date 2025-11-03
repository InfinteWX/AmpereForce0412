// ------------------------------------------------------------
// @file       RandomDelayExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-30 09:10:16
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class RandomDelayExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ActionKit.Repeat()
                     .Delay(() => Random.Range(0.5f, 2.5f))
                     .Callback(() => { Debug.Log("Time: " + Time.time); })
                     .Start(this);
        }
    }
}