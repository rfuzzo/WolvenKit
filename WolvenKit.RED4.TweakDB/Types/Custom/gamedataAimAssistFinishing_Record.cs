namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistFinishing_Record : gamedataTweakDBRecord
    {
        [RED("velocityDecreaseActivationFactor")]
        public CFloat VelocityDecreaseActivationFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("inputHistoryTime")]
        public CFloat InputHistoryTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxTime")]
        public CFloat MaxTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxCorrectionPitch")]
        public CFloat MaxCorrectionPitch
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxCorrectionYaw")]
        public CFloat MaxCorrectionYaw
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxCorrectionAngle")]
        public CFloat MaxCorrectionAngle
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
    }
}
