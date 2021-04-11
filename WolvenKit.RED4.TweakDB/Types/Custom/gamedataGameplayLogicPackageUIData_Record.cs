namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGameplayLogicPackageUIData_Record : gamedataTweakDBRecord
    {
        [RED("localizedName")]
        public CString LocalizedName
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
        
        [RED("nameValues")]
        public CArray<CName> NameValues
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("intValues")]
        public CArray<CInt32> IntValues
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
        
        [RED("localizedDescription")]
        public CString LocalizedDescription
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("iconPath")]
        public CName IconPath
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("stats")]
        public CArray<TweakDBID> Stats
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
