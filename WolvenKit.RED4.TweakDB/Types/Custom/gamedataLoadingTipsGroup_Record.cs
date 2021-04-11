namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLoadingTipsGroup_Record : gamedataTweakDBRecord
    {
        [RED("unlockingFact")]
        public CName UnlockingFact
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("hintLocalizationKeys")]
        public CArray<CName> HintLocalizationKeys
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
    }
}
