namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataFriendlyTargetDistanceCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("vaidateOnlyForCombatTarget")]
        public CBool VaidateOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("friendlyTargetPreferredDistance")]
        public CFloat FriendlyTargetPreferredDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("friendlyTargetMaxDistance")]
        public CFloat FriendlyTargetMaxDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distanceToFriendlyTargetMultiplier")]
        public CFloat DistanceToFriendlyTargetMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("friendlyTargetMinDistance")]
        public CFloat FriendlyTargetMinDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spatialHintMults")]
        public Vector3 SpatialHintMults
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("scoreOnlyForCombatTarget")]
        public CBool ScoreOnlyForCombatTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("friendlyTargetZLimit")]
        public CFloat FriendlyTargetZLimit
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
