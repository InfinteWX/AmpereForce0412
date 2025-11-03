// ------------------------------------------------------------
// @file       HapticCylinder.cs
// @brief
// @author     zhangyiran
// @Modified   2025-04-13 20:24:50
// @Copyright  Copyright (c) 2025, zhangyiran
// ------------------------------------------------------------

using System;
using Framework3.Toolkits.ActionKit;
using Framework3.Toolkits.EventKit;
using Framework3.Toolkits.FluentAPI;
using Framework3.Toolkits.SingletonKit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AmpereForce
{
    using Framework3.Core;

    /// <summary>
    /// Touch 棍子
    /// </summary>
    public class HapticCylinder : MonoSingleton<HapticCylinder>
    {
        [ShowInInspector]
        public bool IsInMagnetic { get; private set; } // 是否在磁场内

        public Transform StartSide;
        public Transform EndSide;
        
        public Transform FollowStartSide;
        public Transform FollowEndSide;
        
        public ElectronicsCtl ElectronicsCtl; 

        public Vector3 Velocity // 棍棒速度
        {
            get => HapticHelper.GetVelocity() / 100f; // 除以 100 以缩放大小
        }

        private void Awake()
        {
            this.GetModel<MagneticModel>().EpMode.Register((oldValue, newValue) =>
            {
                var alpha = newValue == EpMode.Macro ? 1 : 0.1f;
                
                GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, alpha);
            }).UnregisterWhenGameObjectDestroyed(this);
        }

        private void Start()
        {
            // 延迟0.1秒后执行
            ActionKit.Delay(0.1f, () =>
            {
                // 当FollowStartSide更新时，将其位置设置为StartSide的位置
                FollowStartSide.OnUpdateEvent(() =>
                {
                    FollowStartSide.position = StartSide.position;
                });
                // 当FollowEndSide更新时，将其位置设置为EndSide的位置
                FollowEndSide.OnUpdateEvent(() =>
                {
                    FollowEndSide.position = EndSide.position;
                });    
            }).Start(this);
        }

        protected override void Update()
        {
            var model = this.GetModel<MagneticModel>();

            if (IsInMagnetic) // 在磁场区域内，则不断更新
            {
                if (model.EpType == EpType.AmpereForce) // 依据当前类型，做相应的更新
                {
                    AmpereForceUpdate();
                }
                else if (model.EpType == EpType.LorentzForce)
                {
                    LorentzForceUpdate();
                }
            }
            else
            {
                HapticHelper.SetForce(Vector3.zero); // 不在磁场区域内，需要设置力为 0，否则会一直有力
            }

            // 实时更新棍棒位置和角度
            model.CylinderPos = this.GetPosition();
            model.CylinderDir = -transform.up;
        }

        private void OnTriggerEnter(Collider other)
        {
            // 记录进入磁场区域
            if (other.CompareTag("MagneticField"))
            {
                IsInMagnetic = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // 记录退出磁场区域
            if (other.CompareTag("MagneticField"))
            {
                IsInMagnetic = false;
            }
        }

        /// <summary>
        /// 更新安培力的作用
        /// </summary>
        private void AmpereForceUpdate()
        {
            var magneticModel = this.GetModel<MagneticModel>(); // 获取数据

            // 获取参数
            var B = magneticModel.Data.B;
            var I = this.GetModel<MagneticModel>().I;
            var L = PhysicsHelper.CalculateL(
                magneticField: magneticModel.Data.Bounds,
                cylinderPos: this.GetPosition(),
                cylinderDir: transform.up,
                length: this.GetScale().y);

            var ampereForce = PhysicsHelper.CalculateAmpereForce(B, I, L); // 计算力

            Debug.Log($"B: {B} || I: {I} || L: {L} || ampereForce: {ampereForce}");

            HapticHelper.SetForce(ampereForce); // 施加力

            magneticModel.AmpereForce = ampereForce; // 更新力
        }

        /// <summary>
        /// 更新洛伦兹力的作用
        /// </summary>
        private void LorentzForceUpdate()
        {
            var magneticModel = this.GetModel<MagneticModel>(); // 获取数据

            // 获取参数
            var B = magneticModel.Data.B;
            var L = PhysicsHelper.CalculateL(
                magneticField: magneticModel.Data.Bounds,
                cylinderPos: this.GetPosition(),
                cylinderDir: transform.up,
                length: this.GetScale().y);
            var V = Velocity;
            var R = this.GetModel<MagneticModel>().R;

            var E = PhysicsHelper.CalculateE(B, L, V); // 计算电动势
            var I = E / R;

            magneticModel.I = I; // 更新安培力数据

            var lorentzForce = PhysicsHelper.CalculateAmpereForce(B, I, L); // 计算力

            Debug.Log($"V: {V} || E: {E} || lorentzForce: {lorentzForce}");

            HapticHelper.SetForce(lorentzForce); // 施加力
            
            magneticModel.LorentzForce = lorentzForce; // 更新力
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}