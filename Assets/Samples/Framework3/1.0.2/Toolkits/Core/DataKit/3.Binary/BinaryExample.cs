// ------------------------------------------------------------
// @file       JsonExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-07 00:12:57
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework3.Toolkits.Core.DataKit.Example._1Json
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
        public void SaveBinary()
        {
            DataKit.SaveBinary("example", new BinaryData()
            {
                Name = "hello",
                Age = 18
            });
        }

        public void LoadBinary()
        {
            var data = DataKit.LoadBinary<BinaryData>("example");
            Debug.Log(data);
        }

        public void OpenFolder()
        {
            BinaryHelper.OpenBinarySavePath();
        }
    }
}