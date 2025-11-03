using System;
using Framework3.Core;
using Sirenix.OdinInspector;

namespace AmpereForce
{
    using Framework3.Core;
    using UnityEngine;

    /// <summary>
    /// 整个实验的数据
    /// </summary>
    [ShowInInspector]
    public class MagneticModel : AbstractModel
    {
        private EpType _epType = EpType.AmpereForce; // 实验类型

        public EpType EpType
        {
            get => _epType;
            set
            {
                _epType = value;
                switch (_epType)
                {
                    case EpType.AmpereForce:  LorentzForce = Vector3.zero; break;  // 恒定电流设置洛伦兹力为0
                    case EpType.LorentzForce: AmpereForce  = Vector3.zero; break;  // 电磁感应设置安培力为0
                    default:                  throw new ArgumentOutOfRangeException();
                }

                Data.Magnitude = 0; // 切换模式后，磁场默认为 0
            }
        }

        public BindableProperty<EpMode> EpMode = new();

        [ShowInInspector]
        public MagneticData Data = new MagneticData()
        {
            Direction = Vector3.down,
            Magnitude = 1,
        };

        public float I = 0f; // 电流值，正负表示方向

        public float R = 1f; // 电阻值

        public Vector3 CylinderPos; // 导体棒位置

        public Vector3 CylinderDir; // 导体棒方向

        public Vector3 AmpereForce; // 安培力

        public Vector3 LorentzForce; // 洛伦兹力

        // 当前力
        public Vector3 CurrentForce
        {
            get => _epType switch {
                EpType.AmpereForce  => AmpereForce,
                EpType.LorentzForce => LorentzForce,
                _                   => throw new ArgumentOutOfRangeException()
            };
        }

        protected override void OnInit()
        { }
    }
}