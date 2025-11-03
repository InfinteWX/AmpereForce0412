// ------------------------------------------------------------
// @file       BuyLifeCommand.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 14:10:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Command
{
    using Model;

    public class BuyLifeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.Life.Value++;
            gameModel.Gold.Value--;
        }
    }
}