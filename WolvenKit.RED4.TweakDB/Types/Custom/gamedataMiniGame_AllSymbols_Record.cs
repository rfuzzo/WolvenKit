namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMiniGame_AllSymbols_Record : gamedataTweakDBRecord
    {
        [RED("symbolsWithRarity")]
        public CArray<TweakDBID> SymbolsWithRarity
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
