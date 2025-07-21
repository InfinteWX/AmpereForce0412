// ------------------------------------------------------------
// @file       BasicExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-26 22:12:17
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Example.Toolkits.InputKit.InputSystem_Example._1.EventUse
{
    using Framework.Toolkits.FluentAPI;
    using Framework.Toolkits.InputKit;
    using UnityEngine;

    public class EventUseExample : MonoBehaviour
    {
        public GameObject Cube;

        public float Speed = 5f;

        public Vector2 _moveDir;

        private void Awake()
        {
            Cube = "Cube".GetGameObjectInHierarchy();

            InputKit.BindPerformed("Move", context =>
            {
                _moveDir = context.ReadValue<Vector2>();
            }).BindCanceled(context =>
            {
                _moveDir = Vector2.zero;
            });
        }

        private void Update()
        {
            Cube.transform.Translate(_moveDir * (Time.deltaTime * Speed));
        }
    }
}