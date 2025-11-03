// ------------------------------------------------------------
// @file       IStorage.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._0.CounterApp.Scripts.Utility
{
    // 存储接口，定义了保存和加载整数值的方法
    public interface IStorage : IUtility
    {
        void SaveInt(string key, int value);

        int LoadInt(string key, int defaultValue = 0);
    }
}