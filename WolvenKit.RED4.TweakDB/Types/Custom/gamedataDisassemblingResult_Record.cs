namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDisassemblingResult_Record : gamedataTweakDBRecord
    {
        [RED("ingredients")]
        public CArray<TweakDBID> Ingredients
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
