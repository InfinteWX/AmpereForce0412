// ------------------------------------------------------------
// @file       ICountDownSystem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 13:10:56
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._7.PointPointPoint.Scripts.System.CountSownSystem
{
    public interface ICountDownSystem : ISystem
    {
        int CurrentRemainSecond { get; }

        void Update();
    }
}