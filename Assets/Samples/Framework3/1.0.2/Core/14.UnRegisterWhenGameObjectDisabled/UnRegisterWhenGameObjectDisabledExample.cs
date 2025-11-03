// ------------------------------------------------------------
// @file       UnregisterWhenDisabledExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 23:10:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._14.UnregisterWhenGameObjectDisabled
{
    using UnityEngine;

    public class UnregisterWhenGameObjectDisabledExample : MonoBehaviour
    {
        private void Awake()
        {
            var receivedGameObj = new GameObject();
            var eventA          = new EasyEvent();

            eventA.Register(() =>
            {
                Debug.Log("Received");
            }).UnregisterWhenGameObjectDisabled(receivedGameObj);

            eventA.Trigger(); // Received
            eventA.Trigger(); // Received
            eventA.Trigger(); // Received

            receivedGameObj.SetActive(false);

            eventA.Trigger(); // Noting
            eventA.Trigger(); // Noting
            eventA.Trigger(); // Noting
        }
    }
}