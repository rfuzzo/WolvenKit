namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDistanceFromOthersCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("scoreOnlyForCombatTarget")]
        public CBool ScoreOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minimalPreferredDistance")]
        public CFloat MinimalPreferredDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distanceScoreMultiplier")]
        public CFloat DistanceScoreMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("vaidateOnlyForCombatTarget")]
        public CBool VaidateOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minimalDistance")]
        public CFloat MinimalDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
