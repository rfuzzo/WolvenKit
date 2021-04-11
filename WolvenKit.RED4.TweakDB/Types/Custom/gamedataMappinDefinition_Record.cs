namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMappinDefinition_Record : gamedataBase_MappinDefinition_Record
    {
        [RED("possibleVariants")]
        public CArray<TweakDBID> PossibleVariants
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
