// ------------------------------------------------------------
// @file       BasicExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-26 22:12:17
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Example.Toolkits.InputKit.InputSystem_Example._0.UpdateUse
{
    using Framework.Toolkits.FluentAPI;
    using Framework.Toolkits.InputKit;
    using UnityEngine;

    public class UpdateUseExample : MonoBehaviour
    {
        public GameObject Cube;

        public float Speed = 5f;

        private void Awake()
        {
            Cube = "Cube".GetGameObjectInHierarchy();
        }

        private void Update()
        {
            Cube.transform.Translate(InputKit.ReadValue<Vector2>("Move") * (Time.deltaTime * Speed));
        }
    }
}