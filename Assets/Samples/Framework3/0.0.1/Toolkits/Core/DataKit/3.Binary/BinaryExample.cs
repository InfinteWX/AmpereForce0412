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
    using Toolkits.DataKit;

    public class BinaryData
    {
        public string Name;
        public int    Age;

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    public class BinaryExample : MonoBehaviour
    {
        private void OnGUI()
        {
            if (GUILayout.Button("SaveBinary", GUILayout.Width(160), GUILayout.Height(60)))
            {
                DataKit.SaveBinary("example", new BinaryData()
                {
                    Name = "hello",
                    Age  = 18
                });
            }

            if (GUILayout.Button("LoadBinary", GUILayout.Width(160), GUILayout.Height(60)))
            {
                var data = DataKit.LoadBinary<BinaryData>("example");
                Debug.Log(data);
            }
        }
    }
}