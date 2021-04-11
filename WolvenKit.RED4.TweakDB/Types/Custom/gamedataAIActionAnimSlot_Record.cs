namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionAnimSlot_Record : gamedataTweakDBRecord
    {
        [RED("resetRagdollOnStart")]
        public CBool ResetRagdollOnStart
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("useDynamicObjectsCheck")]
        public CBool UseDynamicObjectsCheck
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("useRootMotion")]
        public CBool UseRootMotion
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("recoverySlide")]
        public TweakDBID RecoverySlide
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("loopSlide")]
        public TweakDBID LoopSlide
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("startupSlide")]
        public TweakDBID StartupSlide
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("usePoseMatching")]
        public CBool UsePoseMatching
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
