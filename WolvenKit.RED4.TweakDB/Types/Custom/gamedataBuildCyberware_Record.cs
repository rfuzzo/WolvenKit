namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBuildCyberware_Record : gamedataTweakDBRecord
    {
        [RED("cyberware")]
        public TweakDBID Cyberware
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
