namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemBlueprint_Record : gamedataTweakDBRecord
    {
        [RED("rootElement")]
        public TweakDBID RootElement
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
