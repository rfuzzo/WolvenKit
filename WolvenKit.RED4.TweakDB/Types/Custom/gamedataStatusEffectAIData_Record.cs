namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatusEffectAIData_Record : gamedataTweakDBRecord
    {
        [RED("updateSenses")]
        public CBool UpdateSenses
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("shouldProcessAIDataOnReapplication")]
        public CBool ShouldProcessAIDataOnReapplication
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("behaviourName")]
        public CName BehaviourName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("shouldDelayStatusEffectApplication")]
        public CBool ShouldDelayStatusEffectApplication
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("behaviorEventFlag")]
        public TweakDBID BehaviorEventFlag
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("behaviorSignalResendDelay")]
        public CArray<TweakDBID> BehaviorSignalResendDelay
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("sensePreset")]
        public TweakDBID SensePreset
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("activationPrereqs")]
        public CArray<TweakDBID> ActivationPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("priority")]
        public CFloat Priority
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("behaviorType")]
        public TweakDBID BehaviorType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("stimulis")]
        public CArray<TweakDBID> Stimulis
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("stimRangeMultiplier")]
        public CFloat StimRangeMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
