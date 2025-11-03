// ------------------------------------------------------------
// @file       GlobalMonoEventExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-29 11:10:32
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using Framework3.Core;
    using UnityEngine;

    public class GlobalMonoEventExample : MonoBehaviour
    {
        void Start()
        {
            ActionKit.OnUpdate.Register(() =>
            {
                if (Time.frameCount % 30 == 0)
                {
                    Debug.Log("Update");
                }
            }).UnregisterWhenGameObjectDestroyed(gameObject);

            ActionKit.OnFixedUpdate.Register(() =>
            {
                // fixed update code here
                // 这里写 fixed update 相关代码
            }).UnregisterWhenGameObjectDestroyed(gameObject);

            ActionKit.OnLateUpdate.Register(() =>
            {
                // late update code here
                // 这里写 late update 相关代码
            }).UnregisterWhenGameObjectDestroyed(gameObject);

            ActionKit.OnGUI.Register(() =>
            {
                GUILayout.Label("See Example Code");
                GUILayout.Label("请查看示例代码");
            }).UnregisterWhenGameObjectDestroyed(gameObject);

            ActionKit.OnApplicationFocus.Register(focus =>
            {
                Debug.Log("focus: " + focus);
            }).UnregisterWhenGameObjectDestroyed(gameObject);

            ActionKit.OnApplicationPause.Register(pause =>
            {
                Debug.Log("pause: " + pause);
            }).UnregisterWhenGameObjectDestroyed(gameObject);

            ActionKit.OnApplicationQuit.Register(() =>
            {
                Debug.Log("quit");
            }).UnregisterWhenGameObjectDestroyed(gameObject);
        }
    }
}