using Framework.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AmpereForce
{
    public class TestView : AbstractView
    {
        [ShowInInspector]
        public EpType EpType
        {
            get => this.GetModel<MagneticModel>().EpType;
            set => this.GetModel<MagneticModel>().EpType = value;
        }

        [ShowInInspector]
        public Vector3 B
        {
            get => this.GetModel<MagneticModel>().Data.B;
            set
            {
                if (value.normalized != Vector3.zero)
                {
                    this.GetModel<MagneticModel>().Data.Direction = value.normalized;
                }
                this.GetModel<MagneticModel>().Data.Magnitude = value.magnitude;
            }
        }

        [ShowInInspector]
        public float I
        {
            get => this.GetModel<MagneticModel>().I;
            set => this.GetModel<MagneticModel>().I = value;
        }

        [ShowInInspector]
        public float R
        {
            get => this.GetModel<MagneticModel>().R;
            set => this.GetModel<MagneticModel>().R = value;
        }

        protected override IArchitecture _Architecture
        {
            get => AmpereForce.Architecture;
        }
    }
}