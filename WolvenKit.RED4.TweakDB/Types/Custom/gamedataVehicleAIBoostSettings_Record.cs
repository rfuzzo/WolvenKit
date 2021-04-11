namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleAIBoostSettings_Record : gamedataTweakDBRecord
    {
        [RED("maxTorqueBoost")]
        public CFloat MaxTorqueBoost
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxLongTractionBoost")]
        public CFloat MaxLongTractionBoost
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxLatTractionBoost")]
        public CFloat MaxLatTractionBoost
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
