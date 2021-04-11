namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataConstantStatModifier_Record : gamedataStatModifier_Record
    {
        [RED("value")]
        public CFloat Value
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
