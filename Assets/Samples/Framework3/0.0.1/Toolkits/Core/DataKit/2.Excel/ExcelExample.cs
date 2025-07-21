// ------------------------------------------------------------
// @file       JsonExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-07 00:12:57
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework.Toolkits.Core.DataKit.Example._1Json
{
    using Sirenix.OdinInspector;
    using Toolkits.DataKit;

    public class ExcelExample : MonoBehaviour
    {
        [ShowInInspector]
        public ExcelSheet Sheet = new ExcelSheet();

        public string FileName  = "example";
        public string SheetName = "example";

        private void OnGUI()
        {
            if (GUILayout.Button("SaveExcel", GUILayout.Width(160), GUILayout.Height(60)))
            {
                Sheet[3, 2] = "hello world";
                Sheet.Save(FileName, SheetName);
            }

            if (GUILayout.Button("LoadExcel", GUILayout.Width(160), GUILayout.Height(60)))
            {
                Sheet.Load(FileName, SheetName);
                Debug.Log($"{Sheet.Start} -> {Sheet.End}");
            }
            
            if (GUILayout.Button("SaveCsv", GUILayout.Width(160), GUILayout.Height(60)))
            {
                Sheet[2, 4] = "hello world";
                Sheet.Save(FileName, SheetName, ExcelFormat.Csv);
            }

            if (GUILayout.Button("LoadCsv", GUILayout.Width(160), GUILayout.Height(60)))
            {
                Sheet.Load(FileName, SheetName, ExcelFormat.Csv);
                Debug.Log($"{Sheet.Start} -> {Sheet.End}");
            }
        }
    }
}