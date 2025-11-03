// ------------------------------------------------------------
// @file       AchievementItem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 23:10:51
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.System.AchievementSystem
{
    using global::System;

    public class AchievementItem
    {
        public string Name { get; set; }

        public Func<bool> CheckComplete { get; set; }

        public bool Unlocked { get; set; }
    }
}