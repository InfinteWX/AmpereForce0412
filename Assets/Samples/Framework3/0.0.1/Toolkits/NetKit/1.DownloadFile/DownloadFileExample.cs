// ------------------------------------------------------------
// @file       DownloadFileExample.cs
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

    public class DownloadFileExample : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            NetKit.DownloadFile(
                "http://172.24.128.176:8080/HTTP%20Server",
                "test.png",
                Application.dataPath + $"/Framework/Example/Toolkits/NetKit/Download/test_DownloadFileExample_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.png",
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