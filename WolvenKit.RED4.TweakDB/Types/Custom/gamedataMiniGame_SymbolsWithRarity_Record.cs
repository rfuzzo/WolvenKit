namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMiniGame_SymbolsWithRarity_Record : gamedataTweakDBRecord
    {
        [RED("probability")]
        public CFloat Probability
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("name")]
        public CString Name
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("symbol")]
        public CString Symbol
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
    }
}
