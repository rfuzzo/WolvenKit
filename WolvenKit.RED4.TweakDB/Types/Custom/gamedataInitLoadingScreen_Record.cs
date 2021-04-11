namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataInitLoadingScreen_Record : gamedataTweakDBRecord
    {
        [RED("loadingScreenResource")]
        public raRef<CResource> LoadingScreenResource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("mainMenuResource")]
        public raRef<CResource> MainMenuResource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("thirdAnimName")]
        public CName ThirdAnimName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("mainMenuLoopAnimName")]
        public CName MainMenuLoopAnimName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("secondAnimLibraryName")]
        public CName SecondAnimLibraryName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("firstAnimLibraryName")]
        public CName FirstAnimLibraryName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("mainMenuAnimName")]
        public CName MainMenuAnimName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("mainMenuLibraryName")]
        public CName MainMenuLibraryName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("loopAnimName")]
        public CName LoopAnimName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("secondAnimName")]
        public CName SecondAnimName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("thirdAnimLibraryName")]
        public CName ThirdAnimLibraryName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("firstAnimName")]
        public CName FirstAnimName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("voTrackAnimName")]
        public CName VoTrackAnimName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
