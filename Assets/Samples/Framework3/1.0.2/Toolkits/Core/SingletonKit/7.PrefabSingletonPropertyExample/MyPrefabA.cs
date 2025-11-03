// ------------------------------------------------------------
// @file       MyPrefabA.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:19
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.SingletonKit.Example._7.PrefabSingletonPropertyExample
{
    using UnityEngine;

    public class MyPrefabA : MonoBehaviour
    {
        private static int s_index = 0;

        // static MyPrefabA()
        // {
        //     PrefabSingletonProperty<MyPrefabA>
        //        .InstanceWithLoader(prefabName => Resources.Load<GameObject>("Prefabs/" + prefabName));
        // }

        public void Awake()
        {
            s_index++;
        }

        public void Log(string content)
        {
            Debug.Log("MyPrefabA" + s_index + ": " + content);
        }
    }
}