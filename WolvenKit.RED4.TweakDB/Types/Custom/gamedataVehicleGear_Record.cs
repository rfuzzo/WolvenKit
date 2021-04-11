namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleGear_Record : gamedataTweakDBRecord
    {
        [RED("minEngineRPM")]
        public CFloat MinEngineRPM
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minSpeed")]
        public CFloat MinSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("torqueMultiplier")]
        public CFloat TorqueMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxEngineRPM")]
        public CFloat MaxEngineRPM
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxSpeed")]
        public CFloat MaxSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
