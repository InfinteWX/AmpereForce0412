// ------------------------------------------------------------
// @file       Arrow.cs
// @brief
// @author     zhangyiran
// @Modified   2025-04-21 15:11:47
// @Copyright  Copyright (c) 2025, zhangyiran
// ------------------------------------------------------------

using System;
using Framework3.Core;
using Framework3.Toolkits.FluentAPI;
using Shapes;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace AmpereForce
{
    using Framework3.Core;

    public class Arrow : AbstractView
    {
        [HierarchyPath("Line")]
        public Line Line;

        [HierarchyPath("Cone")]
        public Cone Cone;

        [HierarchyPath("Text")]
        public TextMeshPro Text;

        public Vector3 TextOffset;

        [PropertyRange(0, 1f)]
        public float LengthRatio = 0.5f;

        /// <summary>
        /// 世界坐标系下的箭头矢量（大小+方向）
        /// </summary>
        public Vector3 ValueVector
        {
            get => transform.TransformVector(Line.End / LengthRatio);
            set
            {
                var localVec = transform.InverseTransformVector(value); // 转为本地向量
                Line.End = localVec * LengthRatio;

                Cone.SetLocalPosition(Line.End);
                Cone.SetTransformForward(Line.End);
                Text.SetLocalPosition(Line.End + TextOffset);
                // Text.SetTransformRight(Line.End);
            }
        }

        public Vector3 LengthVector
        {
            get => transform.TransformVector(Line.End);
        }

        private void Awake()
        {
            this.BindHierarchyComponent();
        }

        private void Update()
        {
            // var localPos = Line.End + new Vector3(TextOffset.x, TextOffset.y, 0);
            // Text.SetLocalPosition(localPos); // 更新力显示的位置
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}