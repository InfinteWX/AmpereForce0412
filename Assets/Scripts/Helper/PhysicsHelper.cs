namespace AmpereForce
{
    using Framework.Toolkits.FluentAPI;
    using UnityEngine;

    /// <summary>
    /// 物理量计算 Helper
    /// </summary>
    public class PhysicsHelper
    {
        public static Vector3 CalculateL(Bounds magneticField, Vector3 cylinderPos, Vector3 cylinderDir, float length)
        {
            return cylinderDir.normalized * length; // todo 先不考虑长度问题
        }

        /// <summary>
        /// 计算安培力
        /// </summary>
        /// <param name="B">磁场强度</param>
        /// <param name="I">电流大小</param>
        /// <param name="L">杆向量</param>
        /// <returns>安培力</returns>
        public static Vector3 CalculateAmpereForce(
            Vector3 B,
            float   I,
            Vector3 L)
        {
            if (B.magnitude == 0)
            {
                return Vector3.zero;
            }

            var projection = Vector3.Dot(B, L) / B.magnitude;                    // 投影
            var effectiveL = Mathf.Sqrt(L.magnitude.Pow(2) - projection.Pow(2)); // 有效长度
            
            return I * Vector3.Cross(L.normalized * effectiveL, B);
        }

        /// <summary>
        /// 计算电动势大小
        /// </summary>
        /// <param name="B">磁场强度</param>
        /// <param name="L">杆向量</param>
        /// <param name="V">切割速度</param>
        /// <returns>电动势大小</returns>
        public static float CalculateE(
            Vector3 B,
            Vector3 L,
            Vector3 V)
        {
            if (B.magnitude == 0)
            {
                return 0;
            }
            
            var projection = Vector3.Dot(B, L) / B.magnitude;                    // 投影
            var effectiveL = Mathf.Sqrt(L.magnitude.Pow(2) - projection.Pow(2)); // 有效长度

            var BL_Plane   = new Plane(Vector3.zero, B, L);
            var effectiveV = BL_Plane.GetDistanceToPoint(V); // 有效速度

            return B.magnitude * effectiveL * effectiveV;
        }
    }
}