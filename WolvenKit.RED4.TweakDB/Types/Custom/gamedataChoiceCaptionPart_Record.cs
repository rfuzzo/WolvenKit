namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataChoiceCaptionPart_Record : gamedataTweakDBRecord
    {
        [RED("partType")]
        public TweakDBID PartType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
