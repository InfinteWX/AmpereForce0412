// ------------------------------------------------------------
// @file       MyScriptableA.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:45
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.SingletonKit.Example._8.ScriptableSingletonPropertyExample
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(MyScriptableA))]
    public class MyScriptableA : ScriptableObject
    {
        public string ScriptableKey;
        
        public static MyScriptableA Instance => ScriptableSingletonProperty<MyScriptableA>.InstanceWithLoader(
            scriptableName => Resources.Load<MyScriptableA>("Scriptable/" + scriptableName));
    }
}