namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDriveWheelsAccelerateNoise_Record : gamedataTweakDBRecord
    {
        [RED("maxApplyTime")]
        public CFloat MaxApplyTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("accelerationBoostReverse")]
        public CFloat AccelerationBoostReverse
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("accelerationNoiseMaxSpeed")]
        public CFloat AccelerationNoiseMaxSpeed
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
        
        [RED("minForcesDifference")]
        public CFloat MinForcesDifference
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minApplyTime")]
        public CFloat MinApplyTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("accelerationBoost")]
        public CFloat AccelerationBoost
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxForcesDifference")]
        public CFloat MaxForcesDifference
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minLongSlipRatio")]
        public CFloat MinLongSlipRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("accelerationBoostMaxSpeed")]
        public CFloat AccelerationBoostMaxSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
