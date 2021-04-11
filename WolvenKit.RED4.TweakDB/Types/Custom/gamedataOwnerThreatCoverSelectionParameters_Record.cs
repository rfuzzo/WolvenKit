namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataOwnerThreatCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("ownerThreatCoverAngle")]
        public CFloat OwnerThreatCoverAngle
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
