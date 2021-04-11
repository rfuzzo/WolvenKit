namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataRegularGDM_Record : gamedataTweakDBRecord
    {
        [RED("detonationTimer")]
        public CFloat DetonationTimer
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bounciness")]
        public CFloat Bounciness
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("accelerationZ")]
        public CFloat AccelerationZ
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("initialQuickThrowVelocity")]
        public CFloat InitialQuickThrowVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("trackingRadius")]
        public CFloat TrackingRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("initialVelocity")]
        public CFloat InitialVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("type")]
        public TweakDBID Type
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
