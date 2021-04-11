namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataSmartGunTargetSortConfigurations_Record : gamedataTweakDBRecord
    {
        [RED("hipConfig")]
        public TweakDBID HipConfig
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("adsConfig")]
        public TweakDBID AdsConfig
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
