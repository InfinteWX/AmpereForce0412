// ------------------------------------------------------------
// @file       IStorage.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._0.CounterApp.Scripts.Utility
{
    public interface IStorage : IUtility
    {
        void SaveInt(string key, int value);

        int LoadInt(string key, int defaultValue = 0);
    }
}