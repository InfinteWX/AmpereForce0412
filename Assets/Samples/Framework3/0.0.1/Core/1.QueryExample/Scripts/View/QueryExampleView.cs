// ------------------------------------------------------------
// @file       QueryExampleView.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 14:10:48
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._1.QueryExample.Scripts.View
{
    using Core;
    using Query;
    using UnityEngine;

    public class QueryExampleView : AbstractView
    {
        protected override IArchitecture _Architecture => QueryExampleApp.Architecture;

        private int _allPersonCount = 0;

        private void OnGUI()
        {
            if (GUILayout.Button("查询学校总人数", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _allPersonCount = this.SendQuery(new SchoolAllPersonCountQuery());
            }

            GUILayout.Label($"All Person Count: {_allPersonCount}");
        }
    }
}