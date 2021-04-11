namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataStatDistributionData_Record : gamedataTweakDBRecord
    {
        [RED("value")]
        public CFloat Value
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("statType")]
        public TweakDBID StatType
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
