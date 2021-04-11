namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionSmartComposite_Record : gamedataTweakDBRecord
    {
        [RED("repeat")]
        public CInt32 Repeat
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("disableActionsLimit")]
        public CBool DisableActionsLimit
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("gracefulInterruptionConditionCheckInterval")]
        public CFloat GracefulInterruptionConditionCheckInterval
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("failOnNodeActivationConditionFailure")]
        public CBool FailOnNodeActivationConditionFailure
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("gracefulInterruptionCondition")]
        public CArray<TweakDBID> GracefulInterruptionCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("nodes")]
        public CArray<TweakDBID> Nodes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("conditionSuccessDuration")]
        public CFloat ConditionSuccessDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
