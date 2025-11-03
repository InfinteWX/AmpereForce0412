// ------------------------------------------------------------
// @file       ICounterAppModel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:51
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._0.CounterApp.Scripts.Model
{
    // 计数应用模型接口，继承自 IModel
    public interface ICounterAppModel : IModel
    {
        public BindableProperty<int> Count { get; } // 计数属性，可以绑定事件，当值变更时触发事件
    }
}