namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleCrowdCollisionsParams_Record : gamedataTweakDBRecord
    {
        [RED("ragdollSpeedThreshold")]
        public CFloat RagdollSpeedThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("vehicleCollisionBoxScaleBump")]
        public CFloat VehicleCollisionBoxScaleBump
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("vehicleCollisionBoxScaleRagdoll")]
        public CFloat VehicleCollisionBoxScaleRagdoll
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("bumpEventSpeedThreshold")]
        public CFloat BumpEventSpeedThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("collisionWarningTime")]
        public CFloat CollisionWarningTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ragdollActivationTime")]
        public CFloat RagdollActivationTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
