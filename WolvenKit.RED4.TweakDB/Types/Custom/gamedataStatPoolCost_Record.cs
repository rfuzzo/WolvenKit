namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatPoolCost_Record : gamedataObjectActionCost_Record
    {
        [RED("statPool")]
        public TweakDBID StatPool
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
