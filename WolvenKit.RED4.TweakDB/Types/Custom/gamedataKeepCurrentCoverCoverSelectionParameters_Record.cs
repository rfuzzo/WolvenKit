namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataKeepCurrentCoverCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("keepCoverBonus")]
        public CFloat KeepCoverBonus
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
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
    }
}
