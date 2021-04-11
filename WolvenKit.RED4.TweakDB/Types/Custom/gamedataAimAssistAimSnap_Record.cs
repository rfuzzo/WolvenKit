namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAimAssistAimSnap_Record : gamedataTweakDBRecord
    {
        [RED("endOnTimeExceeded")]
        public CBool EndOnTimeExceeded
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("cancelWithRecoil")]
        public CBool CancelWithRecoil
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isEnabled")]
        public CBool IsEnabled
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("adjustPitch")]
        public CBool AdjustPitch
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("adjustYaw")]
        public CBool AdjustYaw
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("easeIn")]
        public CBool EaseIn
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("cameraInputMagToBreak")]
        public CFloat CameraInputMagToBreak
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("evaluateTargets")]
        public CBool EvaluateTargets
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("precision")]
        public CFloat Precision
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxDistance")]
        public CFloat MaxDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("easeOut")]
        public CBool EaseOut
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("targetAngleDistanceFactor")]
        public CFloat TargetAngleDistanceFactor
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("endOnAimingStopped")]
        public CBool EndOnAimingStopped
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("endOnCameraInputApplied")]
        public CBool EndOnCameraInputApplied
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minDistance")]
        public CFloat MinDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxDuration")]
        public CFloat MaxDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("endOnTargetReached")]
        public CBool EndOnTargetReached
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
        
        [RED("checkRange")]
        public CBool CheckRange
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
