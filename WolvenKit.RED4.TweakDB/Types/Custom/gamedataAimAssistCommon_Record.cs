namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistCommon_Record : gamedataTweakDBRecord
    {
        [RED("angleProximityBonus")]
        public CFloat AngleProximityBonus
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleProximityThreshold")]
        public CFloat AngleProximityThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("worldProximityBonus")]
        public CFloat WorldProximityBonus
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("recentInputTime")]
        public CFloat RecentInputTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pastTargetWeight")]
        public CFloat PastTargetWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("worldDistUnitWeight")]
        public CFloat WorldDistUnitWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("targetAcquisitionDelayTime")]
        public CFloat TargetAcquisitionDelayTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleDistUnitWeight")]
        public CFloat AngleDistUnitWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("isEnabled")]
        public CBool IsEnabled
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("angleDistUnit")]
        public CFloat AngleDistUnit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("firstPassAngleRange")]
        public EulerAngles FirstPassAngleRange
        {
            get => GetProperty<EulerAngles>();
            set => SetProperty<EulerAngles>(value);
        }
        
        [RED("softLockTargetWeight")]
        public CFloat SoftLockTargetWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("aimAssistType")]
        public TweakDBID AimAssistType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("targetLostTimeOut")]
        public CFloat TargetLostTimeOut
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("worldDistUnit")]
        public CFloat WorldDistUnit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("softLockBrakeAngle")]
        public EulerAngles SoftLockBrakeAngle
        {
            get => GetProperty<EulerAngles>();
            set => SetProperty<EulerAngles>(value);
        }
        
        [RED("worldProximityThreshold")]
        public CFloat WorldProximityThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("isEnabledForMouse")]
        public CBool IsEnabledForMouse
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("rotatingAwayFromPastTargetPenalty")]
        public CFloat RotatingAwayFromPastTargetPenalty
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
