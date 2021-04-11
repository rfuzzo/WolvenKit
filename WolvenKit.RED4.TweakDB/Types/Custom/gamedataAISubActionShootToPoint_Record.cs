namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionShootToPoint_Record : gamedataTweakDBRecord
    {
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("targetPositionObj")]
        public TweakDBID TargetPositionObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("positionObj")]
        public TweakDBID PositionObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("aimingDelay")]
        public CFloat AimingDelay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("pointPosition")]
        public CArray<Vector3> PointPosition
        {
            get => GetProperty<CArray<Vector3>>();
            set => SetProperty<CArray<Vector3>>(value);
        }
        
        [RED("shootingPatternPackages")]
        public CArray<TweakDBID> ShootingPatternPackages
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("targetOffset")]
        public Vector3 TargetOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("weaponSlots")]
        public CArray<TweakDBID> WeaponSlots
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("dualWieldShootingStyle")]
        public CName DualWieldShootingStyle
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("predictionTime")]
        public CFloat PredictionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("instigator")]
        public TweakDBID Instigator
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("waypointTag")]
        public CArray<CName> WaypointTag
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("rotationObj")]
        public TweakDBID RotationObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("pauseCondition")]
        public CArray<TweakDBID> PauseCondition
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("rangedAttack")]
        public TweakDBID RangedAttack
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("tbhCoefficient")]
        public CFloat TbhCoefficient
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxNumberOfShots")]
        public CInt32 MaxNumberOfShots
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("numberOfShots")]
        public CInt32 NumberOfShots
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("triggerMode")]
        public TweakDBID TriggerMode
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
