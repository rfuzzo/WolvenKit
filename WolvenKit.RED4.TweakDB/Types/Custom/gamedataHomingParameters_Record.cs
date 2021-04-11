namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataHomingParameters_Record : gamedataTweakDBRecord
    {
        [RED("startVelocity")]
        public CFloat StartVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleInHitPlane")]
        public CFloat AngleInHitPlane
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleInVerticalPlane")]
        public CFloat AngleInVerticalPlane
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("accuracy")]
        public CFloat Accuracy
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("halfLeanAngle")]
        public CFloat HalfLeanAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shouldRotate")]
        public CBool ShouldRotate
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("linearTimeRatio")]
        public CFloat LinearTimeRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("returnTimeMargin")]
        public CFloat ReturnTimeMargin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bendTimeRatio")]
        public CFloat BendTimeRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("snapRadius")]
        public CFloat SnapRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleInterpolationDuration")]
        public CFloat AngleInterpolationDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("endLeanAngle")]
        public CFloat EndLeanAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bendFactor")]
        public CFloat BendFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("interpolationTimeRatio")]
        public CFloat InterpolationTimeRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
