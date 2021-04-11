namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRowSymbols_Record : gamedataTweakDBRecord
    {
        [RED("symbols")]
        public CArray<CInt32> Symbols
        {
            get => GetProperty<CArray<CInt32>>();
            set => SetProperty<CArray<CInt32>>(value);
        }
    }
}
