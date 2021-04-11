namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRearWheelsFrictionModifier_Record : gamedataTweakDBRecord
    {
        [RED("maxHelperAcceleration")]
        public CFloat MaxHelperAcceleration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxLatSlipRatio")]
        public CFloat MaxLatSlipRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minLatSlipRatio")]
        public CFloat MinLatSlipRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minLongSlipRatio")]
        public CFloat MinLongSlipRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minLongFrictionCoef")]
        public CFloat MinLongFrictionCoef
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
        
        [RED("maxSpeed")]
        public CFloat MaxSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxLongSlipRatio")]
        public CFloat MaxLongSlipRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minLatFrictionCoef")]
        public CFloat MinLatFrictionCoef
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
