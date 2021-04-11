namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionPhase_Record : gamedataTweakDBRecord
    {
        [RED("conditionSuccessDuration")]
        public CFloat ConditionSuccessDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("notRepeatPhaseCondition")]
        public CArray<TweakDBID> NotRepeatPhaseCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dynamicDuration")]
        public TweakDBID DynamicDuration
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("useDurationFromAnimSlot")]
        public CBool UseDurationFromAnimSlot
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("toNextPhaseCondition")]
        public CArray<TweakDBID> ToNextPhaseCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("repeat")]
        public CInt32 Repeat
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("animationDuration")]
        public CFloat AnimationDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("toNextPhaseConditionCheckInterval")]
        public CFloat ToNextPhaseConditionCheckInterval
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("completeActionWithFailureOnCondition")]
        public CBool CompleteActionWithFailureOnCondition
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("movePolicy")]
        public TweakDBID MovePolicy
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("changeNPCState")]
        public TweakDBID ChangeNPCState
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
