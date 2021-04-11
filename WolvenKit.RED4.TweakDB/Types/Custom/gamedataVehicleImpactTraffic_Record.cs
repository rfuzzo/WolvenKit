namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleImpactTraffic_Record : gamedataTweakDBRecord
    {
        [RED("maxThreshold")]
        public CFloat MaxThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minThreshold")]
        public CFloat MinThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxTimerStunned")]
        public CFloat MaxTimerStunned
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
