// ------------------------------------------------------------
// @file       AudioKitActionExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-16 20:11:48
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework3.Toolkits.AudioKit.Example._1.AudioKitAction
{
    using ActionKit;
    using PoolKit;

    public class AudioKitActionExample : MonoBehaviour
    {
        private void Start()
        {
            // 使用 ResourcesAudioLoader 作为音频加载器
            AudioKit.AudioLoaderPool.SetObjectFactory(new CustomObjectFactory<IAudioLoader>(() => new ResourcesAudioLoader()));
            
            ActionKit.Sequence()
                     .Delay(2)
                     .PlaySound("Music/HomeBg")
                     .Delay(2)
                     .PlaySound("Music/PillowTalk")
                     .Start(this);
        }
    }
}