// ------------------------------------------------------------
// @file       MyScriptableA.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 19:10:45
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.SingletonKit.Example._8.ScriptableSingletonPropertyExample
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(MyScriptableA))]
    public class MyScriptableA : ScriptableObject
    {
        public string ScriptableKey;
    }
}