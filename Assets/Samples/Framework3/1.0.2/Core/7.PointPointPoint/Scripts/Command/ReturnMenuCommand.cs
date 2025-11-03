// ------------------------------------------------------------
// @file       ReturnMenuCommand.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 17:10:58
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using NotImplementedException = System.NotImplementedException;

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Command
{

    public class ReturnMenuCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<OnReturnMenuEvent>();
        }
    }
}