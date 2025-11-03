// ------------------------------------------------------------
// @file       PrefabSingletonPropertyExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:57
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.SingletonKit.Example._7.PrefabSingletonPropertyExample
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class PrefabSingletonPropertyExample : MonoBehaviour
    {
        private void Awake()
        {
            // optional: set custom loader
            PrefabSingletonProperty<MyPrefabA>
               .InstanceWithLoader(prefabName => Resources.Load<GameObject>("Prefabs/" + prefabName));
        }

        private void Start()
        {
            PrefabSingletonProperty<MyPrefabA>.Instance.Log("Hello World!");

            // delete current instance
            PrefabSingletonProperty<MyPrefabA>.Dispose();

            // new instance
            PrefabSingletonProperty<MyPrefabA>.Instance.Log("Hello World!");
        }

        private void OnDestroy()
        {
            PrefabSingletonProperty<MyPrefabA>.Dispose();
        }
    }
}
