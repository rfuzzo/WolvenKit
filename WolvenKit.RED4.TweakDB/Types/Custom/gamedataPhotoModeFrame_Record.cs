namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPhotoModeFrame_Record : gamedataTweakDBRecord
    {
        [RED("flipHorizontal")]
        public CBool FlipHorizontal
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("libraryItemName")]
        public CName LibraryItemName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("locked")]
        public CBool Locked
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("flipVertical")]
        public CBool FlipVertical
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("displayName")]
        public CName DisplayName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("atlasName")]
        public raRef<CResource> AtlasName
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("imagePartsNames")]
        public CArray<CName> ImagePartsNames
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("color")]
        public CArray<CInt32> Color
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
    }
}
