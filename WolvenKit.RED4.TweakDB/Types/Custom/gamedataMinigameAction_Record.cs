namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMinigameAction_Record : gamedataTweakDBRecord
    {
        [RED("targetClass")]
        public CName TargetClass
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("complexity")]
        public CFloat Complexity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("startEffects")]
        public CArray<TweakDBID> StartEffects
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("instigatorActivePrereqs")]
        public CArray<TweakDBID> InstigatorActivePrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("hackCategory")]
        public TweakDBID HackCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("instigatorPrereqs")]
        public CArray<TweakDBID> InstigatorPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("objectActionUI")]
        public TweakDBID ObjectActionUI
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("targetActivePrereqs")]
        public CArray<TweakDBID> TargetActivePrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("rewards")]
        public CArray<TweakDBID> Rewards
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("activationTime")]
        public CArray<TweakDBID> ActivationTime
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("interactionLayer")]
        public CName InteractionLayer
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("cooldown")]
        public TweakDBID Cooldown
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("targetPrereqs")]
        public CArray<TweakDBID> TargetPrereqs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("showPopup")]
        public CBool ShowPopup
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("memoryCost")]
        public CFloat MemoryCost
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("objectActionType")]
        public TweakDBID ObjectActionType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("reward")]
        public TweakDBID Reward
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("completionEffects")]
        public CArray<TweakDBID> CompletionEffects
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("category")]
        public TweakDBID Category
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("journalEntry")]
        public CString JournalEntry
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("factName")]
        public CName FactName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("factValue")]
        public CInt32 FactValue
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("gameplayCategory")]
        public TweakDBID GameplayCategory
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("costs")]
        public CArray<TweakDBID> Costs
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("actionName")]
        public CName ActionName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("priority")]
        public CFloat Priority
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
