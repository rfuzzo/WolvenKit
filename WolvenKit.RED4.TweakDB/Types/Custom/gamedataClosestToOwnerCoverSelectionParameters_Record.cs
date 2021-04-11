namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataClosestToOwnerCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("distanceToOwnerMultiplier")]
        public CFloat DistanceToOwnerMultiplier
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
        
        [RED("preferredOwnerDistance")]
        public CFloat PreferredOwnerDistance
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
    }
}
