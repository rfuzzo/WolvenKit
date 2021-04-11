namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRotationLimiter_Record : gamedataTweakDBRecord
    {
        [RED("driftFullAngleBegin")]
        public CFloat DriftFullAngleBegin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("handbrakeLimit")]
        public CFloat HandbrakeLimit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("driftFullAngleEnd")]
        public CFloat DriftFullAngleEnd
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
        
        [RED("smoothingTime")]
        public CFloat SmoothingTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("driftExceededAngle")]
        public CFloat DriftExceededAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("driftLimitStartVel")]
        public CFloat DriftLimitStartVel
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("driftLimitMaxVel")]
        public CFloat DriftLimitMaxVel
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxAngularSpeedRad")]
        public CFloat MaxAngularSpeedRad
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("driftLimit")]
        public CFloat DriftLimit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
