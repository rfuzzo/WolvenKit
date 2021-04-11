namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataUphillDriveHelper_Record : gamedataDriveHelper_Record
    {
        [RED("slopeCompensationMaxAngle")]
        public CFloat SlopeCompensationMaxAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("slopeCompensationFactor")]
        public CFloat SlopeCompensationFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
