// ------------------------------------------------------------
// @file       StateA.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 23:10:07
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.FSMKit.Example._1.StateClass
{
    using UnityEngine;

    public class StateA : AbstractState<States, IStateClassExample>
    {
        public StateA(FSM<States> fsm, IStateClassExample owner) : base(fsm, owner)
        { }

        protected override bool OnCondition()
        {
            return _fsm.CurrentStateId == States.B;
        }

        public override void OnGUI()
        {
            GUILayout.Label("State A", GUILayout.Width(150), GUILayout.Height(60));

            if (GUILayout.Button("To State B", GUILayout.Width(150), GUILayout.Height(60)))
            {
                _fsm.ChangeState(States.B);
            }
        }
    }
}