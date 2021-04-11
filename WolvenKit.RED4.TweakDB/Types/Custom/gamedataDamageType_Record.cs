namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDamageType_Record : gamedataTweakDBRecord
    {
        [RED("resistances")]
        public CArray<TweakDBID> Resistances
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("associatedStat")]
        public TweakDBID AssociatedStat
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("enumName")]
        public CString EnumName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
