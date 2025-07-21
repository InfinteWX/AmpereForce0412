// ------------------------------------------------------------
// @file       CountDownSystem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 13:10:40
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._7.PointPointPoint.Scripts.System.CountSownSystem
{
    using global::System;

    public class CountDownSystem : AbstractSystem, ICountDownSystem
    {
        private DateTime _gameStartTime;
        private bool     _started;

        protected override void OnInit()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);
            this.RegisterEvent<GameWinEvent>(OnGameWin);
        }

        public int CurrentRemainSecond
        {
            get { return 10 - (int) (DateTime.Now - _gameStartTime).TotalSeconds; }
        }

        public void Update()
        {
            if (!_started) return;

            if (DateTime.Now - _gameStartTime > TimeSpan.FromSeconds(10))
            {
                this.SendEvent<OnCountDownEndEvent>();
            }
        }

        private void OnGameStart(GameStartEvent e)
        {
            _started       = true;
            _gameStartTime = DateTime.Now;
        }

        private void OnGameWin(GameWinEvent e)
        {
            _started = false;
        }
    }
}