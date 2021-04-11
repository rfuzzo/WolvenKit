namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataHomingGDM_Record : gamedataTweakDBRecord
    {
        [RED("trackingRadius")]
        public CFloat TrackingRadius
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("lockOnDelay")]
        public CFloat LockOnDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("detonationTimer")]
        public CFloat DetonationTimer
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("freezeDuration")]
        public CFloat FreezeDuration
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("freezeDelayAfterBounce")]
        public CFloat FreezeDelayAfterBounce
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
        
        [RED("lockOnFailDetonationDelay")]
        public CFloat LockOnFailDetonationDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("freezeDelay")]
        public CFloat FreezeDelay
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
        
        [RED("accelerationZ")]
        public CFloat AccelerationZ
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
        
        [RED("bounciness")]
        public CFloat Bounciness
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("flyUpParameters")]
        public TweakDBID FlyUpParameters
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("lockOnAltitude")]
        public CFloat LockOnAltitude
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("flyToTargetParameters")]
        public TweakDBID FlyToTargetParameters
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
