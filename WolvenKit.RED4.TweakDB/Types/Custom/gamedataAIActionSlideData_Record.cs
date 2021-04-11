namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionSlideData_Record : gamedataTweakDBRecord
    {
        [RED("offsetAroundTarget")]
        public CFloat OffsetAroundTarget
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("disablePositionSlideAgainstNpc")]
        public CBool DisablePositionSlideAgainstNpc
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("rotationSpeed")]
        public CFloat RotationSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("directionAngle")]
        public CFloat DirectionAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distance")]
        public CFloat Distance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("positionSpeed")]
        public CFloat PositionSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("useRotationSlide")]
        public CBool UseRotationSlide
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("slideStartDelay")]
        public CFloat SlideStartDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("positionPredictionTime")]
        public CFloat PositionPredictionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("offsetToTarget")]
        public CFloat OffsetToTarget
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("usePositionSlide")]
        public CBool UsePositionSlide
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("finalRotationAngle")]
        public CFloat FinalRotationAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("zAlignmentCollisionThreshold")]
        public CFloat ZAlignmentCollisionThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("overrideOffsetToTargetFromWeapon")]
        public CBool OverrideOffsetToTargetFromWeapon
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
