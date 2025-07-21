// ------------------------------------------------------------
// @file       ForceVisualizer.cs
// @brief
// @author     zhangyiran
// @Modified   2025-04-21 14:59:09
// @Copyright  Copyright (c) 2025, zhangyiran
// ------------------------------------------------------------

using System;
using Framework.Toolkits.FluentAPI;
using Framework.Toolkits.SingletonKit;
using Shapes;
using UnityEngine;

namespace AmpereForce
{
    using Framework.Core;

    public class ForceVisualizer : MonoSingleton<ForceVisualizer>
    {
        [HierarchyPath("Plane")]
        public Rectangle Plane;

        [HierarchyPath("ForceArrow")]
        public Arrow ForceArrow;

        [HierarchyPath("BArrow")]
        public Arrow BArrow;

        public override void OnSingletonInit()
        {
            // this.BindHierarchyComponent();
        }

        private void Awake()
        {
            this.BindHierarchyComponent();
        }

        protected override void Update()
        {
            base.Update();

            var model = this.GetModel<MagneticModel>();

            // 更新平面的位置和角度
            this.SetPosition(model.CylinderPos);

            Debug.Log($"CylinderDir: {model.CylinderDir}");

            Plane.transform.right = model.CylinderDir.Set(y: 0f); // 平面法线，只转水平面

            // 更新力
            UpdateForceArrow(model);

            // 更新磁场
            UpdateBArrow(model);
        }

        private void UpdateBArrow(MagneticModel model)
        {
            // 更新B箭头的值向量
            BArrow.ValueVector = model.Data.B;

            // 计算B箭头的中间位置
            var middlePos = -BArrow.LengthVector / 2;
            // 设置B箭头的位置
            BArrow.SetLocalPosition(middlePos);
        }

        private void UpdateForceArrow(MagneticModel model)
        {
            // 更新力箭头
            ForceArrow.ValueVector = model.CurrentForce;

            ForceArrow.Text.text = $"F: {model.CurrentForce.magnitude:F2}N"; // 实时更新力文字
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}