namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDistrictPreventionData_Record : gamedataTweakDBRecord
    {
        [RED("heat4")]
        public TweakDBID Heat4
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("heat1")]
        public TweakDBID Heat1
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("deescalationZeroTime")]
        public CFloat DeescalationZeroTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("nonAggressiveReactionMultipler")]
        public CFloat NonAggressiveReactionMultipler
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("damagePercentThreshold")]
        public CFloat DamagePercentThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("heat3")]
        public TweakDBID Heat3
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("heat2")]
        public TweakDBID Heat2
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("interiorSpawnDelay")]
        public CFloat InteriorSpawnDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
