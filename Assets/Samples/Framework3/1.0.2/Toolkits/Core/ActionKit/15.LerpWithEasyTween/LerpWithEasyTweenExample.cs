// ------------------------------------------------------------
// @file       LerpWithEasyTweenExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-30 19:10:29
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using FluentAPI;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class LerpWithEasyTweenExample : MonoBehaviour
    {
        [SerializeField]
        private Transform _quad;

        [ShowInInspector]
        private int _startX = 0;

        [ShowInInspector]
        private int _endX = 5;

        private void Start()
        {
            _quad = GameObject.Find("/Quad").transform;
        }

        public void Linear()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.Linear(_startX, _endX, t))).Start(this);
        }

        public void InOutBack()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutBack(_startX, _endX, t))).Start(this);
        }
        
        public void OutBack()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutBack(_startX, _endX, t))).Start(this);
        }
        
        public void InBack()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InBack(_startX, _endX, t))).Start(this);
        }
        
        public void InOutBounce()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutBounce(_startX, _endX, t))).Start(this);
        }
        
        public void OutBounce()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutBounce(_startX, _endX, t))).Start(this);
        }
        
        public void InBounce()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InBounce(_startX, _endX, t))).Start(this);
        }
        
        public void InOutCircle()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutCircle(_startX, _endX, t))).Start(this);
        }
        
        public void OutCircle()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutCircle(_startX, _endX, t))).Start(this);
        }
        
        public void InCircle()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InCircle(_startX, _endX, t))).Start(this);
        }
        
        public void InOutCubic()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutCubic(_startX, _endX, t))).Start(this);
        }
        
        public void OutCubic()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutCubic(_startX, _endX, t))).Start(this);
        }
        
        public void InCubic()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InCubic(_startX, _endX, t))).Start(this);
        }
        
        public void InOutElastic()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutElastic(_startX, _endX, t))).Start(this);
        }
        
        public void OutElastic()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutElastic(_startX, _endX, t))).Start(this);
        }
        
        public void InElastic()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InElastic(_startX, _endX, t))).Start(this);
        }
        
        public void InOutExpo()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutExpo(_startX, _endX, t))).Start(this);
        }
        
        public void OutExpo()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutExpo(_startX, _endX, t))).Start(this);
        }
        
        public void InExpo()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InExpo(_startX, _endX, t))).Start(this);
        }
        
        public void InOutQuad()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutQuad(_startX, _endX, t))).Start(this);
        }
        
        public void OutQuad()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutQuad(_startX, _endX, t))).Start(this);
        }
        
        public void InQuad()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InQuad(_startX, _endX, t))).Start(this);
        }
        
        public void InOutQuart()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutQuart(_startX, _endX, t))).Start(this);
        }
        
        public void OutQuart()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutQuart(_startX, _endX, t))).Start(this);
        }
        
        public void InQuart()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InQuart(_startX, _endX, t))).Start(this);
        }
        
        public void InOutQuint()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutQuint(_startX, _endX, t))).Start(this);
        }
        
        public void OutQuint()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutQuint(_startX, _endX, t))).Start(this);
        }
        
        public void InQuint()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InQuint(_startX, _endX, t))).Start(this);
        }
        
        public void InOutSine()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InOutSine(_startX, _endX, t))).Start(this);
        }
        
        public void OutSine()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.OutSine(_startX, _endX, t))).Start(this);
        }
        
        public void InSine()
        {
            ActionKit.Lerp01(3, t => _quad.SetLocalPosition(x: EasyTween.InSine(_startX, _endX, t))).Start(this);
        }
    }
}