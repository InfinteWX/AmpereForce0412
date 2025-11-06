using System;
using System.Collections.Generic;
using Framework3.Core;
using Framework3.Toolkits.DataKit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AmpereForce
{
    public class RecordModel : AbstractModel
    {
        [ShowInInspector]
        private RecordData _currentRecord = new RecordData();

        private List<string> _btnNames = new()
        {
            "EpType",
            "MagneticDir",
            "IDir",
            "PrevPage",
            "NextPage",
            "MicroMode",
            "I_0",
            "I_0.2",
            "I_0.4",
            "I_0.6",
            "B_0",
            "B_1",
            "B_2",
            "B_3",
        };

        private readonly ExcelSheet _sheet = new ExcelSheet();
        public string FileName = "Records";
        public string SheetName = "Records1104";


        protected override void OnInit()
        {
            StartRecord();
        }

        public void BtnClick(string btnName)
        {
            // if (!_currentRecord.BtnClickCount.TryAdd(btnName, 1))
            // {
            //     _currentRecord.BtnClickCount[btnName]++;
            // }
            _currentRecord.BtnClickCount[btnName]++;
        }

        public void StartRecord()
        {
            _currentRecord = new RecordData
            {
                StartTime = Time.time
            };
            // 初始化字典，确保每个按钮都存在
            foreach (var btnName in _btnNames)
            {
                _currentRecord.BtnClickCount.Add(btnName, 0);
            }
        }

        public void StopRecord()
        {
            _currentRecord.EndTime = Time.time;
            _currentRecord.Duration = Time.time - _currentRecord.StartTime;
            DateTime time = DateTime.Now;
            // 表头
            for (int i = 0; i < _btnNames.Count; i++)
            {
                _sheet[0, i] = _btnNames[i];
            }

            // 记录
            int row = _sheet.End[0];
            for (int i = 0; i < _btnNames.Count; i++)
            {
                _sheet[row, i] = _currentRecord.BtnClickCount[_btnNames[i]].ToString();
            }

            // 时间
            _sheet[row, 14] = _currentRecord.Duration.ToString();
            // Sheet.Save(FileName, SheetName);
            // DataKit.SaveJson($"record_{time.Month}_{time.Day}_{time.Hour}_{time.Minute}_{time.Second}", _currentRecord);
        }

        public void SaveRecord()
        {
            _sheet.Save(FileName, SheetName);
        }
    }
}