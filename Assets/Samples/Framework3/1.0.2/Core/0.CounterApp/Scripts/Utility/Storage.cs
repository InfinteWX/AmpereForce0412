// ------------------------------------------------------------
// @file       Storage.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:52
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._0.CounterApp.Scripts.Utility
{
    using UnityEngine;

    // 存储实现类，使用 Unity 的 PlayerPrefs 进行本地存储
    public class Storage : IStorage
    {
        // 保存整数值到本地存储
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value); // 使用 Unity 的 PlayerPrefs 进行存储
        }

        // 从本地存储加载整数值，如果不存在则返回默认值
        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue); // 使用 Unity 的 PlayerPrefs 进行加载
        }
    }
}