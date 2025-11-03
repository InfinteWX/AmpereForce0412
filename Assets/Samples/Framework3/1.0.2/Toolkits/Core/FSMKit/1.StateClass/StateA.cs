// ------------------------------------------------------------
// @file       StateA.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 23:10:07
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.FSMKit.Example._1.StateClass
{
    using UnityEngine;

    public class StateA : AbstractState<States, IStateClassExample>
    {
        public StateA(FSM<States> fsm, IStateClassExample owner) : base(fsm, owner)
        { }
        
        protected override void OnEnter()
        {
            Debug.Log("Enter A");
            _owner.SetTextInfo("Current State: A");
        }

        protected override bool OnCondition()
        {
            return _fsm.CurrentStateId == States.B;
        }
    }
}