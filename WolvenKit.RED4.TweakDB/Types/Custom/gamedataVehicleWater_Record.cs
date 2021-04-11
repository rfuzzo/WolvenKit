namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWater_Record : gamedataTweakDBRecord
    {
        [RED("buoyancyCoef")]
        public CFloat BuoyancyCoef
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("linearDampingCoef")]
        public CFloat LinearDampingCoef
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("disableEngine")]
        public CBool DisableEngine
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("submergedThreshold")]
        public CFloat SubmergedThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("angularDampingCoef")]
        public CFloat AngularDampingCoef
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("disableAirControl")]
        public CBool DisableAirControl
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
