// ------------------------------------------------------------
// @file       AudioKitActionExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-16 20:11:48
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework.Toolkits.AudioKit.Example._1.AudioKitAction
{
    using System;
    using ActionKit;

    public class AudioKitActionExample : MonoBehaviour
    {
        private void Start()
        {
            ActionKit.Sequence()
                     .Delay(2)
                     .PlaySound("HomeBg")
                     .Delay(2)
                     .PlaySound("PillowTalk")
                     .Start(this);
        }
    }
}