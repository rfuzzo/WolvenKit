namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistBulletMagnetism_Record : gamedataTweakDBRecord
    {
        [RED("targetSearchAngleYaw")]
        public CFloat TargetSearchAngleYaw
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("magPointOffset")]
        public CFloat MagPointOffset
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
        
        [RED("targetSearchAnglePitch")]
        public CFloat TargetSearchAnglePitch
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("targetHighAngularVelocity")]
        public CFloat TargetHighAngularVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
