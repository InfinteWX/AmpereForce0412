// ------------------------------------------------------------
// @file       GameModel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-14 18:10:33
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.Model
{
    using UnityEngine;
    using Utility;

    public class GameModel : AbstractModel, IGameModel
    {
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>() { Value = 0 };

        public BindableProperty<int> Gold { get; } = new BindableProperty<int>() { Value = 0 };

        public BindableProperty<int> Score { get; } = new BindableProperty<int>() { Value = 0 };

        public BindableProperty<int> BestScore { get; } = new BindableProperty<int>() { Value = 0 };

        public BindableProperty<int> Life { get; } = new BindableProperty<int>() { Value = 0 };

        protected override void OnInit()
        {
            // 获取 IStorage 工具
            var storage = this.GetUtility<IStorage>();
            Debug.Log(storage);

            // 初始化数据，绑定监听事件
            BestScore.Value = storage.LoadInt(nameof(BestScore), 0);
            BestScore.Register((oldValue, value) => storage.SaveInt(nameof(BestScore), value));

            Life.Value = storage.LoadInt(nameof(Life), 3);
            Life.Register((oldValue, value) => storage.SaveInt(nameof(Life), value));

            Gold.Value = storage.LoadInt(nameof(Gold), 0);
            Gold.Register((oldValue, value) => storage.SaveInt(nameof(Gold), value));
        }
    }
}