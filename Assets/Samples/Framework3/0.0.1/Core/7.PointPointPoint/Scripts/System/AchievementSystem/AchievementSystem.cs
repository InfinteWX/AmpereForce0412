// ------------------------------------------------------------
// @file       AchievementSystem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 23:10:21
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using NotImplementedException = System.NotImplementedException;

namespace Framework.Core.Example._7.PointPointPoint.Scripts.System.AchievementSystem
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using Model;
    using UnityEngine;

    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        private IGameModel _gameModel;

        private List<AchievementItem> _items = new List<AchievementItem>();

        private bool _missed;

        protected override void OnInit()
        {
            _gameModel = this.GetModel<IGameModel>();

            _items.AddRange(new[]
            {
                new AchievementItem() { Name = "百分成就", CheckComplete = () => _gameModel.BestScore.Value > 100 },
                new AchievementItem() { Name = "手残", CheckComplete   = () => _gameModel.Score.Value < 0 },
                new AchievementItem() { Name = "手速", CheckComplete   = () => !_missed },
                new AchievementItem() { Name = "成就大师", CheckComplete = () => _items.Count(item => item.Unlocked) >= 3 }
            });

            this.RegisterEvent<GameStartEvent>(OnGameStart);
            this.RegisterEvent<OnMissEvent>(OnMiss);
            this.RegisterEvent<GameWinEvent>(OnGameWin);
        }

        private void OnGameStart(GameStartEvent arg0)
        {
            _missed = false;
        }

        private void OnMiss(OnMissEvent e)
        {
            _missed = true;
        }

        private async void OnGameWin(GameWinEvent e)
        {
            await Task.Delay(TimeSpan.FromSeconds(0.1f));

            // 成就系统一般是持久化的，所以如果需要持久化也是在这个时机进行，可以让 Unlocked 变成 BindableProperty
            foreach (var item in _items)
            {
                if (!item.Unlocked && item.CheckComplete())
                {
                    item.Unlocked = true;
                    Debug.Log("解锁成就：" + item.Name);
                }
            }
        }
    }
}