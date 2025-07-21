// ------------------------------------------------------------
// @file       MagneticDir.cs
// @brief
// @author     zhangyiran
// @Modified   2025-04-16 15:19:52
// @Copyright  Copyright (c) 2025, zhangyiran
// ------------------------------------------------------------

using System;
using Framework.Toolkits.FluentAPI;
using UnityEngine;

namespace AmpereForce
{
    using Framework.Core;

    /// <summary>
    /// 注册事件
    /// </summary>
    public class Magnet : AbstractView
    {
        [HierarchyPath("固定磁感线/椎体")]
        public Transform MagneticLine;

        [HierarchyPath("马蹄铁模型")]
        public Transform MagneticModel;

        private void Awake()
        {
            this.BindHierarchyComponent();
            
            //  注册事件 ChangeMagneticDirEvent
            TypeEventSystem.GLOBAL.Register<ChangeMagneticDirEvent>(e =>
            {
                // 翻转箭头
                var y = MagneticLine.GetLocalScaleY();
                MagneticLine.SetLocalScale(y: -y);

                // 翻转马蹄铁
                y = MagneticModel.GetLocalScaleY();
                MagneticModel.SetLocalScale(y: -y);
            }).UnRegisterWhenGameObjectDestroyed(this);
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}