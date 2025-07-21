// ------------------------------------------------------------
// @file       IStateBasicUsageExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 23:10:25
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.FSMKit.Example._0.BasicUsage
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class IStateBasicUsageExample : MonoBehaviour
    {
        [ShowInInspector]
        private FSM<States> _fsm = new FSM<States>();

        void Start()
        {
            Application.targetFrameRate = 60;

            _fsm.OnStateChanged((previousState, nextState) =>
            {
                Debug.Log($"{previousState} => {nextState}");
            });

            _fsm.State(States.A)
               .OnCondition(() => _fsm.CurrentStateId == States.B)
               .OnEnter(() => { Debug.Log("Enter A"); })
               .OnUpdate(() =>
                {
                    if (_fsm.FrameCountOfCurrentState % 60 == 0)
                    {
                        Debug.Log("Heart beat");
                    }
                })
               .OnGUI(() =>
                {
                    GUILayout.Label("State A", GUILayout.Width(150), GUILayout.Height(60));
                    if (GUILayout.Button("To State B", GUILayout.Width(150), GUILayout.Height(60)))
                    {
                        _fsm.ChangeState(States.B);
                    }
                })
               .OnExit(() => { Debug.Log("Exit A"); });

            _fsm.State(States.B)
               .OnCondition(() => _fsm.CurrentStateId == States.A)
               .OnGUI(() =>
                {
                    GUILayout.Label("State B", GUILayout.Width(150), GUILayout.Height(60));
                    if (GUILayout.Button("To State A", GUILayout.Width(150), GUILayout.Height(60)))
                    {
                        _fsm.ChangeState(States.A);
                    }
                });

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

        public enum States
        {
            A,
            B
        }
    }
}