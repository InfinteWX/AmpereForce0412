// ------------------------------------------------------------
// @file       SchoolAllPersonCountQuery.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 14:10:23
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._1.QueryExample.Scripts.Query
{
    using Model;

    public class SchoolAllPersonCountQuery : Query<int>
    {
        protected override int OnDo()
        {
            return this.GetModel<StudentModel>().Students.Count +
                   this.GetModel<TeacherModel>().Teachers.Count;
        }
    }
}