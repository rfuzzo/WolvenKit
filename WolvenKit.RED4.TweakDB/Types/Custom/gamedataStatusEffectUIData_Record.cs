namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatusEffectUIData_Record : gamedataTweakDBRecord
    {
        [RED("iconPAth")]
        public CString IconPAth
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("priority")]
        public CFloat Priority
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("intValues")]
        public CArray<CInt32> IntValues
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("nameValues")]
        public CArray<CName> NameValues
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("iconPath")]
        public CString IconPath
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("description")]
        public CString Description
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("displayName")]
        public CString DisplayName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("floatValues")]
        public CArray<CFloat> FloatValues
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("stats")]
        public CArray<TweakDBID> Stats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("fluffText")]
        public CString FluffText
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
