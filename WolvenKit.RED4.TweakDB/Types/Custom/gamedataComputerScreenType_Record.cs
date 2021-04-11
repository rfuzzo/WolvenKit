namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataComputerScreenType_Record : gamedataTweakDBRecord
    {
        [RED("libraryPath")]
        public raRef<CResource> LibraryPath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("ratio")]
        public TweakDBID Ratio
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("contentRatio")]
        public TweakDBID ContentRatio
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
