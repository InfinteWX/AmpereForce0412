// ------------------------------------------------------------
// @file       LerpWithEasyTweenExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-30 19:10:29
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using FluentAPI;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class LerpWithEasyTweenExample : MonoBehaviour
    {
        private Transform _quad;

        [ShowInInspector]
        private int _startX = 0;

        [ShowInInspector]
        private int _endX = 5;

        private void Start()
        {
            _quad = GameObject.Find("Quad").transform;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Linear", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.Linear(_startX, _endX, t))).Start(this);
            }
            
            GUILayout.Space(20);

            GUILayout.BeginVertical();
            
            if (GUILayout.Button("InOutBack", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutBack(_startX, _endX, t))).Start(this);
            }
            
            if (GUILayout.Button("OutBack", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutBack(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InBack", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InBack(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();

            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutBounce", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutBounce(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutBounce", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutBounce(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InBounce", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InBounce(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();
            
            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutCircle", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutCircle(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutCircle", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutCircle(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InCircle", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InCircle(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();
            
            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutCubic", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutCubic(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutCubic", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutCubic(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InCubic", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InCubic(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();
            
            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutElastic", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutElastic(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutElastic", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutElastic(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InElastic", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InElastic(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();
            
            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutExpo", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutExpo(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutExpo", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutExpo(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InExpo", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InExpo(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();
            
            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutQuad", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutQuad(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutQuad", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutQuad(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InQuad", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InQuad(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();
            
            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutQuart", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutQuart(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutQuart", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutQuart(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InQuart", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InQuart(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();
            
            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutQuint", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutQuint(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutQuint", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutQuint(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InQuint", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InQuint(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();
            
            GUILayout.Space(20);
            
            GUILayout.BeginVertical();

            if (GUILayout.Button("InOutSine", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutSine(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("OutSine", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutSine(_startX, _endX, t))).Start(this);
            }

            if (GUILayout.Button("InSine", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InSine(_startX, _endX, t))).Start(this);
            }

            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }
    }
}