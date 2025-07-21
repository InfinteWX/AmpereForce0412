// ------------------------------------------------------------
// @file       PointGame.cs
// @brief
// @author     zheliku
// @Modified   2024-10-14 18:10:35
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._7.PointPointPoint.Scripts
{
    using System;
    using System.AchievementSystem;
    using System.CountSownSystem;
    using System.ScoreSystem;
    using Model;
    using Utility;

    public class PointGame : AbstractArchitecture<PointGame>
    {
        protected override void Init()
        {
            // 注册 Model
            this.RegisterModel<IGameModel>(new GameModel());

            // 注册 System
            this.RegisterSystem<ICountDownSystem>(new CountDownSystem());
            this.RegisterSystem<IScoreSystem>(new ScoreSystem());
            this.RegisterSystem<IAchievementSystem>(new AchievementSystem());

            // 注册 Utility
            this.RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
    }
}