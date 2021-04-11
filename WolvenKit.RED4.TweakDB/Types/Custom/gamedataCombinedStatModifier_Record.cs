namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCombinedStatModifier_Record : gamedataTweakDBRecord
    {
        [RED("modifierType")]
        public CName ModifierType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("refObject")]
        public CName RefObject
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("statType")]
        public TweakDBID StatType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("opSymbol")]
        public CName OpSymbol
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("refStat")]
        public TweakDBID RefStat
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("value")]
        public CFloat Value
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
