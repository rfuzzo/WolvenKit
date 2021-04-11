namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataFastTravelScreenData_Record : gamedataTweakDBRecord
    {
        [RED("extendingResourcePath")]
        public raRef<CResource> ExtendingResourcePath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("weather")]
        public TweakDBID Weather
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("resourcePath")]
        public raRef<CResource> ResourcePath
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("time")]
        public TweakDBID Time
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("district")]
        public TweakDBID District
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
