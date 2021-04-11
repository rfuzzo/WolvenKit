namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataApplyStatGroupEffector_Record : gamedataTweakDBRecord
    {
        [RED("statGroup")]
        public TweakDBID StatGroup
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("prereqRecord")]
        public TweakDBID PrereqRecord
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("statModifierGroups")]
        public CArray<TweakDBID> StatModifierGroups
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
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
        
        [RED("effectorClassName")]
        public CName EffectorClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("applicationTarget")]
        public CString ApplicationTarget
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
