// ------------------------------------------------------------
// @file       BindablePropertyExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-13 16:10:51
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._4.BindableProperty
{
    using UnityEngine;

    public class BindablePropertyExample : MonoBehaviour
    {
        private BindableProperty<int> _someValue        = new BindableProperty<int>(0);
        private string                _someValueContent = "Some Value: 0";

        void Start()
        {
            _someValue.Register((oldValue, newValue) =>
            {
                _someValueContent = $"SomeValue: {newValue}";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            Debug.Log("new BindableProperty<int>(5) == 5: " + (new BindableProperty<int>(5) == 5));
            Debug.Log("new BindableProperty<int>(5) == 6: " + (new BindableProperty<int>(5) == 6));
            Debug.Log("new BindableProperty<int>(Vector3.forward) == Vector3.forward: " + (new BindableProperty<Vector3>(Vector3.forward) == Vector3.forward));
            Debug.Log("new BindableProperty<int>(Vector3.back) == Vector3.forward: " + (new BindableProperty<Vector3>(Vector3.back) == Vector3.forward));
            Debug.Log("new BindableProperty<Test>(new Test()) == new Test()): " + (new BindableProperty<Test>(new Test()) == new Test()));
            Debug.Log("new BindableProperty<Test>(new Test()) == new Test(1)): " + (new BindableProperty<Test>(new Test()) == new Test(1)));
            Debug.Log("new BindableProperty<Test>(new Test(1)) == new Test(1)): " + (new BindableProperty<Test>(new Test(1)) == new Test(1)));
            Debug.Log("new BindableProperty<Test>(null) == null): " + (new BindableProperty<Test>(null) == null));
            Debug.Log("new BindableProperty<Test>(null) == new BindableProperty<Test>(null)): " + (new BindableProperty<Test>(null) == new BindableProperty<Test>(null)));
            Debug.Log("null == new BindableProperty<Test>(null)): " + (null == new BindableProperty<Test>(null)));
        }

        private void OnGUI()
        {
            if (GUILayout.Button("SomeValue++", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _someValue.Value++;
            }
            GUILayout.Label(_someValueContent, GUILayout.Width(150), GUILayout.Height(50));
        }
    }

    public class Test
    {
        public readonly int Value;

        public Test(int value = 0)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            // If parameter cannot be cast to Point return false.
            if (obj is not Test test)
            {
                return false;
            }

            // Return true if the fields match:
            return (Value == test.Value);
        }

        protected bool Equals(Test other)
        {
            // If parameter is null return false:
            if (other is null)
            {
                return false;
            }
            
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}