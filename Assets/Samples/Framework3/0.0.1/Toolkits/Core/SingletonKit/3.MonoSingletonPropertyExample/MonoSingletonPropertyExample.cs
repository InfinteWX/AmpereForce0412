// ------------------------------------------------------------
// @file       MonoSingletonPropertyExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:51
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.SingletonKit.Example._3.MonoSingletonPropertyExample
{
    using System.Collections;
    using UnityEngine;

    public class MonoSingletonPropertyExample : MonoBehaviour
    {
        private IEnumerator Start()
        {
            var instance = Class2MonoSingletonProperty.Instance;

            yield return new WaitForSeconds(3.0f);
			
            instance.Dispose();
        }
    }

    internal class Class2MonoSingletonProperty : MonoBehaviour, ISingleton
    {
        public static Class2MonoSingletonProperty Instance => MonoSingletonProperty<Class2MonoSingletonProperty>.Instance;

        public void Dispose()
        {
            MonoSingletonProperty<Class2MonoSingletonProperty>.Dispose();
        }

        public void OnSingletonInit()
        {
            Debug.Log(name + ": " + "OnSingletonInit");
        }

        private void Awake()
        {
            Debug.Log(name + ": " + "Awake");
        }

        private void Start()
        {
            Debug.Log(name + ": " + "Start");
        }

        protected void OnDestroy()
        {
            Debug.Log(name + ": " + "OnDestroy");
        }
    }
}