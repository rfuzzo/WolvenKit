namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPathLengthCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("doorInvalidatesPath")]
        public CBool DoorInvalidatesPath
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
        
        [RED("multiplier")]
        public CFloat Multiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maximumRatio")]
        public CFloat MaximumRatio
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minPathLengthToPerform")]
        public CFloat MinPathLengthToPerform
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("useFriendlyTargetAsStart")]
        public CBool UseFriendlyTargetAsStart
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
