namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemQuery_Record : gamedataTweakDBRecord
    {
        [RED("tagsToExclude")]
        public CArray<CName> TagsToExclude
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("recordType")]
        public CName RecordType
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
    }
}
