namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAdvertisementFormatDef_Record : gamedataTweakDBRecord
    {
        [RED("localizationKeyOverride")]
        public gamedataLocKeyWrapper LocalizationKeyOverride
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("libraryName")]
        public CString LibraryName
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("format")]
        public CString Format
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
