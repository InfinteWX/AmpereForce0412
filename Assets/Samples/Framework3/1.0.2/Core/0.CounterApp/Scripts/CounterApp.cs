// ------------------------------------------------------------
// @file       CouterApp.cs
// @brief
// @author     zheliku
// @Modified   2024-10-08 23:10:10
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._0.CounterApp.Scripts
{
    using System;
    using Model;
    using UnityEngine;
    using Utility;

    public class CounterApp : AbstractArchitecture<CounterApp>
    {
        protected override void Init()
        {
            // 注册 System 
            this.RegisterSystem<IAchievementSystem>(new AchievementSystem());

            // 注册 Model
            this.RegisterModel<ICounterAppModel>(new CounterAppModel());

            // 注册存储工具的对象
            this.RegisterUtility<IStorage>(new Storage());
        }

        // 重写 ExecuteCommand 方法以添加日志功能
        protected override void ExecuteCommand(ICommand command)
        {
            Debug.Log("Before " + command.GetType().Name + "Execute");
            base.ExecuteCommand(command);
            Debug.Log("After " + command.GetType().Name + "Execute");
        }

        protected override TResult ExecuteCommand<TResult>(ICommand<TResult> command)
        {
            Debug.Log("Before " + command.GetType().Name + "Execute");
            var result = base.ExecuteCommand(command);
            Debug.Log("After " + command.GetType().Name + "Execute");
            return result;
        }
    }
}