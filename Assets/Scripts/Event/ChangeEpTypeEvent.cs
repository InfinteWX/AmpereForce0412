namespace AmpereForce
{
    public struct ChangeEpTypeEvent
    {
        public EpType Type;

        public ChangeEpTypeEvent(EpType type)
        {
            Type = type;
        }
    }
}