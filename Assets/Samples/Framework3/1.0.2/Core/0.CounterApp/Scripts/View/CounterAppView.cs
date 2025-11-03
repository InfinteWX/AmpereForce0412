// ------------------------------------------------------------
// @file       CounterAppView.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:52
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._0.CounterApp.Scripts.View
{
    using Command;
    using Core;
    using Model;
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine.UI;

    public class CounterAppView : AbstractView
    {
        protected override IArchitecture _Architecture
        {
            get => CounterApp.Architecture;
        }

        [HierarchyPath("/Canvas/Txt_Count")] // View 组件获取（方式 1），使用特性绑定，"/Canvas/Txt_Count" 是组件在场景中的路径
        private TextMeshProUGUI _txtCount;

        [ShowInInspector]
        private ICounterAppModel _model;

        private void Start()
        {
            // 获取模型
            _model = this.GetModel<ICounterAppModel>();

            // View 组件获取（方式 2）
            // _txtCount = GameObject.Find("Canvas/TxtCount").GetComponent<Text>();

            // 绑定 Model 事件，更新视图
            // 每次 Count 变更时，都会调用 UpdateView 方法
            _model.Count.RegisterWithInitValue(UpdateView) // 一开始就更新一次视图
                  .UnregisterWhenGameObjectDestroyed(gameObject);
        }

        private void UpdateView(int oldCount, int count)
        {
            _txtCount.text = count.ToString();
        }
        
        // 用于按钮点击事件绑定
        public void IncreaseCount()
        {
            this.SendCommand<IncreaseCountCommand>();
        }
        
        // 用于按钮点击事件绑定
        public void DecreaseCount()
        {
            this.SendCommand<DecreaseCountCommand>();
        }

        private void OnDestroy()
        {
            // 可选，将 Model 置空
            // _model = null;
        }
    }
}