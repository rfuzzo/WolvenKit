namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVehicleDestruction_Record : gamedataTweakDBRecord
    {
        [RED("damageThreshold")]
        public CFloat DamageThreshold
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("forcePropagationFalloff")]
        public CFloat ForcePropagationFalloff
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("glass")]
        public CArray<TweakDBID> Glass
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("vehicleDimensions")]
        public Vector3 VehicleDimensions
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("gridDimensions")]
        public Vector3 GridDimensions
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("detachableParts")]
        public CArray<TweakDBID> DetachableParts
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("enableOnHit")]
        public CBool EnableOnHit
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("velocityValueMinDamage")]
        public CFloat VelocityValueMinDamage
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("velocityValueMaxDamage")]
        public CFloat VelocityValueMaxDamage
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("wheels")]
        public CArray<TweakDBID> Wheels
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("damageExponent")]
        public CFloat DamageExponent
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("onHitVelocity")]
        public CFloat OnHitVelocity
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("gridLocalOffset")]
        public Vector3 GridLocalOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("pointDampers")]
        public CArray<TweakDBID> PointDampers
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("lights")]
        public CArray<TweakDBID> Lights
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("detachedPartExplosionEffect")]
        public raRef<CResource> DetachedPartExplosionEffect
        {
            get => GetProperty<raRef<CResource>>();
            set => SetProperty<raRef<CResource>>(value);
        }
        
        [RED("deformableParts")]
        public CArray<TweakDBID> DeformableParts
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
    }
}
