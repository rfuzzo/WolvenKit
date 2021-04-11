namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataInAirGravityModifier_Record : gamedataTweakDBRecord
    {
        [RED("baseAddedGravity")]
        public CFloat BaseAddedGravity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("smoothingFactor")]
        public CFloat SmoothingFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("driveSpeedAddedGravity")]
        public CFloat DriveSpeedAddedGravity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxDriveSpeed")]
        public CFloat MaxDriveSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minDriveSpeed")]
        public CFloat MinDriveSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zVelReductionEnd")]
        public CFloat ZVelReductionEnd
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zVelReductionStart")]
        public CFloat ZVelReductionStart
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
