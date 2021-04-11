namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLookAtPreset_Record : gamedataTweakDBRecord
    {
        [RED("calculatePositionInParentSpace")]
        public CBool CalculatePositionInParentSpace
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("followingSpeedFactorOverride")]
        public CFloat FollowingSpeedFactorOverride
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("softLimitDegrees")]
        public CFloat SoftLimitDegrees
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("lookAtParts")]
        public CArray<TweakDBID> LookAtParts
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("mode")]
        public CInt32 Mode
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("attachLeftHandtoRightHand")]
        public CBool AttachLeftHandtoRightHand
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("hardLimitDegrees")]
        public CFloat HardLimitDegrees
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hasOutTransition")]
        public CBool HasOutTransition
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("attachRightHandtoLeftHand")]
        public CBool AttachRightHandtoLeftHand
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("backLimitDegrees")]
        public CFloat BackLimitDegrees
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bodyPart")]
        public CName BodyPart
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hardLimitDistance")]
        public CFloat HardLimitDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("outTransitionSpeed")]
        public CFloat OutTransitionSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("suppress")]
        public CFloat Suppress
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("transitionSpeed")]
        public CFloat TransitionSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("priority")]
        public CInt32 Priority
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
