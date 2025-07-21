using UnityEngine;

namespace AmpereForce
{
    /// <summary>
    /// Touch 方法封装
    /// </summary>
    public class HapticHelper
    {
        /// <summary>
        /// 力反馈设备设置力
        /// </summary>
        /// <param name="force"></param>
        public static void SetForce(Vector3 force)
        {
            HapticPlugin.setForce("Default Device", new double[] { force.x, force.y, force.z }, new[] { 0d, 0d, 0d });
        }

        /// <summary>
        /// 获取力反馈设备速度
        /// </summary>
        /// <returns>速度向量</returns>
        public static Vector3 GetVelocity()
        {
            var velocity = new double[3];
            HapticPlugin.getVelocity("Default Device", velocity);
            return new Vector3((float)velocity[0], (float)velocity[1], (float)velocity[2]);
        }
    }
}