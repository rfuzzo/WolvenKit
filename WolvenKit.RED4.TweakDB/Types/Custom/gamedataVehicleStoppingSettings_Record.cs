namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleStoppingSettings_Record : gamedataTweakDBRecord
    {
        [RED("errorMagnitudeForFullBrakingChange")]
        public CFloat ErrorMagnitudeForFullBrakingChange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("mildBrakingChangeSpeed")]
        public CFloat MildBrakingChangeSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("errorMagnitudeForMildBrakingChange")]
        public CFloat ErrorMagnitudeForMildBrakingChange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("fullBrakingChangeSpeed")]
        public CFloat FullBrakingChangeSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("decreaseMul")]
        public CFloat DecreaseMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
