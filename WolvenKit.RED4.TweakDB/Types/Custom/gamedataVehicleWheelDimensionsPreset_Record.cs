namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleWheelDimensionsPreset_Record : gamedataTweakDBRecord
    {
        [RED("tireWidth")]
        public CFloat TireWidth
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("wheelOffset")]
        public CFloat WheelOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rimRadius")]
        public CFloat RimRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tireRadius")]
        public CFloat TireRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
