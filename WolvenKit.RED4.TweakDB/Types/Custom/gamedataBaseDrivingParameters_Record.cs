namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataBaseDrivingParameters_Record : gamedataTweakDBRecord
    {
        [RED("wheelTurnSpeed")]
        public CFloat WheelTurnSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("steeringReverse")]
        public TweakDBID SteeringReverse
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("steering")]
        public TweakDBID Steering
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("brake")]
        public TweakDBID Brake
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("maxVisionDistance")]
        public CFloat MaxVisionDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("hasPanic")]
        public CBool HasPanic
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("stopping")]
        public TweakDBID Stopping
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("accel")]
        public TweakDBID Accel
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("boostStats")]
        public TweakDBID BoostStats
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
