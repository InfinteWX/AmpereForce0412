// ------------------------------------------------------------
// @file       CounterAppView.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:52
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._0.CounterApp.Scripts.View
{
    using Command;
    using Core;
    using Model;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.UI;

    public class CounterAppView : AbstractView
    {
        protected override IArchitecture _Architecture => CounterApp.Architecture;

        private Button _btnAdd;
        private Button _btnSub;
        private Text   _txtCount;

        [ShowInInspector]
        private ICounterAppModel _model;

        private void Start()
        {
            // 获取模型
            _model = this.GetModel<ICounterAppModel>();

            // View 组件获取
            _btnAdd   = GameObject.Find("Canvas/BtnAdd").GetComponent<Button>();
            _btnSub   = GameObject.Find("Canvas/BtnSub").GetComponent<Button>();
            _txtCount = GameObject.Find("Canvas/TxtCount").GetComponent<Text>();

            // 监听输入
            _btnAdd.onClick.AddListener(this.SendCommand<IncreaseCountCommand>);
            _btnSub.onClick.AddListener(() =>
            {
                // 交互逻辑
                this.SendCommand(new DecreaseCountCommand( /* 这里可以传参（如果有） */));
            });

            _model.Count.RegisterWithInitValue(UpdateView)
                  .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void UpdateView(int oldCount, int count)
        {
            _txtCount.text = count.ToString();
        }

        private void OnDestroy()
        {
            // 将 Model 置空
            _model = null;
        }
    }
}