namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataGenericHighwaySign_Record : gamedataTweakDBRecord
    {
        [RED("iconName")]
        public CName IconName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
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
        
        [RED("resource")]
        public raRef<CResource> Resource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("districtName")]
        public CString DistrictName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("styleStateName")]
        public CName StyleStateName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
