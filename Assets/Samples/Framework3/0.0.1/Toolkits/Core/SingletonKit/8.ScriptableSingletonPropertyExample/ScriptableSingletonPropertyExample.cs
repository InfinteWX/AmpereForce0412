// ------------------------------------------------------------
// @file       ScriptableSingletonPropertyExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:25
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.SingletonKit.Example._8.ScriptableSingletonPropertyExample
{
    using UnityEngine;

    public class ScriptableSingletonPropertyExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(MyScriptableA.Instance.ScriptableKey);
        }
        
        private void OnDestroy()
        {
            ScriptableSingletonProperty<MyScriptableA>.Dispose();
        }
    }
}