// ------------------------------------------------------------
// @file       AxisInput.cs
// @brief
// @author     zheliku
// @Modified   2024-12-03 15:12:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.InputKit.Example._2.KeyCode
{
    using UnityEngine;

    public class KeyCodeInputExample : MonoBehaviour
    {
        public GameObject Cube;

        public float Speed = 5;

        private void Start()
        {
            OldInputKit.RegisterKeyCode(KeyCode.W, (oldValue, value) =>
            {
                if (value)
                {
                    Cube.transform.Translate(Vector3.up * (Speed * Time.deltaTime));
                }
            }, InputType.Hold);
            
            OldInputKit.RegisterKeyCode(KeyCode.S, (oldValue, value) =>
            {
                if (value)
                {
                    Cube.transform.Translate(Vector3.down * (Speed * Time.deltaTime));
                }
            }, InputType.Hold);
            
            OldInputKit.RegisterKeyCode(KeyCode.A, (oldValue, value) =>
            {
                if (value)
                {
                    Cube.transform.Translate(Vector3.left * (Speed * Time.deltaTime));
                }
            }, InputType.Hold);
            
            OldInputKit.RegisterKeyCode(KeyCode.D, (oldValue, value) =>
            {
                if (value)
                {
                    Cube.transform.Translate(Vector3.right * (Speed * Time.deltaTime));
                }
            }, InputType.Hold);

            OldInputKit.RegisterKeyCode(KeyCode.Space, (oldValue, value) =>
            {
                if (value)
                {
                    OldInputKit.UnregisterKeyCode(KeyCode.A);
                }
            }, InputType.Press);
        }

        private void Update()
        {
            
        }
    }
}