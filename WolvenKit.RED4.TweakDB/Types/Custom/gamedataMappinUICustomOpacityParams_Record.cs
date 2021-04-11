namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMappinUICustomOpacityParams_Record : gamedataTweakDBRecord
    {
        [RED("visibilityConeStartAngle")]
        public CFloat VisibilityConeStartAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("visibilityConeEndAngle")]
        public CFloat VisibilityConeEndAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("visibilityConeMaximumOpacity")]
        public CFloat VisibilityConeMaximumOpacity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distanceWhenFullyVisible")]
        public CFloat DistanceWhenFullyVisible
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distanceWhenFullyHidden")]
        public CFloat DistanceWhenFullyHidden
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
