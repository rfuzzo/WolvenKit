namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNPCTypePrereq_Record : gamedataTweakDBRecord
    {
        [RED("allowedTypes")]
        public CArray<TweakDBID> AllowedTypes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("prereqClassName")]
        public CName PrereqClassName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
