namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPhotoModeSticker_Record : gamedataPhotoModeItem_Record
    {
        [RED("imagePartName")]
        public CName ImagePartName
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
    }
}
