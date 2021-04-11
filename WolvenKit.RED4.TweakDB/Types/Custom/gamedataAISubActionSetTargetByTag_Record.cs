namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class gamedataAISubActionSetTargetByTag_Record : gamedataTweakDBRecord
    {
        [RED("avoidSelectingSameTarget")]
        public CBool AvoidSelectingSameTarget
        {
            get => GetProperty<CBool>();
            set => SetProperty<CBool>(value);
        }
        
        [RED("rangeObj")]
        public TweakDBID RangeObj
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rangeFromOwner")]
        public Vector2 RangeFromOwner
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
        
        [RED("avoidSelectingSameTargetMethod")]
        public CInt32 AvoidSelectingSameTargetMethod
        {
            get => GetProperty<CInt32>();
            set => SetProperty<CInt32>(value);
        }
        
        [RED("allowedOffMeshTags")]
        public CArray<CName> AllowedOffMeshTags
        {
            get => GetProperty<CArray<CName>>();
            set => SetProperty<CArray<CName>>(value);
        }
        
        [RED("selectionMethod")]
        public CName SelectionMethod
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("tag")]
        public CName Tag
        {
            get => GetProperty<CName>();
            set => SetProperty<CName>(value);
        }
        
        [RED("target")]
        public TweakDBID Target
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("delay")]
        public CFloat Delay
        {
            get => GetProperty<CFloat>();
            set => SetProperty<CFloat>(value);
        }
        
        [RED("lineOfSightTarget")]
        public TweakDBID LineOfSightTarget
        {
            get => GetProperty<TweakDBID>();
            set => SetProperty<TweakDBID>(value);
        }
        
        [RED("rangeFromObj")]
        public Vector2 RangeFromObj
        {
            get => GetProperty<Vector2>();
            set => SetProperty<Vector2>(value);
        }
    }
}
