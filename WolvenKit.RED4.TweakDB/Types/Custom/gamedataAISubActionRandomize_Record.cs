namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionRandomize_Record : gamedataTweakDBRecord
    {
        [RED("animVariationRandomize")]
        public CArray<CInt32> AnimVariationRandomize
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
    }
}
