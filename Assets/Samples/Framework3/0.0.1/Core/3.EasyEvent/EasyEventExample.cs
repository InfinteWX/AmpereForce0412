// ------------------------------------------------------------
// @file       EasyEventExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 16:10:36
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._3.EasyEvent
{
    using Sirenix.OdinInspector;
    using UnityEngine;
    using EasyEvent = Core.EasyEvent;

    public class EventA : EasyEvent<int, int>
    { }

    public class EasyEventExample : MonoBehaviour
    {
        [ShowInInspector]
        private EasyEvent _easyEvent = new EasyEvent();

        private string _easyEventContent = "Waiting...";

        [ShowInInspector]
        private EasyEvent<int> _easyEventInt = new EasyEvent<int>();

        private int    _easyEventIntValue   = 0;
        private string _easyEventIntContent = "Value: 0";

        [ShowInInspector]
        private EventA _eventA = new EventA();

        private int    _eventAValue1  = 0;
        private int    _eventAValue2  = 0;
        private string _eventAContent = "Value: 0, 0";

        private void Start()
        {
            _easyEvent.Register(() =>
            {
                _easyEventContent = "Clicked!";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            _easyEvent.Register(() =>
            {
                Debug.Log("Clicked! 1");
            }, 2).UnRegisterWhenGameObjectDestroyed(gameObject);

            _easyEvent.Register(() =>
            {
                Debug.Log("Clicked! 2");
            }, 1).UnRegisterWhenGameObjectDestroyed(gameObject);

            _easyEventInt.Register(value =>
            {
                _easyEventIntContent = $"Value: {value}";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);


            _eventA.Register((a, b) =>
            {
                _eventAContent = $"Value: {a}, {b}";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            if (GUILayout.Button("EasyEvent", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _easyEvent.Trigger();
            }
            GUILayout.Label(_easyEventContent);
            GUILayout.EndVertical();

            GUILayout.Space(40);

            GUILayout.BeginVertical();
            if (GUILayout.Button("EasyEventInt", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _easyEventInt.Trigger(_easyEventIntValue);
            }
            _easyEventIntValue = (int) GUILayout.HorizontalSlider(_easyEventIntValue, 0f, 10f);
            GUILayout.Label(_easyEventIntContent);
            GUILayout.EndVertical();

            GUILayout.Space(40);

            GUILayout.BeginVertical();
            if (GUILayout.Button("EventA", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _eventA.Trigger(_eventAValue1, _eventAValue2);
            }
            _eventAValue1 = (int) GUILayout.HorizontalSlider(_eventAValue1, 0f, 10f);
            _eventAValue2 = (int) GUILayout.HorizontalSlider(_eventAValue2, 0f, 10f);
            GUILayout.Label(_eventAContent);
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }
    }
}