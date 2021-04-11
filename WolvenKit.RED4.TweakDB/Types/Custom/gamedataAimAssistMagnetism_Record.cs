namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistMagnetism_Record : gamedataTweakDBRecord
    {
        [RED("finishingEnabled")]
        public CBool FinishingEnabled
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("blendOffTime")]
        public CFloat BlendOffTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distanceMultiplier")]
        public CName DistanceMultiplier
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("targetLostBlendOut")]
        public CBool TargetLostBlendOut
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stickInputMagMultiplier")]
        public CName StickInputMagMultiplier
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("fullStickThreshold")]
        public CFloat FullStickThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxStrength")]
        public Vector2 MaxStrength
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("softLockTimeToReach")]
        public CFloat SoftLockTimeToReach
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("disableWithNoInput")]
        public CBool DisableWithNoInput
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("checkWeaponEffectiveRange")]
        public CBool CheckWeaponEffectiveRange
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("yawBoundAdditiveForPitchMagnetism")]
        public CFloat YawBoundAdditiveForPitchMagnetism
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minTimeTillOffTarget")]
        public CFloat MinTimeTillOffTarget
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
        
        [RED("maxTimeTillOffTarget")]
        public CFloat MaxTimeTillOffTarget
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pitchBoundAdditiveForYawMagnetism")]
        public CFloat PitchBoundAdditiveForYawMagnetism
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("blendOnTime")]
        public CFloat BlendOnTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("fullStickYawAngleDisable")]
        public CFloat FullStickYawAngleDisable
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
