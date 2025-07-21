using Framework.Core;

namespace AmpereForce
{
    public class AmpereForce : AbstractArchitecture<AmpereForce>
    {
        protected override void Init()
        {
            RegisterModel(new MagneticModel());
        }
    }
}