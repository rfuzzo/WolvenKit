namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataApperanceToEthnicities_Record : gamedataTweakDBRecord
    {
        [RED("ethnicities")]
        public CArray<TweakDBID> Ethnicities
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("appearanceName")]
        public CName AppearanceName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
