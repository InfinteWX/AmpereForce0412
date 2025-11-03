// ------------------------------------------------------------
// @file       QueryExampleView.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 14:10:48
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._1.QueryExample.Scripts.View
{
    using Core;
    using Model;
    using Query;
    using TMPro;
    using Toolkits.FluentAPI;

    public class QueryExampleView : AbstractView
    {
        [HierarchyPath("/Canvas/Txt_Info")] // 使用特性绑定，"/Canvas/Txt_Info" 是组件在场景中的路径
        private TextMeshProUGUI _textInfo;
        
        [HierarchyPath("/Canvas/Txt_Result")] // 使用特性绑定，"/Canvas/Txt_Result" 是组件在场景中的路径
        private TextMeshProUGUI _textResult;

        protected override IArchitecture _Architecture
        {
            get => QueryExampleApp.Architecture;
        }

        public void StartQuery()
        {
            var studentModel = this.GetModel<StudentModel>();
            var teacherModel = this.GetModel<TeacherModel>();

            _textInfo.text = "Students:\n"
                       + studentModel.Students.Join("\n")
                       + "\n\nTeachers:\n"
                       + teacherModel.Teachers.Join("\n");

            var allPersonCount = this.SendQuery(new SchoolAllPersonCountQuery());
            _textResult.text = $"All Person Count: {allPersonCount}";
        }
    }
}