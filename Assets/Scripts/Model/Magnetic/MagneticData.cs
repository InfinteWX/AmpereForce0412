using Sirenix.OdinInspector;

namespace AmpereForce
{
    using UnityEngine;

    [ShowInInspector]
    public class MagneticData
    {
        public Vector3 Direction; // 磁场方向

        public float Magnitude; // 磁场强度

        // 磁场
        public Vector3 B
        {
            get => Direction * Magnitude;
        }

        public Bounds Bounds; // 磁场边界
    }

    /// <summary>
    /// 实验类型
    /// </summary>
    public enum EpType
    {
        AmpereForce,
        LorentzForce
    }
}