using System;
using System.Collections.Generic;
using UnityEngine;

namespace AmpereForce
{
    [CreateAssetMenu(fileName = "BlackboardConfig", menuName = "SO/BlackboardConfig", order = 0)]
    public class BlackboardConfigSO : ScriptableObject
    {
        public List<BlackboardItem> Items = new List<BlackboardItem>();
    }

    [Serializable]
    public class BlackboardItem
    {
        public int       Id;
        public string    Content;
        public AudioClip AudioClip;
    }
}