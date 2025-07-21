// ------------------------------------------------------------
// @file       6.SimpleArchitectureInHeartExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 16:10:35
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._6.SimpleArchitectureInHeart
{
    using UnityEngine;

    /// <summary>
    /// 简易 Architecture 实现
    /// </summary>
    public class SimpleArchitectureInHeartExample : MonoBehaviour
    {
        private GUIStyle _labelStyle;

    #region Framework

        public interface ICommand
        {
            void Execute();
        }

        /// <summary>
        /// 简易 BindableProperty 类
        /// </summary>
        /// <typeparam name="T">Property 类型</typeparam>
        public class BindableProperty<T>
        {
            private T _value = default;

            public T Value
            {
                get => _value;
                set
                {
                    if (_value != null && _value.Equals(value)) return;
                    _value = value;
                    OnValueChanged?.Invoke(_value);
                }
            }

            public event global::System.Action<T> OnValueChanged = _ => { };
        }

    #endregion


    #region 定义 Model

        public static class CounterModel
        {
            public static BindableProperty<int> Counter = new BindableProperty<int>()
            {
                Value = 0
            };
        }

    #endregion

    #region 定义 Command

        public struct IncreaseCountCommand : ICommand
        {
            public void Execute()
            {
                CounterModel.Counter.Value++;
            }
        }

        public struct DecreaseCountCommand : ICommand
        {
            public void Execute()
            {
                CounterModel.Counter.Value--;
            }
        }

    #endregion

        private void OnGUI()
        {
            if (GUILayout.Button("+", GUILayout.Width(150), GUILayout.Height(50)))
            {
                new IncreaseCountCommand().Execute();
            }

            _labelStyle ??= new GUIStyle(GUI.skin.label)
            {
                fontSize  = 30, // 设置字体大小  
                alignment = TextAnchor.MiddleCenter,
            };
            GUILayout.Label(CounterModel.Counter.Value.ToString(), _labelStyle);

            if (GUILayout.Button("-", GUILayout.Width(150), GUILayout.Height(50)))
            {
                new DecreaseCountCommand().Execute();
            }
        }
    }
}