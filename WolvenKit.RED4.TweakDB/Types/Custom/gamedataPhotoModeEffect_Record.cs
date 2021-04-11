namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataPhotoModeEffect_Record : gamedataTweakDBRecord
    {
        [RED("displayName")]
        public CName DisplayName
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
        
        [RED("hdrLutPath")]
        public CName HdrLutPath
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("lutPath")]
        public CName LutPath
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
