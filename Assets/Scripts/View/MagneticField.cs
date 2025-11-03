using System;
using UnityEngine;

namespace AmpereForce
{
    using Framework3.Core;

    /// <summary>
    /// 磁场区域
    /// </summary>
    public class MagneticField : AbstractView
    {
        private void Awake()
        {
            var magneticModel = this.GetModel<MagneticModel>();
            
            // 初始设置数据
            magneticModel.Data.Bounds = GetComponent<Collider>().bounds;
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}