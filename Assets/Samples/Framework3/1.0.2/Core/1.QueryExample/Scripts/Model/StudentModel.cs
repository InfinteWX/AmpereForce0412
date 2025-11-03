// ------------------------------------------------------------
// @file       StudentModel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 14:10:40
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._1.QueryExample.Scripts.Model
{
    using System.Collections.Generic;

    public class StudentModel : AbstractModel
    {
        public List<string> Students { get; } = new List<string>()
        {
            "zhang san",
            "li si"
        };
        
        protected override void OnInit() { }
    }

    public class TeacherModel : AbstractModel
    {
        public List<string> Teachers { get; } = new List<string>()
        {
            "wang wu",
            "zhao liu"
        };

        protected override void OnInit() { }
    }
}