namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataLinearAccuracy_Record : gamedataTweakDBRecord
    {
        [RED("duration")]
        public CFloat Duration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minDistanceToRunCooldown")]
        public CFloat MinDistanceToRunCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("accuracyDropCooldown")]
        public CFloat AccuracyDropCooldown
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
