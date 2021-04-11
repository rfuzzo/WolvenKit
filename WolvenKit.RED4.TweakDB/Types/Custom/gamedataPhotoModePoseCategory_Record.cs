namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPhotoModePoseCategory_Record : gamedataTweakDBRecord
    {
        [RED("displayName")]
        public CName DisplayName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("categoryName")]
        public CName CategoryName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
