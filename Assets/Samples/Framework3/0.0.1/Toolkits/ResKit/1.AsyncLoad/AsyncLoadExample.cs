// ------------------------------------------------------------
// @file       AsyncLoadExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-10 16:12:01
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework.Toolkits.ResKit.Example._1.AsyncLoad
{
    using ActionKit;
    using FluentAPI;
    using ActionKit = ActionKit.ActionKit;
    using Random = UnityEngine.Random;

    public class AsyncLoadExample : MonoBehaviour
    {
        private void Start()
        {
            ResKit.LoadAssetsAsync<GameObject>(new[] { "Cube", "Sphere" }, objs =>
            {
                foreach (var obj in objs)
                {
                    Instantiate(obj)
                       .SetPosition(x: Random.Range(-1, 2f));
                }
            }).UnLoadWhenGameObjectDestroyed(gameObject);

            ResKit.LoadAssetAsync<GameObject>("Cube", obj =>
            {
                Instantiate(obj)
                   .SetPosition(x: Random.Range(-1, 2f));
            }).UnLoadWhenGameObjectDestroyed(gameObject);

            ActionKit
               .Delay(3, this.DestroyGameObjectGracefully)
               .Start(this);
        }
    }
}