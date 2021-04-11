namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDynamicDownforceHelper_Record : gamedataTweakDBRecord
    {
        [RED("maxSpeedFactorAir")]
        public CFloat MaxSpeedFactorAir
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
        
        [RED("maxSpeedFactorGround")]
        public CFloat MaxSpeedFactorGround
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
        
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
