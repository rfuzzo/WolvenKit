namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAchievement_Record : gamedataTweakDBRecord
    {
        [RED("enumName")]
        public CName EnumName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("SteamKey")]
        public CString SteamKey
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("XB1Key")]
        public CString XB1Key
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("displayName")]
        public CName DisplayName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("GOGKey")]
        public CString GOGKey
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("PS4Key")]
        public CInt32 PS4Key
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("localizedDescription")]
        public CString LocalizedDescription
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
