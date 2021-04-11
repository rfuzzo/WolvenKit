namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataXPPoints_Record : gamedataTweakDBRecord
    {
        [RED("quantityModifiers")]
        public CArray<TweakDBID> QuantityModifiers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
