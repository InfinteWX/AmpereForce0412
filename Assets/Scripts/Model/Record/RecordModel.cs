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
        
        protected override void OnInit()
        {
            
        }

        public void BtnClick(string btnName)
        {
            if (!_currentRecord.BtnClickCount.TryAdd(btnName, 1))
            {
                _currentRecord.BtnClickCount[btnName]++;
            }
        }

        public void StartRecord()
        {
            _currentRecord = new RecordData
            {
                StartTime = Time.time
            };
        }

        public void StopRecord()
        {
            _currentRecord.EndTime = Time.time;
            _currentRecord.Duration =  Time.time - _currentRecord.StartTime;
            DateTime time = DateTime.Now;
            DataKit.SaveJson($"record_{time.Month}_{time.Day}_{time.Hour}_{time.Minute}_{time.Second}", _currentRecord);
        }
    }
}