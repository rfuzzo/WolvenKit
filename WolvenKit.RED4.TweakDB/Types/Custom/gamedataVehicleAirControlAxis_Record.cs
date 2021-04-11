namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleAirControlAxis_Record : gamedataTweakDBRecord
    {
        [RED("multiplier")]
        public CFloat Multiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleCorrectionFactorMin")]
        public CFloat AngleCorrectionFactorMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("velocityDampingThresholdMin")]
        public CFloat VelocityDampingThresholdMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("velocityDampingThresholdMax")]
        public CFloat VelocityDampingThresholdMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxAngleCompensation")]
        public CFloat MaxAngleCompensation
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleCorrectionFactorMax")]
        public CFloat AngleCorrectionFactorMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("velocityDampingFactorMax")]
        public CFloat VelocityDampingFactorMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxVelocityCompensation")]
        public CFloat MaxVelocityCompensation
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("velocityDampingFactorMin")]
        public CFloat VelocityDampingFactorMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("controlAxis")]
        public CName ControlAxis
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("angleCorrectionThresholdMin")]
        public CFloat AngleCorrectionThresholdMin
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angleCorrectionThresholdMax")]
        public CFloat AngleCorrectionThresholdMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("brakeMultiplierWhenNoInput")]
        public CFloat BrakeMultiplierWhenNoInput
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zeroAngleThreshold")]
        public CFloat ZeroAngleThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxAngleToCompensateThreshold")]
        public CFloat MaxAngleToCompensateThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("stabilizeAxis")]
        public CBool StabilizeAxis
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
