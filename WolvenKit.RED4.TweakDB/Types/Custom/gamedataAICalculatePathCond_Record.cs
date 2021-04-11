namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAICalculatePathCond_Record : gamedataTweakDBRecord
    {
        [RED("checkDynamicObstacle")]
        public CBool CheckDynamicObstacle
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("startPositionOffset")]
        public Vector3 StartPositionOffset
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("directionAngle")]
        public CFloat DirectionAngle
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("checkStraightPath")]
        public CBool CheckStraightPath
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("tolerance")]
        public CFloat Tolerance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("allowedOffMeshTags")]
        public CArray<CName> AllowedOffMeshTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("invert")]
        public CBool Invert
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("distance")]
        public CFloat Distance
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
