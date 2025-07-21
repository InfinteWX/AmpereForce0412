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

    public class JsonData
    {
        public string Name;
        public int    Age;

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    public class JsonExample : MonoBehaviour
    {
        private void OnGUI()
        {
            if (GUILayout.Button("SaveJson", GUILayout.Width(160), GUILayout.Height(60)))
            {
                DataKit.SaveJson("example", new JsonData()
                {
                    Name = "hello",
                    Age  = 18
                });
            }

            if (GUILayout.Button("LoadJson", GUILayout.Width(160), GUILayout.Height(60)))
            {
                var data = DataKit.LoadJson<JsonData>("example");
                Debug.Log(data);
            }
        }
    }
}