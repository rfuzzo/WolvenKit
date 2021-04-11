namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataThreatDistanceCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("useThreatMaxDistanceFiltering")]
        public CBool UseThreatMaxDistanceFiltering
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("threatPredictionTime")]
        public CFloat ThreatPredictionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("threatMinDistance")]
        public CFloat ThreatMinDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("threatPreferredDistance")]
        public CFloat ThreatPreferredDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("threatMaxDistance")]
        public CFloat ThreatMaxDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("allowNegativeThreatMaxDistanceScoring")]
        public CBool AllowNegativeThreatMaxDistanceScoring
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("scoreOnlyForCombatTarget")]
        public CBool ScoreOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("vaidateOnlyForCombatTarget")]
        public CBool VaidateOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("distanceToThreatMultiplier")]
        public CFloat DistanceToThreatMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
