namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatModifier_Record : gamedataTweakDBRecord
    {
        [RED("statType")]
        public TweakDBID StatType
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
    }
}
