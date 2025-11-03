// ------------------------------------------------------------
// @file       IStateBasicUsageExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 23:10:25
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.FSMKit.Example._0.BasicUsage
{
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine;

    public class IStateBasicUsageExample : MonoBehaviour
    {
        [ShowInInspector]
        private FSM<States> _fsm = new FSM<States>();

        [SerializeField]
        private TextMeshProUGUI _textInfo;

        void Start()
        {
            Application.targetFrameRate = 60;

            _fsm.OnStateChanged((previousState, nextState) =>
            {
                Debug.Log($"{previousState} => {nextState}");
            });

            _fsm.State(States.A)
               .OnCondition(() => _fsm.CurrentStateId == States.B)
               .OnEnter(() =>
                {
                    Debug.Log("Enter A");
                    _textInfo.text = "Current State: A";
                })
               .OnUpdate(() =>
                {
                    if (_fsm.FrameCountOfCurrentState % 60 == 0)
                    {
                        Debug.Log("Heart beat");
                    }
                })
               .OnExit(() => { Debug.Log("Exit A"); });

            _fsm.State(States.B)
               .OnEnter(() =>
                {
                    Debug.Log("Enter B");
                    _textInfo.text = "Current State: B";
                })
               .OnCondition(() => _fsm.CurrentStateId == States.A)
               .OnExit(() => { Debug.Log("Exit A"); });

            _fsm.StartState(States.A);
        }

        private void Update()
        {
            _fsm.Update();
        }

        private void FixedUpdate()
        {
            _fsm.FixedUpdate();
        }

        private void OnGUI()
        {
            _fsm.OnGUI();
        }

        private void OnDestroy()
        {
            _fsm.Clear();
        }

        public void ChangeToStateA()
        {
            _fsm.ChangeState(States.A);
        }

        public void ChangeToStateB()
        {
            _fsm.ChangeState(States.B);
        }

        public enum States
        {
            A,
            B
        }
    }
}