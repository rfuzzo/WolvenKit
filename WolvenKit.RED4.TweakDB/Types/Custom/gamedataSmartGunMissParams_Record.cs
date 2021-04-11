namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSmartGunMissParams_Record : gamedataTweakDBRecord
    {
        [RED("spiralRampDownDistanceEnd")]
        public CFloat SpiralRampDownDistanceEnd
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spiralRampUpDistanceEnd")]
        public CFloat SpiralRampUpDistanceEnd
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spiralRandomizePhase")]
        public CBool SpiralRandomizePhase
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("spiralRampDownDistanceStart")]
        public CFloat SpiralRampDownDistanceStart
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxMissAngleYaw")]
        public CFloat MaxMissAngleYaw
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxMissAnglePitch")]
        public CFloat MaxMissAnglePitch
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minMissAnglePitch")]
        public CFloat MinMissAnglePitch
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spiralRadius")]
        public CFloat SpiralRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minMissAngleYaw")]
        public CFloat MinMissAngleYaw
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spiralRampUpDistanceStart")]
        public CFloat SpiralRampUpDistanceStart
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spiralCycleTimeMin")]
        public CFloat SpiralCycleTimeMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("gravity")]
        public CFloat Gravity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("areaToIgnoreHalfYaw")]
        public CFloat AreaToIgnoreHalfYaw
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spiralRampDownFactor")]
        public CFloat SpiralRampDownFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spiralCycleTimeMax")]
        public CFloat SpiralCycleTimeMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
