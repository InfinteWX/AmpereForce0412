// ------------------------------------------------------------
// @file       EventTriggerExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 17:10:48
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.EventKit.Example._2.EventTriggerExample
{
    using Framework.Core;
    using UnityEngine;

    public class EventTriggerExample : MonoBehaviour
    {
        private GameObject _ground;
        private GameObject _image;

        private void Awake()
        {
            _ground = GameObject.Find("Ground");
            _image = GameObject.Find("Canvas/Image");
        }

        void Start()
        {
            _ground.OnCollisionEnter2DEvent(collider2D1 =>
            {
                Debug.Log(collider2D1.gameObject.name + ": entered");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            _image.OnPointerDownEvent(data =>
            {
                Debug.Log("Click");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
    }
}