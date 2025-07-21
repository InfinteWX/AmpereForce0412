// ------------------------------------------------------------
// @file       StudentModel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 14:10:40
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._1.QueryExample.Scripts.Model
{
    using Core.Model;
    using global::System.Collections.Generic;

    public class StudentModel : AbstractModel
    {
        public List<string> Students { get; } = new List<string>()
        {
            "张三",
            "李四"
        };

        protected override void OnInit() { }
    }

    public class TeacherModel : AbstractModel
    {
        public List<string> Teachers { get; } = new List<string>()
        {
            "王五",
            "赵六"
        };

        protected override void OnInit() { }
    }
}