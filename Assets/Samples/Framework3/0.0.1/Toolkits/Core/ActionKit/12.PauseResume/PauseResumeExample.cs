// ------------------------------------------------------------
// @file       PauseResumeExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-30 10:10:59
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using System.Collections;
    using UnityEngine;

    public class PauseResumeExample : MonoBehaviour
    {
        // Start is called before the first frame update
        IEnumerator Start()
        {
            // NOT Support Yet
            var action = ActionKit.Repeat()
                                  .Delay(0.5f)
                                  .Callback(() => Debug.Log(Time.time))
                                  .Start(this);

            yield return new WaitForSeconds(3.0f);
            action.Pause();

            yield return new WaitForSeconds(2.0f);
            action.Resume();

        }
    }
}