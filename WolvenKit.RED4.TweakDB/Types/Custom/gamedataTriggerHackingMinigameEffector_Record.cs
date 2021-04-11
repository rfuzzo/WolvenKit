namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataTriggerHackingMinigameEffector_Record : gamedataTweakDBRecord
    {
        [RED("showPopup")]
        public CBool ShowPopup
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("factValue")]
        public CInt32 FactValue
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("factName")]
        public CName FactName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("journalEntry")]
        public CString JournalEntry
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("reward")]
        public TweakDBID Reward
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statPoolUpdates")]
        public CArray<TweakDBID> StatPoolUpdates
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("removeAfterActionCall")]
        public CBool RemoveAfterActionCall
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("prereqRecord")]
        public TweakDBID PrereqRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("effectorClassName")]
        public CName EffectorClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
