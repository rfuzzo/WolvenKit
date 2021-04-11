namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemArrayQuery_Record : gamedataTweakDBRecord
    {
        [RED("recordType")]
        public CName RecordType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("tagsToExclude")]
        public CArray<CName> TagsToExclude
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("tags")]
        public CArray<CName> Tags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("minItems")]
        public CInt32 MinItems
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("maxItems")]
        public CInt32 MaxItems
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
