// ------------------------------------------------------------
// @file       AchievementSystem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-08 23:10:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._0.CounterApp.Scripts.System
{
    using Model;
    using UnityEngine;

    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        protected override void OnInit()
        {
            this.GetModel<ICounterAppModel>().Count.Register((oldValue, newCount) =>
            {
                if (newCount == -10) Debug.Log("Achievement unlocked: -10 counts");
                if (newCount == 10) Debug.Log("Achievement unlocked: 10 counts");
                if (newCount == 20) Debug.Log("Achievement unlocked: 20 counts");
            });
        }
    }
}