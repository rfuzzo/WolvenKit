namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemPartListElement_Record : gamedataTweakDBRecord
    {
        [RED("weight")]
        public CFloat Weight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("item")]
        public TweakDBID Item
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
