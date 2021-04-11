namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionSetWorldPosition_Record : gamedataTweakDBRecord
    {
        [RED("checkForNavmesh")]
        public CBool CheckForNavmesh
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("customPositionTarget")]
        public TweakDBID CustomPositionTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("maxOffsetFromTarget")]
        public Vector3 MaxOffsetFromTarget
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("referenceTarget")]
        public TweakDBID ReferenceTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("useLocalSpace")]
        public CBool UseLocalSpace
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("minOffsetFromTarget")]
        public Vector3 MinOffsetFromTarget
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("randomizePoint")]
        public CBool RandomizePoint
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
    }
}
