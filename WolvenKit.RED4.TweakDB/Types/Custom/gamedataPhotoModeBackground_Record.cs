namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPhotoModeBackground_Record : gamedataTweakDBRecord
    {
        [RED("displayName")]
        public CName DisplayName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("textureName")]
        public raRef<CResource> TextureName
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("locked")]
        public CBool Locked
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
