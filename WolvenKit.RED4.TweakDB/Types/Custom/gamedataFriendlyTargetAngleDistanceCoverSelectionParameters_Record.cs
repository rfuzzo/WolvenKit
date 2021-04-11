namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataFriendlyTargetAngleDistanceCoverSelectionParameters_Record : gamedataTweakDBRecord
    {
        [RED("minDot")]
        public CFloat MinDot
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
        
        [RED("coverProtectionAngleMul")]
        public CFloat CoverProtectionAngleMul
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("positionChangeThreshold")]
        public CFloat PositionChangeThreshold
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
        
        [RED("maxScoreIfInRange")]
        public CBool MaxScoreIfInRange
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("angleDistanceScore")]
        public CFloat AngleDistanceScore
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
