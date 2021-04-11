namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAbsoluteZLimiterCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("scoreOnlyForCombatTarget")]
        public CBool ScoreOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("zLimit")]
        public CFloat ZLimit
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
    }
}
