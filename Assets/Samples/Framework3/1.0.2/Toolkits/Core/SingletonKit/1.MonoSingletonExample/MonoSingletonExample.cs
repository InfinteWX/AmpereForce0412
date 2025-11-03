// ------------------------------------------------------------
// @file       MonoSingletonExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 18:10:57
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.SingletonKit.Example._1.MonoSingletonExample
{
    using System.Collections;
    using UnityEngine;

    public class MonoSingletonExample : MonoBehaviour
    {
        private void Start()
        {
            Class2MonoSingleton.Instance.Log("Hello World!");

            // delete current instance
            Class2MonoSingleton.Instance.Dispose();

            // new instance
            Class2MonoSingleton.Instance.Log("Hello World!");
        }
        
        private void OnDestroy()
        {
            Class2MonoSingleton.Instance.Dispose();
        }   
    }

    /// <summary> <![CDATA[
    /// 只能继承 MonoSingleton<Class2Singleton> 类
    /// ]]> </summary>
    internal class Class2MonoSingleton : MonoSingleton<Class2MonoSingleton>
    {
        private static int s_index = 0;
        
        public override void OnSingletonInit()
        {
            s_index++;
        }

        public void Log(string content)
        {
            Debug.Log("Class2MonoSingleton" + s_index + ": " + content);
        }
    }
}