// ------------------------------------------------------------
// @file       IStorage.cs
// @brief
// @author     zheliku
// @Modified   2024-10-14 18:10:41
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Utility
{
    public interface IStorage : IUtility
    {
        void SaveInt(string key, int value);

        int LoadInt(string key, int defaultValue = 0);
    }
}