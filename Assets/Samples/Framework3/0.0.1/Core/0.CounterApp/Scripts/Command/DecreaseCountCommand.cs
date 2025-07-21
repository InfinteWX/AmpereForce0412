// ------------------------------------------------------------
// @file       IncreaseCountCommand.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._0.CounterApp.Scripts.Command
{
    using Core.Command;
    using Model;

    public class DecreaseCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICounterAppModel>().Count.Value--;
        }
    }
}