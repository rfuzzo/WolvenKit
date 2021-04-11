namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataClearLineOfSightCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("multiplier")]
        public CFloat Multiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("preferredActionCount")]
        public CInt32 PreferredActionCount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("clearLOSDistanceTolerance")]
        public CFloat ClearLOSDistanceTolerance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("cooldown")]
        public CFloat Cooldown
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
