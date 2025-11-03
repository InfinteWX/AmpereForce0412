// ------------------------------------------------------------
// @file       SchoolAllPersonCountQuery.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 14:10:23
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._1.QueryExample.Scripts.Query
{
    using Model;

    public class SchoolAllPersonCountQuery : Query<int>
    {
        // 查询学校所有人员数量（学生+老师）
        protected override int OnDo()
        {
            return this.GetModel<StudentModel>().Students.Count +
                   this.GetModel<TeacherModel>().Teachers.Count;
        }
    }
}