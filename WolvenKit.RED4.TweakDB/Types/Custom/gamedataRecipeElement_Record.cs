namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRecipeElement_Record : gamedataTweakDBRecord
    {
        [RED("amount")]
        public CInt32 Amount
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("ingredient")]
        public TweakDBID Ingredient
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
