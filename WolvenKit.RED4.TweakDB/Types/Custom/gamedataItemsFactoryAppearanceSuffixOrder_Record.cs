namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemsFactoryAppearanceSuffixOrder_Record : gamedataTweakDBRecord
    {
        [RED("appearanceSuffixes")]
        public CArray<TweakDBID> AppearanceSuffixes
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
