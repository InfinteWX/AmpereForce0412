// ------------------------------------------------------------
// @file       KillEnemyCommand.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 14:10:25
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Command
{
    using Model;
    using UnityEngine;

    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.KillCount.Value++;

            if (Random.Range(0, 10) <= 3)
            { // 30% 概率掉落 1-2 金币
                gameModel.Gold.Value += Random.Range(1, 3);
            }

            this.SendEvent<OnEnemyKillEvent>();

            if (gameModel.KillCount.Value == 10)
            { // 杀死 10 个敌人胜利
                this.SendEvent<GameWinEvent>();
            }
        }
    }
}