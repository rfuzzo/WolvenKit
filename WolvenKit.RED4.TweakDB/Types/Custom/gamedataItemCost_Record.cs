namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataItemCost_Record : gamedataTweakDBRecord
    {
        [RED("costMods")]
        public CArray<TweakDBID> CostMods
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("item")]
        public TweakDBID Item
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
