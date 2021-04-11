namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataHandbrakeFrictionModifier_Record : gamedataTweakDBRecord
    {
        [RED("rearWheelsLatFrictionCoef")]
        public CFloat RearWheelsLatFrictionCoef
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("rearWheelsLongFrictionCoef")]
        public CFloat RearWheelsLongFrictionCoef
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
        
        [RED("blendOutTime")]
        public CFloat BlendOutTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("postHandbrakeTractionBoost")]
        public CFloat PostHandbrakeTractionBoost
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("additionalBrakeForLongUse")]
        public CFloat AdditionalBrakeForLongUse
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
