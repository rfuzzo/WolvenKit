namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionGeneratePointOfInterestTarget_Record : gamedataTweakDBRecord
    {
        [RED("squadMateWatchingMaxAngle")]
        public CFloat SquadMateWatchingMaxAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("choosingClosestThreatChanceWeight")]
        public CFloat ChoosingClosestThreatChanceWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("randomPointYRotationAngleRange")]
        public Vector2 RandomPointYRotationAngleRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("choosingRandomPointChanceWeight")]
        public CFloat ChoosingRandomPointChanceWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("squadMateDurationRange")]
        public Vector2 SquadMateDurationRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("friendlyTargetDurationRange")]
        public Vector2 FriendlyTargetDurationRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("randomPointZRotationAngleRange")]
        public Vector2 RandomPointZRotationAngleRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("friendlyTargetWatchingMaxAngle")]
        public CFloat FriendlyTargetWatchingMaxAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("closestThreatWatchingMaxAngle")]
        public CFloat ClosestThreatWatchingMaxAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("choosingFriendlyTargetChanceWeight")]
        public CFloat ChoosingFriendlyTargetChanceWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("closestThreatDurationRange")]
        public Vector2 ClosestThreatDurationRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("randomPointDurationRange")]
        public Vector2 RandomPointDurationRange
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("choosingSquadMateChanceWeight")]
        public CFloat ChoosingSquadMateChanceWeight
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
