namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAngleDistanceCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("shootingSpotLowerMinVerticalAngle")]
        public CFloat ShootingSpotLowerMinVerticalAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("threatPredictionTime")]
        public CFloat ThreatPredictionTime
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
        
        [RED("verticalAngleCooldown")]
        public CFloat VerticalAngleCooldown
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
        
        [RED("closestThreatsAmountToIgnoreDistanceCheck")]
        public CInt32 ClosestThreatsAmountToIgnoreDistanceCheck
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("maximumDistance")]
        public CFloat MaximumDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("coverProtectionAngleMul")]
        public CFloat CoverProtectionAngleMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("coverLowerMinVerticalAngle")]
        public CFloat CoverLowerMinVerticalAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minThreatsAmountToCheckDistance")]
        public CInt32 MinThreatsAmountToCheckDistance
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("angleDistanceScore")]
        public CFloat AngleDistanceScore
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
