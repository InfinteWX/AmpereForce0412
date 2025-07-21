// ------------------------------------------------------------
// @file       AxisInput.cs
// @brief
// @author     zheliku
// @Modified   2024-12-03 15:12:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.InputKit.Example._0.Axis
{
    using System;
    using UnityEngine;

    public class AxisInputExample : MonoBehaviour
    {
        public GameObject Cube;

        public float Speed = 5;

        private void Start()
        {
            InputKit.RegisterAxis("Horizontal", (oldValue, value) =>
            {
                Cube.transform.Translate(Vector3.right * (Speed * value * Time.deltaTime));
            });
            
            InputKit.RegisterAxis("Vertical", (oldValue, value) =>
            {
                Cube.transform.Translate(Vector3.up * (Speed * value * Time.deltaTime));
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InputKit.UnRegisterAxis("Vertical");
            }
        }
    }
}