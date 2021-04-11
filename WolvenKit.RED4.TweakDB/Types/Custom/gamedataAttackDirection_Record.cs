namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAttackDirection_Record : gamedataTweakDBRecord
    {
        [RED("startPosition")]
        public Vector3 StartPosition
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("endPosition")]
        public Vector3 EndPosition
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("direction")]
        public TweakDBID Direction
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
    }
}
