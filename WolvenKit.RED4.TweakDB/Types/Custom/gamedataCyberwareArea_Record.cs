namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCyberwareArea_Record : gamedataTweakDBRecord
    {
        [RED("numberOfEquipSlots")]
        public CInt32 NumberOfEquipSlots
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("locked")]
        public CBool Locked
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
        
        [RED("localizedName")]
        public CString LocalizedName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("enumComment")]
        public CString EnumComment
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
