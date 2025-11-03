// ------------------------------------------------------------
// @file       ForceVisualizer.cs
// @brief
// @author     zhangyiran
// @Modified   2025-04-21 14:59:09
// @Copyright  Copyright (c) 2025, zhangyiran
// ------------------------------------------------------------

using System;
using Framework3.Toolkits.FluentAPI;
using Framework3.Toolkits.SingletonKit;
using Shapes;
using UnityEngine;

namespace AmpereForce
{
    using Framework3.Core;

    public class ForceVisualizer : MonoSingleton<ForceVisualizer>
    {
        [HierarchyPath("Plane")]
        public Rectangle Plane;

        [HierarchyPath("ForceArrow")]
        public Arrow ForceArrow;

        [HierarchyPath("BArrow")]
        public Arrow BArrow;
        
        [HierarchyPath("IArrow")]
        public Arrow IArrow;

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
            
            // 更新电流
            UpdateIArrow(model);
        }

        private void UpdateIArrow(MagneticModel model)
        {
            // 更新I箭头的值向量
            IArrow.ValueVector = model.I * model.CylinderDir.normalized;

            // 计算I箭头的中间位置
            var middlePos = -IArrow.LengthVector / 2;
            // 设置I箭头的位置
            IArrow.SetLocalPosition(middlePos + Vector3.right*0.05f); // 偏移一点点
            //实时更新电流文字
            IArrow.Text.text = $"I: {model.I:F2}A";
        }
        private void UpdateBArrow(MagneticModel model)
        {
            // 更新B箭头的值向量
            BArrow.ValueVector = model.Data.B * 0.2f;

            // 计算B箭头的中间位置
            var middlePos = -BArrow.LengthVector / 2;
            // 设置B箭头的位置
            BArrow.SetLocalPosition(middlePos);
            //实时更新磁场文字
            BArrow.Text.text = $"B: {model.Data.B.magnitude}T";
        }

        private void UpdateForceArrow(MagneticModel model)
        {
            // 更新力箭头
            ForceArrow.ValueVector = model.CurrentForce;
            // 实时更新力文字
            ForceArrow.Text.text = $"F: {model.CurrentForce.magnitude:F2}N"; 
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}