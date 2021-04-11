namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataObjectActionCost_Record : gamedataTweakDBRecord
    {
        [RED("costMods")]
        public CArray<TweakDBID> CostMods
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
