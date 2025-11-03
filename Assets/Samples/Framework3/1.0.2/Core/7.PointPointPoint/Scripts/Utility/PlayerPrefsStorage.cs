// ------------------------------------------------------------
// @file       PlayerPrefsStorage.cs
// @brief
// @author     zheliku
// @Modified   2024-10-14 18:10:13
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Utility
{
    using UnityEngine;

    public class PlayerPrefsStorage : IStorage
    {
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }
}