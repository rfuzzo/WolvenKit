namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionDroneModifyAltitude_Record : gamedataTweakDBRecord
    {
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("altitudeOffset")]
        public CFloat AltitudeOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
