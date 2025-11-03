// ------------------------------------------------------------
// @file       ScoreSystem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 17:10:03
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.System.ScoreSystem
{
    using CountSownSystem;
    using Framework3.Core.Example._7.PointPointPoint.Scripts.Model;

    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        private IGameModel _gameModel;

        protected override void OnInit()
        {
            _gameModel = this.GetModel<IGameModel>();

            this.RegisterEvent<OnEnemyKillEvent>(OnEnemyKill);
            this.RegisterEvent<OnMissEvent>(OnMiss);
            this.RegisterEvent<GameWinEvent>(OnGameWin);
        }

        private void OnEnemyKill(OnEnemyKillEvent e)
        {
            _gameModel.Score.Value += 10;
        }

        private void OnMiss(OnMissEvent e)
        {
            _gameModel.Score.Value -= 5;
        }

        private void OnGameWin(GameWinEvent e)
        {
            var countDownSystem = this.GetSystem<ICountDownSystem>();

            var newScore = countDownSystem.CurrentRemainSecond * 10;
            _gameModel.Score.Value += newScore;

            if (_gameModel.Score.Value > _gameModel.BestScore.Value)
            { // 更新最佳分数
                _gameModel.BestScore.Value = _gameModel.Score.Value;
            }
        }
    }
}