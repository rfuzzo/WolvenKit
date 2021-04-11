namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataOwnerDistanceCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("ownerPreferredDistance")]
        public CFloat OwnerPreferredDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ownerMinDistance")]
        public CFloat OwnerMinDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ownerMaxDistance")]
        public CFloat OwnerMaxDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
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
        
        [RED("scoreOnlyForCombatTarget")]
        public CBool ScoreOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
