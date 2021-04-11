namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataVirtualNetwork_Record : gamedataTweakDBRecord
    {
        [RED("paths")]
        public CArray<TweakDBID> Paths
        {
            get => GetProperty<CArray<TweakDBID>>();
            set => SetProperty<CArray<TweakDBID>>(value);
        }
        
        [RED("minDistanceToOther")]
        public CFloat MinDistanceToOther
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("offsetMultiplier")]
        public CFloat OffsetMultiplier
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("segmentMarker")]
        public Vector3 SegmentMarker
        {
            get => GetProperty<Vector3>();
            set => SetProperty<Vector3>(value);
        }
        
        [RED("scale")]
        public CFloat Scale
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
    }
}
