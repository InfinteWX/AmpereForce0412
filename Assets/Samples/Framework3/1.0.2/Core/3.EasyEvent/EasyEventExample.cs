// ------------------------------------------------------------
// @file       EasyEventExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 16:10:36
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._3.EasyEvent
{
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using EasyEvent = Core.EasyEvent;
    using Random = UnityEngine.Random;

    public class EventA : EasyEvent<int, int>
    { }

    public class EasyEventExample : AbstractView
    {
        [HierarchyPath("/Canvas/EasyEvent/Txt_Info")]
        private TextMeshProUGUI _easyEventText;

        [HierarchyPath("/Canvas/EasyEventInt/Txt_Info")]
        private TextMeshProUGUI _easyEventIntText;

        [HierarchyPath("/Canvas/EventA/Txt_Info")]
        private TextMeshProUGUI _eventAText;

        [HierarchyPath("/Canvas/EasyEventInt/Scrollbar")]
        private Scrollbar _easyEventIntScrollbar;

        [ShowInInspector]
        private EasyEvent _easyEvent = new EasyEvent();

        [ShowInInspector]
        private EasyEvent<int> _easyEventInt = new EasyEvent<int>();

        [ShowInInspector]
        private EventA _eventA = new EventA();

        private void Start()
        {
            _easyEvent.Register(() =>
            {
                _easyEventText.text = "Clicked!";
            }).UnregisterWhenGameObjectDestroyed(gameObject);

            _easyEvent.Register(() =>
            {
                Debug.Log("Clicked! 1");
            }, 2).UnregisterWhenGameObjectDestroyed(gameObject);

            _easyEvent.Register(() =>
            {
                Debug.Log("Clicked! 2");
            }, 1).UnregisterWhenGameObjectDestroyed(gameObject);

            _easyEventInt.Register(value =>
            {
                _easyEventIntText.text = $"Value: {value}";
            }).UnregisterWhenGameObjectDestroyed(gameObject);

            _eventA.Register((a, b) =>
            {
                _eventAText.text = $"Value: {a}, {b}";
            }).UnregisterWhenGameObjectDestroyed(gameObject);
        }

        public void SendEasyEvent()
        {
            _easyEvent.Trigger();
        }

        public void SendEasyEventInt()
        {
            var intValue = (int) (_easyEventIntScrollbar.value * 10);
            _easyEventInt.Trigger(intValue);
        }

        public void SendEventA()
        {
            _eventA.Trigger(Random.Range(0, 10), Random.Range(0, 10));
        }

        protected override IArchitecture _Architecture
        {
            get => null;
        }
    }
}