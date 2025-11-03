// ------------------------------------------------------------
// @file       CoroutineExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-29 11:10:19
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using System.Collections;
    using UnityEngine;

    public class CoroutineExample : MonoBehaviour
    {
        private void Start()
        {
            ActionKit.Coroutine(SomeCoroutine).Start(this);

            SomeCoroutine().ToAction().Start(this);

            ActionKit.Sequence()
                     .Coroutine(SomeCoroutine)
                     .Start(this);
        }

        IEnumerator SomeCoroutine()
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Hello: " + Time.time);
        }
    }
}