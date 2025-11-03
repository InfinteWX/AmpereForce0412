// ------------------------------------------------------------
// @file       MonoSingletonPropertyExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:51
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.SingletonKit.Example._3.MonoSingletonPropertyExample
{
    using UnityEngine;

    public class MonoSingletonPropertyExample : MonoBehaviour
    {
        private void Start()
        {
            Class2MonoSingletonProperty.Instance.Log("Hello World!");

            // delete current instance
            Class2MonoSingletonProperty.Instance.Dispose();

            // new instance
            Class2MonoSingletonProperty.Instance.Log("Hello World!");
        }
        
        private void OnDestroy()
        {
            Class2MonoSingletonProperty.Instance.Dispose();
        }
    }

    internal class Class2MonoSingletonProperty : MonoBehaviour, ISingleton
    {
        public static Class2MonoSingletonProperty Instance
        {
            get => MonoSingletonProperty<Class2MonoSingletonProperty>.Instance;
        }

        private static int s_index = 0;

        public void OnSingletonInit()
        {
            s_index++;
        }

        public void Dispose()
        {
            MonoSingletonProperty<Class2MonoSingletonProperty>.Dispose();
        }

        public void Log(string content)
        {
            Debug.Log("Class2MonoSingletonProperty" + s_index + ": " + content);
        }
    }
}