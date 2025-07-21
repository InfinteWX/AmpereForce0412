// ------------------------------------------------------------
// @file       StartGlobalExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-30 09:10:21
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class StartGlobalExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

            var action = ActionKit.Repeat()
                                  .Delay(1.0f)
                                  .Callback(() => Debug.Log("wait 1.0f"))
                                  .StartGlobal();

            // action.Pause();
            // action.Resume();
            // action.Deinit(); // Stop
        }
    }
}