namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleSteeringSettings_Record : gamedataTweakDBRecord
    {
        [RED("speedForMaxDistance")]
        public CFloat SpeedForMaxDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("fullSteeringSpeed")]
        public CFloat FullSteeringSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minTargetDistance")]
        public CFloat MinTargetDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("errorMagnitudeForMildSteering")]
        public CFloat ErrorMagnitudeForMildSteering
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxTargetDistance")]
        public CFloat MaxTargetDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mildSteeringSpeed")]
        public CFloat MildSteeringSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("errorMagnitudeForFullSteering")]
        public CFloat ErrorMagnitudeForFullSteering
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("speedForMinDistance")]
        public CFloat SpeedForMinDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
