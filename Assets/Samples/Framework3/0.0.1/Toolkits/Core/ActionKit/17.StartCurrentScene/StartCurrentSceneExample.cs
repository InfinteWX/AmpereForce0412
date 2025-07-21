// ------------------------------------------------------------
// @file       StartCurrentSceneExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-31 15:10:09
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class StartCurrentSceneExample : MonoBehaviour
    {
        void Start()
        {
            ActionKit.Sequence()
                     .Delay(1.0f)
                     .Callback(() =>
                      {
                          Debug.Log("printed");
                          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                      })
                     .Delay(1.0f)
                     .Callback(() =>
                      {
                          Debug.Log("Not print"); // 永远不会输出代码中的 Not print, 因为当场景变更时，会自动停止动作序列的执行。
                      })
                     .StartCurrentScene();
        }
    }
}