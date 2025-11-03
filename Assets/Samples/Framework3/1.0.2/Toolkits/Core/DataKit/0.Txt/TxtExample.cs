// ------------------------------------------------------------
// @file       TxtExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-06 23:12:34
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework3.Toolkits.Core.DataKit.Example._0.Txt
{
    using TMPro;
    using Toolkits.DataKit;

    public class TxtExample : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _inputField;
        
        public void Save()
        {
            DataKit.SaveTxt("example", _inputField.text);
        }
        
        public void Load()
        {
            var txt = DataKit.LoadTxt("example");
            Debug.Log(txt);
        }
        
        public void OpenFolder()
        {
            TxtHelper.OpenTxtSavePath();
        }
    }
}
