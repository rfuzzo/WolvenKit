namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatusEffectPrereq_Record : gamedataTweakDBRecord
    {
        [RED("tagToCheck")]
        public CName TagToCheck
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("checkType")]
        public CString CheckType
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("fireAndForget")]
        public CBool FireAndForget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("statusEffect")]
        public TweakDBID StatusEffect
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("prereqClassName")]
        public CName PrereqClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
