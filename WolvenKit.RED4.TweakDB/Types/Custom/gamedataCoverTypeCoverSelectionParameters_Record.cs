namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCoverTypeCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("maxScore")]
        public CFloat MaxScore
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("coverScore")]
        public CFloat CoverScore
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("shootingSpotScore")]
        public CFloat ShootingSpotScore
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
        
        [RED("scoreOnlyForCombatTarget")]
        public CBool ScoreOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
