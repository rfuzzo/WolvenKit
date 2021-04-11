namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehiclePIDSettings_Record : gamedataTweakDBRecord
    {
        [RED("outputSaturationLimit")]
        public CFloat OutputSaturationLimit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("P")]
        public CFloat P
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("D")]
        public CFloat D
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("I")]
        public CFloat I
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("integratorClampingLimit")]
        public CFloat IntegratorClampingLimit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
