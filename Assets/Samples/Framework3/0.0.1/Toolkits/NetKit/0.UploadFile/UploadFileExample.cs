// ------------------------------------------------------------
// @file       UploadFileExample.cs
// @brief
// @author     zheliku
// @Modified   2025-05-16 18:16:20
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

namespace Framework.Example.Toolkits.NetKit._0.Upload_Download
{
    using System;
    using UnityEngine;
    using Framework.Toolkits.NetKit;

    public class UploadFileExample : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            NetKit.UploadFile(
                "http://172.24.128.176:8080/HTTP%20Server",
                $"test_UploadFileExample_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt",
                Application.dataPath + "/Framework/Example/Toolkits/NetKit/Upload/test.txt",
                (result) =>
                {
                    Debug.Log(result);
                });
        }

        // Update is called once per frame
        void Update()
        { }
    }
}