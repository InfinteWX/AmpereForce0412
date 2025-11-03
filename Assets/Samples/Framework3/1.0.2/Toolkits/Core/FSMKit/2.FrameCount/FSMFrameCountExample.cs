// ------------------------------------------------------------
// @file       FSMFrameCountExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 23:10:28
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.FSMKit.Example._2.FrameCount
{
    using FluentAPI;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.UI;

    public class FSMFrameCountExample : MonoBehaviour
    {
        enum States
        {
            FadeAlphaIn,
            FadeAlphaOut,
            FadeColorBlue,
            FadeColorRed,
            Delay,
            RotateTo
        }

        [ShowInInspector]
        private FSM<States> _fsm = new FSM<States>();

        private Image _image;

        private void Awake()
        {
            _image = GameObject.Find("Canvas/Image").GetComponent<Image>();
        }

        void Start()
        {
            Application.targetFrameRate = 60;

            _fsm.State(States.FadeAlphaIn)
                .OnEnter(() => _image.SetColor(a: 0))
                .OnUpdate(() =>
                 {
                     if (_fsm.FrameCountOfCurrentState <= 60)
                     {
                         _image.SetColor(a: Mathf.Lerp(0, 1, _fsm.FrameCountOfCurrentState / 60.0f));
                     }
                     else
                     {
                         _fsm.ChangeState(States.FadeAlphaOut);
                     }
                 });

            _fsm.State(States.FadeAlphaOut)
                .OnUpdate(() =>
                 {
                     if (_fsm.FrameCountOfCurrentState <= 60)
                     {
                         _image.SetColor(a: Mathf.Lerp(1, 0, _fsm.FrameCountOfCurrentState / 60.0f));
                     }
                     else
                     {
                         _fsm.ChangeState(States.FadeColorBlue);
                     }
                 });

            _fsm.State(States.FadeColorBlue)
                .OnUpdate(() =>
                 {
                     if (_fsm.FrameCountOfCurrentState <= 60)
                     {
                         _image.color = Color.Lerp(new Color(1, 1, 1, 0), Color.blue,
                                                  _fsm.FrameCountOfCurrentState / 60.0f);
                     }
                     else
                     {
                         _fsm.ChangeState(States.FadeColorRed);
                     }
                 });

            _fsm.State(States.FadeColorRed)
                .OnUpdate(() =>
                 {
                     if (_fsm.FrameCountOfCurrentState <= 60)
                     {
                         _image.color = Color.Lerp(Color.blue, Color.red,
                                                  _fsm.FrameCountOfCurrentState / 60.0f);
                     }
                     else
                     {
                         _fsm.ChangeState(States.Delay);
                     }
                 });

            _fsm.State(States.Delay)
                .OnUpdate(() =>
                 {
                     if (_fsm.FrameCountOfCurrentState > 60)
                     {
                         _fsm.ChangeState(States.RotateTo);
                     }
                 });

            _fsm.State(States.RotateTo)
                .OnUpdate(() =>
                 {
                     if (_fsm.FrameCountOfCurrentState <= 60)
                     {
                         _image.SetRotation(Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(45, 45, 45),
                                                           _fsm.FrameCountOfCurrentState / 60.0f));
                     }
                 });

            _fsm.StartState(States.FadeAlphaIn);
        }

        // Update is called once per frame
        void Update()
        {
            _fsm.Update();
        }

        private void OnDestroy()
        {
            _fsm.Clear();
            _fsm = null;
        }
    }
}