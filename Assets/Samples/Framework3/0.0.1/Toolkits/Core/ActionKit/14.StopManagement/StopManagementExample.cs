// ------------------------------------------------------------
// @file       StopManagementExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-30 10:10:31
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using System.Collections.Generic;
    using UnityEngine;

    public class StopManagementExample : MonoBehaviour
    {
        private List<IActionController> _actionControllers = new List<IActionController>();

        // Start is called before the first frame update
        void Start()
        {
            var a = default(IActionController);
            a = ActionKit.Sequence()
                         .Callback(() => { Debug.Log("Start"); })
                         .Delay(1.0f)
                         .Callback(() => { Debug.Log("Delay 1.0f"); })
                         .Start(this, () =>
                          {
                              ActionKit.Sequence()
                                       .Callback(() => { Debug.Log("New Start"); })
                                       .Delay(0.5f)
                                       .Callback(() => { Debug.Log("Delay 0.5f, Ready to Deinit"); })
                                       .Start(this, () =>
                                        {
                                            a.Deinit();
                                        });
                          });
        }
    }
}