namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAccelerateTowardsParameters_Record : gamedataTweakDBRecord
    {
        [RED("accelerationSpeed")]
        public CFloat AccelerationSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("diffForMaxRotation")]
        public CFloat DiffForMaxRotation
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("minRotationSpeed")]
        public CFloat MinRotationSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxRotationSpeed")]
        public CFloat MaxRotationSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("accuracy")]
        public CFloat Accuracy
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("decelerateTowardsTargetPositionDistance")]
        public CFloat DecelerateTowardsTargetPositionDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxSpeed")]
        public CFloat MaxSpeed
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
