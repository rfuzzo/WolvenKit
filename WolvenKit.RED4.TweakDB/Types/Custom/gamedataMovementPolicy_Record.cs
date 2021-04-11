namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataMovementPolicy_Record : gamedataTweakDBRecord
    {
        [RED("ignoreLoSPrecheck")]
        public CBool IgnoreLoSPrecheck
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("symmetricAnglesScores")]
        public CBool SymmetricAnglesScores
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("allowedTags")]
        public CArray<TweakDBID> AllowedTags
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("calculateStartTangent")]
        public CBool CalculateStartTangent
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("circlingDirection")]
        public CName CirclingDirection
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("movementType")]
        public CName MovementType
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("deadAngle")]
        public CFloat DeadAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("strafingPredictionTime")]
        public CFloat StrafingPredictionTime
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("debugName")]
        public CName DebugName
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("blockedTags")]
        public CArray<TweakDBID> BlockedTags
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("ignoreCollisionAvoidance")]
        public CBool IgnoreCollisionAvoidance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("useFollowSlots")]
        public CBool UseFollowSlots
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("ignoreNavigation")]
        public CBool IgnoreNavigation
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("dynamicTargetUpdateDistance")]
        public CFloat DynamicTargetUpdateDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("maxPathLengthToDirectDistanceRatioCurve")]
        public CName MaxPathLengthToDirectDistanceRatioCurve
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("maxPathLength")]
        public CFloat MaxPathLength
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ringDistanceMult")]
        public CFloat RingDistanceMult
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ringToleranceMult")]
        public CFloat RingToleranceMult
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ringToleranceOffset")]
        public CFloat RingToleranceOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("ignoreSpotReservation")]
        public CBool IgnoreSpotReservation
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("strafingPredictionVelocityMax")]
        public CFloat StrafingPredictionVelocityMax
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("tolerance")]
        public CFloat Tolerance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dontUseStart")]
        public CBool DontUseStart
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("avoidThreatRange")]
        public CFloat AvoidThreatRange
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("spatialHintMults")]
        public Vector3 SpatialHintMults
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("ignoreRestrictedMovementArea")]
        public CBool IgnoreRestrictedMovementArea
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minDistance")]
        public CFloat MinDistance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("useOffMeshAllowedTags")]
        public CBool UseOffMeshAllowedTags
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("ring")]
        public TweakDBID Ring
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("avoidObstacleWithinTolerance")]
        public CBool AvoidObstacleWithinTolerance
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("strafingRotationOffset")]
        public CFloat StrafingRotationOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("getOutOfWay")]
        public CBool GetOutOfWay
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("avoidThreat")]
        public CBool AvoidThreat
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("avoidThreatCost")]
        public CFloat AvoidThreatCost
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("keepLineOfSight")]
        public CName KeepLineOfSight
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("destinationOrientationPosition")]
        public TweakDBID DestinationOrientationPosition
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("strafingTarget")]
        public TweakDBID StrafingTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("stopOnObstacle")]
        public CBool StopOnObstacle
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("useOffMeshBlockedTags")]
        public CBool UseOffMeshBlockedTags
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("dontUseStop")]
        public CBool DontUseStop
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("ringDistanceOffset")]
        public CFloat RingDistanceOffset
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("distance")]
        public CFloat Distance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("dynamicTargetUpdateTimer")]
        public CFloat DynamicTargetUpdateTimer
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
