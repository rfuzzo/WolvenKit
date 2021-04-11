namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataForceDismembermentEffector_Record : gamedataTweakDBRecord
    {
        [RED("shouldKillNPC")]
        public CBool ShouldKillNPC
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("skipDeathAnim")]
        public CBool SkipDeathAnim
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("dismembermentChance")]
        public CFloat DismembermentChance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("isCritical")]
        public CBool IsCritical
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("statPoolUpdates")]
        public CArray<TweakDBID> StatPoolUpdates
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("woundType")]
        public CString WoundType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("removeAfterActionCall")]
        public CBool RemoveAfterActionCall
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("bodyPart")]
        public CString BodyPart
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("effectorClassName")]
        public CName EffectorClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("prereqRecord")]
        public TweakDBID PrereqRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
