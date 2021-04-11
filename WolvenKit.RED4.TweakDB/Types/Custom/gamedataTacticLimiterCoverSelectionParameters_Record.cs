namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataTacticLimiterCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
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
        
        [RED("addUtilityValue")]
        public CFloat AddUtilityValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
