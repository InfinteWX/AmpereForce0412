// ------------------------------------------------------------
// @file       ScriptableSingletonPropertyExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:25
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.SingletonKit.Example._8.ScriptableSingletonPropertyExample
{
    using UnityEngine;

    public class ScriptableSingletonPropertyExample : MonoBehaviour
    {
        private void Awake()
        {
            ScriptableSingletonProperty<MyScriptableA>.InstanceWithLoader(
                scriptableName => Resources.Load<MyScriptableA>("Scriptable/" + scriptableName));
        }

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("MyScriptableA.ScriptableKey: " + ScriptableSingletonProperty<MyScriptableA>.Instance.ScriptableKey);
        }
        
        private void OnDestroy()
        {
            ScriptableSingletonProperty<MyScriptableA>.Dispose();
        }
    }
}