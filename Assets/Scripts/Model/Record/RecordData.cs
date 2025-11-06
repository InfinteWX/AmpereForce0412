using System;
using System.Collections.Generic;

namespace AmpereForce
{
    [Serializable]
    public class RecordData
    {
        public Dictionary<string, int> BtnClickCount = new();
        
        public float StartTime;
        public float EndTime;
        public float Duration;
    }
}
