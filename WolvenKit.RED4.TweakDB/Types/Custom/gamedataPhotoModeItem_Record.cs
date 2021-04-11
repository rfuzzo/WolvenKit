namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPhotoModeItem_Record : gamedataTweakDBRecord
    {
        [RED("locked")]
        public CBool Locked
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
    }
}
