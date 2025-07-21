// ------------------------------------------------------------
// @file       BlackBoard.cs
// @brief
// @author     zhangyiran
// @Modified   2025-05-14 15:23:10
// @Copyright  Copyright (c) 2025, zhangyiran
// ------------------------------------------------------------

using System;
using Framework.Toolkits.AudioKit;
using Sirenix.OdinInspector;
using TMPro;

namespace AmpereForce
{
    using Framework.Core;

    public class BlackBoard : AbstractView
    {
        [HierarchyPath("txtContent")]
        public TextMeshPro txtContent; // 内容文本

        public BlackboardConfigSO Config; // 配置文件

        public int CurrentIndex; // 当前索引

        public AudioPlayer AudioPlayer; // 音效播放器

        private void Awake()
        {
            this.BindHierarchyComponent();
        }

        [Button]
        // 点击按钮时执行
        public void Next()
        {
            // 当前索引加一
            CurrentIndex++;
            // 如果当前索引大于等于配置项的数量，则将当前索引置为0
            if (CurrentIndex >= Config.Items.Count)
            {
                CurrentIndex = 0;
            }

            // 调用Tick方法
            Tick();
        }

        [Button]
        // 点击按钮时执行的方法
        public void Prev()
        {
            // 当前索引减一
            CurrentIndex--;
            // 如果当前索引小于0，则将当前索引设置为配置项的最后一个索引
            if (CurrentIndex < 0)
            {
                CurrentIndex = Config.Items.Count - 1;
            }

            // 执行Tick方法
            Tick();
        }

        private void Tick()
        {
            // 获取当前索引对应的配置项
            var item = Config.Items[CurrentIndex];
            // 将配置项的内容显示在文本框中
            txtContent.text = item.Content;

            // 停止当前播放的音频
            AudioPlayer?.Stop();
            // 如果配置项中有音频文件，则播放音频
            if (item.AudioClip != null)
            {
                AudioPlayer = AudioKit.PlaySound(item.AudioClip);
            }
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}