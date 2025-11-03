// ------------------------------------------------------------
// @file       Electronics.cs
// @brief
// @author     zheliku
// @Modified   2025-07-21 11:38:37
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using Framework3.Toolkits.FluentAPI;
using Unity.VisualScripting;
using UnityEngine;

namespace AmpereForce
{
    using Framework3.Core;

    public enum EpMode
    {
        Macro,
        Micro
    }

    public class ElectronicsCtl : AbstractView
    {
        // 定义一个Transform类型的List，用于存储电子元件
        public List<Transform> Electronics;

        // 定义一个float类型的Speed，用于控制电子元件的移动速度
        public float Speed = 0.4f;

        // 定义一个bool类型的IsRunning，用于判断电子元件是否正在运行
        public bool IsMicro { get; set; }

        // 在Awake方法中，注册一个事件，当EpMode发生变化时，更新IsRunning的值
        private void Awake()
        {
            this.GetModel<MagneticModel>().EpMode.Register((oldValue, newValue) =>
            {
                IsMicro = newValue == EpMode.Micro;
                // Debug.Log($"EpMode changed from {oldValue} to {newValue}, IsRunning is {IsMicro}");
            }).UnregisterWhenGameObjectDestroyed(this);
        }

        // 在Update方法中，如果IsRunning为true，则遍历Electronics，更新每个电子元件的位置
        private void Update()
        {
            // 获取当前磁场力
            var I = this.GetModel<MagneticModel>().I;
            Debug.Log("I:" + I);
            // 判断是否在运行状态
            bool IsRunning = IsMicro && (I.Abs()  > 0);
            // Debug.Log("IsRunning_:" + IsRunning_);
            if (IsRunning)
            {
                // 遍历电子元件
                foreach (var electronic in Electronics)
                {
                    // 计算电子元件的移动方向
                    var IDir = I > 0 ? 1 : -1;
                    // 计算电子元件的移动距离
                    var deltaY = Time.deltaTime * Speed * I;
                    // 更新电子元件的位置
                    electronic.Translate(Vector3.up * deltaY, Space.Self);

                    // 获取电子元件的本地位置Y坐标
                    var localPosY = electronic.GetLocalPositionY();
                    // 如果电子元件的本地位置Y坐标大于1，则将其位置设置为-1
                    if (localPosY > 1)
                    {
                        electronic.SetLocalPosition(y: localPosY - 2);
                    }
                    // 如果电子元件的本地位置Y坐标小于-1，则将其位置设置为1
                    else if (localPosY < -1)
                    {
                        electronic.SetLocalPosition(y: localPosY + 2);
                    }
                }
            }
            else
            {
                return;
            }
        }

        // 返回当前架构
        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}