// ------------------------------------------------------------
// @file       IGameModel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-14 18:10:53
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Model
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> KillCount { get; }

        BindableProperty<int> Gold { get; }

        BindableProperty<int> Score { get; }

        BindableProperty<int> BestScore { get; }

        BindableProperty<int> Life { get; }
    }
}