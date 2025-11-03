using Framework3.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace AmpereForce
{
    /// <summary>
    /// 电流表指针，子鹏代码，慎碰
    /// </summary>
    public class Pointer : AbstractView
    {
        /// <summary>
        /// 电流表量程
        /// </summary>
        public const float CurrentRange = 0.6f;

        public int a1;
        public int b2;
        public int c3;
        public int d4;
        public int e5;

        /// <summary>
        /// 电流强度
        /// </summary>
        [ShowInInspector] 
        [Range(-0.6f, 0.6f)]
        public float CurrentIntensity
        {
            get => this.GetModel<MagneticModel>().I;
        }

        /// <summary>
        /// 电流表指针旋转比例
        /// </summary>
        public float RotateScale = 0;

        /// <summary>
        /// 指针宽度
        /// </summary>
        public float LineWidth = 0.01f;

        [HierarchyPath("CenterMark")]
        public Transform CenterMark = null;

        public Transform[] LeftMarks  = null;
        public Transform[] RightMarks = null;

        [HierarchyPath("TopMark")]
        public Transform TopMark = null;

        [HierarchyPath]
        public LineRenderer LineRenderer = null;

        public Vector3 PointerPosition = Vector3.zero;

        private void Awake()
        {
            this.BindHierarchyComponent();

            // 获得左侧定位点坐标，为"LeftMarks"的所有子物体
            LeftMarks = new Transform[transform.Find("LeftMarks").childCount];
            for (int i = 0; i < LeftMarks.Length; i++)
            {
                LeftMarks[i] = transform.Find("LeftMarks").GetChild(i);
            }

            // 获得右侧定位点坐标，为"RightMarks"的所有子物体
            RightMarks = new Transform[transform.Find("RightMarks").childCount];
            for (int i = 0; i < RightMarks.Length; i++)
            {
                RightMarks[i] = transform.Find("RightMarks").GetChild(i);
            }
        }

        private void Update()
        {
            UpdateRotateScale();
            UpdatePointerPosition();
            UpdateVectorArrow(LineRenderer, CenterMark.position, PointerPosition, LineWidth,
                              Mathf.Abs(CurrentIntensity) > CurrentRange + 1e-5 ? Color.red : Color.blue);
        }

        /// <summary>
        /// 更新指针坐标（由旋转比例rotateScale计算指针尖端坐标）
        /// </summary>
        private void UpdatePointerPosition()
        {
            if (RotateScale >= 0)
                PointerPosition = CalculateArcPoint(RightMarks, Mathf.Abs(RotateScale));
            else
                PointerPosition = CalculateArcPoint(LeftMarks, Mathf.Abs(RotateScale));
        }

        /// <summary>
        /// 获取电流currentIntensity计算更新rotateScale （旋转比例）
        /// </summary>
        private void UpdateRotateScale()
        {
            // 获取电流大小(平滑后)
            // currentIntensity = 1;
            // 由电流计算指针旋转比例
            RotateScale = CurrentIntensity / CurrentRange;
            // 超量程时，对旋转比例超出部分进行截断
            RotateScale = Mathf.Clamp(RotateScale, -1.1f, 1.1f);
        }

        /// <summary>
        /// 在圆心角AOB中，求点C，使得角AOC占角AOB的比例为scale
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointO">圆心角顶点</param>
        /// <param name="scale">比例</param>
        /// <returns>点C坐标</returns>
        Vector3 CalculateArcPoint(Transform[] Marks, float scale)
        {
            // Marks[] 为0~1的均等分布的点，0为起点，1为终点
            // 首先计算出scale属于哪两个点之间
            int indexA = Mathf.FloorToInt(scale * (Marks.Length - 1));
            // 防止indexA越界
            indexA = Mathf.Clamp(indexA, 0, Marks.Length - 2);

            int     indexB = indexA + 1;
            Vector3 pointA = Marks[indexA].position;
            Vector3 pointB = Marks[indexB].position;
            Vector3 pointO = CenterMark.position;

            // 计算scale在indexA和indexB之间的比例
            scale = (scale - indexA * 1.0f / (Marks.Length - 1)) * (Marks.Length - 1);
            // 防止scale越界(允许超出一点点，但会被标记为红色)
            scale = Mathf.Clamp(scale, 0, 1.2f);

            //print(scale + " " + indexA + " " + indexB);

            // 计算AO向量
            Vector3 OA = pointA - pointO;

            // 计算BO向量
            Vector3 OB = pointB - pointO;

            float angleAOB = Vector3.Angle(OA, OB);

            // 计算旋转角度
            float angleAOC = scale * angleAOB;

            // 计算旋转轴
            Vector3 rotationAxis = Vector3.Cross(OA.normalized, OB.normalized);

            // 使用Quaternion.AngleAxis进行旋转
            Quaternion rotation = Quaternion.AngleAxis(angleAOC, rotationAxis);

            // 计算旋转后向量OC.normlized
            Vector3 rotatedPoint = rotation * OA;

            // 将旋转后的点映射到AO向量上，并加上O点的位置
            // 这里使用centerMark->topMark的向量作为映射基准长度
            Vector3 pointC = rotatedPoint.normalized * (TopMark.position - CenterMark.position).magnitude + pointO;

            return pointC;
        }

        // 传入LineRenderer，更新矢量箭头
        void UpdateVectorArrow(LineRenderer lineRenderer, Vector3 from, Vector3 to, float lineWidth, Color color)
        {
            lineRenderer.material.color = color;
            lineRenderer.startWidth     = lineWidth;

            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, from);
            lineRenderer.SetPosition(1, to);
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}