// ------------------------------------------------------------
// @file       MissCommand.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 14:10:06
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Command
{
    using Model;

    public class MissCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            if (gameModel.Life.Value > 0)
            {
                gameModel.Life.Value--;
            }
            else
            {
                this.SendEvent<OnMissEvent>();
            }
        }
    }
}