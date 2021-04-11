namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatusEffectPlayerData_Record : gamedataTweakDBRecord
    {
        [RED("disableCrouch")]
        public CBool DisableCrouch
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("landAnimDuration")]
        public CFloat LandAnimDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("scaleImpulseDistance")]
        public CBool ScaleImpulseDistance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("blockMovement")]
        public CBool BlockMovement
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("disableJump")]
        public CBool DisableJump
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("disableDodge")]
        public CBool DisableDodge
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("jamWeapon")]
        public CBool JamWeapon
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("impulseDistance")]
        public CFloat ImpulseDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("cameraInputInterference")]
        public CBool CameraInputInterference
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("statusEffectVariation")]
        public TweakDBID StatusEffectVariation
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("recoveryAnimDuration")]
        public CFloat RecoveryAnimDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("disableSprint")]
        public CBool DisableSprint
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("startupAnimDuration")]
        public CFloat StartupAnimDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("cameraShakeStrength")]
        public CFloat CameraShakeStrength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rotateToSource")]
        public CBool RotateToSource
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("airRecoveryAnimDuration")]
        public CFloat AirRecoveryAnimDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("forceSafeWeapon")]
        public CBool ForceSafeWeapon
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("startupAnimInterruptPoint")]
        public CFloat StartupAnimInterruptPoint
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("forceUnequipWeapon")]
        public CBool ForceUnequipWeapon
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("priority")]
        public CFloat Priority
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
