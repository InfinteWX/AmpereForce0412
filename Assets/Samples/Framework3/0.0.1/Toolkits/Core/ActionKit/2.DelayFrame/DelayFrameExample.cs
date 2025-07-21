// ------------------------------------------------------------
// @file       DelayFrameExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-26 11:10:32
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class DelayFrameExample : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Delay Frame Start FrameCount: " + Time.frameCount);
            
            ActionKit.DelayFrame(1, () => { Debug.Log("Delay Frame Finish FrameCount: " + Time.frameCount); })
                     .Start(this);


            ActionKit.Sequence()
                     .DelayFrame(10)
                     .Callback(() => Debug.Log("Sequence Delay FrameCount: " + Time.frameCount))
                     .Start(this);

            // ActionKit.Sequence()
            //      .NextFrame()
            //      .Start(this);

            ActionKit.NextFrame(() => { Debug.Log("Next Frame Finish FrameCount: " + Time.frameCount); })
                     .Start(this);
        }
    }
}