// ------------------------------------------------------------
// @file       IStateClassExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 23:10:28
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.FSMKit.Example._1.StateClass
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class IStateClassExample : MonoBehaviour
    {
        [ShowInInspector]
        private FSM<States> _fsm = new FSM<States>();

        private void Start()
        {
            _fsm.AddState(States.A, new StateA(_fsm, this));
            _fsm.AddState(States.B, new StateB(_fsm, this));

            // 支持和链式模式混用
            // FSM.State(States.C)
            //     .OnEnter(() =>
            //     {
            //
            //     });
            
            _fsm.StartState(States.A);
        }

        private void OnGUI()
        {
            _fsm.OnGUI();
        }

        private void OnDestroy()
        {
            _fsm.Clear();
        }
    }
}