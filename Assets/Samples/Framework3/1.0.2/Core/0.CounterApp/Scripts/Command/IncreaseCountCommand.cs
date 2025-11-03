// ------------------------------------------------------------
// @file       IncreaseCountCommand.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:04
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._0.CounterApp.Scripts.Command
{
    using Model;

    // 增加计数命令，继承自 AbstractCommand
    public class IncreaseCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICounterAppModel>().Count.Value++;
        }
    }
}