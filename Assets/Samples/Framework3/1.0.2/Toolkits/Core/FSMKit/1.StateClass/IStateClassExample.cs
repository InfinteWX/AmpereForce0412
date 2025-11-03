// ------------------------------------------------------------
// @file       IStateClassExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 23:10:28
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.FSMKit.Example._1.StateClass
{
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine;
    
    public enum States
    {
        A, B, C
    }

    public class IStateClassExample : MonoBehaviour
    {
        [ShowInInspector]
        private FSM<States> _fsm = new FSM<States>();
        
        [SerializeField]
        private TextMeshProUGUI _textInfo;

        private void Start()
        {
            _fsm.AddState(States.A, new StateA(_fsm, this));
            _fsm.AddState(States.B, new StateB(_fsm, this));
            
            _fsm.StartState(States.A);
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
        
        public void SetTextInfo(string text)
        {
            _textInfo.text = text;
        }
    }
}