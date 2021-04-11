namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIActionSelector_Record : gamedataTweakDBRecord
    {
        [RED("actions")]
        public CArray<TweakDBID> Actions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("minLOD")]
        public CInt32 MinLOD
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("failOnNodeActivationConditionFailure")]
        public CBool FailOnNodeActivationConditionFailure
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("disableActionsLimit")]
        public CBool DisableActionsLimit
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("activationCondition")]
        public TweakDBID ActivationCondition
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("defaultAction")]
        public TweakDBID DefaultAction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isVirtual")]
        public CBool IsVirtual
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
