namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGenericMetroSign_Record : gamedataTweakDBRecord
    {
        [RED("styleStateName")]
        public CName StyleStateName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("metroLineName")]
        public CArray<CName> MetroLineName
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("resource")]
        public raRef<CResource> Resource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("subDistrictName")]
        public CString SubDistrictName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("isUnique")]
        public CBool IsUnique
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stationName")]
        public CString StationName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("iconName")]
        public CName IconName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
