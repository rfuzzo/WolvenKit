namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleAirControl_Record : gamedataTweakDBRecord
    {
        [RED("yaw")]
        public TweakDBID Yaw
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("pitch")]
        public TweakDBID Pitch
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("flippedOverRecoveryPID")]
        public CArray<CFloat> FlippedOverRecoveryPID
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("roll")]
        public TweakDBID Roll
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("massReference")]
        public CFloat MassReference
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("anglePID")]
        public CArray<CFloat> AnglePID
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
        
        [RED("velocityPID")]
        public CArray<CFloat> VelocityPID
        {
            get => GetProperty<CArray<CFloat>>();
            set => SetProperty<CArray<CFloat>>(value);
        }
    }
}
