// ------------------------------------------------------------
// @file       StartCurrentSceneExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-31 15:10:09
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class StartCurrentSceneExample : MonoBehaviour
    {
        private static bool s_loaded;

        void Start()
        {
            ActionKit.Sequence()
                     .Delay(1.0f)
                     .Callback(() =>
                      {
                          Debug.Log("printed"); // 只会打印 2 次

                          if (!s_loaded)
                          {
                              s_loaded = true;
                              // 重新加载当前场景
                              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                          }
                      })
                     .Delay(1.0f)
                     .Callback(() =>
                      {
                          Debug.Log("Scene Loaded!");
                      })
                     .StartCurrentScene();
        }
    }
}