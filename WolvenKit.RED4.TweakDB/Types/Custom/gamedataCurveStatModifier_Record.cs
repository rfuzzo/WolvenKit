namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataCurveStatModifier_Record : gamedataTweakDBRecord
    {
        [RED("refStat")]
        public TweakDBID RefStat
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("modifierType")]
        public CName ModifierType
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
        
        [RED("id")]
        public CString Id
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("column")]
        public CString Column
        {
            get => GetProperty<CString>();
            set => SetProperty<CString>(value);
        }
        
        [RED("refObject")]
        public CName RefObject
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
    }
}
