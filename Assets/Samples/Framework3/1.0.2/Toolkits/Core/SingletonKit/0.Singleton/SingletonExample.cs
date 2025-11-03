// ------------------------------------------------------------
// @file       SingletonExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 18:10:22
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.SingletonKit.Example._0.Singleton
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
        
        private void OnDestroy()
        {
            Class2Singleton.Instance.Dispose();
        }
    }

    /// <summary> <![CDATA[
    /// 只能继承 Singleton<Class2Singleton> 类
    /// ]]> </summary>
    internal class Class2Singleton : Singleton<Class2Singleton>
    {
        private static int s_index = 0;

        private Class2Singleton() { }

        public override void OnSingletonInit()
        {
            s_index++;
        }

        public void Log(string content)
        {
            Debug.Log("Class2Singleton" + s_index + ": " + content);
        }
    }
}