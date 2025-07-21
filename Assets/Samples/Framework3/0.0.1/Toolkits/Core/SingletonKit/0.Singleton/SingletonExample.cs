// ------------------------------------------------------------
// @file       SingletonExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 18:10:22
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.SingletonKit.Example._0.Singleton
{
    using UnityEngine;

    public class SingletonExample : MonoBehaviour
    {
        private void Start()
        {
            Class2Singleton.Instance.Log("Hello World!");

            // delete instance
            Class2Singleton.Instance.Dispose();

            // a different instance
            Class2Singleton.Instance.Log("Hello World!");
        }
    }

    /// <summary> <![CDATA[
    /// 只能继承 Singleton<Class2Singleton> 类
    /// ]]> </summary>
    internal class Class2Singleton : Singleton<Class2Singleton>
    {
        private static int _Index = 0;

        private Class2Singleton() { }

        public override void OnSingletonInit()
        {
            _Index++;
        }

        public void Log(string content)
        {
            Debug.Log("Class2Singleton" + _Index + ": " + content);
        }
    }
}