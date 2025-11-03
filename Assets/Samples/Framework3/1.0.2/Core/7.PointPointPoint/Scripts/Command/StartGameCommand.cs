// ------------------------------------------------------------
// @file       StartGameCommand.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 14:10:51
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Command
{
    using Model;

    public class StartGameCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            // 重置数据
            var gameModel = this.GetModel<IGameModel>();

            gameModel.KillCount.Value = 0;
            gameModel.Score.Value     = 0;

            this.SendEvent<GameStartEvent>();
        }
    }
}