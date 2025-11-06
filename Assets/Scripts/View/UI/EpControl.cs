// ------------------------------------------------------------
// @file       EpControl.cs
// @brief
// @author     zhangyiran
// @Modified   2025-04-16 14:47:44
// @Copyright  Copyright (c) 2025, zhangyiran
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;

namespace AmpereForce
{
    using Framework3.Core;

    /// <summary>
    ///  实验控制UI
    /// </summary>
    public class EpControl : AbstractView
    {
        [HierarchyPath("btnEpType")]
        public Button BtnEpType; // 切换实验类型

        [HierarchyPath("btnMagneticDir")]
        public Button BtnMagneticDir; // 翻转磁场方向

        [HierarchyPath("btnMode")]
        public Button BtnMode; // 切换模式

        [HierarchyPath("btnIDir")]
        public Button BtnIDir; // 翻转磁场方向

        [HierarchyPath("I_ValueGroup")]
        public HorizontalLayoutGroup IValueGroup;

        [HierarchyPath("B_ValueGroup")]
        public HorizontalLayoutGroup BValueGroup;

        // I 和 B 的按钮值
        private List<float> _iValues = new List<float>() { 0, 0.2f, 0.4f, 0.6f };
        private List<float> _bValuesInAmpereType = new List<float>() { 0, 3, 6, 9 };
        private List<float> _bValuesInLorentzType = new List<float>() { 0, 1, 2, 3 };

        private void Awake()
        {
            this.BindHierarchyComponent();

            // _btnEpType.onClick.AddListener(OnBtnEpTypeClick); // 实验类型切换

            // 改变磁场方向
            // _btnMagneticDir.onClick.AddListener(OnBtnMagneticDirClick);

            // 改变电流方向
            // _btnIDir.onClick.AddListener(OnBtnIDirClick);

            // 设置电流值
            IValueGroupInit();

            // 设置磁场值
            BValueGroupInit();


            // 注册切换实验事件
            TypeEventSystem.Global.Register<ChangeEpTypeEvent>(e =>
            {
                BtnIDir.interactable = e.Type == EpType.AmpereForce;

                for (int i = 0; i < IValueGroup.transform.childCount; i++)
                {
                    // 获取子元素的Button组件
                    var btn = IValueGroup.transform.GetChild(i).GetComponent<Button>();

                    // 如果不是安培力实验，则将 btn 失活
                    btn.interactable = e.Type == EpType.AmpereForce;
                }
            });
        }

        private void OnApplicationQuit()
        {
            // 整体实验结束运行后保存文件
            this.GetModel<RecordModel>().SaveRecord();
        }

        [Button]
        public void OnBtnIDirClick()
        {
            var model = this.GetModel<MagneticModel>();
            model.I *= -1;
            TypeEventSystem.Global.Send<ChangeIDirEvent>();
        }

        [Button]
        public void OnBtnMagneticDirClick()
        {
            var model = this.GetModel<MagneticModel>();
            model.Data.Direction *= -1;
            TypeEventSystem.Global.Send<ChangeMagneticDirEvent>();
        }

        public void OnBtnModeClick()
        {
            var model = this.GetModel<MagneticModel>();
            var text = BtnMode.GetComponentInChildren<TextMeshProUGUI>();

            var currentMode = model.EpMode.Value;
            if (currentMode == EpMode.Macro)
            {
                model.EpMode.Value = EpMode.Micro;
                text.text = "微观模式:开";
            }
            else
            {
                model.EpMode.Value = EpMode.Macro;
                text.text = "微观模式:关";
            }
        }

        // 每个button的记录函数
        public void Record(string btnName)
        {
            this.GetModel<RecordModel>().BtnClick(btnName);
        }

        // 点击开始实验，重新开始记录
        public void StartRecord()
        {
            this.GetModel<RecordModel>().StartRecord();
        }

        // 结束实验，将记录存入Sheet
        public void StopRecord()
        {
            this.GetModel<RecordModel>().StopRecord();
        }

        private void IValueGroupInit()
        {
            // 遍历_iValueGroup的子元素
            for (int i = 0; i < IValueGroup.transform.childCount; i++)
            {
                // 获取子元素的Button组件
                var btn = IValueGroup.transform.GetChild(i).GetComponent<Button>();
                // 缓存i的值
                var cacheI = i;
                // 给Button添加点击事件监听
                btn.onClick.AddListener(() =>
                {
                    // 获取MagneticModel模型
                    var model = this.GetModel<MagneticModel>();
                    // 设置模型的I值
                    model.I = _iValues[cacheI];
                });
            }
        }

        private void BValueGroupInit()
        {
            // 遍历_bValueGroup的子元素
            for (int i = 0; i < BValueGroup.transform.childCount; i++)
            {
                // 获取子元素的Button组件
                var btn = BValueGroup.transform.GetChild(i).GetComponent<Button>();
                // 缓存i的值
                var cacheI = i;
                // 给Button添加点击事件监听
                btn.onClick.AddListener(() =>
                {
                    // 获取MagneticModel模型
                    var model = this.GetModel<MagneticModel>();
                    // 依据当前实验类型获取按钮值列表
                    var valueList = model.EpType == EpType.AmpereForce ? _bValuesInAmpereType : _bValuesInLorentzType;

                    // 更改磁场大小
                    model.Data.Magnitude = valueList[cacheI];
                });

                // 注册实验类型切换事件
                TypeEventSystem.Global.Register<ChangeEpTypeEvent>(e =>
                {
                    // 获取 txt 组件
                    var txt = btn.GetComponentInChildren<TextMeshProUGUI>();

                    // 依据当前实验类型获取按钮值列表
                    var valueList = e.Type == EpType.AmpereForce ? _bValuesInAmpereType : _bValuesInLorentzType;

                    // 更新按钮文字
                    txt.text = $"{valueList[cacheI]:F0}T";
                });
            }
        }

        public void OnBtnEpTypeClick()
        {
            // 获取MagneticModel模型
            var model = this.GetModel<MagneticModel>();
            // 获取按钮上的文本
            var text = BtnEpType.GetComponentInChildren<TextMeshProUGUI>();

            // 如果当前模式是AmpereForce
            if (model.EpType == EpType.AmpereForce)
            {
                // 将模式改为LorentzForce
                model.EpType = EpType.LorentzForce;
                // 将按钮上的文本改为“模式：电磁感应”
                text.text = "模式：电磁感应";

                // 发送实验切换事件
                TypeEventSystem.Global.Send(new ChangeEpTypeEvent(EpType.LorentzForce));
            }
            // 否则
            else
            {
                // 将模式改为AmpereForce
                model.EpType = EpType.AmpereForce;
                // 将按钮上的文本改为“模式：恒定电流”
                text.text = "模式：恒定电流";

                // 发送实验切换事件
                TypeEventSystem.Global.Send(new ChangeEpTypeEvent(EpType.AmpereForce));
            }
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}