namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAIMovementCond_Record : gamedataTweakDBRecord
    {
        [RED("isEvaluated")]
        public CInt32 IsEvaluated
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("isPauseByDynamicCollision")]
        public CInt32 IsPauseByDynamicCollision
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("isDestinationChanged")]
        public CInt32 IsDestinationChanged
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("lineOfSightFailed")]
        public CInt32 LineOfSightFailed
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("destination")]
        public TweakDBID Destination
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("isUsingOffMeshLink")]
        public CInt32 IsUsingOffMeshLink
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("spatialHintMults")]
        public Vector3 SpatialHintMults
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("slope")]
        public Vector2 Slope
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("constrainedByRestrictedArea")]
        public CInt32 ConstrainedByRestrictedArea
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("pathFindingFailed")]
        public CInt32 PathFindingFailed
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("distanceToDestination")]
        public Vector2 DistanceToDestination
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("movementType")]
        public CName MovementType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("isDestinationCalculated")]
        public CInt32 IsDestinationCalculated
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("offMeshLinkType")]
        public CName OffMeshLinkType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("isMoving")]
        public CInt32 IsMoving
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
    }
}
