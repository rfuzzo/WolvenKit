namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAdvertisement_Record : gamedataTweakDBRecord
    {
        [RED("localizationKey")]
        public gamedataLocKeyWrapper LocalizationKey
        {
            get => GetProperty<gamedataLocKeyWrapper>();
            set => SetProperty<gamedataLocKeyWrapper>(value);
        }
        
        [RED("resource")]
        public raRef<CResource> Resource
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("definitions")]
        public CArray<TweakDBID> Definitions
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
