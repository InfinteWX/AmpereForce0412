// ------------------------------------------------------------
// @file       AxisInput.cs
// @brief
// @author     zheliku
// @Modified   2024-12-03 15:12:14
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.InputKit.Example._1.Mouse
{
    using System;
    using FluentAPI;
    using UnityEngine;

    public class MouseInputExample : MonoBehaviour
    {
        public GameObject Cube;

        private void Start()
        {
           InputKit.RegisterMouse(MouseInputType.Left, (oldValue, value) =>
           {
               if (value)
               {
                   Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition.Set(z: 10));
                   Cube.SetPosition(mousePos);
               }
           });
           
            InputKit.RegisterMouse(MouseInputType.Right, (oldValue, value) =>
            {
                if (value)
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition.Set(z: 10));
                    Cube.SetPosition(mousePos);
                }
            }, InputType.Hold);
        }
    }
}