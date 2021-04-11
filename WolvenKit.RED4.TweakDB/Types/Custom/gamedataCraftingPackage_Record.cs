namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCraftingPackage_Record : gamedataTweakDBRecord
    {
        [RED("craftingExpModifier")]
        public CFloat CraftingExpModifier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("craftingRecipe")]
        public CArray<TweakDBID> CraftingRecipe
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("overcraftPenaltyModifier")]
        public CFloat OvercraftPenaltyModifier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
