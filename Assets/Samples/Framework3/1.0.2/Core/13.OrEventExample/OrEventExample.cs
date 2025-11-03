// ------------------------------------------------------------
// @file       OrEventExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 23:10:56
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework3.Core.Example._13.OrEventExample
{
    public class OrEventExample : MonoBehaviour
    {
        private BindableProperty<int> _propertyA = new BindableProperty<int>();
        private BindableProperty<int> _propertyB = new BindableProperty<int>();

        private EasyEvent _event = new EasyEvent();

        private void Awake()
        {
            _propertyA.Or(_event).Or(_propertyB)
                      .Register(() => { Debug.Log("Event Received!"); })
                      .UnregisterWhenGameObjectDestroyed(gameObject);
        }

        public void PropertyAPlusPlus()
        {
            _propertyA.Value++;
        }
        
        public void PropertyBPlusPlus()
        {
            _propertyB.Value++;
        }
        
        public void TriggerEvent()
        {
            _event.Trigger();
        }
    }
}