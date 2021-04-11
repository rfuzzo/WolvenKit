namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCurrencyReward_Record : gamedataTweakDBRecord
    {
        [RED("amount")]
        public CInt32 Amount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("currency")]
        public TweakDBID Currency
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("quantityModifiers")]
        public CArray<TweakDBID> QuantityModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
