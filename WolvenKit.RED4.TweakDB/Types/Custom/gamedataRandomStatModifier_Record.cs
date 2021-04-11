namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRandomStatModifier_Record : gamedataTweakDBRecord
    {
        [RED("max")]
        public CFloat Max
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("min")]
        public CFloat Min
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
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
    }
}
