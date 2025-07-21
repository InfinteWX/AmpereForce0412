// ------------------------------------------------------------
// @file       SingletonPropertyExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:22
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.SingletonKit.Example._2.SingletonPropertyExample
{
    using UnityEngine;

    public class SingletonPropertyExample : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Class2SingletonProperty.Instance.Log("Hello World!");

            // delete current instance
            Class2SingletonProperty.Instance.Dispose();

            // new instance
            Class2SingletonProperty.Instance.Log("Hello World!");
        }
    }

    /// <summary>
    /// Class2SingletonProperty 可以继承其他类
    /// </summary>
    internal class Class2SingletonProperty : ISingleton
    {
        /// <summary>
        /// 通过属性返回静态单例，来实现单例模式
        /// </summary>
        public static Class2SingletonProperty Instance => SingletonProperty<Class2SingletonProperty>.Instance;

        private Class2SingletonProperty() { }

        private static int _Index = 0;

        public void OnSingletonInit()
        {
            _Index++;
        }

        public void Dispose()
        {
            SingletonProperty<Class2SingletonProperty>.Dispose();
        }

        public void Log(string content)
        {
            Debug.Log("Class2SingletonProperty" + _Index + ": " + content);
        }
    }
}