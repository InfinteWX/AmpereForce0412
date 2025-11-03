// ------------------------------------------------------------
// @file       AxisInput.cs
// @brief
// @author     zheliku
// @Modified   2024-12-03 15:12:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.InputKit.Example._0.Axis
{
    using UnityEngine;

    public class AxisInputExample : MonoBehaviour
    {
        public GameObject Cube;

        public float Speed = 5;

        private void Start()
        {
            OldInputKit.RegisterAxis("Horizontal", (oldValue, value) =>
            {
                Cube.transform.Translate(Vector3.right * (Speed * value * Time.deltaTime));
            });
            
            OldInputKit.RegisterAxis("Vertical", (oldValue, value) =>
            {
                Cube.transform.Translate(Vector3.up * (Speed * value * Time.deltaTime));
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OldInputKit.UnregisterAxis("Vertical");
            }
        }
    }
}