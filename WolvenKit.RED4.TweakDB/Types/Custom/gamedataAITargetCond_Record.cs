namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAITargetCond_Record : gamedataTweakDBRecord
    {
        [RED("isActive")]
        public CInt32 IsActive
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("isCombatTargetVisibleFrom")]
        public TweakDBID IsCombatTargetVisibleFrom
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("minAccuracySharedValue")]
        public CFloat MinAccuracySharedValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("invalidExpectation")]
        public CInt32 InvalidExpectation
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("isMoving")]
        public CInt32 IsMoving
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("maxVisibilityToTargetDistance")]
        public CFloat MaxVisibilityToTargetDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("attitude")]
        public CInt32 Attitude
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("isAlive")]
        public CInt32 IsAlive
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isVisible")]
        public CInt32 IsVisible
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("minAccuracyValue")]
        public CFloat MinAccuracyValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minDetectionValue")]
        public CFloat MinDetectionValue
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
