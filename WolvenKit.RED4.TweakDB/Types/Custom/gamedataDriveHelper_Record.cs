namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDriveHelper_Record : gamedataTweakDBRecord
    {
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
