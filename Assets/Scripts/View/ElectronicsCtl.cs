// ------------------------------------------------------------
// @file       Electronics.cs
// @brief
// @author     zheliku
// @Modified   2025-07-21 11:38:37
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using Framework.Toolkits.FluentAPI;
using UnityEngine;

namespace AmpereForce
{
    using Framework.Core;

    public enum EpMode
    {
        Macro,
        Micro
    }

    public class ElectronicsCtl : AbstractView
    {
        public List<Transform> Electronics;

        public float Speed = 5f;

        public bool IsRunning { get; set; }

        private void Awake()
        {
            this.GetModel<MagneticModel>().EpMode.Register((oldValue, newValue) =>
            {
                IsRunning = newValue == EpMode.Micro;
            }).UnRegisterWhenGameObjectDestroyed(this);
        }

        private void Update()
        {
            if (!IsRunning) return;

            foreach (var electronic in Electronics)
            {
                var deltaY = Time.deltaTime * Speed;
                electronic.Translate(Vector3.up * deltaY, Space.Self);

                var localPosY = electronic.GetLocalPositionY();
                if (localPosY > 1)
                {
                    electronic.SetLocalPosition(y: localPosY - 2);
                }
                else if (localPosY < -1)
                {
                    electronic.SetLocalPosition(y: localPosY + 2);
                }
            }
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}