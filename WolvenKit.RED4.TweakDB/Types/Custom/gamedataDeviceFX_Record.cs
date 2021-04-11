namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataDeviceFX_Record : gamedataTweakDBRecord
    {
        [RED("visionConeEffectLength")]
        public CFloat VisionConeEffectLength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("idleEffectLength")]
        public CFloat IdleEffectLength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("scanGameEffectLength")]
        public CFloat ScanGameEffectLength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
