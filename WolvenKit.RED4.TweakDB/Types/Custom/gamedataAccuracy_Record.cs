namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAccuracy_Record : gamedataTweakDBRecord
    {
        [RED("accuracyDropCooldown")]
        public CFloat AccuracyDropCooldown
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
    }
}
