// ------------------------------------------------------------
// @file       AchievementSystem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-08 23:10:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._0.CounterApp.Scripts.System
{
    using Model;
    using UnityEngine;

    // 成就系统，当计数达到特定值时解锁成就
    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        protected override void OnInit()
        {
            // 监听计数属性的变化
            this.GetModel<ICounterAppModel>().Count.Register((oldValue, newCount) =>
            {
                // 根据新的计数值解锁成就
                if (newCount == -10) Debug.Log("Achievement unlocked: -10 counts");
                if (newCount == 10) Debug.Log("Achievement unlocked: 10 counts");
                if (newCount == 20) Debug.Log("Achievement unlocked: 20 counts");
            });
        }
    }
}