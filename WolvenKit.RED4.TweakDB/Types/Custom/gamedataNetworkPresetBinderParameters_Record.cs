namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataNetworkPresetBinderParameters_Record : gamedataTweakDBRecord
    {
        [RED("pingPresetID")]
        public TweakDBID PingPresetID
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
