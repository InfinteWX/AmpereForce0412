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

    public class StateB : AbstractState<States, IStateClassExample>
    {
        public StateB(FSM<States> fsm, IStateClassExample owner) : base(fsm, owner)
        { }

        protected override bool OnCondition()
        {
            return _fsm.CurrentStateId == States.A;
        }

        public override void OnGUI()
        {
            GUILayout.Label("State B", GUILayout.Width(150), GUILayout.Height(60));

            if (GUILayout.Button("To State A", GUILayout.Width(150), GUILayout.Height(60)))
            {
                _fsm.ChangeState(States.A);
            }
        }
    }
}