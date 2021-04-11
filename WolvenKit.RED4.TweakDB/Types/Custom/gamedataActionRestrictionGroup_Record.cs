namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataActionRestrictionGroup_Record : gamedataTweakDBRecord
    {
        [RED("allowedActionNames")]
        public CArray<CString> AllowedActionNames
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
        
        [RED("inactiveReason")]
        public CString InactiveReason
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("disallowedActionNames")]
        public CArray<CString> DisallowedActionNames
        {
            get => GetProperty<CArray<CString>>();
            set => SetProperty<CArray<CString>>(value);
        }
    }
}
