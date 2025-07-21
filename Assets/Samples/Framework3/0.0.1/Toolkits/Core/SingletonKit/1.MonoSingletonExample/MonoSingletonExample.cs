// ------------------------------------------------------------
// @file       MonoSingletonExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 18:10:57
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.SingletonKit.Example._1.MonoSingletonExample
{
    using System.Collections;
    using UnityEngine;

    public class MonoSingletonExample : MonoBehaviour
    {
        private IEnumerator Start()
        {
            var instance = Class2MonoSingleton.Instance;

            yield return new WaitForSeconds(3.0f);
			
            instance.Dispose();
        }
    }

    /// <summary> <![CDATA[
    /// 只能继承 MonoSingleton<Class2Singleton> 类
    /// ]]> </summary>
    internal class Class2MonoSingleton : MonoSingleton<Class2MonoSingleton>
    {
        public override void OnSingletonInit()
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

        protected override void OnDestroy()
        {
            base.OnDestroy();

            Debug.Log(name + ": " + "OnDestroy");
        }
    }
}