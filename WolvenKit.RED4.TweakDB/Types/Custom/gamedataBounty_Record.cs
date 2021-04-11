namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBounty_Record : gamedataTweakDBRecord
    {
        [RED("reward")]
        public TweakDBID Reward
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("bountySetter")]
        public TweakDBID BountySetter
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("drawWeight")]
        public CFloat DrawWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("transgressions")]
        public CArray<TweakDBID> Transgressions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("wantedStars")]
        public CInt32 WantedStars
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
